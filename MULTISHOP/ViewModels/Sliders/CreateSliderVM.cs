using System.ComponentModel.DataAnnotations;

namespace MULTISHOP.ViewModels.Sliders
{
    public class CreateSliderVM
    {
        [MaxLength(32,ErrorMessage ="uzunglug max 32 ola biler"),Required]
        public string Title { get; set; }
        [MaxLength(64, ErrorMessage = "uzunglug max 64 ola biler"), Required]
        public string Subtitle { get; set; }
        [Required]
        public IFormFile ImageFile {  get; set; }




    }
}
