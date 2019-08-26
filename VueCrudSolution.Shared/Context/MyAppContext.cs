using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VueCrudSolution.Data.Models;
using VueCrudSolution.Data.Models.Map;
using VueCrudSolution.Shared.DataAccess;
using VueCrudSolution.Shared.DataAccess.Interface;
using VueCrudSolution.Data.Models.HelperClass;
using VueCrudSolution.Shared.Migrations.Data;

namespace VueCrudSolution.Shared.Context
{
    public partial class MyAppContext : IdentityDbContext<ApplicationIdentityUser, 
        ApplicationIdentityRole, Guid, ApplicationIdentityUserClaim, 
        ApplicationIdentityUserRole, ApplicationIdentityUserLogin, 
        ApplicationIdentityRoleClaim, ApplicationIdentityUserToken>, IDbContext
    {
        private IDbContextTransaction _transaction;
        public MyAppContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.ApplyConfiguration(new ApplicationIdentityRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationIdentityUserMap());
            modelBuilder.ApplyConfiguration(new ApplicationIdentityUserRoleMap());
            modelBuilder.ApplyConfiguration(new ApplicationIdentityUserLoginMap());
            modelBuilder.ApplyConfiguration(new ApplicationIdentityUserTokenMap());
            modelBuilder.ApplyConfiguration(new ApplicationIdentityUserClaimMap());
            modelBuilder.ApplyConfiguration(new IdeaMap());
            modelBuilder.ApplyConfiguration(new PhotoMap());
            modelBuilder.ApplyConfiguration(new UserAddressMap());

            var typesToRegister = typeof(BaseEntity).Assembly.GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityTypeConfiguration<>));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)configurationInstance);
            }

            SetupCountries(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        public static void SetupCountries(ModelBuilder builder)
        {
            var fullPath = GetFileWithName(@"\Migrations\Data\nigeria.json");

            List<CountryData> countryViewModel = new List<CountryData>();
            using (StreamReader file = File.OpenText(fullPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                countryViewModel = (List<CountryData>)serializer.Deserialize(file, typeof(List<CountryData>));
            }

            List<Country> countries = new List<Country>();
            List<Region> regions = new List<Region>();
            List<City> cities = new List<City>();

            foreach (var vm in countryViewModel)
            {
                var country = (Country)vm;
                country.Id = Guid.NewGuid();
                country.CreatedBy_Id = Guid.Parse("1989883f-4f99-43bf-a754-239bbbfec00e");
                country.ModifiedOn = country.CreatedOn = DateTime.UtcNow;
                country.ModifiedBy_Id = country.CreatedBy_Id;
                countries.Add(country);

                foreach (var r in vm.Regions)
                {
                    var region = (Region)r;
                    region.Id = Guid.NewGuid();
                    region.Country_Id = country.Id;
                    region.CreatedBy_Id = country.CreatedBy_Id;
                    region.ModifiedBy_Id = country.CreatedBy_Id;
                    region.CreatedOn = DateTime.UtcNow;
                    regions.Add(region);

                    foreach (var cit in r.Cities)
                    {
                        var city = (City)cit;
                        city.Id = Guid.NewGuid();
                        city.CreatedBy_Id = country.CreatedBy_Id;
                        city.ModifiedBy_Id = country.CreatedBy_Id;
                        city.ModifiedOn = city.CreatedOn = DateTime.UtcNow;
                        city.Region_Id = region.Id;
                        cities.Add(city);
                    }
                }
            }

            builder.Entity<Country>().HasData(countries.ToArray());
            builder.Entity<Region>().HasData(regions.ToArray());
            builder.Entity<City>().HasData(cities.ToArray());
        }

        public static string GetFileWithName(string filePath)
        {
            var baseDir = $@"{AppDomain.CurrentDomain.BaseDirectory}";

            Debug.WriteLine(baseDir);

            if (Directory.Exists($"{baseDir}\bin"))
                return $@"{baseDir}\\bin{filePath}";
            else
                return $@"{baseDir}\{filePath}";
        }

        private static void ApplyStateUsingIsKeySet(EntityEntry entry)
        {
            if (entry.IsKeySet)
            {
                if (((ClientChangeTracker)entry.Entity).IsDirty)
                {
                    entry.State = EntityState.Modified;
                }
                else
                {
                    entry.State = EntityState.Unchanged;
                }
            }
            else
            {
                entry.State = EntityState.Added;
            }
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Added);
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Modified);
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Deleted);
        }


        public void SetAsDetached<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            UpdateEntityState(entity, EntityState.Detached);
        }

        public void BeginTransaction()
        {
            _transaction = Database.BeginTransaction();
        }

        public int Commit()
        {
            var saveChanges = SaveChanges();
            _transaction.Commit();
            return saveChanges;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public Task<int> CommitAsync()
        {
            var saveChangesAsync = SaveChangesAsync();
            _transaction.Commit();
            return saveChangesAsync;
        }

        private void UpdateEntityState<TEntity>(TEntity entity, EntityState entityState) where TEntity : BaseEntity
        {
            //this.ChangeTracker.TrackGraph(entity, e => ApplyStateUsingIsKeySet(e.Entry));
            var dbEntityEntry = GetDbEntityEntrySafely(entity);
            dbEntityEntry.State = entityState;
        }

        private EntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var dbEntityEntry = Entry<TEntity>(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }
            return dbEntityEntry;
        }

        public override void Dispose()
        {
            //if (this.Database.GetDbConnection() != null && this.Database.GetDbConnection().State == ConnectionState.Open)
            //{
            //    this.Database.GetDbConnection().Close();
            //}

            base.Dispose();
        }

        /// <summary>
        /// Create database script
        /// </summary>
        /// <returns>SQL to generate database</returns>
        public string CreateDatabaseScript()
        {
            return string.Empty;
        }

        /// <summary>
        /// Attach an entity to the context or return an already attached entity (if it was already attached)
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Attached entity</returns>
        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                //attach new entity
                Set<TEntity>().Attach(entity);
                return entity;
            }
            else
            {
                //entity is already loaded.
                return alreadyAttached;
            }
        }

        /// <summary>
        /// Execute stores procedure and load a list of entities at the end
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="commandText">Command text</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entities</returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            //add parameters to command
            if (parameters != null && parameters.Length > 0)
            {
                for (int i = 0; i <= parameters.Length - 1; i++)
                {
                    var p = parameters[i] as DbParameter;
                    if (p == null)
                        throw new Exception("Not support parameter type");

                    commandText += i == 0 ? " " : ", ";

                    commandText += "@" + p.ParameterName;
                    if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                    {
                        //output parameter
                        commandText += " output";
                    }
                }
            }

            var result = SqlQuery<TEntity>(commandText, parameters).ToList();

            for (int i = 0; i < result.Count; i++)
                result[i] = AttachEntityToContext(result[i]);

            return result;
        }



        /// <summary>
        /// Use when Model isn't attach in context
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> ExecuteSqlQuery<TElement>(string sql, params object[] parameters) where TElement : BaseEntity, new()
        {
            return Database.GetModelFromQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IQueryable<TElement> SqlQuery<TElement>(string sql, params object[] parameters) where TElement : class
        {
            return base.Set<TElement>().FromSql<TElement>(sql, parameters);
        }

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, int? timeout = null, params object[] parameters)
        {
            var result = this.Database.ExecuteSqlCommand(sql, parameters);
            return result;
        }


        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
