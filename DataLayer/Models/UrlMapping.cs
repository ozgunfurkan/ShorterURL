using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    [Table("URL_Mapping")]
    public class UrlMapping
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty; 

    }
}
