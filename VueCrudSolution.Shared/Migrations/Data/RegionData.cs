using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VueCrudSolution.Data.Models.HelperClass;

namespace VueCrudSolution.Shared.Migrations.Data
{
    public class RegionData
    {
        public RegionData()
        {
            Cities = new Collection<CityData>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAscii { get; set; }
        public int GeonameId { get; set; }
        public string AlternativeNames { get; set; }
        public string DisplayName { get; set; }
        public string GeonameCode { get; set; }
        public CountryData Country { get; set; }
        public string Slug { get; set; }
        public virtual ICollection<CityData> Cities { get; set; }

        public static explicit operator Region(RegionData source)
        {
            var destination = new Region()
            {
                Name = source.Name,
                NameAscii = source.Name,
                GeonameId = source.GeonameId,
                AlternativeNames = source.AlternativeNames,
                DisplayName = source.DisplayName,
                GeonameCode = source.GeonameCode,
                Slug = source.Slug,
                //Cities = source.Cities.Select(c =>(City) c).ToList()
            };

            return destination;
        }
    }
}
