using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAspnet.Data;
using ApiAspnet.Models;

namespace ApiAspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolioColoniaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FolioColoniaController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Folio_Detalle_Colonia>>> GetFolios() 
            => await _context.Folio_Detalles.ToListAsync();
    }
}