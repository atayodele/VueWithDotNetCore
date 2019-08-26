using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VueCrudSolution.Data.Constants;
using VueCrudSolution.Data.Models.HelperClass;

namespace VueCrudSolution.Data.Models
{
    public class ApplicationIdentityUser : IdentityUser<Guid>
    {
        public ApplicationIdentityUser()
        {
            Id = Guid.NewGuid();
            CreatedOnUtc = DateTime.Now.GetDateUtcNow();

            Photos = new Collection<Photo>();
            Ideas = new Collection<Idea>();
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool Activated { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid? Address_Id { get; set; }
        [ForeignKey(nameof(Address_Id))]
        public UserAddress Address { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Idea> Ideas { get; set; }
    }

    public class ApplicationIdentityUserClaim : IdentityUserClaim<Guid>
    {

    }

    public class ApplicationIdentityUserLogin : IdentityUserLogin<Guid>
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }

    public class ApplicationIdentityRole : IdentityRole<Guid>
    {
        public ApplicationIdentityRole()
        {
            Id = Guid.NewGuid();
            ConcurrencyStamp = Guid.NewGuid().ToString("N");
        }
    }

    public class ApplicationIdentityUserRole : IdentityUserRole<Guid>
    {

    }

    public class ApplicationIdentityRoleClaim : IdentityRoleClaim<Guid>
    {

    }

    public class ApplicationIdentityUserToken : IdentityUserToken<Guid>
    {

    }
}
