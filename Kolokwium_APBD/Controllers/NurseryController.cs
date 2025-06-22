using Kolokwium_APBD.Data;
using Kolokwium_APBD.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_APBD.Controllers;

[ApiController]
[Route("api/nurseries")]
public class NurseryController : ControllerBase
{
    private readonly DatabaseContext _context;
    
    public NurseryController(DatabaseContext context)
    {
        _context = context;
    }
    
    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNurseryWithBatches(int id)
    {
        var nursery = await _context.Nurseries
            .Include(n => n.SeedlingBatches)
            .ThenInclude(sb => sb.TreeSpecies)
            .Include(n => n.SeedlingBatches)
            .ThenInclude(sb => sb.Responsibles)
            .ThenInclude(r => r.Employee)
            .FirstOrDefaultAsync(n => n.NurseryId == id);

        if (nursery == null)
            return NotFound($"Nursery with id {id} was not found");

        var result = new GetNurseryWithBatchesDTO
        {
            NurseryId = nursery.NurseryId,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate.Date,
            Batches = nursery.SeedlingBatches.Select(sb => new GetBatchDetailsDTO
            {
                BatchId = sb.BatchId,
                Quantity = sb.Quantity,
                SownDate = sb.SownDate.Date,
                ReadyDate = sb.ReadyDate?.Date,
                Species = new GetSpeciesDTO
                {
                    LatinName = sb.TreeSpecies.LatinName,
                    GrowthTimeInYears = sb.TreeSpecies.GrowthTimeInYears
                },
                Responsible = sb.Responsibles.Select(r => new GetResponsibleDTO
                {
                    FirstName = r.Employee.FirstName,
                    LastName = r.Employee.LastName,
                    Role = r.Role
                }).ToList()
            }).ToList()
        };

        return Ok(result);
    }
    
}