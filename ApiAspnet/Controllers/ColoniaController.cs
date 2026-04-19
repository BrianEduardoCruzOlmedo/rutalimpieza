using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiAspnet.Data;
using ApiAspnet.Models;


namespace ApiAspnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoniaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ColoniaController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colonia>>> GetAll() => await _context.Colonias.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Colonia>> GetById(int id)
        {
            var colonia = await _context.Colonias.FindAsync(id);
            return (colonia == null) ? NotFound() : colonia;
        }

        [HttpPost]
        public async Task<ActionResult<Colonia>> Create(Colonia colonia)
        {
            _context.Colonias.Add(colonia);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = colonia.ID }, colonia);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Colonia colonia)
        {
            if (id != colonia.ID) return BadRequest();
            _context.Entry(colonia).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var colonia = await _context.Colonias.FindAsync(id);
            if (colonia == null) return NotFound();
            _context.Colonias.Remove(colonia);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}