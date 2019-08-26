using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VueCrudSolution.Data.Models.HelperClass;

namespace VueCrudSolution.Shared.Migrations.Data
{
    public class CountryData
    {
        public CountryData()
        {
            Regions = new Collection<RegionData>();
        }

        public int Id { get; set; }
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
        public ICollection<RegionData> Regions { get; set; }

        public static explicit operator Country(CountryData source)
        {
            var destination = new Country()
            {
                Name = source.Name,
                NameAscii = source.NameAscii,
                Slug = source.Slug,
                GeonameId = source.GeonameId,
                AlternateNames = source.AlternateNames,
                Code2 = source.Code2,
                Code3 = source.Code3,
                Continent = source.Continent,
                Tld = source.Tld,
                Phone = source.Phone,
                Currency = source.Currency,
                CurrencyCode = source.CurrencyCode,
                // Regions = source.Regions.Select(r => (Region)r).ToList()
            };

            return destination;
        }
    }
}
