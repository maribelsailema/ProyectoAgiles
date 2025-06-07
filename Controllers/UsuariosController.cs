using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;
namespace Proyecto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DiticDbContext _context;

        public UsuariosController(DiticDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{ced}")]
        public async Task<ActionResult<Usuario>> GetUsuario(string ced)
        {
            var usuario = await _context.Usuarios.FindAsync(ced);
            if (usuario == null) return NotFound();
            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { ced = usuario.Ced }, usuario);
        }

        [HttpPut("{ced}")]
        public async Task<IActionResult> ActualizarUsuario(string ced, Usuario usuario)
        {
            if (ced != usuario.Ced) return BadRequest();

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Usuarios.Any(e => e.Ced == ced)) return NotFound();
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{ced}")]
        public async Task<IActionResult> EliminarUsuario(string ced)
        {
            var usuario = await _context.Usuarios.FindAsync(ced);
            if (usuario == null) return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    
}
}
