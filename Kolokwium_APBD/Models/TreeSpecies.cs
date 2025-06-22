using System.ComponentModel.DataAnnotations;

namespace Kolokwium_APBD.Models;

public class TreeSpecies
{
    [Key]
    public int SpeciesId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LatinName { get; set; }
    
    [Required]
    public int GrowthTimeInYears { get; set; }
    
    public virtual ICollection<SeedlingBatch> SeedlingBatches { get; set; } = new List<SeedlingBatch>();
}