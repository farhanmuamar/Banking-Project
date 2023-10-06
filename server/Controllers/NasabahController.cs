using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NasabahController : Controller
    {
        private readonly DataContext _context;

        public NasabahController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Nasabah>>> GetNasabah()
        {
            return Ok(await _context.Nasabah.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Nasabah> GetNasabah(int id)
        {
            var nasabah = _context.Nasabah.Find(id);

            if (nasabah == null)
            {
                return NotFound();
            }

            return nasabah;
        }

        [HttpPost]
        public async Task<ActionResult<Nasabah>> Create(Nasabah nasabah)
        {
            _context.Add(nasabah);

            await _context.SaveChangesAsync();

            return Ok(nasabah);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Nasabah nasabah)
        {
            if (id != nasabah.AccountId) 
            {
                return BadRequest();
            }

            _context.Entry(nasabah).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nasabah = await _context.Nasabah.FindAsync(id);

            if (nasabah == null)
            {
                return NotFound("In correct id : " + id);
            }

            _context.Nasabah.Remove(nasabah);   
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}