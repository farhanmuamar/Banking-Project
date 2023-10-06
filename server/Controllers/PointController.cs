using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : Controller
    {
        private readonly DataContext _context;

        public PointController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Point>>> GetPoint()
        {
            return Ok(await _context.Point.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Point>> Create(Point point)
        {
            _context.Add(point);

            await _context.SaveChangesAsync();

            return Ok(point);
        }
    }
}