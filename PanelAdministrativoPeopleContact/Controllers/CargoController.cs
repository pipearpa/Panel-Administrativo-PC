using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PanelAdministrativoPeopleContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly DataContext _context;

        public CargoController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Cargo>>> Get()
        {
            return Ok(await _context.Cargos.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargo>> Get(int id)
        {
            var cargo = await _context.Cargos.FindAsync(id);
            if (cargo == null)
                return BadRequest("Cargo not found.");
            return Ok(cargo);
        }
        [HttpPost]
        public async Task<ActionResult<List<Cargo>>> AddCargo(Cargo cargo)
        {
            _context.Cargos.Add(cargo);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cargos.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Cargo>>> UpdateCargo(Cargo request)
        {
            var dbCargo = await _context.Cargos.FindAsync(request.IdCargo);
            if (dbCargo == null)
                return BadRequest("Cargo not found.");

           
            dbCargo.Nombre = request.Nombre;
            dbCargo.Descripcion = request.Descripcion;
            dbCargo.Estado = request.Estado;
            

            await _context.SaveChangesAsync();

            return Ok(await _context.Cargos.ToListAsync());
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Cargo>>> DeleteCargo(int id)

        {
            var dbCargo = await _context.Cargos.FindAsync(id);
            if (dbCargo == null)
                return BadRequest("Cargo not found.");



            _context.Cargos.Remove(dbCargo);
            await _context.SaveChangesAsync();


            return Ok(await _context.Cargos.ToListAsync());
        }
    }
}
