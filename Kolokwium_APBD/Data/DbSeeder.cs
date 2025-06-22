using Kolokwium_APBD.Models;

namespace Kolokwium_APBD.Data;

public static class DbSeeder
{
    public static void Seed(this DatabaseContext context)
    {
        
        context.Responsibles.RemoveRange(context.Responsibles);
        context.SeedlingBatches.RemoveRange(context.SeedlingBatches);
        context.Employees.RemoveRange(context.Employees);
        context.Nurseries.RemoveRange(context.Nurseries);
        context.TreeSpecies.RemoveRange(context.TreeSpecies);
        context.SaveChanges();
        
        var species = new TreeSpecies
        {
            LatinName = "Quercus robur",
            GrowthTimeInYears = 5
        };
        context.TreeSpecies.Add(species);
        context.SaveChanges();
        
        var nursery = new Nursery
        {
            Name = "Green Forest Nursery",
            EstablishedDate = new DateTime(2005, 5, 10)
        };
        context.Nurseries.Add(nursery);
        context.SaveChanges();
        
        var batch = new SeedlingBatch
        {
            NurseryId = nursery.NurseryId,
            SpeciesId = species.SpeciesId,
            Quantity = 500,
            SownDate = new DateTime(2024, 3, 15),
            ReadyDate = new DateTime(2029, 3, 15)
        };
        context.SeedlingBatches.Add(batch);
        context.SaveChanges();
        
        var employees = new List<Employee>
        {
            new Employee
            {
                FirstName = "Anna",
                LastName = "Kowalska",
                HireDate = DateTime.Now
            },
            new Employee
            {
                FirstName = "Jan",
                LastName = "Nowak",
                HireDate = DateTime.Now
            }
        };
        context.Employees.AddRange(employees);
        context.SaveChanges();
        
        var responsibles = new List<Responsible>
        {
            new Responsible
            {
                BatchId = batch.BatchId,
                EmployeeId = employees[0].EmployeeId,
                Role = "Supervisor"
            },
            new Responsible
            {
                BatchId = batch.BatchId,
                EmployeeId = employees[1].EmployeeId,
                Role = "Planter"
            }
        };
        context.Responsibles.AddRange(responsibles);
        context.SaveChanges();
    }
}