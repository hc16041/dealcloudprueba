// Api/Controllers/PositionsController.cs
using DealCloudBackend.Infrastructure.Data;
using DealCloudBackend.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PositionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/positions
    [HttpGet]
    public async Task<IActionResult> GetPositions()
    {
        var positions = await _context.Positions.ToListAsync();
        return Ok(positions);
    }

    // POST: api/positions
    [HttpPost]
    public async Task<IActionResult> CreatePosition([FromBody] Position position)
    {
        // Lógica para crear (asignar FirmId, etc.)
        _context.Positions.Add(position);
        await _context.SaveChangesAsync();
        return Ok(position);
    }

    // DELETE: api/positions/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePosition(int id)
    {
        var position = await _context.Positions.FindAsync(id);
        if (position == null) return NotFound();

        _context.Positions.Remove(position);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}