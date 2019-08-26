using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VueCrudSolution.Data.Models
{
    public class Photo : BaseEntity
    {
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public Guid Login_Id { get; set; }
        [ForeignKey(nameof(Login_Id))]
        public ApplicationIdentityUser Login { get; set; }
    }
}
