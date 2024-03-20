using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PanelAdministrativoPeopleContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoController : ControllerBase
    {
        private readonly DataContext _context;

        public ObjetivoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Objetivo>>> Get()
        {
            return Ok(await _context.Objetivos.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Objetivo>> Get(int id)
        {
            var objetivo = await _context.Objetivos.FindAsync(id);
            if (objetivo == null)
                return BadRequest("Objetivo not found.");
            return Ok(objetivo);
        }
        [HttpPost]
        public async Task<ActionResult<List<Objetivo>>> AddObjetivo(Objetivo objetivo)
        {
            _context.Objetivos.Add(objetivo);
            await _context.SaveChangesAsync();

            return Ok(await _context.Objetivos.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Objetivo>>> UpdateObjetivo(Objetivo request)
        {
            var dbObjetivo = await _context.Objetivos.FindAsync(request.IdObjetivo);
            if (dbObjetivo == null)
                return BadRequest("Objetivo not found.");


            dbObjetivo.Observacion = request.Observacion;
            dbObjetivo.Detalle = request.Detalle;
            dbObjetivo.Estado = request.Estado;


            await _context.SaveChangesAsync();

            return Ok(await _context.Objetivos.ToListAsync());
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Objetivo>>> ObjetivoCargo(int id)

        {
            var dbObjetivo = await _context.Objetivos.FindAsync(id);
            if (dbObjetivo == null)
                return BadRequest("Objetivo not found.");



            _context.Objetivos.Remove(dbObjetivo);
            await _context.SaveChangesAsync();


            return Ok(await _context.Objetivos.ToListAsync());
        }

    }
}
