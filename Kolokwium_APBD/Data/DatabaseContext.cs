using Kolokwium_APBD.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium_APBD.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    public DbSet<SeedlingBatch> SeedlingBatches { get; set; }
    public DbSet<TreeSpecies> TreeSpecies { get; set; }
    
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Nursery>().ToTable("Nursery");
            modelBuilder.Entity<Responsible>().ToTable("Responsible");
            modelBuilder.Entity<SeedlingBatch>().ToTable("Seedling_Batch");
            modelBuilder.Entity<TreeSpecies>().ToTable("Tree_Species");
            
            
            modelBuilder.Entity<Responsible>()
                .HasKey(r => new { r.BatchId, r.EmployeeId });
            
            
            modelBuilder.Entity<Responsible>()
                .HasOne(r => r.SeedlingBatch)
                .WithMany(sb => sb.Responsibles)
                .HasForeignKey(r => r.BatchId);
            
            
            modelBuilder.Entity<Responsible>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Responsibles)
                .HasForeignKey(r => r.EmployeeId);
            
         
            modelBuilder.Entity<SeedlingBatch>()
                .HasOne(sb => sb.Nursery)
                .WithMany(n => n.SeedlingBatches)
                .HasForeignKey(sb => sb.NurseryId);
            
     
            modelBuilder.Entity<SeedlingBatch>()
                .HasOne(sb => sb.TreeSpecies)
                .WithMany(ts => ts.SeedlingBatches)
                .HasForeignKey(sb => sb.SpeciesId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
