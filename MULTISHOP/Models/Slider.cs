using System.ComponentModel.DataAnnotations;

namespace MULTISHOP.Models
{
    public class Slider :BaseEntity
    {
        [MaxLength(32),Required]
        public string Title { get; set; }
        [MaxLength(64),Required]
        public string Subtitle { get; set; }
        [Required]
        public string ImgAdress { get; set; }
    }
}
