using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_RenameColumnAboutImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AbouyImages",
                table: "AbouyImages");

            migrationBuilder.RenameTable(
                name: "AbouyImages",
                newName: "AboutImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AboutImages",
                table: "AboutImages",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AboutImages",
                table: "AboutImages");

            migrationBuilder.RenameTable(
                name: "AboutImages",
                newName: "AbouyImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbouyImages",
                table: "AbouyImages",
                column: "Id");
        }
    }
}
