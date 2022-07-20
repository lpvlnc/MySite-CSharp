namespace Portfolio.DTO
{
    public class MeAboutDto
    {
        /// <summary>
        /// A brief description about the developer.
        /// </summary>
        public string About { get; set; } = string.Empty;

        /// <summary>
        /// Picture of the 'About' session on the website.
        /// </summary>
        public string PictureAbout { get; set; } = string.Empty;

        /// <summary>
        /// Number of clients.
        /// </summary>
        public int? Clients { get; set; }

        /// <summary>
        /// Number of project's that the developer has worked on.
        /// </summary>
        public int? Projects { get; set; }

        /// <summary>
        /// How many years the developer has been working professionally bases on the attribute 'WorkSince's value.
        /// </summary>
        public int YearsOfExperience { get; set; }
    }
}
