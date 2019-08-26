using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VueCrudSolution.Shared.Context;
using VueCrudSolution.Shared.Exceptions;
using VueCrudSolution.VueCliServices;

namespace VueCrudSolution.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            HostingEnvironment = env;
        }
        public static IConfiguration Configuration { get; set; }
        private static IHostingEnvironment HostingEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyAppConnection")));
            services.AddAutoMapper();
            AddCustomIdentity(services);
            AddSwagger(services);
            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            AddIposbiService(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthentication();
            UseCustomSwaggerApi(app);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "template";

                if (env.IsDevelopment())
                {
                    spa.UseVueCliServer(npmScript: "serve");
                }
            });
        }
    }
}