using emes.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace emes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationNGStoreController : ControllerBase
    {
        //public EmesDbContext(DbContextOptions<EmesDbContext> options) : base(options) { }

        private readonly EmesDbContext _db;

        public LocationNGStoreController(EmesDbContext db)=>_db=db;


        [HttpGet]
        public ActionResult<string> Index()
        {
            return Ok("OK");
        }
        [HttpGet("all")]
        public async Task<ActionResult<string>> All()
        {
            var data = await _db.NGStoreLocations.ToListAsync();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data) ;
        }

    }
}
