using NeoForum.Areas.Identity.Data;
using NeoForum.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace NeoForum.Models
{
    public class Article
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public Categories Categories { get; set; }

        [Required]
        public string? Text { get; set; }

        [Required]
        public string? Author { get; set; }

        public DateTime When { get; set; }
    }
}
