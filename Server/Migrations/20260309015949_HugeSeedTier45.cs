using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class HugeSeedTier45 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.AddColumn<string>(
                name: "FkTarget",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Cardinality", "DataType", "DefaultValue", "Description", "FkTarget", "GroupId", "HasPermission", "IsCore", "IsHidden", "IsRequired", "Name", "Scope", "SqlColumnName" },
                values: new object[,]
                {
                    { 40101, "1:1", "VARCHAR(50)", null, "", null, 1, false, true, false, true, "Mã Nhóm", "System", "code" },
                    { 40102, "1:1", "NVARCHAR(200)", null, "", null, 1, false, true, false, true, "Tên Tiếng Việt", "System", "name_vi" },
                    { 40103, "1:1", "NVARCHAR(200)", null, "", null, 1, false, true, false, false, "Tên Tiếng Anh", "System", "name_en" },
                    { 40104, "1:1", "INT", null, "", "bnt4_nhomduocly(Id)", 1, false, true, false, false, "Nhóm Cha ID", "System", "parent_id" },
                    { 40105, "1:1", "NVARCHAR(MAX)", null, "", null, 1, false, true, false, false, "Mục Tiêu Sinh Học", "System", "bio_target" },
                    { 40106, "1:1", "NVARCHAR(MAX)", null, "", null, 1, false, true, false, false, "Cơ chế TV", "System", "mechanism_vi" },
                    { 40107, "1:1", "NVARCHAR(MAX)", null, "", null, 1, false, true, false, false, "Cơ chế TA", "System", "mechanism_en" },
                    { 40108, "1:1", "VARCHAR(100)", null, "", null, 1, false, true, false, false, "Cấu trúc hóa học", "System", "chemical_structure" },
                    { 40109, "1:1", "VARCHAR(10)", "1.0", "", null, 1, false, true, false, true, "Phiên bản", "System", "version" },
                    { 40110, "1:1", "VARCHAR(50)", "ACTIVE", "", null, 1, false, true, false, true, "Trạng thái", "System", "status" },
                    { 40201, "1:1", "VARCHAR(50)", null, "", null, 2, false, true, false, true, "Mã Hoạt Chất", "System", "code" },
                    { 40202, "1:1", "NVARCHAR(200)", null, "", null, 2, false, true, false, true, "Tên Tiếng Việt", "System", "name_vi" },
                    { 40203, "1:1", "NVARCHAR(200)", null, "", null, 2, false, true, false, false, "Tên Tiếng Anh", "System", "name_en" },
                    { 40204, "1:1", "INT", null, "", "bnt4_nhomduocly(Id)", 2, false, true, false, true, "Nhóm Dược Lý ID", "System", "group_id" },
                    { 40205, "1:1", "VARCHAR(20)", null, "", null, 2, false, true, false, false, "ATC Code", "System", "atc_code" },
                    { 40206, "1:1", "VARCHAR(100)", null, "", null, 2, false, true, false, false, "Công thức phân tử", "System", "molecular_formula" },
                    { 40207, "1:1", "DECIMAL(10,4)", null, "", null, 2, false, true, false, false, "Khối lượng P.Tử", "System", "molecular_weight" },
                    { 40208, "1:1", "VARCHAR(50)", null, "", null, 2, false, true, false, false, "Thời gian bán thải", "System", "half_life" },
                    { 40209, "1:1", "DECIMAL(5,2)", null, "", null, 2, false, true, false, false, "Sinh khả dụng", "System", "bioavailability" },
                    { 40210, "1:1", "VARCHAR(10)", "1.0", "", null, 2, false, true, false, true, "Phiên bản", "System", "version" },
                    { 40211, "1:1", "VARCHAR(50)", "ACTIVE", "", null, 2, false, true, false, true, "Trạng thái", "System", "status" },
                    { 40301, "1:1", "INT", null, "", "bnt4_hoatchat(Id)", 3, false, true, false, true, "Chất Gây Dị Ứng (Source)", "System", "substance_from_id" },
                    { 40302, "1:1", "INT", null, "", "bnt4_hoatchat(Id)", 3, false, true, false, true, "Chất Dị Ứng Chéo (Target)", "System", "substance_to_id" },
                    { 40303, "1:1", "VARCHAR(50)", null, "", null, 3, false, true, false, true, "Mức độ", "System", "severity" },
                    { 40304, "1:1", "NVARCHAR(MAX)", null, "", null, 3, false, true, false, false, "Mô tả", "System", "description" },
                    { 40305, "1:1", "VARCHAR(50)", null, "", null, 3, false, true, false, false, "Mức độ bằng chứng", "System", "evidence_level" },
                    { 40306, "1:1", "DATETIME", "GETDATE()", "", null, 3, false, true, false, true, "Ngày tạo", "System", "created_at" },
                    { 40401, "1:1", "INT", null, "", "bnt4_hoatchat(Id)", 4, false, true, false, true, "Thuốc 1", "System", "drug1_id" },
                    { 40402, "1:1", "INT", null, "", "bnt4_hoatchat(Id)", 4, false, true, false, true, "Thuốc 2", "System", "drug2_id" },
                    { 40403, "1:1", "NVARCHAR(MAX)", null, "", null, 4, false, true, false, true, "Tác dụng", "System", "effect" },
                    { 40404, "1:1", "VARCHAR(50)", null, "", null, 4, false, true, false, true, "Mức độ", "System", "severity" },
                    { 40405, "1:1", "NVARCHAR(MAX)", null, "", null, 4, false, true, false, false, "Xử trí", "System", "management" },
                    { 40406, "1:1", "NVARCHAR(MAX)", null, "", null, 4, false, true, false, false, "Bằng chứng", "System", "evidence" },
                    { 40501, "1:1", "INT", null, "", "Patient(Id)", 5, false, true, false, true, "Bệnh nhân ID", "System", "patient_id" },
                    { 40502, "1:1", "INT", null, "", "bnt4_hoatchat(Id)", 5, false, true, false, true, "Hoạt Chất ID", "System", "substance_id" },
                    { 40503, "1:1", "VARCHAR(50)", null, "", null, 5, false, true, false, true, "Mức độ", "System", "severity" },
                    { 40504, "1:1", "VARCHAR(50)", null, "", null, 5, false, true, false, true, "Loại phản ứng", "System", "reaction_type" },
                    { 40505, "1:1", "DATE", null, "", null, 5, false, true, false, false, "Ngày phát hiện", "System", "onset_date" },
                    { 40506, "1:1", "BIT", "0", "", null, 5, false, true, false, true, "Đã khỏi", "System", "resolved" },
                    { 40507, "1:1", "NVARCHAR(MAX)", null, "", null, 5, false, true, false, false, "Ghi chú", "System", "notes" },
                    { 40601, "1:1", "INT", null, "", "Patient(Id)", 6, false, true, false, true, "Bệnh nhân ID", "System", "patient_id" },
                    { 40602, "1:1", "VARCHAR(20)", null, "", null, 6, false, true, false, true, "Mã ICD", "System", "condition_code" },
                    { 40603, "1:1", "DATE", null, "", null, 6, false, true, false, false, "Ngày chẩn đoán", "System", "diagnosed_at" },
                    { 40604, "1:1", "VARCHAR(50)", null, "", null, 6, false, true, false, false, "Mức độ", "System", "severity_level" },
                    { 40605, "1:1", "VARCHAR(50)", null, "", null, 6, false, true, false, true, "Trạng thái", "System", "status" },
                    { 40606, "1:1", "NVARCHAR(MAX)", null, "", null, 6, false, true, false, false, "Ghi chú", "System", "notes" },
                    { 40701, "1:1", "VARCHAR(50)", null, "", null, 7, false, true, false, true, "Mã quy tắc", "System", "rule_code" },
                    { 40702, "1:1", "NVARCHAR(MAX)", null, "", null, 7, false, true, false, true, "Mô tả", "System", "description" },
                    { 40703, "1:1", "VARCHAR(50)", null, "", null, 7, false, true, false, true, "Mức độ", "System", "severity" },
                    { 40704, "1:1", "VARCHAR(50)", null, "", null, 7, false, true, false, true, "Hành động", "System", "action" },
                    { 40705, "1:1", "NVARCHAR(MAX)", null, "", null, 7, false, true, false, true, "Điều kiện (JSON)", "System", "trigger_condition" },
                    { 40706, "1:1", "INT", null, "", null, 7, false, true, false, false, "Tuổi áp dụng (Min)", "System", "applicable_age_min" },
                    { 40707, "1:1", "INT", null, "", null, 7, false, true, false, false, "Tuổi áp dụng (Max)", "System", "applicable_age_max" },
                    { 40708, "1:1", "VARCHAR(20)", null, "", null, 7, false, true, false, false, "Giới tính", "System", "applicable_gender" },
                    { 40801, "1:1", "INT", null, "", "Patient(Id)", 8, false, true, false, true, "Bệnh nhân ID", "System", "patient_id" },
                    { 40802, "1:1", "INT", null, "", null, 8, false, true, false, false, "Đơn thuốc ID", "System", "prescription_id" },
                    { 40803, "1:1", "INT", null, "", "bnt4_quytaccanhbao(Id)", 8, false, true, false, true, "Quy tắc ID", "System", "rule_id" },
                    { 40804, "1:1", "VARCHAR(20)", null, "", null, 8, false, true, false, true, "Mã Thuốc", "System", "drug_id" },
                    { 40805, "1:1", "VARCHAR(50)", null, "", null, 8, false, true, false, true, "Quyết định của BS", "System", "action_taken" },
                    { 50101, "1:1", "VARCHAR(50)", null, "", null, 101, false, true, false, true, "Mã Hệ", "System", "code" },
                    { 50102, "1:1", "NVARCHAR(200)", null, "", null, 101, false, true, false, true, "Tên Tiếng Việt", "System", "name_vi" },
                    { 50103, "1:1", "NVARCHAR(200)", null, "", null, 101, false, true, false, false, "Tên Tiếng Anh", "System", "name_en" },
                    { 50104, "1:1", "NVARCHAR(MAX)", null, "", null, 101, false, true, false, false, "Mô tả", "System", "description" },
                    { 50105, "1:1", "INT", null, "", null, 101, false, true, false, false, "Sắp xếp", "System", "sort_order" },
                    { 50106, "1:1", "VARCHAR(10)", "1.0", "", null, 101, false, true, false, true, "Phiên bản", "System", "version" },
                    { 50107, "1:1", "VARCHAR(50)", "ACTIVE", "", null, 101, false, true, false, true, "Trạng thái", "System", "status" },
                    { 50201, "1:1", "INT", null, "", "bnt5_hecoquan(Id)", 102, false, true, false, true, "Hệ Cơ Quan ID", "System", "system_id" },
                    { 50202, "1:1", "VARCHAR(50)", null, "", null, 102, false, true, false, true, "Mã Cấu Trúc", "System", "code" },
                    { 50203, "1:1", "NVARCHAR(200)", null, "", null, 102, false, true, false, true, "Tên Tiếng Việt", "System", "name_vi" },
                    { 50204, "1:1", "NVARCHAR(200)", null, "", null, 102, false, true, false, false, "Tên Tiếng Anh", "System", "name_en" },
                    { 50205, "1:1", "INT", null, "", "bnt5_cautruc(Id)", 102, false, true, false, false, "Cấu trúc cha ID", "System", "parent_id" },
                    { 50206, "1:1", "NVARCHAR(MAX)", null, "", null, 102, false, true, false, false, "Mô tả", "System", "description" },
                    { 50207, "1:1", "INT", null, "", null, 102, false, true, false, false, "Cấp độ phân cấp", "System", "level" },
                    { 50301, "1:1", "INT", null, "", "bnt5_cautruc(Id)", 103, false, true, false, true, "Cấu trúc ID", "System", "structure_id" },
                    { 50302, "1:1", "VARCHAR(50)", null, "", null, 103, false, true, false, true, "Mã Chất/Tín Hiệu", "System", "code" },
                    { 50303, "1:1", "NVARCHAR(200)", null, "", null, 103, false, true, false, true, "Tên TV", "System", "name_vi" },
                    { 50304, "1:1", "VARCHAR(50)", null, "", null, 103, false, true, false, false, "Đơn vị", "System", "unit" },
                    { 50305, "1:1", "NVARCHAR(100)", null, "", null, 103, false, true, false, false, "Giới hạn bt", "System", "normal_range" },
                    { 50306, "1:1", "VARCHAR(50)", null, "", null, 103, false, true, false, true, "Loại Tín Hiệu", "System", "type" },
                    { 50401, "1:1", "VARCHAR(50)", null, "", null, 104, false, true, false, true, "Mã Xét Nghiệm", "System", "code" },
                    { 50402, "1:1", "NVARCHAR(200)", null, "", null, 104, false, true, false, true, "Tên Xét Nghiệm", "System", "name_vi" },
                    { 50403, "1:1", "NVARCHAR(200)", null, "", null, 104, false, true, false, false, "Tên Tiếng Anh", "System", "name_en" },
                    { 50404, "1:1", "VARCHAR(50)", null, "", null, 104, false, true, false, true, "Phương pháp đo", "System", "method" },
                    { 50405, "1:1", "VARCHAR(50)", null, "", null, 104, false, true, false, true, "Loại mẫu", "System", "sample_type" },
                    { 50406, "1:1", "DECIMAL(18,2)", null, "", null, 104, false, true, false, false, "Giá thành (Cost)", "System", "cost" },
                    { 50501, "1:1", "INT", null, "", "bnt5_dmxnghiem(Id)", 105, false, true, false, true, "Xét nghiệm ID", "System", "test_id" },
                    { 50502, "1:1", "INT", null, "", null, 105, false, true, false, false, "Độ tuổi Min", "System", "age_min" },
                    { 50503, "1:1", "INT", null, "", null, 105, false, true, false, false, "Độ tuổi Max", "System", "age_max" },
                    { 50504, "1:1", "VARCHAR(20)", null, "", null, 105, false, true, false, true, "Giới tính", "System", "gender" },
                    { 50505, "1:1", "DECIMAL(18,4)", null, "", null, 105, false, true, false, false, "Cận dưới", "System", "low" },
                    { 50506, "1:1", "DECIMAL(18,4)", null, "", null, 105, false, true, false, false, "Cận trên", "System", "high" },
                    { 50507, "1:1", "DECIMAL(18,4)", null, "", null, 105, false, true, false, false, "Nguy hiểm (Low)", "System", "critical_low" },
                    { 50508, "1:1", "DECIMAL(18,4)", null, "", null, 105, false, true, false, false, "Nguy hiểm (High)", "System", "critical_high" },
                    { 50601, "1:1", "INT", null, "", "Patient(Id)", 106, false, true, false, true, "Bệnh nhân ID", "System", "patient_id" },
                    { 50602, "1:1", "INT", null, "", "bnt5_dmxnghiem(Id)", 106, false, true, false, true, "Xét nghiệm ID", "System", "test_id" },
                    { 50603, "1:1", "DATETIME", null, "", null, 106, false, true, false, true, "Ngày yêu cầu", "System", "order_date" },
                    { 50604, "1:1", "VARCHAR(20)", null, "", null, 106, false, true, false, true, "Độ ưu tiên", "System", "priority" },
                    { 50605, "1:1", "VARCHAR(20)", "PENDING", "", null, 106, false, true, false, true, "Trạng thái", "System", "status" },
                    { 50701, "1:1", "INT", null, "", "bnt5_ychidinh(Id)", 107, false, true, false, true, "Phiếu Chỉ Định ID", "System", "order_id" },
                    { 50702, "1:1", "DECIMAL(18,4)", null, "", null, 107, false, true, false, true, "Giá trị đo được", "System", "result_value" },
                    { 50703, "1:1", "VARCHAR(50)", null, "", null, 107, false, true, false, false, "Đơn vị thực tế", "System", "unit" },
                    { 50704, "1:1", "DATETIME", null, "", null, 107, false, true, false, true, "Ngày có kết quả", "System", "result_date" },
                    { 50705, "1:1", "VARCHAR(20)", null, "", null, 107, false, true, false, false, "Đánh giá flag", "System", "flags" },
                    { 50801, "1:1", "INT", null, "", "bnt5_ketqua(Id)", 108, false, true, false, true, "Kết quả ID", "System", "result_id" },
                    { 50802, "1:1", "DECIMAL(5,2)", null, "", null, 108, false, true, false, false, "Độ pH", "System", "ph" },
                    { 50803, "1:1", "DECIMAL(18,4)", null, "", null, 108, false, true, false, false, "Ion Balance", "System", "ion_balance" },
                    { 50901, "1:1", "INT", null, "", "bnt5_ketqua(Id)", 109, false, true, false, true, "Kết quả ID", "System", "result_id" },
                    { 50902, "1:1", "VARCHAR(20)", null, "", null, 109, false, true, false, false, "Huyết áp", "System", "blood_pressure" },
                    { 50903, "1:1", "INT", null, "", null, 109, false, true, false, false, "Nhịp tim", "System", "heart_rate" },
                    { 50904, "1:1", "DECIMAL(5,2)", null, "", null, 109, false, true, false, false, "SpO2", "System", "oxygen_sat" },
                    { 51001, "1:1", "INT", null, "", "bnt5_ketqua(Id)", 110, false, true, false, true, "Kết quả ID", "System", "result_id" },
                    { 51002, "1:1", "INT", null, "", null, 110, false, true, false, false, "Số lượng TB", "System", "cell_count" },
                    { 51101, "1:1", "INT", null, "", "bnt5_ketqua(Id)", 111, false, true, false, true, "Kết quả ID", "System", "result_id" },
                    { 51102, "1:1", "VARCHAR(200)", null, "", null, 111, false, true, false, false, "Đường dẫn File", "System", "image_file" },
                    { 51103, "1:1", "VARCHAR(50)", null, "", null, 111, false, true, false, false, "Vị trí", "System", "modality" },
                    { 51201, "1:1", "INT", null, "", "bnt5_ketqua(Id)", 112, false, true, false, true, "Kết quả ID", "System", "result_id" },
                    { 51202, "1:1", "DECIMAL(18,4)", null, "", null, 112, false, true, false, false, "Tần số điện", "System", "frequency" },
                    { 51203, "1:1", "JSON", null, "", null, 112, false, true, false, false, "Waveform File", "System", "waveform" },
                    { 51301, "1:1", "INT", null, "", "bnt5_dmxnghiem(Id)", 113, false, true, false, true, "Xét nghiệm Gốc (From)", "System", "test_from_id" },
                    { 51302, "1:1", "INT", null, "", "bnt5_dmxnghiem(Id)", 113, false, true, false, true, "Xét nghiệm Đích (To)", "System", "test_to_id" },
                    { 51303, "1:1", "VARCHAR(50)", null, "", null, 113, false, true, false, true, "Loại Liên Kết", "System", "relation_type" },
                    { 51304, "1:1", "DECIMAL(5,2)", null, "", null, 113, false, true, false, false, "Độ tin cậy", "System", "strength" },
                    { 51401, "1:1", "VARCHAR(50)", null, "", null, 114, false, true, false, true, "Mã quy tắc", "System", "rule_code" },
                    { 51402, "1:1", "NVARCHAR(MAX)", null, "", null, 114, false, true, false, true, "Biểu thức điều kiện", "System", "condition" },
                    { 51403, "1:1", "NVARCHAR(MAX)", null, "", null, 114, false, true, false, true, "Cảnh báo Message", "System", "message" },
                    { 51404, "1:1", "NVARCHAR(MAX)", null, "", null, 114, false, true, false, false, "Nhóm XN khuyên giải (JSON)", "System", "suggested_tests" }
                });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 113,
                column: "Description",
                value: "Mối liên hệ tương quan giữa các xét nghiệm với nhau");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40101);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40102);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40103);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40104);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40105);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40106);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40107);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40108);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40109);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40110);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40201);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40202);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40203);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40204);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40205);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40206);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40207);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40208);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40209);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40210);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40211);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40301);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40302);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40303);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40304);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40305);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40306);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40401);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40402);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40403);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40404);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40405);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40406);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40501);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40502);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40503);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40504);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40505);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40506);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40507);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40601);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40602);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40603);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40604);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40605);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40606);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40701);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40702);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40703);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40704);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40705);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40706);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40707);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40708);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40801);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40802);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40803);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40804);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40805);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50101);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50102);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50103);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50104);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50105);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50106);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50107);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50201);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50202);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50203);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50204);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50205);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50206);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50207);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50301);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50302);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50303);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50304);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50305);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50306);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50401);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50402);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50403);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50404);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50405);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50406);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50501);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50502);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50503);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50504);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50505);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50506);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50507);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50508);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50601);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50602);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50603);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50604);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50605);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50701);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50702);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50703);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50704);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50705);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50801);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50802);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50803);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50901);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50902);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50903);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50904);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51001);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51002);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51101);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51102);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51103);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51201);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51202);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51203);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51301);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51302);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51303);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51304);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51401);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51402);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51403);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51404);

            migrationBuilder.DropColumn(
                name: "FkTarget",
                table: "Attributes");

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Cardinality", "DataType", "DefaultValue", "Description", "GroupId", "HasPermission", "IsCore", "IsHidden", "IsRequired", "Name", "Scope", "SqlColumnName" },
                values: new object[,]
                {
                    { 1, "1:1", "VARCHAR(50)", null, "", 1, false, true, false, true, "Mã Nhóm", "System", "ma_nhom" },
                    { 2, "1:1", "NVARCHAR(200)", null, "", 1, false, true, false, true, "Tên Tiếng Việt", "System", "ten_tieng_viet" },
                    { 3, "1:1", "VARCHAR(50)", null, "", 2, false, true, false, true, "Mã Hoạt Chất", "System", "ma_hoat_chat" },
                    { 4, "1:1", "INT", null, "FK references bnt4_nhomduocly(Id)", 2, false, true, false, true, "Nhóm Dược Lý ID", "System", "nhom_duoc_ly_id" },
                    { 5, "1:1", "INT", null, "FK references bnt4_hoatchat(Id)", 5, false, true, false, true, "Chất Dị Ứng ID", "System", "chat_di_ung_id" },
                    { 6, "1:1", "INT", null, "", 5, false, true, false, true, "Mức độ", "System", "muc_do" },
                    { 7, "1:1", "VARCHAR(20)", null, "", 6, false, true, false, true, "Mã ICD", "System", "ma_icd" },
                    { 8, "1:1", "DATE", null, "", 6, false, true, false, false, "Ngày Chẩn Đoán", "System", "ngay_chan_doan" },
                    { 101, "1:1", "VARCHAR(50)", null, "", 101, false, true, false, true, "Mã Hệ Cơ Quan", "System", "ma_he_co_quan" },
                    { 102, "1:1", "NVARCHAR(200)", null, "", 101, false, true, false, true, "Tên Hệ", "System", "ten_he" },
                    { 103, "1:1", "VARCHAR(50)", null, "", 102, false, true, false, true, "Mã Cấu Trúc", "System", "ma_cau_truc" },
                    { 104, "1:1", "INT", null, "FK references bnt5_hecoquan(Id)", 102, false, true, false, true, "Hệ Cơ Quan ID", "System", "he_co_quan_id" },
                    { 105, "1:1", "VARCHAR(50)", null, "", 104, false, true, false, true, "Mã Xét Nghiệm", "System", "ma_xet_nghiem" },
                    { 106, "1:1", "INT", null, "FK references bnt5_cautruc(Id)", 104, false, true, false, false, "Cấu Trúc ID", "System", "cau_truc_id" },
                    { 107, "1:1", "DECIMAL(18,4)", null, "", 107, false, true, false, true, "Giá Trị", "System", "gia_tri" },
                    { 108, "1:1", "INT", null, "FK references bnt5_dmxnghiem(Id)", 107, false, true, false, true, "Xét Nghiệm ID", "System", "xet_nghiem_id" }
                });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 113,
                column: "Description",
                value: "Mối liên hệ giữa các xét nghiệm");
        }
    }
}
