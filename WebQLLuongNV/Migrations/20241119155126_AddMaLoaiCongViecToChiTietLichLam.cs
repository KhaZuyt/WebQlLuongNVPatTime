using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebQLLuongNV.Migrations
{
    /// <inheritdoc />
    public partial class AddMaLoaiCongViecToChiTietLichLam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Noilam",
                table: "ChiTietLichLam",
                newName: "NoiLam");

            migrationBuilder.AlterColumn<string>(
                name: "NoiLam",
                table: "ChiTietLichLam",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaLoaiCongViec",
                table: "ChiTietLichLam",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TongSoCaQuyDinh",
                table: "ChiTietLichLam",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LichLam_MaLoaiCongViec",
                table: "LichLam",
                column: "MaLoaiCongViec");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietLichLam_MaLoaiCongViec",
                table: "ChiTietLichLam",
                column: "MaLoaiCongViec");

            migrationBuilder.AddForeignKey(
                name: "FK_ChiTietLichLam_LoaiCongViec",
                table: "ChiTietLichLam",
                column: "MaLoaiCongViec",
                principalTable: "LoaiCongViec",
                principalColumn: "MaLoaiCongViec");

            migrationBuilder.AddForeignKey(
                name: "FK_LichLam_LoaiCongViec",
                table: "LichLam",
                column: "MaLoaiCongViec",
                principalTable: "LoaiCongViec",
                principalColumn: "MaLoaiCongViec");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiTietLichLam_LoaiCongViec",
                table: "ChiTietLichLam");

            migrationBuilder.DropForeignKey(
                name: "FK_LichLam_LoaiCongViec",
                table: "LichLam");

            migrationBuilder.DropIndex(
                name: "IX_LichLam_MaLoaiCongViec",
                table: "LichLam");

            migrationBuilder.DropIndex(
                name: "IX_ChiTietLichLam_MaLoaiCongViec",
                table: "ChiTietLichLam");

            migrationBuilder.DropColumn(
                name: "MaLoaiCongViec",
                table: "ChiTietLichLam");

            migrationBuilder.DropColumn(
                name: "TongSoCaQuyDinh",
                table: "ChiTietLichLam");

            migrationBuilder.RenameColumn(
                name: "NoiLam",
                table: "ChiTietLichLam",
                newName: "Noilam");

            migrationBuilder.AlterColumn<string>(
                name: "Noilam",
                table: "ChiTietLichLam",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
