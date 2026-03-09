using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVietnameseColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SqlColumnName",
                value: "ma_nhom");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2,
                column: "SqlColumnName",
                value: "ten_tieng_viet");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 3,
                column: "SqlColumnName",
                value: "ma_hoat_chat");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4,
                column: "SqlColumnName",
                value: "nhom_duoc_ly_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 5,
                column: "SqlColumnName",
                value: "chat_di_ung_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 6,
                column: "SqlColumnName",
                value: "muc_do");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 7,
                column: "SqlColumnName",
                value: "ma_icd");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 8,
                column: "SqlColumnName",
                value: "ngay_chan_doan");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 101,
                column: "SqlColumnName",
                value: "ma_he_co_quan");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 102,
                column: "SqlColumnName",
                value: "ten_he");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 103,
                column: "SqlColumnName",
                value: "ma_cau_truc");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 104,
                column: "SqlColumnName",
                value: "he_co_quan_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 105,
                column: "SqlColumnName",
                value: "ma_xet_nghiem");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 106,
                column: "SqlColumnName",
                value: "cau_truc_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 107,
                column: "SqlColumnName",
                value: "gia_tri");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 108,
                column: "SqlColumnName",
                value: "xet_nghiem_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2,
                column: "SqlColumnName",
                value: "name_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 3,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4,
                column: "SqlColumnName",
                value: "nhomduocly_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 5,
                column: "SqlColumnName",
                value: "hoatchat_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 6,
                column: "SqlColumnName",
                value: "severity");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 7,
                column: "SqlColumnName",
                value: "condition_code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 8,
                column: "SqlColumnName",
                value: "diagnosed_at");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 101,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 102,
                column: "SqlColumnName",
                value: "name_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 103,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 104,
                column: "SqlColumnName",
                value: "system_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 105,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 106,
                column: "SqlColumnName",
                value: "cautruc_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 107,
                column: "SqlColumnName",
                value: "result_value");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 108,
                column: "SqlColumnName",
                value: "dmxnghiem_id");
        }
    }
}
