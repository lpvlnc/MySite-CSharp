using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Model
{
    [Table(nameof(Experience))]
    public class Experience
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Technology { get; set; } = string.Empty;

        [Required]
        public virtual string Level { get; set; } = string.Empty;

        [Required]
        public virtual char Stack { get; set; }
    }
}
