// Api/Controllers/ProBonoController.cs
using DealCloudBackend.Infrastructure.Data;
using DealCloudBackend.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProBonoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProBonoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/probono
    [HttpGet]
    public async Task<IActionResult> GetProBonoCases()
    {
        var cases = await _context.ProBonos.ToListAsync();
        return Ok(cases);
    }

    // ... (Implementar GET(id), POST, PUT, DELETE de forma similar a ClientsController) ...
}