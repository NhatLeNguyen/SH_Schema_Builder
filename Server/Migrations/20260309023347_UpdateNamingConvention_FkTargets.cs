using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamingConvention_FkTargets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40104,
                column: "FkTarget",
                value: "bnt4_nhom_duoc_ly(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40204,
                column: "FkTarget",
                value: "bnt4_nhom_duoc_ly(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40301,
                column: "FkTarget",
                value: "bnt4_hoat_chat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40302,
                column: "FkTarget",
                value: "bnt4_hoat_chat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40401,
                column: "FkTarget",
                value: "bnt4_hoat_chat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40402,
                column: "FkTarget",
                value: "bnt4_hoat_chat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40502,
                column: "FkTarget",
                value: "bnt4_hoat_chat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40803,
                column: "FkTarget",
                value: "bnt4_quy_tac_canh_bao(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50201,
                column: "FkTarget",
                value: "bnt5_he_co_quan(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50205,
                column: "FkTarget",
                value: "bnt5_cau_truc_sinh_hoc(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50301,
                column: "FkTarget",
                value: "bnt5_cau_truc_sinh_hoc(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50501,
                column: "FkTarget",
                value: "bnt5_dm_xet_nghiem(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50602,
                column: "FkTarget",
                value: "bnt5_dm_xet_nghiem(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50701,
                column: "FkTarget",
                value: "bnt5_chi_dinh_do_luong(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50801,
                column: "FkTarget",
                value: "bnt5_ket_qua_do_luong(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50901,
                column: "FkTarget",
                value: "bnt5_ket_qua_do_luong(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51001,
                column: "FkTarget",
                value: "bnt5_ket_qua_do_luong(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51101,
                column: "FkTarget",
                value: "bnt5_ket_qua_do_luong(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51201,
                column: "FkTarget",
                value: "bnt5_ket_qua_do_luong(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51301,
                column: "FkTarget",
                value: "bnt5_dm_xet_nghiem(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51302,
                column: "FkTarget",
                value: "bnt5_dm_xet_nghiem(Id)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40104,
                column: "FkTarget",
                value: "bnt4_nhomduocly(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40204,
                column: "FkTarget",
                value: "bnt4_nhomduocly(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40301,
                column: "FkTarget",
                value: "bnt4_hoatchat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40302,
                column: "FkTarget",
                value: "bnt4_hoatchat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40401,
                column: "FkTarget",
                value: "bnt4_hoatchat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40402,
                column: "FkTarget",
                value: "bnt4_hoatchat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40502,
                column: "FkTarget",
                value: "bnt4_hoatchat(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40803,
                column: "FkTarget",
                value: "bnt4_quytaccanhbao(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50201,
                column: "FkTarget",
                value: "bnt5_hecoquan(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50205,
                column: "FkTarget",
                value: "bnt5_cautruc(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50301,
                column: "FkTarget",
                value: "bnt5_cautruc(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50501,
                column: "FkTarget",
                value: "bnt5_dmxnghiem(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50602,
                column: "FkTarget",
                value: "bnt5_dmxnghiem(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50701,
                column: "FkTarget",
                value: "bnt5_ychidinh(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50801,
                column: "FkTarget",
                value: "bnt5_ketqua(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50901,
                column: "FkTarget",
                value: "bnt5_ketqua(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51001,
                column: "FkTarget",
                value: "bnt5_ketqua(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51101,
                column: "FkTarget",
                value: "bnt5_ketqua(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51201,
                column: "FkTarget",
                value: "bnt5_ketqua(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51301,
                column: "FkTarget",
                value: "bnt5_dmxnghiem(Id)");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51302,
                column: "FkTarget",
                value: "bnt5_dmxnghiem(Id)");
        }
    }
}
