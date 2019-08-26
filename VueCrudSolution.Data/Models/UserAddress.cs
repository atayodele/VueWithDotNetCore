using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using VueCrudSolution.Data.Models.HelperClass;

namespace VueCrudSolution.Data.Models
{
    public class UserAddress : BaseEntity
    {
        public Guid? Region_Id { get; set; }
        [ForeignKey(nameof(Region_Id))]
        public Region Region { get; set; }
        public Guid? Country_Id { get; set; }
        [ForeignKey(nameof(Country_Id))]
        public Country Country { get; set; }
        public Guid? City_Id { get; set; }
        [ForeignKey(nameof(City_Id))]
        public City City { get; set; }
        public Guid Login_Id { get; set; }
        [ForeignKey(nameof(Login_Id))]
        public ApplicationIdentityUser Login { get; set; }
    }
}
