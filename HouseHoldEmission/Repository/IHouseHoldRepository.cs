using HouseHoldEmission.Model.DTO;
using HouseHoldEmission.Model;

namespace HouseHoldEmission.Repository
{
    public interface IHouseHoldRepository
    {
        Task<IEnumerable<HouseHoldEntity>> GetHouseHoldEntities();
        Task<IEnumerable<HouseHoldEntity>> GetHouseHoldEntityById(int userid);
        Task<HouseHoldEntity> PostHouseHoldEntity(HouseHoldDto entity);
        Task<HouseHoldEntity> PutHouseHoldEntity(int id, HouseHoldDto entity);
        Task<bool> DeleteHouseHoldEntity(int id);
    }
}
