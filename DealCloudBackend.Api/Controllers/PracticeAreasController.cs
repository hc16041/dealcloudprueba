// Api/Controllers/PracticeAreasController.cs
using DealCloudBackend.Infrastructure.Data;
using DealCloudBackend.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PracticeAreasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PracticeAreasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/practiceareas
    [HttpGet]
    public async Task<IActionResult> GetPracticeAreas()
    {
        var areas = await _context.PracticeAreas.ToListAsync();
        return Ok(areas);
    }

    // ... (Implementar POST, PUT, DELETE de forma similar a PositionsController) ...
}