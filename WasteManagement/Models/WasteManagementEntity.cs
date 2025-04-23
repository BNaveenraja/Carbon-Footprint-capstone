using System.ComponentModel.DataAnnotations;

namespace WasteManagement.Models
{
    public class WasteManagementEntity
    {
        [Key]
        public int WasteManagementId { get; set; }
        public int UserId { get; set; }
        public double RecycledWaste { get; set; }
        public double CompostWaste { get; set; }
        public double LandfillWaste { get; set; }
        public DateOnly RecordedDate { get; set; }
        public double WasteEmission { get; set; }
    }
}
