using HouseHoldEmission.Data;
using HouseHoldEmission.Model.DTO;
using HouseHoldEmission.Model;
using HouseHoldEmission.Repository;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.HouseHoldApi.Repository
{
    public class HouseHoldRepository : IHouseHoldRepository
    {
        private readonly HouseHoldDbContext _db;
        public HouseHoldRepository(HouseHoldDbContext db)
        {
            _db = db;
        }
        public async Task<bool> DeleteHouseHoldEntity(int id)
        {
            var ent = await _db.HouseHoldEntities.FindAsync(id);
            if (ent != null)
            {
                _db.HouseHoldEntities.Remove(ent);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<HouseHoldEntity>> GetHouseHoldEntities()
        {
            return await _db.HouseHoldEntities.ToListAsync();
        }

        public async Task<IEnumerable<HouseHoldEntity>> GetHouseHoldEntityById(int userid)
        {
            return await _db.HouseHoldEntities.Where(en => en.UserId == userid).ToListAsync();
        }




        public async Task<HouseHoldEntity> PostHouseHoldEntity(HouseHoldDto entity)
        {
            var userId = entity.UserId;

            var currentMonth = entity.RecordedDate.Month;
            var currentYear = entity.RecordedDate.Year;

            var existingRecord = await _db.HouseHoldEntities
                .FirstOrDefaultAsync(h => h.UserId == userId &&
                                     h.RecordedDate.Month == currentMonth &&
                                     h.RecordedDate.Year == currentYear);
            if (existingRecord != null)
            {
                existingRecord.ElectricityUsage = entity.ElectricityUsage;
                existingRecord.LPGUsage = entity.LPGUsage;
                existingRecord.CoalUsage = entity.CoalUsage;
                existingRecord.HouseHoldEmission = (entity.ElectricityUsage * 0.8275) + (entity.LPGUsage * 1.51) + (entity.CoalUsage * 2.86);
                existingRecord.RecordedDate = entity.RecordedDate;
                await _db.SaveChangesAsync();
                return existingRecord;
            }
            var ent = new HouseHoldEntity()
            {
                UserId = entity.UserId,
                ElectricityUsage = entity.ElectricityUsage,
                LPGUsage = entity.LPGUsage,
                CoalUsage = entity.CoalUsage,
                RecordedDate = entity.RecordedDate,
                HouseHoldEmission = (entity.ElectricityUsage * 0.8275) + (entity.LPGUsage * 1.51) + (entity.CoalUsage * 2.86)
            };
            _db.HouseHoldEntities.Add(ent);
            await _db.SaveChangesAsync();
            return ent;

        }

        public async Task<HouseHoldEntity> PutHouseHoldEntity(int id, HouseHoldDto entity)
        {
            var ent = await _db.HouseHoldEntities.FindAsync(id);
            if (ent != null)
            {
                ent.ElectricityUsage = entity.ElectricityUsage;
                ent.CoalUsage = entity.CoalUsage;
                ent.LPGUsage = entity.LPGUsage;
                await _db.SaveChangesAsync();
            }
            return ent;

        }
    }
}
