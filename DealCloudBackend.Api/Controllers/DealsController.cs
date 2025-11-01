// Api/Controllers/DealsController.cs
using DealCloudBackend.Infrastructure.Data; // Para ApplicationDbContext
using DealCloudBackend.Core; // Para tus Modelos (Lawyer, Client, etc.)
using Microsoft.AspNetCore.Mvc; // Para [ApiController], ControllerBase, [Route]
using Microsoft.AspNetCore.Authorization; // Para [Authorize]
using Microsoft.EntityFrameworkCore; // Para .ToListAsync(), .FindAsync()
using DealCloudBackend.Application.Dtos; // Para tus DTOs (si los usas aquí)
using AutoMapper; // Si estás usando AutoMapper aquí
using System.Threading.Tasks; // Para async/await
using System.Collections.Generic; // Para List<>
using System.Linq; // Para .Where()

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class DealsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DealsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/deals
    [HttpGet]
    public async Task<IActionResult> GetDeals(
        [FromQuery] int? practiceAreaId,
        [FromQuery] int? partnerId,
        [FromQuery] bool? isConfidential)
    {
        // Lógica de filtrado basado en los requerimientos
        var query = _context.Deals.AsQueryable();

        if (practiceAreaId.HasValue)
            query = query.Where(d => d.PracticeAreaId == practiceAreaId.Value);

        if (isConfidential.HasValue)
            query = query.Where(d => d.IsConfidential == isConfidential.Value);

        // ...más filtros

        var deals = await query.ToListAsync();
        return Ok(deals);
    }

    // ... (Métodos GET(id), POST, PUT, DELETE similares a LawyersController) ...
}