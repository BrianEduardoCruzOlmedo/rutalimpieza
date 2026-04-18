using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAspnet.Data;
using ApiAspnet.Models;

namespace ApiAspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUnidadController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TipoUnidadController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo_Unidad>>> GetTipos() 
            => await _context.Tipos_Unidades.ToListAsync();
    }
}