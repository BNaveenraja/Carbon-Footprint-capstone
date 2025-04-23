using TransportationEmission.Models.DTO;
using TransportationEmission.Models;

namespace TransportationEmission.Repository
{
    public interface ITransportationRepository
    {
        Task<IEnumerable<TransportationEntity>> GetTransportationEntities();
        Task<IEnumerable<TransportationEntity>> GetTransportationById(int userid);
        Task<TransportationEntity> postTransportationEntity(TransportationDto entity);
        Task<TransportationEntity> putTransportationEntity(int id, TransportationDto entity);
        Task<bool> DeleteTransportationEntity(int id);
    }
}
