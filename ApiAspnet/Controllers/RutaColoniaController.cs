using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAspnet.Data;
using ApiAspnet.Models;


namespace ApiAspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaColoniaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public RutaColoniaController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colonia>>> GetRutas() 
            => await _context.Colonias.ToListAsync();
    }
}