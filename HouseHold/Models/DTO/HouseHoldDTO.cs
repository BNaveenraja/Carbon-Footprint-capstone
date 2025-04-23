namespace HouseHold.Models.DTO
{
    public class HouseHoldDTO
    {
        public int UserId { get; set; }
        public double ElectricityUsage { get; set; }
        public double LPGUsage { get; set; }
        public double GasUsage { get; set; }
        public DateOnly RecordedDate { get; set; }
    }
}
