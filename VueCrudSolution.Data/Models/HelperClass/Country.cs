using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace VueCrudSolution.Data.Models.HelperClass
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Regions = new Collection<Region>();
        }

        public string Name { get; set; }
        public string NameAscii { get; set; }
        public string Slug { get; set; }
        public int GeonameId { get; set; }
        public string AlternateNames { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string Continent { get; set; }
        public string Tld { get; set; }
        public string Phone { get; set; }
        public string Currency { get; set; }
        public string CurrencyCode { get; set; }
        public ICollection<Region> Regions { get; set; }
    }
}
