using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PanelAdministrativoPeopleContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return Ok(await _context.Personas.Include(r=>r.Rol).Include(c=>c.Cargo).Include(a=>a.Area).ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
                return BadRequest("Persona not found.");
            return Ok(persona);
        }

        [HttpPost]
        public async Task<ActionResult<List<Persona>>> AddPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return Ok(await _context.Personas.Include(r => r.Rol).ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Persona>>> UpdatePersona(Persona request)
        {
            var dbPersona = await _context.Personas.FindAsync(request.IdPersona);
            if (dbPersona == null)
                return BadRequest("Persona not found.");

            dbPersona.Usuario = request.Usuario;
            dbPersona.Nombres = request.Nombres;
            dbPersona.Apellido = request.Apellido;
            dbPersona.Documento = request.Documento;
            dbPersona.Genero = request.Genero;

            await _context.SaveChangesAsync();

            return Ok(await _context.Personas.Include(r => r.Rol).ToListAsync());
        }
        [HttpDelete("{id}")]
       
        public async Task<ActionResult<List<Persona>>> DeletePersona(int id)
       
        {
            var dbHero = await _context.Personas.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Persona not found.");


            
            _context.Personas.Remove(dbHero);
            await _context.SaveChangesAsync();

           
            return Ok(await _context.Personas.ToListAsync());
        }



    }
}
