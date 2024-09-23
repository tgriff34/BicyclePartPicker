namespace BicyclePartPicker.Models
{
    public class BottomBracket
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string bBType { get; set; }
        public string Image {  get; set; }
        public List<Bicycle> Bicycles { get; set; } = default!;
        public List<BicycleBottomBracket> BicycleBottomBrackets { get; set; } = default!;
    }
}
