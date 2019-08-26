using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VueCrudSolution.Data.Models.HelperClass
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public string NameAscii { get; set; }
        public int GeonameId { get; set; }
        public string AlternativeNames { get; set; }
        public string DisplayName { get; set; }
        public string GeonameCode { get; set; }

        public Guid Region_Id { get; set; }
        [ForeignKey(nameof(Region_Id))]
        public Region Region { get; set; }
        public string Slug { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Population { get; set; }
        public string FeatureCode { get; set; }
        public string SearchNames { get; set; }
    }
}
