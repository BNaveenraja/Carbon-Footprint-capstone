using Microsoft.AspNetCore.Mvc;
using TransportationEmission.Models.DTO;
using TransportationEmission.Models;
using TransportationEmission.Repository;

namespace EcoLife.TransportationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationController : ControllerBase
    {
        private readonly ITransportationRepository _transportationRepository;

        public TransportationController(ITransportationRepository transportationRepository)
        {
            _transportationRepository = transportationRepository;
        }
        [HttpGet("all")]

        public async Task<ActionResult<IEnumerable<TransportationEntity>>> GetAll()
        {
            var ent = await _transportationRepository.GetTransportationEntities();
            return Ok(ent);
        }
        [HttpGet("{Userid}")]

        public async Task<ActionResult<IEnumerable<TransportationEntity>>> GetById(int Userid)
        {
            var ent = await _transportationRepository.GetTransportationById(Userid);
            return Ok(ent);
        }

        [HttpPost]

        public async Task<ActionResult<TransportationEntity>> PostEntity(TransportationDto entity)
        {
            if (entity != null)
            {
                var ent = await _transportationRepository.postTransportationEntity(entity);
                return Ok(ent);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<TransportationEntity>> PutEntity(int id, TransportationDto entity)
        {
            var ent = await _transportationRepository.putTransportationEntity(id, entity);
            if (ent != null) return Ok(ent);
            return BadRequest();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<bool>> DeleteEntity(int id)
        {
            var ent = await _transportationRepository.DeleteTransportationEntity(id);
            if (ent == true) return Ok(new
            {
                message = "Record Deleted"
            });
            return BadRequest();
        }
    }
}
