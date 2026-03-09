using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public static class SeedTier4
{
    public static void Seed(ModelBuilder builder)
    {
        // Nhóm Tầng 4
        builder.Entity<Group>().HasData(
            new Group { Id = 1, TierId = 4, Name = "Nhóm Dược Lý", SqlTableName = "bnt4_nhduly", TableNameFull = "nhomduocly", Cardinality = "1:N", Description = "Danh mục nhóm dược lý", IsCore = true },
            new Group { Id = 2, TierId = 4, Name = "Hoạt Chất", SqlTableName = "bnt4_hoatch", TableNameFull = "hoatchat", Cardinality = "1:N", Description = "Danh mục hoạt chất", IsCore = true },
            new Group { Id = 3, TierId = 4, Name = "Dị Ứng Chéo", SqlTableName = "bnt4_ducheo", TableNameFull = "diungcheo", Cardinality = "1:N", Description = "Quy tắc dị ứng chéo", IsCore = true },
            new Group { Id = 4, TierId = 4, Name = "Tương Tác Thuốc", SqlTableName = "bnt4_tuatac", TableNameFull = "tuongtacthuoc", Cardinality = "1:N", Description = "Tương tác giữa các hoạt chất", IsCore = true },
            new Group { Id = 5, TierId = 4, Name = "Dị Ứng Bệnh Nhân", SqlTableName = "bnt4_diungb", TableNameFull = "diungbenhnhan", Cardinality = "1:N", Description = "Hồ sơ dị ứng của bệnh nhân", IsCore = true },
            new Group { Id = 6, TierId = 4, Name = "Bệnh Nền", SqlTableName = "bnt4_bnenan", TableNameFull = "benhnenman", Cardinality = "1:N", Description = "Bệnh lý nền bất biến", IsCore = true },
            new Group { Id = 7, TierId = 4, Name = "Quy Tắc Cảnh Báo", SqlTableName = "bnt4_qtcanh", TableNameFull = "quytaccanhbao", Cardinality = "1:N", Description = "Bộ quy tắc cảnh báo lâm sàng", IsCore = true },
            new Group { Id = 8, TierId = 4, Name = "Nhật Ký Cảnh Báo", SqlTableName = "bnt4_nkcbao", TableNameFull = "nhatkycanhbao", Cardinality = "1:N", Description = "Lịch sử cảnh báo đã phát cho bệnh nhân", IsCore = true }
        );

        // Attributes Tầng 4
        builder.Entity<SchemaAttribute>().HasData(
            // T4_G1 Nhóm Dược Lý
            new SchemaAttribute { Id = 40101, GroupId = 1, Name = "Mã Nhóm", SqlColumnName = "code", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40102, GroupId = 1, Name = "Tên Tiếng Việt", SqlColumnName = "name_vi", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40103, GroupId = 1, Name = "Tên Tiếng Anh", SqlColumnName = "name_en", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40104, GroupId = 1, Name = "Nhóm Cha", SqlColumnName = "parent_id", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "bnt4_nhduly(Id)" },
            new SchemaAttribute { Id = 40105, GroupId = 1, Name = "Mục Tiêu Sinh Học", SqlColumnName = "bio_target", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40106, GroupId = 1, Name = "Cơ chế TV", SqlColumnName = "mechanism_vi", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40107, GroupId = 1, Name = "Cơ chế TA", SqlColumnName = "mechanism_en", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40108, GroupId = 1, Name = "Cấu trúc hóa học", SqlColumnName = "chemical_structure", DataType = "VARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40109, GroupId = 1, Name = "Phiên bản", SqlColumnName = "version", DataType = "VARCHAR(10)", IsRequired = true, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 40110, GroupId = 1, Name = "Trạng thái", SqlColumnName = "status", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true, DefaultValue = "'ACTIVE'" },

            // T4_G2 Hoạt Chất
            new SchemaAttribute { Id = 40201, GroupId = 2, Name = "Mã Hoạt Chất", SqlColumnName = "code", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40202, GroupId = 2, Name = "Tên Tiếng Việt", SqlColumnName = "name_vi", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40203, GroupId = 2, Name = "Tên Tiếng Anh", SqlColumnName = "name_en", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40204, GroupId = 2, Name = "Nhóm Dược Lý", SqlColumnName = "group_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_nhduly(Id)" },
            new SchemaAttribute { Id = 40205, GroupId = 2, Name = "Mã ATC", SqlColumnName = "atc_code", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40206, GroupId = 2, Name = "Công thức phân tử", SqlColumnName = "molecular_formula", DataType = "VARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40207, GroupId = 2, Name = "Khối lượng P.Tử", SqlColumnName = "molecular_weight", DataType = "DECIMAL(10,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40208, GroupId = 2, Name = "Thời gian bán thải", SqlColumnName = "half_life", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40209, GroupId = 2, Name = "Sinh khả dụng", SqlColumnName = "bioavailability", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40210, GroupId = 2, Name = "Phiên bản", SqlColumnName = "version", DataType = "VARCHAR(10)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40211, GroupId = 2, Name = "Trạng thái", SqlColumnName = "status", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },

            // T4_G3 Dị Ứng Chéo
            new SchemaAttribute { Id = 40301, GroupId = 3, Name = "Chất nguồn (From)", SqlColumnName = "substance_from_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40302, GroupId = 3, Name = "Chất nhận (To)", SqlColumnName = "substance_to_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40303, GroupId = 3, Name = "Mức độ", SqlColumnName = "severity", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40304, GroupId = 3, Name = "Mô tả", SqlColumnName = "description", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40305, GroupId = 3, Name = "Mức độ bằng chứng", SqlColumnName = "evidence_level", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40306, GroupId = 3, Name = "Ngày tạo", SqlColumnName = "created_at", DataType = "DATETIME", IsRequired = true, IsCore = true, DefaultValue = "GETDATE()" },

            // T4_G4 Tương Tác Thuốc
            new SchemaAttribute { Id = 40401, GroupId = 4, Name = "Thuốc 1", SqlColumnName = "drug1_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40402, GroupId = 4, Name = "Thuốc 2", SqlColumnName = "drug2_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40403, GroupId = 4, Name = "Tác dụng", SqlColumnName = "effect", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40404, GroupId = 4, Name = "Mức độ", SqlColumnName = "severity", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40405, GroupId = 4, Name = "Xử trí", SqlColumnName = "management", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40406, GroupId = 4, Name = "Bằng chứng", SqlColumnName = "evidence", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // T4_G5 Dị Ứng Bệnh Nhân
            new SchemaAttribute { Id = 40501, GroupId = 5, Name = "Mã Bệnh Nhân", SqlColumnName = "patient_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40502, GroupId = 5, Name = "Hoạt Chất", SqlColumnName = "substance_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40503, GroupId = 5, Name = "Mức độ", SqlColumnName = "severity", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40504, GroupId = 5, Name = "Loại phản ứng", SqlColumnName = "reaction_type", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40505, GroupId = 5, Name = "Ngày khởi phát", SqlColumnName = "onset_date", DataType = "DATE", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40506, GroupId = 5, Name = "Đã khỏi", SqlColumnName = "resolved", DataType = "BIT", IsRequired = true, IsCore = true, DefaultValue = "0" },
            new SchemaAttribute { Id = 40507, GroupId = 5, Name = "Ghi chú", SqlColumnName = "notes", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40508, GroupId = 5, Name = "Xác nhận bởi", SqlColumnName = "verified_by", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "User(Id)" },

            // T4_G6 Bệnh Nền
            new SchemaAttribute { Id = 40601, GroupId = 6, Name = "Mã Bệnh Nhân", SqlColumnName = "patient_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40602, GroupId = 6, Name = "Mã ICD", SqlColumnName = "condition_code", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40603, GroupId = 6, Name = "Ngày chẩn đoán", SqlColumnName = "diagnosed_at", DataType = "DATE", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40604, GroupId = 6, Name = "Chẩn đoán bởi", SqlColumnName = "diagnosed_by", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "User(Id)" },
            new SchemaAttribute { Id = 40605, GroupId = 6, Name = "Mức độ", SqlColumnName = "severity_level", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40606, GroupId = 6, Name = "Trạng thái", SqlColumnName = "status", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40607, GroupId = 6, Name = "Ghi chú", SqlColumnName = "notes", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // T4_G7 Quy Tắc Cảnh Báo
            new SchemaAttribute { Id = 40701, GroupId = 7, Name = "Mã quy tắc", SqlColumnName = "rule_code", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40702, GroupId = 7, Name = "Mô tả", SqlColumnName = "description", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40703, GroupId = 7, Name = "Mức độ", SqlColumnName = "severity", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40704, GroupId = 7, Name = "Hành động", SqlColumnName = "action", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }, 
            new SchemaAttribute { Id = 40705, GroupId = 7, Name = "Điều kiện (JSON)", SqlColumnName = "trigger_condition", DataType = "JSON", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40706, GroupId = 7, Name = "Tuổi (Min)", SqlColumnName = "applicable_age_min", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40707, GroupId = 7, Name = "Tuổi (Max)", SqlColumnName = "applicable_age_max", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40708, GroupId = 7, Name = "Giới tính", SqlColumnName = "applicable_gender", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },

            // T4_G8 Nhật Ký Cảnh Báo
            new SchemaAttribute { Id = 40801, GroupId = 8, Name = "Mã Bệnh Nhân", SqlColumnName = "patient_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40802, GroupId = 8, Name = "Đơn thuốc", SqlColumnName = "prescription_id", DataType = "REF", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40803, GroupId = 8, Name = "Quy tắc", SqlColumnName = "rule_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_qtcanh(Id)" },
            new SchemaAttribute { Id = 40804, GroupId = 8, Name = "Mã Thuốc", SqlColumnName = "drug_id", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40805, GroupId = 8, Name = "Mức độ", SqlColumnName = "severity", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40806, GroupId = 8, Name = "Hành động", SqlColumnName = "action_taken", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40807, GroupId = 8, Name = "Xác nhận bởi", SqlColumnName = "confirmed_by", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "User(Id)" },
            new SchemaAttribute { Id = 40808, GroupId = 8, Name = "Audit Time", SqlColumnName = "timestamp", DataType = "DATETIME", IsRequired = true, IsCore = true, DefaultValue = "GETDATE()" }
        );
    }
}
