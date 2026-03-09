using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public static class SeedTier5
{
    public static void Seed(ModelBuilder builder)
    {
        // ── Parent Category Groups (Tầng 5) ──
        builder.Entity<Group>().HasData(
            new Group { Id = 501, TierId = 5, Name = "Danh mục gốc sinh học", SqlTableName = "", TableNameFull = "", Cardinality = "1:N", Description = "Danh mục gốc về sinh học", IsCore = true, ParentGroupId = null },
            new Group { Id = 502, TierId = 5, Name = "Danh mục xét nghiệm & tham chiếu", SqlTableName = "", TableNameFull = "", Cardinality = "1:N", Description = "Danh mục xét nghiệm và khoảng tham chiếu", IsCore = true, ParentGroupId = null },
            new Group { Id = 503, TierId = 5, Name = "Dữ liệu đo lường bệnh nhân", SqlTableName = "", TableNameFull = "", Cardinality = "1:N", Description = "Chỉ định và kết quả đo lường", IsCore = true, ParentGroupId = null },
            new Group { Id = 504, TierId = 5, Name = "Context đặc thù theo loại XN", SqlTableName = "", TableNameFull = "", Cardinality = "1:N", Description = "Bối cảnh chuyên sâu theo loại xét nghiệm", IsCore = true, ParentGroupId = null },
            new Group { Id = 505, TierId = 5, Name = "Liên kết thông minh & Cảnh báo XN", SqlTableName = "", TableNameFull = "", Cardinality = "1:N", Description = "Liên kết tương quan và quy tắc cảnh báo", IsCore = true, ParentGroupId = null }
        );

        // ── Child Groups (Tầng 5) ──
        builder.Entity<Group>().HasData(
            // Danh mục gốc sinh học (parent 501)
            new Group { Id = 101, TierId = 5, ParentGroupId = 501, Name = "BIO_SYSTEM (Hệ cơ quan)", SqlTableName = "bnt5_hecoquan", TableNameFull = "hecoquan", Cardinality = "1:N", Description = "Hệ cơ quan sinh học", IsCore = true },
            new Group { Id = 102, TierId = 5, ParentGroupId = 501, Name = "BIO_STRUCTURE (Cấu trúc sinh học)", SqlTableName = "bnt5_cautruc", TableNameFull = "cautruc", Cardinality = "1:N", Description = "Cấu trúc chi tiết cơ quan", IsCore = true },
            new Group { Id = 103, TierId = 5, ParentGroupId = 501, Name = "BIO_SUBSTANCE (Chất / Tín hiệu)", SqlTableName = "bnt5_chatinhieu", TableNameFull = "chatinhieu", Cardinality = "1:N", Description = "Chất hóa học hoặc tín hiệu đo lường", IsCore = true },

            // Danh mục xét nghiệm & tham chiếu (parent 502)
            new Group { Id = 104, TierId = 5, ParentGroupId = 502, Name = "TEST_CATALOG (Danh mục XN)", SqlTableName = "bnt5_dmxnghiem", TableNameFull = "dmxnghiem", Cardinality = "1:N", Description = "Danh mục xét nghiệm đo lường", IsCore = true },
            new Group { Id = 105, TierId = 5, ParentGroupId = 502, Name = "REF_RANGE (Khoảng tham chiếu)", SqlTableName = "bnt5_ktchieucu", TableNameFull = "ktchieucu", Cardinality = "1:N", Description = "Reference ranges cho XN", IsCore = true },

            // Dữ liệu đo lường bệnh nhân (parent 503)
            new Group { Id = 106, TierId = 5, ParentGroupId = 503, Name = "MEASUREMENT_ORDER (Lệnh chỉ định)", SqlTableName = "bnt5_ychidinh", TableNameFull = "ychidinh", Cardinality = "1:N", Description = "Y lệnh chỉ định XN", IsCore = true },
            new Group { Id = 107, TierId = 5, ParentGroupId = 503, Name = "MEASUREMENT_RESULT (Kết quả đo lường)", SqlTableName = "bnt5_ketqua", TableNameFull = "ketqua", Cardinality = "1:N", Description = "Kết quả đo lường sinh học", IsCore = true },

            // Context đặc thù theo loại XN (parent 504)
            new Group { Id = 108, TierId = 5, ParentGroupId = 504, Name = "CTX_CHEMICAL (Sinh hóa)", SqlTableName = "bnt5_csinhhoa", TableNameFull = "csinhhoa", Cardinality = "1:1", Description = "Bối cảnh đo sinh hóa", IsCore = true },
            new Group { Id = 109, TierId = 5, ParentGroupId = 504, Name = "CTX_VITAL_SIGN (Sinh hiệu)", SqlTableName = "bnt5_cshieusinh", TableNameFull = "cshieusinh", Cardinality = "1:1", Description = "Bối cảnh định kỳ của sinh hiệu", IsCore = true },
            new Group { Id = 110, TierId = 5, ParentGroupId = 504, Name = "CTX_CELL (Tế bào)", SqlTableName = "bnt5_ctebao", TableNameFull = "ctebao", Cardinality = "1:1", Description = "Bối cảnh tế bào", IsCore = true },
            new Group { Id = 111, TierId = 5, ParentGroupId = 504, Name = "CTX_IMAGE (Hình ảnh)", SqlTableName = "bnt5_chinhanh", TableNameFull = "chinhanh", Cardinality = "1:1", Description = "Bối cảnh hình ảnh", IsCore = true },
            new Group { Id = 112, TierId = 5, ParentGroupId = 504, Name = "CTX_ELECTRICAL (Điện sinh lý)", SqlTableName = "bnt5_diensinhly", TableNameFull = "diensinhly", Cardinality = "1:1", Description = "Bối cảnh điện sinh lý", IsCore = true },

            // Liên kết thông minh & Cảnh báo XN (parent 505)
            new Group { Id = 113, TierId = 5, ParentGroupId = 505, Name = "TEST_RELATION (XN liên quan)", SqlTableName = "bnt5_xnlienquan", TableNameFull = "xnlienquan", Cardinality = "1:N", Description = "Mối liên hệ tương quan giữa các xét nghiệm", IsCore = true },
            new Group { Id = 114, TierId = 5, ParentGroupId = 505, Name = "ALERT_RULE (Cảnh báo XN)", SqlTableName = "bnt5_qtcbxn", TableNameFull = "qtcbxn", Cardinality = "1:N", Description = "Quy tắc cảnh báo XN sinh học", IsCore = true }
        );

        // ── Attributes (Tầng 5) ──
        builder.Entity<SchemaAttribute>().HasData(

            // ─── G101: BIO_SYSTEM — Hệ Cơ Quan (hecoquan) — 9 attrs ───
            new SchemaAttribute { Id = 50101, GroupId = 101, Name = "Mã hệ", SqlColumnName = "bnt5_hecoquan_mahe", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50102, GroupId = 101, Name = "Tên tiếng Việt", SqlColumnName = "bnt5_hecoquan_tentiengviet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50103, GroupId = 101, Name = "Tên tiếng Anh", SqlColumnName = "bnt5_hecoquan_tentienganh", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50104, GroupId = 101, Name = "Mô tả", SqlColumnName = "bnt5_hecoquan_mota", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50105, GroupId = 101, Name = "Thứ tự sắp xếp", SqlColumnName = "bnt5_hecoquan_thutusapxep", DataType = "INT", IsRequired = false, IsCore = true, DefaultValue = "0" },
            new SchemaAttribute { Id = 50106, GroupId = 101, Name = "Phiên bản", SqlColumnName = "bnt5_hecoquan_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 50107, GroupId = 101, Name = "Trạng thái", SqlColumnName = "bnt5_hecoquan_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },
            new SchemaAttribute { Id = 50108, GroupId = 101, Name = "Ngày tạo", SqlColumnName = "bnt5_hecoquan_ngaytao", DataType = "DATETIME", IsRequired = false, IsCore = true, DefaultValue = "GETDATE()" },
            new SchemaAttribute { Id = 50109, GroupId = 101, Name = "Ngày cập nhật", SqlColumnName = "bnt5_hecoquan_ngaycapnhat", DataType = "DATETIME", IsRequired = false, IsCore = true },

            // ─── G102: BIO_STRUCTURE — Cấu Trúc Sinh Học (cautruc) — 9 attrs ───
            new SchemaAttribute { Id = 50201, GroupId = 102, Name = "Hệ cơ quan", SqlColumnName = "bnt5_cautruc_hecoquan", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_hecoquan(Id)" },
            new SchemaAttribute { Id = 50202, GroupId = 102, Name = "Mã cấu trúc", SqlColumnName = "bnt5_cautruc_macautruc", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50203, GroupId = 102, Name = "Tên tiếng Việt", SqlColumnName = "bnt5_cautruc_tentiengviet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50204, GroupId = 102, Name = "Tên tiếng Anh", SqlColumnName = "bnt5_cautruc_tentienganh", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50205, GroupId = 102, Name = "Cấu trúc cha", SqlColumnName = "bnt5_cautruc_cautruccha", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "bnt5_cautruc(Id)" },
            new SchemaAttribute { Id = 50206, GroupId = 102, Name = "Mô tả", SqlColumnName = "bnt5_cautruc_mota", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50207, GroupId = 102, Name = "Cấp độ", SqlColumnName = "bnt5_cautruc_capdo", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50208, GroupId = 102, Name = "Phiên bản", SqlColumnName = "bnt5_cautruc_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 50209, GroupId = 102, Name = "Trạng thái", SqlColumnName = "bnt5_cautruc_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },

            // ─── G103: BIO_SUBSTANCE — Chất / Tín Hiệu (chatinhieu) — 10 attrs ───
            new SchemaAttribute { Id = 50301, GroupId = 103, Name = "Cấu trúc", SqlColumnName = "bnt5_chatinhieu_cautruc", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_cautruc(Id)" },
            new SchemaAttribute { Id = 50302, GroupId = 103, Name = "Mã chất", SqlColumnName = "bnt5_chatinhieu_machat", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50303, GroupId = 103, Name = "Tên tiếng Việt", SqlColumnName = "bnt5_chatinhieu_tentiengviet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50304, GroupId = 103, Name = "Tên tiếng Anh", SqlColumnName = "bnt5_chatinhieu_tentienganh", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50305, GroupId = 103, Name = "Đơn vị", SqlColumnName = "bnt5_chatinhieu_donvi", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50306, GroupId = 103, Name = "Khoảng bình thường", SqlColumnName = "bnt5_chatinhieu_khoangbinhthuong", DataType = "NVARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50307, GroupId = 103, Name = "Mô tả", SqlColumnName = "bnt5_chatinhieu_mota", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50308, GroupId = 103, Name = "Loại", SqlColumnName = "bnt5_chatinhieu_loai", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50309, GroupId = 103, Name = "Phiên bản", SqlColumnName = "bnt5_chatinhieu_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 50310, GroupId = 103, Name = "Trạng thái", SqlColumnName = "bnt5_chatinhieu_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },

            // ─── G104: TEST_CATALOG — Danh Mục XN (dmxnghiem) — 10 attrs ───
            new SchemaAttribute { Id = 50401, GroupId = 104, Name = "Mã xét nghiệm", SqlColumnName = "bnt5_dmxnghiem_maxetnghiem", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50402, GroupId = 104, Name = "Tên tiếng Việt", SqlColumnName = "bnt5_dmxnghiem_tentiengviet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50403, GroupId = 104, Name = "Tên tiếng Anh", SqlColumnName = "bnt5_dmxnghiem_tentienganh", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50404, GroupId = 104, Name = "Phương pháp", SqlColumnName = "bnt5_dmxnghiem_phuongphap", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50405, GroupId = 104, Name = "Loại mẫu", SqlColumnName = "bnt5_dmxnghiem_loaimau", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50406, GroupId = 104, Name = "Thời gian trả KQ", SqlColumnName = "bnt5_dmxnghiem_thoigiantrakq", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50407, GroupId = 104, Name = "Giá thành", SqlColumnName = "bnt5_dmxnghiem_giathanh", DataType = "DECIMAL(18,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50408, GroupId = 104, Name = "Mô tả", SqlColumnName = "bnt5_dmxnghiem_mota", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50409, GroupId = 104, Name = "Phiên bản", SqlColumnName = "bnt5_dmxnghiem_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 50410, GroupId = 104, Name = "Trạng thái", SqlColumnName = "bnt5_dmxnghiem_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },

            // ─── G105: REF_RANGE — Khoảng Tham Chiếu (ktchieucu) — 12 attrs ───
            new SchemaAttribute { Id = 50501, GroupId = 105, Name = "Xét nghiệm", SqlColumnName = "bnt5_ktchieucu_xetnghiem", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_dmxnghiem(Id)" },
            new SchemaAttribute { Id = 50502, GroupId = 105, Name = "Tuổi tối thiểu", SqlColumnName = "bnt5_ktchieucu_tuoitoithieu", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50503, GroupId = 105, Name = "Tuổi tối đa", SqlColumnName = "bnt5_ktchieucu_tuoitoida", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50504, GroupId = 105, Name = "Giới tính", SqlColumnName = "bnt5_ktchieucu_gioitinh", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50505, GroupId = 105, Name = "Giá trị thấp", SqlColumnName = "bnt5_ktchieucu_giatrithap", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50506, GroupId = 105, Name = "Giá trị cao", SqlColumnName = "bnt5_ktchieucu_giatricao", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50507, GroupId = 105, Name = "Đơn vị", SqlColumnName = "bnt5_ktchieucu_donvi", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50508, GroupId = 105, Name = "Nguy kịch thấp", SqlColumnName = "bnt5_ktchieucu_nguykichthap", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50509, GroupId = 105, Name = "Nguy kịch cao", SqlColumnName = "bnt5_ktchieucu_nguykichcao", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50510, GroupId = 105, Name = "Ghi chú", SqlColumnName = "bnt5_ktchieucu_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50511, GroupId = 105, Name = "Phiên bản", SqlColumnName = "bnt5_ktchieucu_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 50512, GroupId = 105, Name = "Trạng thái", SqlColumnName = "bnt5_ktchieucu_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },

            // ─── G106: MEASUREMENT_ORDER — Lệnh Chỉ Định (ychidinh) — 8 attrs ───
            new SchemaAttribute { Id = 50601, GroupId = 106, Name = "Mã bệnh nhân", SqlColumnName = "bnt5_ychidinh_mabenhnhan", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 50602, GroupId = 106, Name = "Xét nghiệm", SqlColumnName = "bnt5_ychidinh_xetnghiem", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_dmxnghiem(Id)" },
            new SchemaAttribute { Id = 50603, GroupId = 106, Name = "Ngày chỉ định", SqlColumnName = "bnt5_ychidinh_ngaychidinh", DataType = "DATETIME", IsRequired = true, IsCore = true, DefaultValue = "GETDATE()" },
            new SchemaAttribute { Id = 50604, GroupId = 106, Name = "Chỉ định bởi", SqlColumnName = "bnt5_ychidinh_chidinhboi", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "AspNetUsers(Id)" },
            new SchemaAttribute { Id = 50605, GroupId = 106, Name = "Độ ưu tiên", SqlColumnName = "bnt5_ychidinh_douutien", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50606, GroupId = 106, Name = "Trạng thái", SqlColumnName = "bnt5_ychidinh_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'PENDING'" },
            new SchemaAttribute { Id = 50607, GroupId = 106, Name = "Ghi chú", SqlColumnName = "bnt5_ychidinh_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50608, GroupId = 106, Name = "Ngày tạo", SqlColumnName = "bnt5_ychidinh_ngaytao", DataType = "DATETIME", IsRequired = false, IsCore = true, DefaultValue = "GETDATE()" },

            // ─── G107: MEASUREMENT_RESULT — Kết Quả Đo Lường (ketqua) — 9 attrs ───
            new SchemaAttribute { Id = 50701, GroupId = 107, Name = "Mã chỉ định", SqlColumnName = "bnt5_ketqua_machidinh", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ychidinh(Id)" },
            new SchemaAttribute { Id = 50702, GroupId = 107, Name = "Giá trị", SqlColumnName = "bnt5_ketqua_giatri", DataType = "DECIMAL(18,4)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50703, GroupId = 107, Name = "Đơn vị", SqlColumnName = "bnt5_ketqua_donvi", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50704, GroupId = 107, Name = "Ngày kết quả", SqlColumnName = "bnt5_ketqua_ngayketqua", DataType = "DATETIME", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50705, GroupId = 107, Name = "Nhận định bởi", SqlColumnName = "bnt5_ketqua_nhandinhboi", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "AspNetUsers(Id)" },
            new SchemaAttribute { Id = 50706, GroupId = 107, Name = "Cờ báo động", SqlColumnName = "bnt5_ketqua_cobaodong", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50707, GroupId = 107, Name = "Ghi chú", SqlColumnName = "bnt5_ketqua_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50708, GroupId = 107, Name = "Phiên bản", SqlColumnName = "bnt5_ketqua_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 50709, GroupId = 107, Name = "Trạng thái", SqlColumnName = "bnt5_ketqua_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },

            // ─── G108: CTX_CHEMICAL — Sinh Hóa (csinhhoa) — 5 attrs ───
            new SchemaAttribute { Id = 50801, GroupId = 108, Name = "Mã kết quả", SqlColumnName = "bnt5_csinhhoa_maketqua", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 50802, GroupId = 108, Name = "Độ pH", SqlColumnName = "bnt5_csinhhoa_doph", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50803, GroupId = 108, Name = "Cân bằng ion", SqlColumnName = "bnt5_csinhhoa_canbangion", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50804, GroupId = 108, Name = "Nồng độ enzyme", SqlColumnName = "bnt5_csinhhoa_nongdoenzyme", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50805, GroupId = 108, Name = "Ghi chú", SqlColumnName = "bnt5_csinhhoa_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // ─── G109: CTX_VITAL_SIGN — Sinh Hiệu (cshieusinh) — 7 attrs ───
            new SchemaAttribute { Id = 50901, GroupId = 109, Name = "Mã kết quả", SqlColumnName = "bnt5_cshieusinh_maketqua", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 50902, GroupId = 109, Name = "Huyết áp", SqlColumnName = "bnt5_cshieusinh_huyetap", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50903, GroupId = 109, Name = "Nhịp tim", SqlColumnName = "bnt5_cshieusinh_nhiptim", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50904, GroupId = 109, Name = "Nhiệt độ", SqlColumnName = "bnt5_cshieusinh_nhietdo", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50905, GroupId = 109, Name = "Nhịp thở", SqlColumnName = "bnt5_cshieusinh_nhiptho", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50906, GroupId = 109, Name = "SPO2", SqlColumnName = "bnt5_cshieusinh_spo2", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50907, GroupId = 109, Name = "Ghi chú", SqlColumnName = "bnt5_cshieusinh_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // ─── G110: CTX_CELL — Tế Bào (ctebao) — 5 attrs ───
            new SchemaAttribute { Id = 51001, GroupId = 110, Name = "Mã kết quả", SqlColumnName = "bnt5_ctebao_maketqua", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 51002, GroupId = 110, Name = "Số lượng tế bào", SqlColumnName = "bnt5_ctebao_soluongtebao", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51003, GroupId = 110, Name = "Hình thái", SqlColumnName = "bnt5_ctebao_hinhthai", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51004, GroupId = 110, Name = "Markers", SqlColumnName = "bnt5_ctebao_markers", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51005, GroupId = 110, Name = "Ghi chú", SqlColumnName = "bnt5_ctebao_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // ─── G111: CTX_IMAGE — Hình Ảnh (chinhanh) — 6 attrs ───
            new SchemaAttribute { Id = 51101, GroupId = 111, Name = "Mã kết quả", SqlColumnName = "bnt5_chinhanh_maketqua", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 51102, GroupId = 111, Name = "Loại hình", SqlColumnName = "bnt5_chinhanh_loaihinh", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51103, GroupId = 111, Name = "Phát hiện", SqlColumnName = "bnt5_chinhanh_phathien", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51104, GroupId = 111, Name = "Đường dẫn file", SqlColumnName = "bnt5_chinhanh_duongdanfile", DataType = "VARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51105, GroupId = 111, Name = "Kích thước", SqlColumnName = "bnt5_chinhanh_kichthuoc", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51106, GroupId = 111, Name = "Ghi chú", SqlColumnName = "bnt5_chinhanh_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // ─── G112: CTX_ELECTRICAL — Điện Sinh Lý (diensinhly) — 6 attrs ───
            new SchemaAttribute { Id = 51201, GroupId = 112, Name = "Mã kết quả", SqlColumnName = "bnt5_diensinhly_maketqua", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_ketqua(Id)" },
            new SchemaAttribute { Id = 51202, GroupId = 112, Name = "Dạng sóng", SqlColumnName = "bnt5_diensinhly_dangsong", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51203, GroupId = 112, Name = "Biên độ", SqlColumnName = "bnt5_diensinhly_biendo", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51204, GroupId = 112, Name = "Tần số", SqlColumnName = "bnt5_diensinhly_tanso", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51205, GroupId = 112, Name = "Thời lượng", SqlColumnName = "bnt5_diensinhly_thoiluong", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51206, GroupId = 112, Name = "Ghi chú", SqlColumnName = "bnt5_diensinhly_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // ─── G113: TEST_RELATION — XN Liên Quan (xnlienquan) — 5 attrs ───
            new SchemaAttribute { Id = 51301, GroupId = 113, Name = "XN gốc", SqlColumnName = "bnt5_xnlienquan_xngoc", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_dmxnghiem(Id)" },
            new SchemaAttribute { Id = 51302, GroupId = 113, Name = "XN đích", SqlColumnName = "bnt5_xnlienquan_xndich", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt5_dmxnghiem(Id)" },
            new SchemaAttribute { Id = 51303, GroupId = 113, Name = "Loại liên hệ", SqlColumnName = "bnt5_xnlienquan_loailienhe", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51304, GroupId = 113, Name = "Mô tả", SqlColumnName = "bnt5_xnlienquan_mota", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51305, GroupId = 113, Name = "Độ mạnh", SqlColumnName = "bnt5_xnlienquan_domanh", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },

            // ─── G114: ALERT_RULE — Cảnh Báo XN (qtcbxn) — 8 attrs ───
            new SchemaAttribute { Id = 51401, GroupId = 114, Name = "Mã quy tắc", SqlColumnName = "bnt5_qtcbxn_maquytac", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51402, GroupId = 114, Name = "Điều kiện", SqlColumnName = "bnt5_qtcbxn_dieukien", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51403, GroupId = 114, Name = "Mức độ", SqlColumnName = "bnt5_qtcbxn_mucdo", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51404, GroupId = 114, Name = "Thông điệp", SqlColumnName = "bnt5_qtcbxn_thongdiep", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51405, GroupId = 114, Name = "XN gợi ý", SqlColumnName = "bnt5_qtcbxn_xngoiy", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51406, GroupId = 114, Name = "XN áp dụng", SqlColumnName = "bnt5_qtcbxn_xnapdung", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51407, GroupId = 114, Name = "Phiên bản", SqlColumnName = "bnt5_qtcbxn_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 51408, GroupId = 114, Name = "Trạng thái", SqlColumnName = "bnt5_qtcbxn_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'DRAFT'" }
        );
    }
}
