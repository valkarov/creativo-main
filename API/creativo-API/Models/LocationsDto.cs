using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace creativo_API.Models
{
    public class ProvinceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        internal static ProvinceDto MapToProvinceDto(Province province)
        {
            return new ProvinceDto()
            {
                Id = province.Id,
                Name = province.Name
            };
        }
    }
    
    public class CantonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }

        internal static CantonDto MapToCantonDto(Canton canton)
        {
            return new CantonDto()
            {
                Id = canton.Id,
                Name = canton.Name,
                ProvinceId = canton.ProvinceId
            };
        }
    }

    public class DistrictDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CantonId { get; set; }

        internal static DistrictDto MapToDistrictDto(District district)
        {
            return new DistrictDto()
            {
                Id = district.Id,
                Name = district.Name,
                CantonId = district.CantonId
            };
        }
    }
}