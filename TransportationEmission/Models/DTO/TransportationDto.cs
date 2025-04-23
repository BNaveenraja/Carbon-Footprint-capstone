namespace TransportationEmission.Models.DTO
{
    public class TransportationDto
    {
        public int UserId { get; set; }
        public double PetrolUsage { get; set; }
        public double DieselUsage { get; set; }
        public double CNGUsage { get; set; }
        public DateTime RecordedDate { get; set; } 

    }
}
