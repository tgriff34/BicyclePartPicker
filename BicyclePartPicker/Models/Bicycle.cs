namespace BicyclePartPicker.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Version { get; set; }
        public List<BottomBracket> BottomBrackets { get; set; } = default!;
        public List<BicycleBottomBracket> BicycleBottomBrackets { get; set; } = default!;
    }
}
