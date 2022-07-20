using Microsoft.EntityFrameworkCore;
using Portfolio.Model;

namespace Portfolio.Data
{
    /// <summary>
    /// Data access context for accessing data entities.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="options">A <see cref="DbContextOptions{DataContext}"/> containing connection information.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the collection that contains <see cref="Me"/> entities.
        /// </summary>
        public virtual DbSet<Me> Me
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection that contains <see cref="Experience"/> entities.
        /// </summary>
        public virtual DbSet<Experience> Experiences
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection that contains <see cref="Project"/> entities.
        /// </summary>
        public virtual DbSet<Project> Projects
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection that contains <see cref="Testimonial"/> entities.
        /// </summary>
        public virtual DbSet<Testimonial> Testimonials
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection that contains <see cref="Contact"/> entities.
        /// </summary>
        public virtual DbSet<Contact> Contacts
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the collection that contains <see cref="Social"/> entities.
        /// </summary>
        public virtual DbSet<Social> Socials
        {
            get;
            set;
        }
    }
}
