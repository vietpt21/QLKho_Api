using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddModelXuatKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "xuat_kho",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    loat_xuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_xuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nhan_vien_id = table.Column<int>(type: "int", nullable: false),
                    ma_hoa_don = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sl_san_pham = table.Column<int>(type: "int", nullable: false),
                    sl_xuat = table.Column<int>(type: "int", nullable: false),
                    noi_dung_xuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xuat_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "xuat_kho_ct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiXuat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    xuat_kho_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ngay_xuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    san_pham_id = table.Column<int>(type: "int", nullable: false),
                    ten_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nhom_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hang_sx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thong_tin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quy_cach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dvt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    so_lo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_het_han = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sl_xuat = table.Column<int>(type: "int", nullable: false),
                    sl_xuat_tong = table.Column<int>(type: "int", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xuat_kho_ct", x => x.id);
                    table.ForeignKey(
                        name: "FK_xuat_kho_ct_san_pham_san_pham_id",
                        column: x => x.san_pham_id,
                        principalTable: "san_pham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_xuat_kho_ct_xuat_kho_xuat_kho_id",
                        column: x => x.xuat_kho_id,
                        principalTable: "xuat_kho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_xuat_kho_ct_san_pham_id",
                table: "xuat_kho_ct",
                column: "san_pham_id");

            migrationBuilder.CreateIndex(
                name: "IX_xuat_kho_ct_xuat_kho_id",
                table: "xuat_kho_ct",
                column: "xuat_kho_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "xuat_kho_ct");

            migrationBuilder.DropTable(
                name: "xuat_kho");
        }
    }
}
