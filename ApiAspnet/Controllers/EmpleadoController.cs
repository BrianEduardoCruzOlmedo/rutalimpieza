using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAspnet.Data;
using ApiAspnet.Models;

namespace ApiAspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmpleadoController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> Get() => await _context.Empleados.ToListAsync();

        [HttpGet("Disponibles")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetDisponibles(DateTime inicio, DateTime fin, bool esChofer)
        {
            // 1. Obtener IDs de empleados ocupados en ese rango
            var ocupadosIds = await _context.Folios
                .Where(f => f.Fecha_Inicio < fin && f.Fecha_TerminoReal > inicio)
                .SelectMany(f => f.Empleados.Select(e => e.ID))
                .Distinct()
                .ToListAsync();

            // 2. Retornar empleados que NO están ocupados y cumplen el rol
            return await _context.Empleados
                .Where(e => !ocupadosIds.Contains(e.ID) && e.isChofer == esChofer)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> Create(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return Ok(empleado);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Empleado empleado)
        {
            if (id != empleado.ID) return BadRequest("El ID no coincide");

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Empleados.Any(e => e.ID == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return NotFound();

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}