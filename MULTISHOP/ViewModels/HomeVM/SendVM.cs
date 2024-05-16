using MULTISHOP.Models;
using MULTISHOP.ViewModels.Categories;
using MULTISHOP.ViewModels.Sliders;

namespace MULTISHOP.ViewModels.HomeVM
{
    public class SendVM
    {

        public List<GetCategoryVm> GetCategoryVMs { get; set; }
        public List<GetSliderVM> GetSliderVMs { get; set; }
    }
}
