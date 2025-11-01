// Api/Controllers/ReferencesController.cs
using DealCloudBackend.Infrastructure.Data;
using DealCloudBackend.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ReferencesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReferencesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/references
    [HttpGet]
    public async Task<IActionResult> GetReferences([FromQuery] int? lawyerId)
    {
        var query = _context.References.AsQueryable();

        // Requerimiento: Filtrar por abogado
        if (lawyerId.HasValue)
        {
            query = query.Where(r => r.LawyerId == lawyerId.Value);
        }

        var references = await query.ToListAsync();
        return Ok(references);
    }

    // ... (Implementar GET(id), POST, PUT, DELETE de forma similar a ClientsController) ...
}