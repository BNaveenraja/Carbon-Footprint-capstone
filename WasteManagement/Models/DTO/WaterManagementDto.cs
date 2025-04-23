namespace EcoLife.WasteManagementApi.Models.Dto
{
    public class WasteManagementDto
    {
        public int UserId { get; set; }
        public double RecycledWaste { get; set; }
        public double CompostWaste { get; set; }
        public double LandfillWaste { get; set; }
        public DateOnly RecordedDate { get; set; }

    }
}
