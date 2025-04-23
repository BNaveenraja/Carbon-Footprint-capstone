using TransportationEmission.Models.DTO;
using TransportationEmission.Models;
using TransportationEmission.Data;
using Microsoft.EntityFrameworkCore;

namespace TransportationEmission.Repository
{
    public class TransportationRepository : ITransportationRepository
    {
        private readonly TransportationDbContext _db;

        public TransportationRepository(TransportationDbContext db)
        {
            _db = db;
        }

       

        public async Task<IEnumerable<TransportationEntity>> GetTransportationById(int userid)
        {
            return await _db.transportationEntities.Where(en => en.UserId == userid).ToListAsync();
        }

        public async Task<IEnumerable<TransportationEntity>> GetTransportationEntities()
        {
            return await _db.transportationEntities.ToListAsync();
        }

        public async Task<TransportationEntity> postTransportationEntity(TransportationDto entity)
        {
            var userId = entity.UserId;

            var currentMonth = entity.RecordedDate.Month;
            var currentYear = entity.RecordedDate.Year;

            var existingRecord = await _db.transportationEntities
                .FirstOrDefaultAsync(h => h.UserId == userId &&
                                     h.RecordedDate.Month == currentMonth &&
                                     h.RecordedDate.Year == currentYear);
            if (existingRecord != null)
            {
                existingRecord.PetrolUsage = entity.PetrolUsage;
                existingRecord.DieselUsage = entity.DieselUsage;
                existingRecord.CNGUsage = entity.CNGUsage;
                existingRecord.TransportEmission = (entity.PetrolUsage * 2.3 + entity.DieselUsage * 2.68 + entity.CNGUsage * 2.75);
                existingRecord.RecordedDate = entity.RecordedDate;
                await _db.SaveChangesAsync();
                return existingRecord;
            }
            var result = new TransportationEntity()
            {
                UserId = entity.UserId,
                PetrolUsage = entity.PetrolUsage,
                DieselUsage = entity.DieselUsage,
                CNGUsage = entity.CNGUsage,
                RecordedDate = entity.RecordedDate,
                TransportEmission = (entity.PetrolUsage * 2.3 + entity.DieselUsage * 2.68 + entity.CNGUsage * 2.75)
            };
            _db.transportationEntities.Add(result);
            await _db.SaveChangesAsync();
            return result;
        }

        public async Task<TransportationEntity> putTransportationEntity(int id, TransportationDto entity)
        {
            var result = await _db.transportationEntities.FindAsync(id);
            if (result != null)
            {
                result.PetrolUsage = entity.PetrolUsage;
                result.DieselUsage = entity.DieselUsage;
                result.CNGUsage = entity.CNGUsage;
                await _db.SaveChangesAsync();
            }
            return result;
        }



        public async Task<bool> DeleteTransportationEntity(int id)
        {
            var result = await _db.transportationEntities.FindAsync(id);
            if (result != null)
            {
                _db.transportationEntities.Remove(result);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
