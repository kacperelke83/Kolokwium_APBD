using Kolokwium_APBD.Data;
using Kolokwium_APBD.DTOs;
using Kolokwium_APBD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_APBD.Controllers;

[ApiController]
[Route("api/batches")]
public class BatchesController : ControllerBase
{
    private readonly DatabaseContext _context;

    public BatchesController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddBatch([FromBody] AddBatchDTO dto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid data.");

        var species = await _context.TreeSpecies.FirstOrDefaultAsync(s => s.LatinName == dto.Species);
        if (species == null)
            return NotFound("Tree species not found.");

        var nursery = await _context.Nurseries.FirstOrDefaultAsync(n => n.Name == dto.Nursery);
        if (nursery == null)
            return NotFound("Nursery not found.");

        var employeeIds = dto.Responsible.Select(r => r.EmployeeId).ToList();
        var employees = await _context.Employees.Where(e => employeeIds.Contains(e.EmployeeId)).ToListAsync();
        if (employees.Count != employeeIds.Count)
            return NotFound("One or more employees not found.");

        var batch = new SeedlingBatch
        {
            NurseryId = nursery.NurseryId,
            SpeciesId = species.SpeciesId,
            Quantity = dto.Quantity,
            SownDate = DateTime.Now
        };
        _context.SeedlingBatches.Add(batch);
        await _context.SaveChangesAsync();

        foreach (var resp in dto.Responsible)
        {
            _context.Responsibles.Add(new Responsible
            {
                BatchId = batch.BatchId,
                EmployeeId = resp.EmployeeId,
                Role = resp.Role
            });
        }
        await _context.SaveChangesAsync();

        return CreatedAtAction(null, new { batchId = batch.BatchId });
    }
}