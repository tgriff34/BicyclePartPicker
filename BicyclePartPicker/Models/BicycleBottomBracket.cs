using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace BicyclePartPicker.Models
{
    public class BicycleBottomBracket
    {
        public int BicycleId { get; set; }
        public Bicycle Bicycle { get; set; } = default!;
        public int BottomBracketId { get; set; }
        public BottomBracket BottomBracket { get; set; } = default!;
    }
}
