using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VueCrudSolution.Data.Models.HelperClass;

namespace VueCrudSolution.Shared.Migrations.Data
{
    public class CityData
    {
        public CityData()
        {
            Region = new Collection<RegionData>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string NameAscii { get; set; }
        public int GeonameId { get; set; }
        public string AlternativeNames { get; set; }
        public string DisplayName { get; set; }
        public string GeonameCode { get; set; }
        public CountryData Country { get; set; }
        public string Slug { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Population { get; set; }
        public string FeatureCode { get; set; }
        public string SearchNames { get; set; }
        public Collection<RegionData> Region { get; set; }

        public static explicit operator City(CityData source)
        {
            var destination = new City()
            {
                Id = Guid.NewGuid(),
                Name = source.Name,
                NameAscii = source.NameAscii,
                GeonameId = source.GeonameId,
                AlternativeNames = source.AlternativeNames,
                DisplayName = source.DisplayName,
                GeonameCode = source.GeonameCode,
                Slug = source.Slug,
                Latitude = source.Latitude,
                Longitude = source.Longitude,
                Population = source.Population,
                FeatureCode = source.FeatureCode,
                SearchNames = source.SearchNames
            };

            return destination;
        }
    }
}
