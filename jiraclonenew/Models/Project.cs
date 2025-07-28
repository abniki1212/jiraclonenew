using System.ComponentModel.DataAnnotations;

namespace jiraclonenew.Models
{
    public enum ProjectStatus { Active, Archived }

    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Key { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        public string? LeadId { get; set; }
        public ApplicationUser? Lead { get; set; }

        public ProjectStatus Status { get; set; } = ProjectStatus.Active;

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Sprint> Sprints { get; set; } = new List<Sprint>();
    }
}
