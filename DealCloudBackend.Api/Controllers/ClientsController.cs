// Api/Controllers/ClientsController.cs
using DealCloudBackend.Infrastructure.Data;
using DealCloudBackend.Core; // Asegúrate de tener este using
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ClientsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/clients
    [HttpGet]
    public async Task<IActionResult> GetClients()
    {
        // El filtro de FirmId (Tenant) se aplica automáticamente por el DbContext
        var clients = await _context.Clients
            .Include(c => c.Industry)
            .Include(c => c.Country)
            .ToListAsync();
        return Ok(clients);
    }

    // GET: api/clients/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();
        return Ok(client);
    }

    // POST: api/clients
    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] Client client)
    {
        // NOTA: En la implementación real, deberías usar un DTO (Data Transfer Object)
        // y asignar el FirmId del usuario actual aquí.
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
    }

    // PUT: api/clients/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClient(int id, [FromBody] Client clientUpdateDto)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();

        // Lógica de actualización (ej. Mapeo de DTO a Entidad)
        client.Name = clientUpdateDto.Name;
        // ... actualizar otros campos

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/clients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}