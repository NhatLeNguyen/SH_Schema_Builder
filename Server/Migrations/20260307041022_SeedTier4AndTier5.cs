using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedTier4AndTier5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCore",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCore",
                table: "Attributes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Cardinality", "Description", "IsCore", "Name", "SqlTableName", "TierId" },
                values: new object[,]
                {
                    { 1, "1:N", "Danh mục nhóm dược lý", true, "Nhóm Dược Lý", "bnt4_nhduly", 4 },
                    { 2, "1:N", "Danh mục hoạt chất", true, "Hoạt Chất", "bnt4_hoatch", 4 },
                    { 3, "1:N", "Quy tắc dị ứng chéo", true, "Dị ứng Chéo", "bnt4_ducheo", 4 },
                    { 4, "1:N", "Tương tác giữa các hoạt chất", true, "Tương Tác Thuốc", "bnt4_tuatac", 4 },
                    { 5, "1:N", "Hồ sơ dị ứng của bệnh nhân", true, "Dị Ứng Bệnh Nhân", "bnt4_diungb", 4 },
                    { 6, "1:N", "Bệnh lý nền bất biến", true, "Bệnh Nền", "bnt4_bnenan", 4 },
                    { 7, "1:N", "Bộ quy tắc cảnh báo lâm sàng", true, "Quy Tắc Cảnh Báo", "bnt4_qtcanh", 4 },
                    { 8, "1:N", "Lịch sử cảnh báo đã phát cho bệnh nhân", true, "Nhật Ký Cảnh Báo", "bnt4_nkcbao", 4 },
                    { 101, "1:N", "Hệ cơ quan sinh học", true, "Hệ Cơ Quan", "bnt5_hecqua", 5 },
                    { 102, "1:N", "Cấu trúc chi tiết cơ quan", true, "Cấu Trúc Sinh Học", "bnt5_cautru", 5 },
                    { 103, "1:N", "Chất hoá học hoặc tín hiệu đo lường", true, "Chất / Tín Hiệu", "bnt5_chatin", 5 },
                    { 104, "1:N", "Danh mục xét nghiệm đo lường", true, "DM Xét Nghiệm", "bnt5_dmxngh", 5 },
                    { 105, "1:N", "Reference ranges cho XN", true, "Khoảng Tham Chiếu", "bnt5_ktchie", 5 },
                    { 106, "1:N", "Y lệnh chỉ định XN", true, "Chỉ Định Đo Lường", "bnt5_ychidi", 5 },
                    { 107, "1:N", "Kết quả đo lường sinh học", true, "Kết Quả Đo Lường", "bnt5_ketqua", 5 },
                    { 108, "1:N", "Bối cảnh đo sinh hoá", true, "Context Sinh Hoá", "bnt5_cshoah", 5 },
                    { 109, "1:N", "Bối cảnh định kỳ của sinh hiệu", true, "Context Sinh Hiệu", "bnt5_cshieu", 5 },
                    { 110, "1:N", "Mối liên hệ giữa các xét nghiệm", true, "Liên Kết Xét Nghiệm", "bnt5_xnlqua", 5 },
                    { 111, "1:N", "Quy tắc cảnh báo sinh học", true, "Quy Tắc Cảnh Báo XN", "bnt5_qtcbxn", 5 }
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Cardinality", "DataType", "DefaultValue", "Description", "GroupId", "HasPermission", "IsCore", "IsHidden", "IsRequired", "Name", "Scope", "SqlColumnName" },
                values: new object[,]
                {
                    { 1, "1:1", "VARCHAR(50)", null, "", 1, false, true, false, true, "Mã Nhóm", "System", "code" },
                    { 2, "1:1", "NVARCHAR(200)", null, "", 1, false, true, false, true, "Tên Tiếng Việt", "System", "name_vi" },
                    { 3, "1:1", "VARCHAR(50)", null, "", 2, false, true, false, true, "Mã Hoạt Chất", "System", "code" },
                    { 4, "1:1", "INT", null, "FK references Nhóm Dược Lý", 2, false, true, false, true, "Nhóm Dược Lý ID", "System", "group_id" },
                    { 5, "1:1", "INT", null, "", 5, false, true, false, true, "Chất Dị Ứng ID", "System", "substance_id" },
                    { 6, "1:1", "INT", null, "", 5, false, true, false, true, "Mức độ", "System", "severity" },
                    { 7, "1:1", "VARCHAR(20)", null, "", 6, false, true, false, true, "Mã ICD", "System", "condition_code" },
                    { 8, "1:1", "DATE", null, "", 6, false, true, false, false, "Ngày Chẩn Đoán", "System", "diagnosed_at" },
                    { 101, "1:1", "VARCHAR(50)", null, "", 101, false, true, false, true, "Mã Cơ Quan", "System", "code" },
                    { 102, "1:1", "NVARCHAR(200)", null, "", 101, false, true, false, true, "Tên Tiếng Việt", "System", "name_vi" },
                    { 103, "1:1", "VARCHAR(50)", null, "", 104, false, true, false, true, "Mã Xét Nghiệm", "System", "code" },
                    { 104, "1:1", "NVARCHAR(200)", null, "", 104, false, true, false, true, "Tên Xét Nghiệm", "System", "name_vi" },
                    { 105, "1:1", "DECIMAL(18,4)", null, "", 107, false, true, false, true, "Giá Trị Kết Quả", "System", "result_value" },
                    { 106, "1:1", "NVARCHAR(50)", null, "", 107, false, true, false, false, "Đơn vị", "System", "unit" },
                    { 107, "1:1", "DATETIME", null, "", 107, false, true, false, true, "Thời gian có kết quả", "System", "result_date" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DropColumn(
                name: "IsCore",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "IsCore",
                table: "Attributes");
        }
    }
}
