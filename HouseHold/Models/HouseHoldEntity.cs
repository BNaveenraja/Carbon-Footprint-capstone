namespace HouseHold.Models
{
    public class HouseHoldEntity
    {
        public int HouseHoldId { get; set; }
        public int UserId { get; set; }
        public double LPGUsage { get; set; }
        public double CoalUsage { get; set; }
        public double ElectricityUsage { get; set; }
        public DateOnly RecordedDate { get; set; }
        public double HouseHoldEmission { get; set; }
    }
}
