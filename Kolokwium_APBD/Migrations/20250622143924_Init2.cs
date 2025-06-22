using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium_APBD.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_Employees_EmployeeId",
                table: "Responsibles");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsibles_SeedlingBatches_BatchId",
                table: "Responsibles");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedlingBatches_Nurseries_NurseryId",
                table: "SeedlingBatches");

            migrationBuilder.DropForeignKey(
                name: "FK_SeedlingBatches_TreeSpecies_SpeciesId",
                table: "SeedlingBatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TreeSpecies",
                table: "TreeSpecies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeedlingBatches",
                table: "SeedlingBatches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsibles",
                table: "Responsibles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nurseries",
                table: "Nurseries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "TreeSpecies",
                newName: "Tree_Species");

            migrationBuilder.RenameTable(
                name: "SeedlingBatches",
                newName: "Seedling_Batch");

            migrationBuilder.RenameTable(
                name: "Responsibles",
                newName: "Responsible");

            migrationBuilder.RenameTable(
                name: "Nurseries",
                newName: "Nursery");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_SeedlingBatches_SpeciesId",
                table: "Seedling_Batch",
                newName: "IX_Seedling_Batch_SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_SeedlingBatches_NurseryId",
                table: "Seedling_Batch",
                newName: "IX_Seedling_Batch_NurseryId");

            migrationBuilder.RenameIndex(
                name: "IX_Responsibles_EmployeeId",
                table: "Responsible",
                newName: "IX_Responsible_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tree_Species",
                table: "Tree_Species",
                column: "SpeciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seedling_Batch",
                table: "Seedling_Batch",
                column: "BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsible",
                table: "Responsible",
                columns: new[] { "BatchId", "EmployeeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nursery",
                table: "Nursery",
                column: "NurseryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsible_Employee_EmployeeId",
                table: "Responsible",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsible_Seedling_Batch_BatchId",
                table: "Responsible",
                column: "BatchId",
                principalTable: "Seedling_Batch",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seedling_Batch_Nursery_NurseryId",
                table: "Seedling_Batch",
                column: "NurseryId",
                principalTable: "Nursery",
                principalColumn: "NurseryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seedling_Batch_Tree_Species_SpeciesId",
                table: "Seedling_Batch",
                column: "SpeciesId",
                principalTable: "Tree_Species",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responsible_Employee_EmployeeId",
                table: "Responsible");

            migrationBuilder.DropForeignKey(
                name: "FK_Responsible_Seedling_Batch_BatchId",
                table: "Responsible");

            migrationBuilder.DropForeignKey(
                name: "FK_Seedling_Batch_Nursery_NurseryId",
                table: "Seedling_Batch");

            migrationBuilder.DropForeignKey(
                name: "FK_Seedling_Batch_Tree_Species_SpeciesId",
                table: "Seedling_Batch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tree_Species",
                table: "Tree_Species");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seedling_Batch",
                table: "Seedling_Batch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Responsible",
                table: "Responsible");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nursery",
                table: "Nursery");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Tree_Species",
                newName: "TreeSpecies");

            migrationBuilder.RenameTable(
                name: "Seedling_Batch",
                newName: "SeedlingBatches");

            migrationBuilder.RenameTable(
                name: "Responsible",
                newName: "Responsibles");

            migrationBuilder.RenameTable(
                name: "Nursery",
                newName: "Nurseries");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Seedling_Batch_SpeciesId",
                table: "SeedlingBatches",
                newName: "IX_SeedlingBatches_SpeciesId");

            migrationBuilder.RenameIndex(
                name: "IX_Seedling_Batch_NurseryId",
                table: "SeedlingBatches",
                newName: "IX_SeedlingBatches_NurseryId");

            migrationBuilder.RenameIndex(
                name: "IX_Responsible_EmployeeId",
                table: "Responsibles",
                newName: "IX_Responsibles_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TreeSpecies",
                table: "TreeSpecies",
                column: "SpeciesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeedlingBatches",
                table: "SeedlingBatches",
                column: "BatchId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Responsibles",
                table: "Responsibles",
                columns: new[] { "BatchId", "EmployeeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nurseries",
                table: "Nurseries",
                column: "NurseryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_Employees_EmployeeId",
                table: "Responsibles",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Responsibles_SeedlingBatches_BatchId",
                table: "Responsibles",
                column: "BatchId",
                principalTable: "SeedlingBatches",
                principalColumn: "BatchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedlingBatches_Nurseries_NurseryId",
                table: "SeedlingBatches",
                column: "NurseryId",
                principalTable: "Nurseries",
                principalColumn: "NurseryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeedlingBatches_TreeSpecies_SpeciesId",
                table: "SeedlingBatches",
                column: "SpeciesId",
                principalTable: "TreeSpecies",
                principalColumn: "SpeciesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
