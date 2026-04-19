using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAspnet.Data;
using ApiAspnet.Models;

namespace ApiAspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UnidadController(AppDbContext context)  {
            _context = context; 
                }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unidad>>> GetUnidades()
        { 
            var unidades = await _context.Unidades.Include(u => u.TipoUnidad).ToListAsync();
          
            return unidades;

        }

        // Ruta especial: api/Unidad/tipo/1
        [HttpGet("Read/{Id}")]
        public async Task<ActionResult<Unidad>> Read(int Id)
        {
            var unidad = (await _context.Unidades.Include(u => u.TipoUnidad)
                .FirstOrDefaultAsync(u => u.Id == Id)) ?? new();
                return unidad;
        }
        [HttpPut("Update/{Id}")]
        public async Task<ActionResult<Unidad>> Update(int Id, Unidad unidad)
        {
            var isExistunidad = (await _context.Unidades
                .AnyAsync(u => u.Id == Id));
            if(!isExistunidad)
            {
                return NotFound();
            }
            _context.Unidades.Update(unidad);

            await _context.SaveChangesAsync();
            return unidad;
        }
        [HttpGet("Disponibles")]
        public async Task<ActionResult<IEnumerable<Unidad>>> GetDisponibles(DateTime inicio, DateTime fin)
        {
            var ocupadasIds = await _context.Folios
                .Where(f => f.Fecha_Inicio < fin && f.Fecha_TerminoReal > inicio)
                .Select(f => f.ID_Unidad)
                .Distinct()
                .ToListAsync();

            return await _context.Unidades
                .Include(u => u.TipoUnidad)
                .Where(u => !ocupadasIds.Contains(u.Id))
                .ToListAsync();
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Unidad>> Create(Unidad unidad)
        {
             _context.Unidades.Add(unidad);
            await _context.SaveChangesAsync();
            return unidad;
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var unidad = (await _context.Unidades
               .FirstOrDefaultAsync(u => u.Id == Id));
            if(unidad == null)
            {
                return NotFound();
            }

            _context.Unidades.Remove(unidad);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}