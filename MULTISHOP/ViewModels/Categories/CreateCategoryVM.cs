using System.ComponentModel.DataAnnotations;

namespace MULTISHOP.ViewModels.Categories
{
    public class CreateCategoryVM
    {
        [MaxLength(32), Required]
        public string Name { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
