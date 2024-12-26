using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebQLLuongNV.Migrations
{
    /// <inheritdoc />
    public partial class AddThoiGianDKColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Noilam",
                table: "ChiTietLichLam",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Noilam",
                table: "ChiTietLichLam");
        }
    }
}
