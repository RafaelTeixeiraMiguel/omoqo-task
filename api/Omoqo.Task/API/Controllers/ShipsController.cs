using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ShipsController : BaseController
    {
        private readonly DataContext _context;

        public ShipsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ship>>> GetShips()
        {
            return await _context.Ships.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ship>> GetShip(Guid id)
        {
            return await _context.Ships.FindAsync(id);
        }
    }
}
