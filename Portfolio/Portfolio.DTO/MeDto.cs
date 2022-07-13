using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.DTO
{
    public class MeDto
    {
        /// <summary>
        /// Developer's name.
        /// </summary>
        /// <example>Leonardo Valença</example>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Developer's role(s)
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// Base64 Curriculum vitae.
        /// </summary>
        public string CV { get; set; } = string.Empty;

        /// <summary>
        /// Picture of the 'Me' session on the website.
        /// </summary>
        public string PictureMe { get; set; } = string.Empty;
    }
}
