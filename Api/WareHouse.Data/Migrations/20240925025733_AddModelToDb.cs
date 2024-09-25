using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kho",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_kho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hien_thi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kho", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ncc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_ncc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hien_thi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ten_day_du = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loai_ncc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nguoi_dai_dien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tinh_trang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nv_phu_trach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ncc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nhom_san_pham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    loai_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhom_san_pham", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "san_pham",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ten_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hien_thi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hang_sx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dia_chi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thong_tin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    han_su_dung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quy_cach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dvt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gia_nhap = table.Column<float>(type: "real", nullable: false),
                    sl_toi_thieu = table.Column<int>(type: "int", nullable: false),
                    sl_toi_da = table.Column<int>(type: "int", nullable: false),
                    sl_nhap = table.Column<int>(type: "int", nullable: false),
                    sl_xuat = table.Column<int>(type: "int", nullable: false),
                    sl_ton = table.Column<int>(type: "int", nullable: false),
                    trang_thai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nhom_san_pham_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_san_pham", x => x.id);
                    table.ForeignKey(
                        name: "FK_san_pham_nhom_san_pham_nhom_san_pham_id",
                        column: x => x.nhom_san_pham_id,
                        principalTable: "nhom_san_pham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_san_pham_nhom_san_pham_id",
                table: "san_pham",
                column: "nhom_san_pham_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kho");

            migrationBuilder.DropTable(
                name: "ncc");

            migrationBuilder.DropTable(
                name: "san_pham");

            migrationBuilder.DropTable(
                name: "nhom_san_pham");
        }
    }
}
