using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Model
{
    [Table(nameof(Me))]
    public class Me
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        /// <summary>
        /// Developer's name.
        /// </summary>
        /// <example>Leonardo Valença</example>
        [Required]
        [MaxLength(80, ErrorMessage = "The {0} field only accepts up to 80 characters.")]
        public virtual string Name { get; set; } = string.Empty;

        /// <summary>
        /// Developer's role(s)
        /// </summary>
        [Required]
        [MaxLength(80, ErrorMessage = "The {0} field only accepts up to 100 characters.")]
        public virtual string Role { get; set; } = string.Empty;

        /// <summary>
        /// Base64 Curriculum vitae.
        /// </summary>
        public virtual string CV { get; set; } = string.Empty;

        /// <summary>
        /// A brief description about the developer.
        /// </summary>
        [MaxLength(255, ErrorMessage = "The {0} field only accepts up to 255 characters.")]
        public virtual string About { get; set; } = string.Empty;

        /// <summary>
        /// When the developer started working professionally.
        /// This will be used to dynamically calculate how many years the developer has been working professionally.
        /// </summary>
        public virtual DateTime? WorkSince { get; set; }

        /// <summary>
        /// Number of clients.
        /// </summary>
        public virtual int? Clients { get; set; }

        /// <summary>
        /// Number of project's that the developer has worked on.
        /// </summary>
        public virtual int? Projects { get; set; }

        /// <summary>
        /// Picture of the 'Me' session on the website.
        /// </summary>
        public virtual string PictureMe { get; set; } = string.Empty;

        /// <summary>
        /// Picture of the 'About' session on the website.
        /// </summary>
        public virtual string PictureAbout { get; set; } = string.Empty;

        /// <summary>
        /// How many years the developer has been working professionally bases on the attribute 'WorkSince's value.
        /// </summary>
        [NotMapped]
        public int YearsOfExperience
        {
            get
            {
                if (WorkSince.HasValue)
                {
                    DateTime zeroTime = new (1, 1, 1);
                    TimeSpan span = DateTime.Now - WorkSince.Value;
                    int years = (zeroTime + span).Year - 1;
                    return years;
                }
                return 0;
            }
        }
    }
}
