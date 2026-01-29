using Harfien.Domain.Entities;
using ProjectTrainer.Models;
using System.ComponentModel.DataAnnotations;

public class ChatMessage
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string MessageText { get; set; }

    [Required]
    public string SenderId { get; set; }
    public ApplicationUser Sender { get; set; }

    public int ChatId { get; set; }
    public Chat Chat { get; set; }

    public DateTime SentAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; } = false;
}
