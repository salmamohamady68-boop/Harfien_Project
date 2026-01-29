using Harfien.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harfien.Domain.Entities
{
    public class Review
    {
        public int Id { get; set; }
        // Explicit IDs for faster querying of a Craftsman's profile
        public int ClientId { get; set; } // The Reviewer
        public int CraftsmanId { get; set; } // The Target
        // Use int for easier math (Average Rating)
        // Range: 1 - 5
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        // Navigation Properties
        // will give error for now as order is not defined yet
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
