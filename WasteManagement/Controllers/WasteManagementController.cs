using EcoLife.WasteManagementApi.Data;
using EcoLife.WasteManagementApi.Models;
using EcoLife.WasteManagementApi.Models.Dto;
using EcoLife.WasteManagementApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WasteManagement.Models;

namespace EcoLife.WasteManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WasteManagementController : ControllerBase
    {
        private readonly IWasteManagementRepository _wasteManagementRepository;

        public WasteManagementController(IWasteManagementRepository wasteManagementRepository)
        {
            _wasteManagementRepository = wasteManagementRepository;
        }

        [HttpGet("all")]

        public async Task<ActionResult<IEnumerable<WasteManagementEntity>>> GetAll()
        {
            var ent = await _wasteManagementRepository.GetWasteManagementEntities();
            return Ok(ent);
        }

        [HttpGet("{userid}")]

        public async Task<ActionResult<IEnumerable<WasteManagementEntity>>> GetByID(int userid)
        {
            var ent = await _wasteManagementRepository.GetWasteMangementEntityById(userid);
            return Ok(ent);
        }

        [HttpPost]

        public async Task<ActionResult<WasteManagementEntity>> PostEntity(WasteManagementDto entity)
        {
            if (entity != null)
            {
                var ent = await _wasteManagementRepository.postWasteMangementEntity(entity);
                return Ok(ent);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<WasteManagementEntity>> PutEntity(int id, WasteManagementDto entity)
        {
            var ent = await _wasteManagementRepository.putWasteMangementEntity(id, entity);
            if (ent != null) return Ok(ent);
            return BadRequest();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> DeleteEntity(int id)
        {
            var ent = await _wasteManagementRepository.DeleteWasteMangementEntity(id);
            if (ent == true) return Ok(new
            {
                message = "Record Deleted Successfully"
            });
            return BadRequest();
        }
    }
}
