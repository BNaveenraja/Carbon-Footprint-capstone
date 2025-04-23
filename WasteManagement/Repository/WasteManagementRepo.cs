using EcoLife.WasteManagementApi.Data;
using EcoLife.WasteManagementApi.Models;
using EcoLife.WasteManagementApi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using WasteManagement.Models;

namespace EcoLife.WasteManagementApi.Repository
{
    public class WasteMangementRepository : IWasteManagementRepository
    {
        private readonly WasteManagementDbContext _db;

        public WasteMangementRepository(WasteManagementDbContext db)
        {
            _db = db;
        }

        public async Task<bool> DeleteWasteMangementEntity(int id)
        {
            var ent = await _db.WasteManagementEntities.FindAsync(id);
            if (ent != null)
            {
                _db.WasteManagementEntities.Remove(ent);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<WasteManagementEntity>> GetWasteManagementEntities()
        {
            return await _db.WasteManagementEntities.ToListAsync();
        }

        public async Task<IEnumerable<WasteManagementEntity>> GetWasteMangementEntityById(int userid)
        {
            return await _db.WasteManagementEntities.Where(en => en.UserId == userid).ToListAsync();
        }



        public async Task<WasteManagementEntity> postWasteMangementEntity(WasteManagementDto entity)
        {
            var userId = entity.UserId;

            var currentMonth = entity.RecordedDate.Month;
            var currentYear = entity.RecordedDate.Year;

            var existingRecord = await _db.WasteManagementEntities
                .FirstOrDefaultAsync(h => h.UserId == userId &&
                                     h.RecordedDate.Month == currentMonth &&
                                     h.RecordedDate.Year == currentYear);
            if (existingRecord != null)
            {
                existingRecord.LandfillWaste = entity.LandfillWaste;
                existingRecord.RecycledWaste = entity.RecycledWaste;
                existingRecord.CompostWaste = entity.CompostWaste;
                existingRecord.WasteEmission = (entity.RecycledWaste * 0.05) + (entity.CompostWaste * 0.03) + (entity.LandfillWaste * 0.35);
                existingRecord.RecordedDate = entity.RecordedDate;
                await _db.SaveChangesAsync();
                return existingRecord;
            }
            var ent = new WasteManagementEntity()
            {
                UserId = entity.UserId,
                RecycledWaste = entity.RecycledWaste,
                CompostWaste = entity.CompostWaste,
                LandfillWaste = entity.LandfillWaste,
                RecordedDate = entity.RecordedDate,
                WasteEmission = (entity.RecycledWaste * 0.05) + (entity.CompostWaste * 0.03) + (entity.LandfillWaste * 0.35)
            };
            _db.WasteManagementEntities.Add(ent);
            await _db.SaveChangesAsync();
            return ent;
        }

        public async Task<WasteManagementEntity> putWasteMangementEntity(int id, WasteManagementDto entity)
        {
            var ent = await _db.WasteManagementEntities.FindAsync(id);
            if (ent != null)
            {
                ent.RecycledWaste = entity.RecycledWaste;
                ent.CompostWaste = entity.CompostWaste;
                ent.LandfillWaste = entity.LandfillWaste;
                await _db.SaveChangesAsync();
            }
            return ent;
        }
    }
}
