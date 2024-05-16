using Microsoft.AspNetCore.Components.Web;

namespace MULTISHOP.ViewModels.Sliders
{
    public class GetSliderAdminVM
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string ImgUrl { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set;}

    }
}
