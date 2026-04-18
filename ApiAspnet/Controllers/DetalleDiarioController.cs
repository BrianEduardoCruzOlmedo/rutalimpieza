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
        
        public DetalleDiarioController(AppDbContext context) 
        {
            _context = context;
        }

        // Leer todos los detalles guardados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleDiario>>> GetDetalles() 
        {
            // OJO: Si en tu AppDbContext la lista se llama "Folios", cambia "DetallesDiarios" por "Folios" en la línea de abajo.
            return await _context.Folios.ToListAsync();
        }

        // GUARDAR un nuevo detalle (El que usaremos en el formulario)
        [HttpPost]
        public async Task<ActionResult<DetalleDiario>> PostDetalle(DetalleDiario detalle)
        {
            // OJO: Igual aquí, si en tu AppDbContext se llama "Folios", cámbialo.
            _context.Folios.Add(detalle);
            await _context.SaveChangesAsync();
            return Ok(detalle);
        }
    }
}