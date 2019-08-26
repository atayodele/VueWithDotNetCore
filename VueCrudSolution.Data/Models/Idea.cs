using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VueCrudSolution.Data.Models
{
    public class Idea : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsRead { get; set; }
        public string FilePath { get; set; }
        public Guid Login_Id { get; set; }
        [ForeignKey(nameof(Login_Id))]
        public ApplicationIdentityUser Login { get; set; }
    }
}
