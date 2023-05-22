using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class ShorterUrlRequest
    {
        [Required]
        public string Url { get; set; } = string.Empty;
        public string CustomUrl { get; set; } = string.Empty;
    }
}
