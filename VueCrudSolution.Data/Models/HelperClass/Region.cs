using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VueCrudSolution.Data.Models.HelperClass
{
    public class Region : BaseEntity
    {
        public Region()
        {
            Cities = new Collection<City>();
        }

        public string Name { get; set; }
        public string NameAscii { get; set; }
        public int GeonameId { get; set; }
        public string AlternativeNames { get; set; }
        public string DisplayName { get; set; }
        public string GeonameCode { get; set; }
        public Guid Country_Id { get; set; }
        [ForeignKey(nameof(Country_Id))]
        public Country Country { get; set; }
        public string Slug { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
