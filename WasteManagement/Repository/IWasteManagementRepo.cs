using EcoLife.WasteManagementApi.Models;
using EcoLife.WasteManagementApi.Models.Dto;
using WasteManagement.Models;

namespace EcoLife.WasteManagementApi.Repository
{
    public interface IWasteManagementRepository
    {
        Task<IEnumerable<WasteManagementEntity>> GetWasteManagementEntities();

        Task<IEnumerable<WasteManagementEntity>> GetWasteMangementEntityById(int userid);

        Task<WasteManagementEntity> postWasteMangementEntity(WasteManagementDto entity);

        Task<WasteManagementEntity> putWasteMangementEntity(int id, WasteManagementDto entity);

        Task<bool> DeleteWasteMangementEntity(int id);
    }
}
