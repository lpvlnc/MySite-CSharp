using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model
{
    [Table(nameof(Testimonial))]
    public class Testimonial
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; } = string.Empty;

        [Required]
        public virtual string ProfilePicture { get; set; } = string.Empty;

        [Required]
        public virtual string Relationship { get; set; } = string.Empty;

        [Required]
        public virtual string Message { get; set; } = string.Empty;
    }
}
