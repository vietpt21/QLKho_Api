using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddModelNhapKho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "nhap_kho",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    loai_nhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_nhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ncc_id = table.Column<int>(type: "int", nullable: false),
                    kho_id = table.Column<int>(type: "int", nullable: false),
                    sl_nhap = table.Column<int>(type: "int", nullable: false),
                    nguoi_giao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noi_dung_nhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhap_kho", x => x.id);
                    table.ForeignKey(
                        name: "FK_nhap_kho_kho_kho_id",
                        column: x => x.kho_id,
                        principalTable: "kho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhap_kho_ncc_ncc_id",
                        column: x => x.ncc_id,
                        principalTable: "ncc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nhap_kho_ct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nhap_kho_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ngay_nhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    san_pham_id = table.Column<int>(type: "int", nullable: false),
                    nhom_san_pham = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hang_sx = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinh_anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    thong_tin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    han_su_dung = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quy_cach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dvt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    so_lo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gia_nhap = table.Column<float>(type: "real", nullable: false),
                    sl_nhap = table.Column<int>(type: "int", nullable: false),
                    sl_xuat = table.Column<int>(type: "int", nullable: false),
                    sl_ton = table.Column<int>(type: "int", nullable: false),
                    ngay_het_han = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ghi_chu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngay_tao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ngay_cap_nhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nguoi_tao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhap_kho_ct", x => x.id);
                    table.ForeignKey(
                        name: "FK_nhap_kho_ct_nhap_kho_nhap_kho_id",
                        column: x => x.nhap_kho_id,
                        principalTable: "nhap_kho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nhap_kho_ct_san_pham_san_pham_id",
                        column: x => x.san_pham_id,
                        principalTable: "san_pham",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nhap_kho_kho_id",
                table: "nhap_kho",
                column: "kho_id");

            migrationBuilder.CreateIndex(
                name: "IX_nhap_kho_ncc_id",
                table: "nhap_kho",
                column: "ncc_id");

            migrationBuilder.CreateIndex(
                name: "IX_nhap_kho_ct_nhap_kho_id",
                table: "nhap_kho_ct",
                column: "nhap_kho_id");

            migrationBuilder.CreateIndex(
                name: "IX_nhap_kho_ct_san_pham_id",
                table: "nhap_kho_ct",
                column: "san_pham_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nhap_kho_ct");

            migrationBuilder.DropTable(
                name: "nhap_kho");
        }
    }
}
