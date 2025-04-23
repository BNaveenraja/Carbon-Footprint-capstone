using System.ComponentModel.DataAnnotations;

namespace HouseHoldEmission.Model
{
    public class HouseHoldEntity
    {
        [Key]
        public int HouseHoldId { get; set; }
        public int UserId { get; set; }
        public double ElectricityUsage { get; set; }
        public double LPGUsage { get; set; }
        public double CoalUsage { get; set; }
        public DateOnly RecordedDate { get; set; }
        public double HouseHoldEmission { get; set; }
    }
}
