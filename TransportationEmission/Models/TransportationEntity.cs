using System.ComponentModel.DataAnnotations;

namespace TransportationEmission.Models
{
    public class TransportationEntity
    {
        [Key]
        public int TransportationId { get; set; }
        public int UserId { get; set; }
        public double PetrolUsage { get; set; }
        public double DieselUsage { get; set; }
        public double CNGUsage { get; set; }
        public DateTime RecordedDate { get; set; }
        public double TransportEmission { get; set; }
    }
}
