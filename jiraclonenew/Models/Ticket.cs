using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jiraclonenew.Models
{
    public enum TicketType { Story, Bug, Task, Epic, SubTask }
    public enum TicketStatus { ToDo, InProgress, InReview, Done }
    public enum TicketPriority { Low, Medium, High }

    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public TicketType Type { get; set; } = TicketType.Task;
        public TicketStatus Status { get; set; } = TicketStatus.ToDo;
        public TicketPriority Priority { get; set; } = TicketPriority.Medium;

        public string? AssigneeId { get; set; }
        public ApplicationUser? Assignee { get; set; }

        public string? ReporterId { get; set; }
        public ApplicationUser? Reporter { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
