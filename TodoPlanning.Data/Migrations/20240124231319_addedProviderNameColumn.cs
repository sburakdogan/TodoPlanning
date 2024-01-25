using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoPlanning.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedProviderNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProviderName",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "ProviderName",
                table: "Developers");
        }
    }
}
