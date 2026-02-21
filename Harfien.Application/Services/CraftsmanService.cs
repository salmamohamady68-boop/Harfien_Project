using Harfien.Application.DTO;
using Harfien.Application.Interfaces;
using Harfien.Domain.Entities;
using Harfien.Domain.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Harfien.Application.Services
{
    public class CraftsmanService : ICraftsmanService
    {
        private readonly ICraftsmanRepository _repository;

        public CraftsmanService(ICraftsmanRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CraftsmanDto>> GetAllAsync()
        {
            var craftsmen = await _repository.GetAllWithUserAsync();

            return craftsmen.Select(c => new CraftsmanDto
            {
                Id = c.Id,
                FullName = c.User.FullName,
                Bio = c.Bio,
                Rating = c.Rating,
                YearsOfExperience = c.YearsOfExperience
            }).ToList();
        }
    }






}
