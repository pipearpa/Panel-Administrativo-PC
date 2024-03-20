using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PanelAdministrativoPeopleContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly DataContext _context;

        public AreaController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Area>>> Get()
        {
            return Ok(await _context.Areas.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> Get(int id)
        {
            var area = await _context.Areas.FindAsync(id);
            if (area == null)
                return BadRequest("Cargo not found.");
            return Ok(area);
        }
        [HttpPost]
        public async Task<ActionResult<List<Area>>> AddArea(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();

            return Ok(await _context.Areas.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Area>>> UpdateArea(Area request)
        {
            var dbArea = await _context.Areas.FindAsync(request.IdArea);
            if (dbArea == null)
                return BadRequest("Area not found.");


            dbArea.Nombre = request.Nombre;
            dbArea.Descripcion = request.Descripcion;
            dbArea.Responsable = request.Responsable;


            await _context.SaveChangesAsync();

            return Ok(await _context.Areas.ToListAsync());
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Area>>> DeleteArea(int id)

        {
            var dbArea = await _context.Areas.FindAsync(id);
            if (dbArea == null)
                return BadRequest("Area not found.");



            _context.Areas.Remove(dbArea);
            await _context.SaveChangesAsync();


            return Ok(await _context.Areas.ToListAsync());
        }
    }
}
