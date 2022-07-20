using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Model
{
    [Table(nameof(Project))]
    public class Project
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Title { get; set; } = string.Empty;

        [Required]
        public virtual string Description { get; set; } = string.Empty;

        public virtual string Github { get; set; } = string.Empty;

        public virtual string Build { get; set; } = string.Empty;

        public virtual string Image { get; set; } = string.Empty;
    }
}
