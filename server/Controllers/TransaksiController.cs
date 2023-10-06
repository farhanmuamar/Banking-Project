using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiController : Controller
    {
        private readonly DataContext _context;

        public TransaksiController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaksi>>> GetTransaksi()
        {
            return Ok(await _context.Transaksi.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Transaksi> GetTransaksi(int id)
        {
            var transaksi = _context.Transaksi.Find(id);

            if (transaksi == null)
            {
                return NotFound();
            }

            return transaksi;
        }

        [HttpPost]
        public async Task<ActionResult<Transaksi>> Create(Transaksi transaksi)
        {
            Point point = new Point();
            int AccountId = transaksi.AccountId;
            int amount = Convert.ToInt32(transaksi.Amount);
            // ViewData["point"] = null;

            point.TotalPoint = GetTotal(point, transaksi.Description, Convert.ToInt32(transaksi.Amount));
            point.AccountId = transaksi.AccountId;
            point.Name = _context.Nasabah.Where(n => n.AccountId == transaksi.AccountId).Select(n => n.Name).SingleOrDefault().ToString();

            _context.Add(point);
            
            _context.Add(transaksi);
            await _context.SaveChangesAsync();

            return Ok(transaksi);
        }

        public int GetTotal(Point pts, string? desc, int amount)
        {
            if (desc == "Beli Pulsa") 
            {
                if (amount < 10000)
                {
                    amount = 0;
                }
                else if (amount > 10000 && amount <= 30000)
                {
                    amount = amount % 1000 * 1;
                }
                else if (amount > 30000)
                {
                    amount = amount % 1000 * 2;
                }
            }
            else if (desc == "Beli Listrik") 
            {
                if (amount <= 50000)
                {
                    amount = 0;
                }
                else if (amount > 50000 && amount <= 100000)
                {
                    amount = amount % 2000 * 1;
                }
                else if (amount > 100000)
                {
                    amount = amount % 2000 * 2;
                }
            }
            return amount;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Transaksi transaksi)
        {
            if (id != transaksi.Id) 
            {
                return BadRequest();
            }

            _context.Entry(transaksi).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var transaksi = await _context.Transaksi.FindAsync(id);

            if (transaksi == null)
            {
                return NotFound("In correct id : " + id);
            }

            _context.Transaksi.Remove(transaksi);   
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}