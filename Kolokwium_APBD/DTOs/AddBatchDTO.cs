namespace Kolokwium_APBD.DTOs;

public class AddBatchDTO
{
    public int Quantity { get; set; }
    public string Species { get; set; }
    public string Nursery { get; set; }
    public List<AddResponsibleDTO> Responsible { get; set; }
}

public class AddResponsibleDTO
{
    public int EmployeeId { get; set; }
    public string Role { get; set; }
}