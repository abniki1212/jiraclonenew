using System.ComponentModel.DataAnnotations;

namespace jiraclonenew.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;

        public string AuthorId { get; set; } = string.Empty;
        public ApplicationUser Author { get; set; } = null!;
    }
}
