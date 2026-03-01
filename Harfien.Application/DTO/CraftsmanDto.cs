using Harfien.Application.DTO.Profile_Craftman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO
{
    public class CraftsmanDto
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public double Rating { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsVerified { get; set; }

        public List<ServiceDto> Services { get; set; } = new();
        public List<AvailabilityDto> Availabilities { get; set; } = new();
        public List<ReviewsDto> Reviews { get; set; } = new();
        public int CompletedOrdersCount { get; set; }




    }
}
