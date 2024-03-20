using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PanelAdministrativoPeopleContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly DataContext _context;

        public RolController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Rol>>> Get()
        {
            return Ok(await _context.Roles.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> Get(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            return BadRequest("Rol not found.");
            return Ok(rol);
        }
        [HttpPost]
        public async Task<ActionResult<List<Rol>>> AddRol(Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Rol>>> UpdateRol(Rol request)
        {
            var dbRol = await _context.Roles.FindAsync(request.IdRol);
            if (dbRol == null)
                return BadRequest("Rol not found.");

            dbRol.NombreRol = request.NombreRol;
            dbRol.Descripcion = request.Descripcion;

            await _context.SaveChangesAsync();

            return Ok(await _context.Roles.ToListAsync());
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Rol>>> DeleteRol(int id)

        {
            var dbRol = await _context.Roles.FindAsync(id);
            if (dbRol == null)
                return BadRequest("Rol not found.");



            _context.Roles.Remove(dbRol);
            await _context.SaveChangesAsync();


            return Ok(await _context.Roles.ToListAsync());
        }



    }
}
