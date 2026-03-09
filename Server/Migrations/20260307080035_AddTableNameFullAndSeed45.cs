using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class AddTableNameFullAndSeed45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableNameFull",
                table: "Groups",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "SqlColumnName" },
                values: new object[] { "FK references bnt4_nhomduocly(Id)", "nhomduocly_id" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "SqlColumnName" },
                values: new object[] { "FK references bnt4_hoatchat(Id)", "hoatchat_id" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 101,
                column: "Name",
                value: "Mã Hệ Cơ Quan");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 102,
                column: "Name",
                value: "Tên Hệ");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 102, "Mã Cấu Trúc" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "DataType", "Description", "GroupId", "Name", "SqlColumnName" },
                values: new object[] { "INT", "FK references bnt5_hecoquan(Id)", 102, "Hệ Cơ Quan ID", "system_id" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "DataType", "GroupId", "Name", "SqlColumnName" },
                values: new object[] { "VARCHAR(50)", 104, "Mã Xét Nghiệm", "code" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "DataType", "Description", "GroupId", "Name", "SqlColumnName" },
                values: new object[] { "INT", "FK references bnt5_cautruc(Id)", 104, "Cấu Trúc ID", "cautruc_id" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "DataType", "Name", "SqlColumnName" },
                values: new object[] { "DECIMAL(18,4)", "Giá Trị", "result_value" });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Cardinality", "DataType", "DefaultValue", "Description", "GroupId", "HasPermission", "IsCore", "IsHidden", "IsRequired", "Name", "Scope", "SqlColumnName" },
                values: new object[] { 108, "1:1", "INT", null, "FK references bnt5_dmxnghiem(Id)", 107, false, true, false, true, "Xét Nghiệm ID", "System", "dmxnghiem_id" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "TableNameFull",
                value: "nhomduocly");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "TableNameFull",
                value: "hoatchat");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                column: "TableNameFull",
                value: "diungcheo");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4,
                column: "TableNameFull",
                value: "tuongtacthuoc");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5,
                column: "TableNameFull",
                value: "diungbenhnhan");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6,
                column: "TableNameFull",
                value: "benhnen");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7,
                column: "TableNameFull",
                value: "quytaccanhbao");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8,
                column: "TableNameFull",
                value: "nhatkycanhbao");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 101,
                column: "TableNameFull",
                value: "hecoquan");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 102,
                column: "TableNameFull",
                value: "cautruc");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 103,
                column: "TableNameFull",
                value: "chatinhieu");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 104,
                column: "TableNameFull",
                value: "dmxnghiem");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 105,
                column: "TableNameFull",
                value: "ktchieucu");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 106,
                column: "TableNameFull",
                value: "ychidinh");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 107,
                column: "TableNameFull",
                value: "ketqua");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 108,
                column: "TableNameFull",
                value: "csinhhoa");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 109,
                column: "TableNameFull",
                value: "cshieusinh");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Description", "Name", "SqlTableName", "TableNameFull" },
                values: new object[] { "Bối cảnh tế bào", "Context Tế Bào", "bnt5_ctebao", "ctebao" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Description", "Name", "SqlTableName", "TableNameFull" },
                values: new object[] { "Bối cảnh hình ảnh", "Context Hình Ảnh", "bnt5_hhaanh", "chinhanh" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Cardinality", "Description", "IsCore", "Name", "ParentGroupId", "SqlTableName", "TableNameFull", "TierId" },
                values: new object[,]
                {
                    { 112, "1:N", "Bối cảnh điện sinh lý", true, "Context Điện Sinh Lý", null, "bnt5_dsnlyl", "diensinhly", 5 },
                    { 113, "1:N", "Mối liên hệ giữa các xét nghiệm", true, "Liên Kết Xét Nghiệm", null, "bnt5_xnlqua", "xnlienquan", 5 },
                    { 114, "1:N", "Quy tắc cảnh báo XN sinh học", true, "Quy Tắc Cảnh Báo XN", null, "bnt5_qtcbxn", "qtcbxn", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DropColumn(
                name: "TableNameFull",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "SqlColumnName" },
                values: new object[] { "FK references Nhóm Dược Lý", "group_id" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "SqlColumnName" },
                values: new object[] { "", "substance_id" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 101,
                column: "Name",
                value: "Mã Cơ Quan");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 102,
                column: "Name",
                value: "Tên Tiếng Việt");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "GroupId", "Name" },
                values: new object[] { 104, "Mã Xét Nghiệm" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "DataType", "Description", "GroupId", "Name", "SqlColumnName" },
                values: new object[] { "NVARCHAR(200)", "", 104, "Tên Xét Nghiệm", "name_vi" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "DataType", "GroupId", "Name", "SqlColumnName" },
                values: new object[] { "DECIMAL(18,4)", 107, "Giá Trị Kết Quả", "result_value" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "DataType", "Description", "GroupId", "Name", "SqlColumnName" },
                values: new object[] { "NVARCHAR(50)", "", 107, "Đơn vị", "unit" });

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "DataType", "Name", "SqlColumnName" },
                values: new object[] { "DATETIME", "Thời gian có kết quả", "result_date" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "Description", "Name", "SqlTableName" },
                values: new object[] { "Mối liên hệ giữa các xét nghiệm", "Liên Kết Xét Nghiệm", "bnt5_xnlqua" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "Description", "Name", "SqlTableName" },
                values: new object[] { "Quy tắc cảnh báo sinh học", "Quy Tắc Cảnh Báo XN", "bnt5_qtcbxn" });
        }
    }
}
