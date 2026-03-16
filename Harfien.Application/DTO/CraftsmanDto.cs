using Harfien.Application.DTO.Profile_Craftman;
using Harfien.Application.DTO.Review;
using Microsoft.AspNetCore.Http;
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
        public string UserId { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AreaName { get; set; }
        public string CityName { get; set; }
        public double Rating { get; set; }
        public int YearsOfExperience { get; set; }
        public bool IsVerified { get; set; }
        public string? ProfilePicture { get; set; }

        public List<ServiceDto> Services { get; set; }
        public List<AvailabilityDto> Availabilities { get; set; }
        public List<GetReviewDto> Reviews { get; set; }
        public int CompletedOrdersCount { get; set; }




    }
}
