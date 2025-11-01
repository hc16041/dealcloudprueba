// Api/Controllers/LawyersController.cs
using DealCloudBackend.Infrastructure.Data;
using DealCloudBackend.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Authorize] // Asegura que solo usuarios logueados puedan acceder
[ApiController]
[Route("api/[controller]")]
public class LawyersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LawyersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/lawyers
    [HttpGet]
    public async Task<IActionResult> GetLawyers()
    {
        // La l�gica del _tenantId (Filtro Global) se aplica autom�ticamente
        var lawyers = await _context.Lawyers.ToListAsync();
        return Ok(lawyers);
    }

    // GET: api/lawyers/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetLawyer(int id)
    {
        var lawyer = await _context.Lawyers
            .Include(l => l.PracticeAreas) // Cargar datos relacionados
            .Include(l => l.Industries)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (lawyer == null) return NotFound();
        return Ok(lawyer);
    }

    // POST: api/lawyers
    [HttpPost]
    public IActionResult CreateLawyer([FromBody] Lawyer lawyerDto)
    {
        // Aqu� ir�a la l�gica para crear (mapear DTO a Entidad)
        // _context.Lawyers.Add(newLawyer);
        // await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetLawyer), new { id = 1 /* id del nuevo abogado */ }, lawyerDto);
    }

    // PUT: api/lawyers/5
    [HttpPut("{id}")]
    public IActionResult UpdateLawyer(int id, [FromBody] Lawyer lawyerDto)
    {
        // L�gica para actualizar
        return NoContent();
    }

    // DELETE: api/lawyers/5
    [HttpDelete("{id}")]
    public IActionResult DeleteLawyer(int id)
    {
        // L�gica para eliminar
        return NoContent();
    }
}