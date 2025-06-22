namespace Kolokwium_APBD.DTOs;

public class GetNurseryWithBatchesDTO
{
    public int NurseryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public List<GetBatchDetailsDTO> Batches { get; set; } = new List<GetBatchDetailsDTO>();
}


public class GetBatchDetailsDTO
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    public GetSpeciesDTO Species { get; set; }
    public List<GetResponsibleDTO> Responsible { get; set; } = new List<GetResponsibleDTO>();
}


public class GetSpeciesDTO
{
    public string LatinName { get; set; }
    public int GrowthTimeInYears { get; set; }
}


public class GetResponsibleDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
}
