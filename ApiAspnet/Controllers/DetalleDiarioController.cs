using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAspnet.Data;
using ApiAspnet.Models; 

namespace ApiAspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleDiarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DetalleDiarioController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleDiario>>> GetAll()
        {
            return await _context.Folios
                .Include(d => d.Unidad).ThenInclude(u => u.TipoUnidad)
                .Include(d => d.Empleados)
        .Include(d => d.Ruta)
            .ThenInclude(r => r.CoberturaColonias)
        .ToListAsync();
        }

        [HttpPut("UpdateStatus/{id}")]
        public async Task<IActionResult> UpdateDieselYFechas(int id, DetalleDiario detalleModificado)
        {
            var existente = await _context.Folios.FindAsync(id);
            if (existente == null) return NotFound();

            // Actualizamos solo los campos que mencionaste
            existente.Fecha_TerminoReal = detalleModificado.Fecha_TerminoReal;
            existente.Diesel_Final = detalleModificado.Diesel_Final;
            existente.Diesel_Recargado = detalleModificado.Diesel_Recargado;
            existente.km_Recorridos = detalleModificado.km_Recorridos;

            // Recalcular autonomía si es necesario
            existente.Autonomia = detalleModificado.Autonomia;

            await _context.SaveChangesAsync();
            return Ok(existente);
        }
        [HttpPost]
        public async Task<ActionResult<DetalleDiario>> Post(DetalleDiario detalle)
        {
            // Evitar que EF intente duplicar registros existentes de Empleados/Colonias
            foreach (var emp in detalle.Empleados) _context.Entry(emp).State = EntityState.Unchanged;

            _context.Folios.Add(detalle);
            await _context.SaveChangesAsync();
            return Ok(detalle);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var detalle = await _context.Folios.FindAsync(id);
            if (detalle == null) return NotFound();

            _context.Folios.Remove(detalle);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}