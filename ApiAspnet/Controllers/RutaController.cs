using ApiAspnet.Data;
using ApiAspnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RutaController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ruta>>> Get()
            => await _context.Rutas.Include(r => r.CoberturaColonias).ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Ruta>> Create(Ruta ruta)
        {
            _context.Rutas.Add(ruta);
            await _context.SaveChangesAsync();
            return Ok(ruta);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ruta tipo)
        {
            if (id != tipo.ID) return BadRequest();
            _context.Entry(tipo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tipo = await _context.Rutas.FindAsync(id);
            if (tipo == null) return NotFound();
            _context.Rutas.Remove(tipo);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
