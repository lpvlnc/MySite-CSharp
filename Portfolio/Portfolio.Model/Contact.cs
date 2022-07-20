using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Model
{
    [Table(nameof(Contact))]
    public class Contact
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Title { get; set; } = string.Empty;

        [Required]
        public virtual string Content { get; set; } = string.Empty;

        [Required]
        public virtual string Link { get; set; } = string.Empty;

        [Required]
        public virtual string Icon { get; set; } = string.Empty;
    }

    public class Message
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MessageBody { get; set; } = string.Empty;
    }
}
