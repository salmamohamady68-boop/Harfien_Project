using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Application.DTO.ServiceCategory
{
    public class AddServiceCategoryDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name max 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type is required")]
        [StringLength(50, ErrorMessage = "Type max 50 characters")]
        public string Type { get; set; }

        [StringLength(200, ErrorMessage = "Description max 200 characters")]
        public string Description { get; set; }
    }

}
