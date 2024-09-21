using Microsoft.AspNetCore.Mvc.Rendering;

namespace BicyclePartPicker.Models
{
    public class SelectedListViewModel
    {
        public string SelectedMakeId { get; set; }
        public string SelectModelId { get; set; }
        public string SelectedVersionId { get; set; }

        public List<SelectListItem> BicycleMakes { get; set; }
        public List<SelectListItem> BicycleModels { get; set; }
        public List<SelectListItem> BicycleVersions { get; set; }
        public List<BottomBracket> BottomBrackets { get; set; }

    }
}
