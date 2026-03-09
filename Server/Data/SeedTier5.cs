using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public static class SeedTier5
{
    public static void Seed(ModelBuilder builder)
    {
        // Nhóm Tầng 5
        builder.Entity<Group>().HasData(
            new Group { Id = 101, TierId = 5, Name = "Hệ Cơ Quan", SqlTableName = "bnt5_hecoquan", TableNameFull = "hecoquan", Cardinality = "1:N", Description = "Hệ cơ quan sinh học", IsCore = true },
            new Group { Id = 102, TierId = 5, Name = "Cấu Trúc Sinh Học", SqlTableName = "bnt5_cautruc", TableNameFull = "cautrucsinhhoc", Cardinality = "1:N", Description = "Cấu trúc chi tiết cơ quan", IsCore = true },
            new Group { Id = 103, TierId = 5, Name = "Chất / Tín Hiệu", SqlTableName = "bnt5_chatinhieu", TableNameFull = "chattin hieu", Cardinality = "1:N", Description = "Chất hoá học hoặc tín hiệu đo lường", IsCore = true },
            new Group { Id = 104, TierId = 5, Name = "DM Xét Nghiệm", SqlTableName = "bnt5_dmxnghiem", TableNameFull = "danhmucxetnghiem", Cardinality = "1:N", Description = "Danh mục xét nghiệm đo lường", IsCore = true },
            new Group { Id = 105, TierId = 5, Name = "Khoảng Tham Chiếu", SqlTableName = "bnt5_ktchieucu", TableNameFull = "khoangthamchieu", Cardinality = "1:N", Description = "Reference ranges cho XN", IsCore = true },
            new Group { Id = 106, TierId = 5, Name = "Chỉ Định Đo Lường", SqlTableName = "bnt5_ychidinh", TableNameFull = "ychidinhdoluong", Cardinality = "1:N", Description = "Y lệnh chỉ định XN", IsCore = true },
            new Group { Id = 107, TierId = 5, Name = "Kết Quả Đo Lường", SqlTableName = "bnt5_ketqua", TableNameFull = "ketquadoluong", Cardinality = "1:N", Description = "Kết quả đo lường sinh học", IsCore = true },
            new Group { Id = 108, TierId = 5, Name = "Context Sinh Hoá", SqlTableName = "bnt5_csinhhoa", TableNameFull = "contextsinhhoa", Cardinality = "1:1", Description = "Bối cảnh đo sinh hoá", IsCore = true },
            new Group { Id = 109, TierId = 5, Name = "Context Sinh Hiệu", SqlTableName = "bnt5_cshieusinh", TableNameFull = "contextsinhieu", Cardinality = "1:1", Description = "Bối cảnh định kỳ của sinh hiệu", IsCore = true },
            new Group { Id = 110, TierId = 5, Name = "Context Tế Bào", SqlTableName = "bnt5_ctebao", TableNameFull = "contexttebao", Cardinality = "1:1", Description = "Bối cảnh tế bào", IsCore = true },
            new Group { Id = 111, TierId = 5, Name = "Context Hình Ảnh", SqlTableName = "bnt5_chinhanh", TableNameFull = "contextchinhanh", Cardinality = "1:1", Description = "Bối cảnh hình ảnh", IsCore = true },
            new Group { Id = 112, TierId = 5, Name = "Context Điện Sinh Lý", SqlTableName = "bnt5_diensinhly", TableNameFull = "contextdiensinhly", Cardinality = "1:1", Description = "Bối cảnh điện sinh lý", IsCore = true },
            new Group { Id = 113, TierId = 5, Name = "Liên Kết Xét Nghiệm", SqlTableName = "bnt5_xnlienquan", TableNameFull = "xetnghiemlienquan", Cardinality = "1:N", Description = "Mối liên hệ tương quan giữa các xét nghiệm", IsCore = true },
            new Group { Id = 114, TierId = 5, Name = "Quy Tắc Cảnh Báo XN", SqlTableName = "bnt5_qtcbxn", TableNameFull = "quytaccanhbaoxn", Cardinality = "1:N", Description = "Quy tắc cảnh báo XN sinh học", IsCore = true }
        );

        // Attributes Tầng 5
        builder.Entity<SchemaAttribute>().HasData(
            // T5_G101 Hệ Cơ Quan
            new SchemaAttribute { Id = 50101, GroupId = 101, Name = "Mã Hệ", SqlColumnName = "code", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50102, GroupId = 101, Name = "Tên Tiếng Việt", SqlColumnName = "name_vi", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50103, GroupId = 101, Name = "Tên Tiếng Anh", SqlColumnName = "name_en", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50104, GroupId = 101, Name = "Mô tả", SqlColumnName = "description", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50105, GroupId = 101, Name = "Sắp xếp", SqlColumnName = "sort_order", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50106, GroupId = 101, Name = "Phiên bản", SqlColumnName = "version", DataType = "VARCHAR(10)", IsRequired = true, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 50107, GroupId = 101, Name = "Trạng thái", SqlColumnName = "status", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true, DefaultValue = "'ACTIVE'" },

            // T5_G102 Cấu Trúc Sinh Học
            new SchemaAttribute { Id = 50201, GroupId = 102, Name = "Hệ Cơ Quan", SqlColumnName = "system_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_hecoquan(Id)" },
            new SchemaAttribute { Id = 50202, GroupId = 102, Name = "Mã Cấu Trúc", SqlColumnName = "code", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50203, GroupId = 102, Name = "Tên Tiếng Việt", SqlColumnName = "name_vi", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50204, GroupId = 102, Name = "Tên Tiếng Anh", SqlColumnName = "name_en", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50205, GroupId = 102, Name = "Cấu trúc cha", SqlColumnName = "parent_id", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "bnt5_cautruc(Id)" },
            new SchemaAttribute { Id = 50206, GroupId = 102, Name = "Mô tả", SqlColumnName = "description", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50207, GroupId = 102, Name = "Cấp độ", SqlColumnName = "level", DataType = "INT", IsRequired = false, IsCore = true },

            // T5_G103 Chất / Tín Hiệu
            new SchemaAttribute { Id = 50301, GroupId = 103, Name = "Cấu trúc", SqlColumnName = "structure_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_cautruc(Id)" },
            new SchemaAttribute { Id = 50302, GroupId = 103, Name = "Mã Chất/Tín Hiệu", SqlColumnName = "code", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50303, GroupId = 103, Name = "Tên TV", SqlColumnName = "name_vi", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50304, GroupId = 103, Name = "Tên TA", SqlColumnName = "name_en", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50305, GroupId = 103, Name = "Đơn vị", SqlColumnName = "unit", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50306, GroupId = 103, Name = "Khoảng bt", SqlColumnName = "normal_range", DataType = "NVARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50307, GroupId = 103, Name = "Loại", SqlColumnName = "type", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }, // CHEMICAL, ELECTRICAL...

            // T5_G104 Danh Mục Xét Nghiệm
            new SchemaAttribute { Id = 50401, GroupId = 104, Name = "Mã Xét Nghiệm", SqlColumnName = "code", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50402, GroupId = 104, Name = "Tên TV", SqlColumnName = "name_vi", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50403, GroupId = 104, Name = "Tên TA", SqlColumnName = "name_en", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50404, GroupId = 104, Name = "Phương pháp", SqlColumnName = "method", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }, // LAB, IMAGING...
            new SchemaAttribute { Id = 50405, GroupId = 104, Name = "Loại mẫu", SqlColumnName = "sample_type", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50406, GroupId = 104, Name = "Thời gian trả kq", SqlColumnName = "turnaround_time", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50407, GroupId = 104, Name = "Giá thành", SqlColumnName = "cost", DataType = "DECIMAL(18,2)", IsRequired = false, IsCore = true },

            // T5_G105 Khoảng Tham Chiếu
            new SchemaAttribute { Id = 50501, GroupId = 105, Name = "Xét nghiệm", SqlColumnName = "test_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_dmxnghiem(Id)" },
            new SchemaAttribute { Id = 50502, GroupId = 105, Name = "Tuổi Min", SqlColumnName = "age_min", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50503, GroupId = 105, Name = "Tuổi Max", SqlColumnName = "age_max", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50504, GroupId = 105, Name = "Giới tính", SqlColumnName = "gender", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50505, GroupId = 105, Name = "Thấp", SqlColumnName = "low", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50506, GroupId = 105, Name = "Cao", SqlColumnName = "high", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50507, GroupId = 105, Name = "Nguy kịch Thấp", SqlColumnName = "critical_low", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50508, GroupId = 105, Name = "Nguy kịch Cao", SqlColumnName = "critical_high", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },

            // T5_G106 Chỉ Định Đo Lường
            new SchemaAttribute { Id = 50601, GroupId = 106, Name = "Mã Bệnh Nhân", SqlColumnName = "patient_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 50602, GroupId = 106, Name = "Xét nghiệm", SqlColumnName = "test_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_dmxnghiem(Id)" },
            new SchemaAttribute { Id = 50603, GroupId = 106, Name = "Ngày chỉ định", SqlColumnName = "order_date", DataType = "DATETIME", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50604, GroupId = 106, Name = "Chỉ định bởi", SqlColumnName = "ordered_by", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "User(Id)" },
            new SchemaAttribute { Id = 50605, GroupId = 106, Name = "Độ ưu tiên", SqlColumnName = "priority", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true }, 
            new SchemaAttribute { Id = 50606, GroupId = 106, Name = "Trạng thái", SqlColumnName = "status", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true, DefaultValue = "'PENDING'" },

            // T5_G107 Kết Quả Đo Lường
            new SchemaAttribute { Id = 50701, GroupId = 107, Name = "Mã Chỉ Định", SqlColumnName = "order_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ychidinh(Id)" },
            new SchemaAttribute { Id = 50702, GroupId = 107, Name = "Giá trị", SqlColumnName = "result_value", DataType = "DECIMAL(18,4)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50703, GroupId = 107, Name = "Đơn vị", SqlColumnName = "unit", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50704, GroupId = 107, Name = "Ngày có kết quả", SqlColumnName = "result_date", DataType = "DATETIME", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50705, GroupId = 107, Name = "Flag báo động", SqlColumnName = "flags", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true }, 

            // T5_G108 -> T5_G112 CONTEXT CHUYÊN SÂU
            new SchemaAttribute { Id = 50801, GroupId = 108, Name = "Mã Kết Quả", SqlColumnName = "result_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 50802, GroupId = 108, Name = "Độ pH", SqlColumnName = "ph", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50803, GroupId = 108, Name = "Ion Balance", SqlColumnName = "ion_balance", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50804, GroupId = 108, Name = "Nồng độ Enzyme", SqlColumnName = "enzyme_level", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },

            new SchemaAttribute { Id = 50901, GroupId = 109, Name = "Mã Kết Quả", SqlColumnName = "result_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 50902, GroupId = 109, Name = "Huyết áp", SqlColumnName = "blood_pressure", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50903, GroupId = 109, Name = "Nhịp tim", SqlColumnName = "heart_rate", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50904, GroupId = 109, Name = "Nhiệt độ", SqlColumnName = "temperature", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50905, GroupId = 109, Name = "Nhịp thở", SqlColumnName = "respiratory_rate", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50906, GroupId = 109, Name = "SPO2", SqlColumnName = "oxygen_sat", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },

            new SchemaAttribute { Id = 51001, GroupId = 110, Name = "Mã Kết Quả", SqlColumnName = "result_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 51002, GroupId = 110, Name = "Số lượng TB", SqlColumnName = "cell_count", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51003, GroupId = 110, Name = "Hình thái", SqlColumnName = "morphology", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51004, GroupId = 110, Name = "Markers (JSON)", SqlColumnName = "marker_positive", DataType = "JSON", IsRequired = false, IsCore = true },

            new SchemaAttribute { Id = 51101, GroupId = 111, Name = "Mã Kết Quả", SqlColumnName = "result_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 51102, GroupId = 111, Name = "Loại hình", SqlColumnName = "modality", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true }, // XRAY, CT, MRI...
            new SchemaAttribute { Id = 51103, GroupId = 111, Name = "Phát hiện", SqlColumnName = "findings", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51104, GroupId = 111, Name = "Đường dẫn File", SqlColumnName = "image_file", DataType = "VARCHAR(200)", IsRequired = false, IsCore = true },

            new SchemaAttribute { Id = 51201, GroupId = 112, Name = "Mã Kết Quả", SqlColumnName = "result_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 51202, GroupId = 112, Name = "Dạng sóng (JSON)", SqlColumnName = "waveform", DataType = "JSON", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51203, GroupId = 112, Name = "Biên độ", SqlColumnName = "amplitude", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51204, GroupId = 112, Name = "Tần số", SqlColumnName = "frequency", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },

            // T5_G113 Liên Kết Xét Nghiệm
            new SchemaAttribute { Id = 51301, GroupId = 113, Name = "XN Gốc (From)", SqlColumnName = "test_from_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_dmxnghiem(Id)" },
            new SchemaAttribute { Id = 51302, GroupId = 113, Name = "XN Đích (To)", SqlColumnName = "test_to_id", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_dmxnghiem(Id)" },
            new SchemaAttribute { Id = 51303, GroupId = 113, Name = "Mối liên hệ", SqlColumnName = "relation_type", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }, // COMPLEMENTARY...
            new SchemaAttribute { Id = 51304, GroupId = 113, Name = "Độ mạnh tương quan", SqlColumnName = "strength", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            
            // T5_G114 Quy tắc cảnh báo XN
            new SchemaAttribute { Id = 51401, GroupId = 114, Name = "Mã quy tắc", SqlColumnName = "rule_code", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51402, GroupId = 114, Name = "Điều kiện", SqlColumnName = "condition", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51403, GroupId = 114, Name = "Thông điệp", SqlColumnName = "message", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51404, GroupId = 114, Name = "XN Gợi ý (JSON)", SqlColumnName = "suggested_tests", DataType = "JSON", IsRequired = false, IsCore = true }
        );
    }
}
