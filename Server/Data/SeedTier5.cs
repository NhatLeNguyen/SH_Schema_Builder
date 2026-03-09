using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public static class SeedTier5
{
    public static void Seed(ModelBuilder builder)
    {
        // Nhóm Tầng 5
        builder.Entity<Group>().HasData(
            new Group { Id = 101, TierId = 5, Name = "Hệ Cơ Quan", SqlTableName = "bnt5_he_co_quan", Cardinality = "1:N", Description = "Hệ cơ quan sinh học", IsCore = true },
            new Group { Id = 102, TierId = 5, Name = "Cấu Trúc Sinh Học", SqlTableName = "bnt5_cau_truc_sinh_hoc", Cardinality = "1:N", Description = "Cấu trúc chi tiết cơ quan", IsCore = true },
            new Group { Id = 103, TierId = 5, Name = "Chất / Tín Hiệu", SqlTableName = "bnt5_chat_tin_hieu", Cardinality = "1:N", Description = "Chất hoá học hoặc tín hiệu đo lường", IsCore = true },
            new Group { Id = 104, TierId = 5, Name = "DM Xét Nghiệm", SqlTableName = "bnt5_dm_xet_nghiem", Cardinality = "1:N", Description = "Danh mục xét nghiệm đo lường", IsCore = true },
            new Group { Id = 105, TierId = 5, Name = "Khoảng Tham Chiếu", SqlTableName = "bnt5_khoang_tham_chieu", Cardinality = "1:N", Description = "Reference ranges cho XN", IsCore = true },
            new Group { Id = 106, TierId = 5, Name = "Chỉ Định Đo Lường", SqlTableName = "bnt5_chi_dinh_do_luong", Cardinality = "1:N", Description = "Y lệnh chỉ định XN", IsCore = true },
            new Group { Id = 107, TierId = 5, Name = "Kết Quả Đo Lường", SqlTableName = "bnt5_ket_qua_do_luong", Cardinality = "1:N", Description = "Kết quả đo lường sinh học", IsCore = true },
            new Group { Id = 108, TierId = 5, Name = "Context Sinh Hoá", SqlTableName = "bnt5_context_sinh_hoa", Cardinality = "1:N", Description = "Bối cảnh đo sinh hoá", IsCore = true },
            new Group { Id = 109, TierId = 5, Name = "Context Sinh Hiệu", SqlTableName = "bnt5_context_sinh_hieu", Cardinality = "1:N", Description = "Bối cảnh định kỳ của sinh hiệu", IsCore = true },
            new Group { Id = 110, TierId = 5, Name = "Context Tế Bào", SqlTableName = "bnt5_context_te_bao", Cardinality = "1:N", Description = "Bối cảnh tế bào", IsCore = true },
            new Group { Id = 111, TierId = 5, Name = "Context Hình Ảnh", SqlTableName = "bnt5_context_hinh_anh", Cardinality = "1:N", Description = "Bối cảnh hình ảnh", IsCore = true },
            new Group { Id = 112, TierId = 5, Name = "Context Điện Sinh Lý", SqlTableName = "bnt5_context_dien_sinh_ly", Cardinality = "1:N", Description = "Bối cảnh điện sinh lý", IsCore = true },
            new Group { Id = 113, TierId = 5, Name = "Liên Kết Xét Nghiệm", SqlTableName = "bnt5_lien_ket_xet_nghiem", Cardinality = "1:N", Description = "Mối liên hệ tương quan giữa các xét nghiệm với nhau", IsCore = true },
            new Group { Id = 114, TierId = 5, Name = "Quy Tắc Cảnh Báo XN", SqlTableName = "bnt5_quy_tac_canh_bao_xn", Cardinality = "1:N", Description = "Quy tắc cảnh báo XN sinh học", IsCore = true }
        );

        // Attributes Tầng 5
        builder.Entity<SchemaAttribute>().HasData(
            // T5_G101 Hệ Cơ Quan
            new SchemaAttribute { Id = 50101, GroupId = 101, Name = "Mã Hệ", SqlColumnName = "bnt5_he_co_quan_ma_he", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50102, GroupId = 101, Name = "Tên Tiếng Việt", SqlColumnName = "bnt5_he_co_quan_ten_tieng_viet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50103, GroupId = 101, Name = "Tên Tiếng Anh", SqlColumnName = "bnt5_he_co_quan_ten_tieng_anh", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50104, GroupId = 101, Name = "Mô tả", SqlColumnName = "bnt5_he_co_quan_mo_ta", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50105, GroupId = 101, Name = "Sắp xếp", SqlColumnName = "bnt5_he_co_quan_sap_xep", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50106, GroupId = 101, Name = "Phiên bản", SqlColumnName = "bnt5_he_co_quan_phien_ban", DataType = "VARCHAR(10)", IsRequired = true, IsCore = true, DefaultValue = "1.0" },
            new SchemaAttribute { Id = 50107, GroupId = 101, Name = "Trạng thái", SqlColumnName = "bnt5_he_co_quan_trang_thai", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true, DefaultValue = "ACTIVE" },

            // T5_G102 Cấu Trúc Sinh Học
            new SchemaAttribute { Id = 50201, GroupId = 102, Name = "Hệ Cơ Quan ID", SqlColumnName = "bnt5_cau_truc_sinh_hoc_he_co_quan_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_he_co_quan(Id)" },
            new SchemaAttribute { Id = 50202, GroupId = 102, Name = "Mã Cấu Trúc", SqlColumnName = "bnt5_cau_truc_sinh_hoc_ma_cau_truc", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50203, GroupId = 102, Name = "Tên Tiếng Việt", SqlColumnName = "bnt5_cau_truc_sinh_hoc_ten_tieng_viet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50204, GroupId = 102, Name = "Tên Tiếng Anh", SqlColumnName = "bnt5_cau_truc_sinh_hoc_ten_tieng_anh", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50205, GroupId = 102, Name = "Cấu trúc cha ID", SqlColumnName = "bnt5_cau_truc_sinh_hoc_cau_truc_cha_id", DataType = "INT", IsRequired = false, IsCore = true, FkTarget = "bnt5_cau_truc_sinh_hoc(Id)" },
            new SchemaAttribute { Id = 50206, GroupId = 102, Name = "Mô tả", SqlColumnName = "bnt5_cau_truc_sinh_hoc_mo_ta", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50207, GroupId = 102, Name = "Cấp độ phân cấp", SqlColumnName = "bnt5_cau_truc_sinh_hoc_cap_do_phan_cap", DataType = "INT", IsRequired = false, IsCore = true },

            // T5_G103 Chất / Tín Hiệu
            new SchemaAttribute { Id = 50301, GroupId = 103, Name = "Cấu trúc ID", SqlColumnName = "bnt5_chat_tin_hieu_cau_truc_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_cau_truc_sinh_hoc(Id)" },
            new SchemaAttribute { Id = 50302, GroupId = 103, Name = "Mã Chất/Tín Hiệu", SqlColumnName = "bnt5_chat_tin_hieu_ma_chattin_hieu", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50303, GroupId = 103, Name = "Tên TV", SqlColumnName = "bnt5_chat_tin_hieu_ten_tv", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50304, GroupId = 103, Name = "Đơn vị", SqlColumnName = "bnt5_chat_tin_hieu_don_vi", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50305, GroupId = 103, Name = "Giới hạn bt", SqlColumnName = "bnt5_chat_tin_hieu_gioi_han_bt", DataType = "NVARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50306, GroupId = 103, Name = "Loại Tín Hiệu", SqlColumnName = "bnt5_chat_tin_hieu_loai_tin_hieu", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }, // CHEMICAL, ELECTRICAL

            // T5_G104 Danh Mục Xét Nghiệm
            new SchemaAttribute { Id = 50401, GroupId = 104, Name = "Mã Xét Nghiệm", SqlColumnName = "bnt5_dm_xet_nghiem_ma_xet_nghiem", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50402, GroupId = 104, Name = "Tên Xét Nghiệm", SqlColumnName = "bnt5_dm_xet_nghiem_ten_xet_nghiem", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50403, GroupId = 104, Name = "Tên Tiếng Anh", SqlColumnName = "bnt5_dm_xet_nghiem_ten_tieng_anh", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50404, GroupId = 104, Name = "Phương pháp đo", SqlColumnName = "bnt5_dm_xet_nghiem_phuong_phap_do", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }, // LAB, IMAGING
            new SchemaAttribute { Id = 50405, GroupId = 104, Name = "Loại mẫu", SqlColumnName = "bnt5_dm_xet_nghiem_loai_mau", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50406, GroupId = 104, Name = "Giá thành (Cost)", SqlColumnName = "bnt5_dm_xet_nghiem_gia_thanh_cost", DataType = "DECIMAL(18,2)", IsRequired = false, IsCore = true },

            // T5_G105 Khoảng Tham Chiếu
            new SchemaAttribute { Id = 50501, GroupId = 105, Name = "Xét nghiệm ID", SqlColumnName = "bnt5_khoang_tham_chieu_xet_nghiem_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_dm_xet_nghiem(Id)" },
            new SchemaAttribute { Id = 50502, GroupId = 105, Name = "Độ tuổi Min", SqlColumnName = "bnt5_khoang_tham_chieu_do_tuoi_min", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50503, GroupId = 105, Name = "Độ tuổi Max", SqlColumnName = "bnt5_khoang_tham_chieu_do_tuoi_max", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50504, GroupId = 105, Name = "Giới tính", SqlColumnName = "bnt5_khoang_tham_chieu_gioi_tinh", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50505, GroupId = 105, Name = "Cận dưới", SqlColumnName = "bnt5_khoang_tham_chieu_can_duoi", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50506, GroupId = 105, Name = "Cận trên", SqlColumnName = "bnt5_khoang_tham_chieu_can_tren", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50507, GroupId = 105, Name = "Nguy hiểm (Low)", SqlColumnName = "bnt5_khoang_tham_chieu_nguy_hiem_low", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50508, GroupId = 105, Name = "Nguy hiểm (High)", SqlColumnName = "bnt5_khoang_tham_chieu_nguy_hiem_high", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },

            // T5_G106 Chỉ Định Đo Lường
            new SchemaAttribute { Id = 50601, GroupId = 106, Name = "Bệnh nhân ID", SqlColumnName = "bnt5_chi_dinh_do_luong_benh_nhan_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 50602, GroupId = 106, Name = "Xét nghiệm ID", SqlColumnName = "bnt5_chi_dinh_do_luong_xet_nghiem_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_dm_xet_nghiem(Id)" },
            new SchemaAttribute { Id = 50603, GroupId = 106, Name = "Ngày yêu cầu", SqlColumnName = "bnt5_chi_dinh_do_luong_ngay_yeu_cau", DataType = "DATETIME", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50604, GroupId = 106, Name = "Độ ưu tiên", SqlColumnName = "bnt5_chi_dinh_do_luong_do_uu_tien", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true }, // URGENT...
            new SchemaAttribute { Id = 50605, GroupId = 106, Name = "Trạng thái", SqlColumnName = "bnt5_chi_dinh_do_luong_trang_thai", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true, DefaultValue = "PENDING" },

            // T5_G107 Kết Quả Đo Lường
            new SchemaAttribute { Id = 50701, GroupId = 107, Name = "Phiếu Chỉ Định ID", SqlColumnName = "bnt5_ket_qua_do_luong_phieu_chi_dinh_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_chi_dinh_do_luong(Id)" },
            new SchemaAttribute { Id = 50702, GroupId = 107, Name = "Giá trị đo được", SqlColumnName = "bnt5_ket_qua_do_luong_gia_tri_do_duoc", DataType = "DECIMAL(18,4)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50703, GroupId = 107, Name = "Đơn vị thực tế", SqlColumnName = "bnt5_ket_qua_do_luong_don_vi_thuc_te", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50704, GroupId = 107, Name = "Ngày có kết quả", SqlColumnName = "bnt5_ket_qua_do_luong_ngay_co_ket_qua", DataType = "DATETIME", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 50705, GroupId = 107, Name = "Đánh giá flag", SqlColumnName = "bnt5_ket_qua_do_luong_danh_gia_flag", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true }, // HIGH, LOW...

            // T5_G108 -> T5_G112 CONTEXT CHUYÊN SÂU
            new SchemaAttribute { Id = 50801, GroupId = 108, Name = "Kết quả ID", SqlColumnName = "bnt5_context_sinh_hoa_ket_qua_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_ket_qua_do_luong(Id)" },
            new SchemaAttribute { Id = 50802, GroupId = 108, Name = "Độ pH", SqlColumnName = "bnt5_context_sinh_hoa_do_ph", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50803, GroupId = 108, Name = "Ion Balance", SqlColumnName = "bnt5_context_sinh_hoa_ion_balance", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },

            new SchemaAttribute { Id = 50901, GroupId = 109, Name = "Kết quả ID", SqlColumnName = "bnt5_context_sinh_hieu_ket_qua_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_ket_qua_do_luong(Id)" },
            new SchemaAttribute { Id = 50902, GroupId = 109, Name = "Huyết áp", SqlColumnName = "bnt5_context_sinh_hieu_huyet_ap", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50903, GroupId = 109, Name = "Nhịp tim", SqlColumnName = "bnt5_context_sinh_hieu_nhip_tim", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 50904, GroupId = 109, Name = "SpO2", SqlColumnName = "bnt5_context_sinh_hieu_spo2", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },

            new SchemaAttribute { Id = 51001, GroupId = 110, Name = "Kết quả ID", SqlColumnName = "bnt5_context_te_bao_ket_qua_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_ket_qua_do_luong(Id)" },
            new SchemaAttribute { Id = 51002, GroupId = 110, Name = "Số lượng TB", SqlColumnName = "bnt5_context_te_bao_so_luong_tb", DataType = "INT", IsRequired = false, IsCore = true },

            new SchemaAttribute { Id = 51101, GroupId = 111, Name = "Kết quả ID", SqlColumnName = "bnt5_context_hinh_anh_ket_qua_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_ket_qua_do_luong(Id)" },
            new SchemaAttribute { Id = 51102, GroupId = 111, Name = "Đường dẫn File", SqlColumnName = "bnt5_context_hinh_anh_duong_dan_file", DataType = "VARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51103, GroupId = 111, Name = "Vị trí", SqlColumnName = "bnt5_context_hinh_anh_vi_tri", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },

            new SchemaAttribute { Id = 51201, GroupId = 112, Name = "Kết quả ID", SqlColumnName = "bnt5_context_dien_sinh_ly_ket_qua_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_ket_qua_do_luong(Id)" },
            new SchemaAttribute { Id = 51202, GroupId = 112, Name = "Tần số điện", SqlColumnName = "bnt5_context_dien_sinh_ly_tan_so_dien", DataType = "DECIMAL(18,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 51203, GroupId = 112, Name = "Waveform File", SqlColumnName = "bnt5_context_dien_sinh_ly_waveform_file", DataType = "JSON", IsRequired = false, IsCore = true },

            // T5_G113 Liên Kết Xét Nghiệm (Cross-reference tests)
            new SchemaAttribute { Id = 51301, GroupId = 113, Name = "Xét nghiệm Gốc (From)", SqlColumnName = "bnt5_lien_ket_xet_nghiem_xet_nghiem_goc_from", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_dm_xet_nghiem(Id)" },
            new SchemaAttribute { Id = 51302, GroupId = 113, Name = "Xét nghiệm Đích (To)", SqlColumnName = "bnt5_lien_ket_xet_nghiem_xet_nghiem_dich_to", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt5_dm_xet_nghiem(Id)" },
            new SchemaAttribute { Id = 51303, GroupId = 113, Name = "Loại Liên Kết", SqlColumnName = "bnt5_lien_ket_xet_nghiem_loai_lien_ket", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }, // COMPLEMENTARY...
            new SchemaAttribute { Id = 51304, GroupId = 113, Name = "Độ tin cậy", SqlColumnName = "bnt5_lien_ket_xet_nghiem_do_tin_cay", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            
            // T5_G114 Quy tắc cảnh báo XN
            new SchemaAttribute { Id = 51401, GroupId = 114, Name = "Mã quy tắc", SqlColumnName = "bnt5_quy_tac_canh_bao_xn_ma_quy_tac", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51402, GroupId = 114, Name = "Biểu thức điều kiện", SqlColumnName = "bnt5_quy_tac_canh_bao_xn_bieu_thuc_dieu_kien", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51403, GroupId = 114, Name = "Cảnh báo Message", SqlColumnName = "bnt5_quy_tac_canh_bao_xn_canh_bao_message", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 51404, GroupId = 114, Name = "Nhóm XN khuyên giải (JSON)", SqlColumnName = "bnt5_quy_tac_canh_bao_xn_nhom_xn_khuyen_giai_json", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true }
        );
    }
}
