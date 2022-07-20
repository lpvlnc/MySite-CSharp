using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Model
{
    [Table(nameof(Social))]
    public class Social
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; } = string.Empty;

        [Required]
        public virtual string Link { get; set; } = string.Empty;

        [Required]
        public virtual string Icon { get; set; } = string.Empty;
    }
}
