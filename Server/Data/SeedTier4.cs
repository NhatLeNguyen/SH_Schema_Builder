using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public static class SeedTier4
{
    public static void Seed(ModelBuilder builder)
    {
        // Nhóm Tầng 4
        builder.Entity<Group>().HasData(
            new Group { Id = 1, TierId = 4, Name = "Nhóm Dược Lý", SqlTableName = "bnt4_nhom_duoc_ly", Cardinality = "1:N", Description = "Danh mục nhóm dược lý", IsCore = true },
            new Group { Id = 2, TierId = 4, Name = "Hoạt Chất", SqlTableName = "bnt4_hoat_chat", Cardinality = "1:N", Description = "Danh mục hoạt chất", IsCore = true },
            new Group { Id = 3, TierId = 4, Name = "Dị ứng Chéo", SqlTableName = "bnt4_di_ung_cheo", Cardinality = "1:N", Description = "Quy tắc dị ứng chéo", IsCore = true },
            new Group { Id = 4, TierId = 4, Name = "Tương Tác Thuốc", SqlTableName = "bnt4_tuong_tac_thuoc", Cardinality = "1:N", Description = "Tương tác giữa các hoạt chất", IsCore = true },
            new Group { Id = 5, TierId = 4, Name = "Dị Ứng Bệnh Nhân", SqlTableName = "bnt4_di_ung_benh_nhan", Cardinality = "1:N", Description = "Hồ sơ dị ứng của bệnh nhân", IsCore = true },
            new Group { Id = 6, TierId = 4, Name = "Bệnh Nền", SqlTableName = "bnt4_benh_nen", Cardinality = "1:N", Description = "Bệnh lý nền bất biến", IsCore = true },
            new Group { Id = 7, TierId = 4, Name = "Quy Tắc Cảnh Báo", SqlTableName = "bnt4_quy_tac_canh_bao", Cardinality = "1:N", Description = "Bộ quy tắc cảnh báo lâm sàng", IsCore = true },
            new Group { Id = 8, TierId = 4, Name = "Nhật Ký Cảnh Báo", SqlTableName = "bnt4_nhat_ky_canh_bao", Cardinality = "1:N", Description = "Lịch sử cảnh báo đã phát cho bệnh nhân", IsCore = true }
        );

        // Attributes Tầng 4
        builder.Entity<SchemaAttribute>().HasData(
            // T4_G1 Nhóm Dược Lý
            new SchemaAttribute { Id = 40101, GroupId = 1, Name = "Mã Nhóm", SqlColumnName = "bnt4_nhom_duoc_ly_ma_nhom", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40102, GroupId = 1, Name = "Tên Tiếng Việt", SqlColumnName = "bnt4_nhom_duoc_ly_ten_tieng_viet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40103, GroupId = 1, Name = "Tên Tiếng Anh", SqlColumnName = "bnt4_nhom_duoc_ly_ten_tieng_anh", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40104, GroupId = 1, Name = "Nhóm Cha ID", SqlColumnName = "bnt4_nhom_duoc_ly_nhom_cha_id", DataType = "INT", IsRequired = false, IsCore = true, FkTarget = "bnt4_nhom_duoc_ly(Id)" },
            new SchemaAttribute { Id = 40105, GroupId = 1, Name = "Mục Tiêu Sinh Học", SqlColumnName = "bnt4_nhom_duoc_ly_muc_tieu_sinh_hoc", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40106, GroupId = 1, Name = "Cơ chế TV", SqlColumnName = "bnt4_nhom_duoc_ly_co_che_tv", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40107, GroupId = 1, Name = "Cơ chế TA", SqlColumnName = "bnt4_nhom_duoc_ly_co_che_ta", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40108, GroupId = 1, Name = "Cấu trúc hóa học", SqlColumnName = "bnt4_nhom_duoc_ly_cau_truc_hoa_hoc", DataType = "VARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40109, GroupId = 1, Name = "Phiên bản", SqlColumnName = "bnt4_nhom_duoc_ly_phien_ban", DataType = "VARCHAR(10)", IsRequired = true, IsCore = true, DefaultValue = "1.0" },
            new SchemaAttribute { Id = 40110, GroupId = 1, Name = "Trạng thái", SqlColumnName = "bnt4_nhom_duoc_ly_trang_thai", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true, DefaultValue = "ACTIVE" },

            // T4_G2 Hoạt Chất
            new SchemaAttribute { Id = 40201, GroupId = 2, Name = "Mã Hoạt Chất", SqlColumnName = "bnt4_hoat_chat_ma_hoat_chat", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40202, GroupId = 2, Name = "Tên Tiếng Việt", SqlColumnName = "bnt4_hoat_chat_ten_tieng_viet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40203, GroupId = 2, Name = "Tên Tiếng Anh", SqlColumnName = "bnt4_hoat_chat_ten_tieng_anh", DataType = "NVARCHAR(200)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40204, GroupId = 2, Name = "Nhóm Dược Lý ID", SqlColumnName = "bnt4_hoat_chat_nhom_duoc_ly_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt4_nhom_duoc_ly(Id)" },
            new SchemaAttribute { Id = 40205, GroupId = 2, Name = "ATC Code", SqlColumnName = "bnt4_hoat_chat_atc_code", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40206, GroupId = 2, Name = "Công thức phân tử", SqlColumnName = "bnt4_hoat_chat_cong_thuc_phan_tu", DataType = "VARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40207, GroupId = 2, Name = "Khối lượng P.Tử", SqlColumnName = "bnt4_hoat_chat_khoi_luong_ptu", DataType = "DECIMAL(10,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40208, GroupId = 2, Name = "Thời gian bán thải", SqlColumnName = "bnt4_hoat_chat_thoi_gian_ban_thai", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40209, GroupId = 2, Name = "Sinh khả dụng", SqlColumnName = "bnt4_hoat_chat_sinh_kha_dung", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40210, GroupId = 2, Name = "Phiên bản", SqlColumnName = "bnt4_hoat_chat_phien_ban", DataType = "VARCHAR(10)", IsRequired = true, IsCore = true, DefaultValue = "1.0" },
            new SchemaAttribute { Id = 40211, GroupId = 2, Name = "Trạng thái", SqlColumnName = "bnt4_hoat_chat_trang_thai", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true, DefaultValue = "ACTIVE" },

            // T4_G3 Dị Ứng Chéo
            new SchemaAttribute { Id = 40301, GroupId = 3, Name = "Chất Gây Dị Ứng (Source)", SqlColumnName = "bnt4_di_ung_cheo_chat_gay_di_ung_source", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoat_chat(Id)" },
            new SchemaAttribute { Id = 40302, GroupId = 3, Name = "Chất Dị Ứng Chéo (Target)", SqlColumnName = "bnt4_di_ung_cheo_chat_di_ung_cheo_target", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoat_chat(Id)" },
            new SchemaAttribute { Id = 40303, GroupId = 3, Name = "Mức độ", SqlColumnName = "bnt4_di_ung_cheo_muc_do", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40304, GroupId = 3, Name = "Mô tả", SqlColumnName = "bnt4_di_ung_cheo_mo_ta", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40305, GroupId = 3, Name = "Mức độ bằng chứng", SqlColumnName = "bnt4_di_ung_cheo_muc_do_bang_chung", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40306, GroupId = 3, Name = "Ngày tạo", SqlColumnName = "bnt4_di_ung_cheo_ngay_tao", DataType = "DATETIME", IsRequired = true, IsCore = true, DefaultValue = "GETDATE()" },

            // T4_G4 Tương Tác Thuốc
            new SchemaAttribute { Id = 40401, GroupId = 4, Name = "Thuốc 1", SqlColumnName = "bnt4_tuong_tac_thuoc_thuoc_1", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoat_chat(Id)" },
            new SchemaAttribute { Id = 40402, GroupId = 4, Name = "Thuốc 2", SqlColumnName = "bnt4_tuong_tac_thuoc_thuoc_2", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoat_chat(Id)" },
            new SchemaAttribute { Id = 40403, GroupId = 4, Name = "Tác dụng", SqlColumnName = "bnt4_tuong_tac_thuoc_tac_dung", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40404, GroupId = 4, Name = "Mức độ", SqlColumnName = "bnt4_tuong_tac_thuoc_muc_do", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40405, GroupId = 4, Name = "Xử trí", SqlColumnName = "bnt4_tuong_tac_thuoc_xu_tri", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40406, GroupId = 4, Name = "Bằng chứng", SqlColumnName = "bnt4_tuong_tac_thuoc_bang_chung", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // T4_G5 Dị Ứng Bệnh Nhân
            new SchemaAttribute { Id = 40501, GroupId = 5, Name = "Bệnh nhân ID", SqlColumnName = "bnt4_di_ung_benh_nhan_benh_nhan_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40502, GroupId = 5, Name = "Hoạt Chất ID", SqlColumnName = "bnt4_di_ung_benh_nhan_hoat_chat_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoat_chat(Id)" },
            new SchemaAttribute { Id = 40503, GroupId = 5, Name = "Mức độ", SqlColumnName = "bnt4_di_ung_benh_nhan_muc_do", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40504, GroupId = 5, Name = "Loại phản ứng", SqlColumnName = "bnt4_di_ung_benh_nhan_loai_phan_ung", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40505, GroupId = 5, Name = "Ngày phát hiện", SqlColumnName = "bnt4_di_ung_benh_nhan_ngay_phat_hien", DataType = "DATE", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40506, GroupId = 5, Name = "Đã khỏi", SqlColumnName = "bnt4_di_ung_benh_nhan_da_khoi", DataType = "BIT", IsRequired = true, IsCore = true, DefaultValue = "0" },
            new SchemaAttribute { Id = 40507, GroupId = 5, Name = "Ghi chú", SqlColumnName = "bnt4_di_ung_benh_nhan_ghi_chu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // T4_G6 Bệnh Nền
            new SchemaAttribute { Id = 40601, GroupId = 6, Name = "Bệnh nhân ID", SqlColumnName = "bnt4_benh_nen_benh_nhan_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40602, GroupId = 6, Name = "Mã ICD", SqlColumnName = "bnt4_benh_nen_ma_icd", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40603, GroupId = 6, Name = "Ngày chẩn đoán", SqlColumnName = "bnt4_benh_nen_ngay_chan_doan", DataType = "DATE", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40604, GroupId = 6, Name = "Mức độ", SqlColumnName = "bnt4_benh_nen_muc_do", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40605, GroupId = 6, Name = "Trạng thái", SqlColumnName = "bnt4_benh_nen_trang_thai", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40606, GroupId = 6, Name = "Ghi chú", SqlColumnName = "bnt4_benh_nen_ghi_chu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },

            // T4_G7 Quy Tắc Cảnh Báo
            new SchemaAttribute { Id = 40701, GroupId = 7, Name = "Mã quy tắc", SqlColumnName = "bnt4_quy_tac_canh_bao_ma_quy_tac", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40702, GroupId = 7, Name = "Mô tả", SqlColumnName = "bnt4_quy_tac_canh_bao_mo_ta", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40703, GroupId = 7, Name = "Mức độ", SqlColumnName = "bnt4_quy_tac_canh_bao_muc_do", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40704, GroupId = 7, Name = "Hành động", SqlColumnName = "bnt4_quy_tac_canh_bao_hanh_dong", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }, // BLOCK, WARN
            new SchemaAttribute { Id = 40705, GroupId = 7, Name = "Điều kiện (JSON)", SqlColumnName = "bnt4_quy_tac_canh_bao_dieu_kien_json", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40706, GroupId = 7, Name = "Tuổi áp dụng (Min)", SqlColumnName = "bnt4_quy_tac_canh_bao_tuoi_ap_dung_min", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40707, GroupId = 7, Name = "Tuổi áp dụng (Max)", SqlColumnName = "bnt4_quy_tac_canh_bao_tuoi_ap_dung_max", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40708, GroupId = 7, Name = "Giới tính", SqlColumnName = "bnt4_quy_tac_canh_bao_gioi_tinh", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },

            // T4_G8 Nhật Ký Cảnh Báo
            new SchemaAttribute { Id = 40801, GroupId = 8, Name = "Bệnh nhân ID", SqlColumnName = "bnt4_nhat_ky_canh_bao_benh_nhan_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40802, GroupId = 8, Name = "Đơn thuốc ID", SqlColumnName = "bnt4_nhat_ky_canh_bao_don_thuoc_id", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40803, GroupId = 8, Name = "Quy tắc ID", SqlColumnName = "bnt4_nhat_ky_canh_bao_quy_tac_id", DataType = "INT", IsRequired = true, IsCore = true, FkTarget = "bnt4_quy_tac_canh_bao(Id)" },
            new SchemaAttribute { Id = 40804, GroupId = 8, Name = "Mã Thuốc", SqlColumnName = "bnt4_nhat_ky_canh_bao_ma_thuoc", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40805, GroupId = 8, Name = "Quyết định của BS", SqlColumnName = "bnt4_nhat_ky_canh_bao_quyet_dinh_cua_bs", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true }
        );
    }
}
