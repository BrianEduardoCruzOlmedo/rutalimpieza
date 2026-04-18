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
        public UnidadController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unidad>>> GetUnidades() 
            => await _context.Unidades.ToListAsync();

        // Ruta especial: api/Unidad/tipo/1
        [HttpGet("tipo/{tipoId}")]
        public async Task<ActionResult<IEnumerable<Unidad>>> GetPorTipo(int tipoId)
        {
            return await _context.Unidades
                .Where(u => u.id_tipo_unidad == tipoId)
                .ToListAsync();
        }
    }
}