using HouseHold.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseHold.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseHoldController : ControllerBase
    {
        private readonly AppDbContext db;
        public HouseHoldController(AppDbContext _db)
        {
            db= _db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(db.HouseHoldEntities);
        }

        [HttpPost]
        public IActionResult Post()
        {

        }

        [HttpDelete]
        public IActionResult Delete()
        {

        }
    }
}
