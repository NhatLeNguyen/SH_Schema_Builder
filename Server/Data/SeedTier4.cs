using Microsoft.EntityFrameworkCore;
using Server.Models;

namespace Server.Data;

public static class SeedTier4
{
    public static void Seed(ModelBuilder builder)
    {
        // ── Parent Category Groups (Tầng 4) ──
        builder.Entity<Group>().HasData(
            new Group { Id = 401, TierId = 4, Name = "Danh mục dược học", SqlTableName = "", TableNameFull = "", Cardinality = "1:N", Description = "Danh mục gốc về dược phẩm", IsCore = true, ParentGroupId = null },
            new Group { Id = 402, TierId = 4, Name = "Dữ liệu dược học bệnh nhân", SqlTableName = "", TableNameFull = "", Cardinality = "1:N", Description = "Dữ liệu dược lâm sàng của bệnh nhân", IsCore = true, ParentGroupId = null },
            new Group { Id = 403, TierId = 4, Name = "Cảnh báo & Lịch sử dược", SqlTableName = "", TableNameFull = "", Cardinality = "1:N", Description = "Quy tắc cảnh báo và nhật ký dược", IsCore = true, ParentGroupId = null }
        );

        // ── Child Groups (Tầng 4) ──
        builder.Entity<Group>().HasData(
            // Danh mục dược học (parent 401)
            new Group { Id = 1, TierId = 4, ParentGroupId = 401, Name = "DRUG_GROUP (Nhóm dược lý)", SqlTableName = "bnt4_nhduly", TableNameFull = "nhomduocly", Cardinality = "1:N", Description = "Danh mục nhóm dược lý", IsCore = true },
            new Group { Id = 2, TierId = 4, ParentGroupId = 401, Name = "DRUG_SUBSTANCE (Hoạt chất)", SqlTableName = "bnt4_hoatch", TableNameFull = "hoatchat", Cardinality = "1:N", Description = "Danh mục hoạt chất", IsCore = true },
            new Group { Id = 3, TierId = 4, ParentGroupId = 401, Name = "CROSS_REACTIVITY (Dị ứng chéo)", SqlTableName = "bnt4_ducheo", TableNameFull = "duungcheo", Cardinality = "1:N", Description = "Quy tắc dị ứng chéo", IsCore = true },
            new Group { Id = 4, TierId = 4, ParentGroupId = 401, Name = "DRUG_INTERACTION (Tương tác thuốc)", SqlTableName = "bnt4_tuatac", TableNameFull = "tuongtacthuoc", Cardinality = "1:N", Description = "Tương tác giữa các hoạt chất", IsCore = true },

            // Dữ liệu dược học bệnh nhân (parent 402)
            new Group { Id = 5, TierId = 4, ParentGroupId = 402, Name = "PATIENT_ALLERGY (Dị ứng ADR)", SqlTableName = "bnt4_diungb", TableNameFull = "diungb", Cardinality = "1:N", Description = "Hồ sơ dị ứng của bệnh nhân", IsCore = true },
            new Group { Id = 6, TierId = 4, ParentGroupId = 402, Name = "PATIENT_CONDITION (Bệnh nền)", SqlTableName = "bnt4_bnenan", TableNameFull = "bnenan", Cardinality = "1:N", Description = "Bệnh lý nền bất biến", IsCore = true },

            // Cảnh báo & Lịch sử dược (parent 403)
            new Group { Id = 7, TierId = 4, ParentGroupId = 403, Name = "DRUG_ALERT_RULE (Quy tắc cảnh báo)", SqlTableName = "bnt4_qtcanh", TableNameFull = "qtcanh", Cardinality = "1:N", Description = "Bộ quy tắc cảnh báo lâm sàng", IsCore = true },
            new Group { Id = 8, TierId = 4, ParentGroupId = 403, Name = "ALERT_LOG (Lịch sử cảnh báo)", SqlTableName = "bnt4_nkcbao", TableNameFull = "nkcbao", Cardinality = "1:N", Description = "Lịch sử cảnh báo đã phát cho bệnh nhân", IsCore = true }
        );

        // ── Attributes (Tầng 4) ──
        builder.Entity<SchemaAttribute>().HasData(

            // ─── G1: DRUG_GROUP — Nhóm Dược Lý (nhomduocly) — 10 attrs ───
            new SchemaAttribute { Id = 40101, GroupId = 1, Name = "Mã nhóm", SqlColumnName = "bnt4_nhomduocly_manhom", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40102, GroupId = 1, Name = "Tên tiếng Việt", SqlColumnName = "bnt4_nhomduocly_tentiengviet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40103, GroupId = 1, Name = "Tên tiếng Anh", SqlColumnName = "bnt4_nhomduocly_tentienganh", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40104, GroupId = 1, Name = "Nhóm cha", SqlColumnName = "bnt4_nhomduocly_nhomcha", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "bnt4_nhduly(Id)" },
            new SchemaAttribute { Id = 40105, GroupId = 1, Name = "Mục tiêu sinh học", SqlColumnName = "bnt4_nhomduocly_muctieusinhhoc", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40106, GroupId = 1, Name = "Cơ chế TV", SqlColumnName = "bnt4_nhomduocly_cochetv", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40107, GroupId = 1, Name = "Cơ chế TA", SqlColumnName = "bnt4_nhomduocly_cocheta", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40108, GroupId = 1, Name = "Cấu trúc hóa học", SqlColumnName = "bnt4_nhomduocly_cautruchoahoc", DataType = "VARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40109, GroupId = 1, Name = "Phiên bản", SqlColumnName = "bnt4_nhomduocly_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 40110, GroupId = 1, Name = "Trạng thái", SqlColumnName = "bnt4_nhomduocly_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },

            // ─── G2: DRUG_SUBSTANCE — Hoạt Chất (hoatchat) — 11 attrs ───
            new SchemaAttribute { Id = 40201, GroupId = 2, Name = "Mã hoạt chất", SqlColumnName = "bnt4_hoatchat_mahoatchat", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40202, GroupId = 2, Name = "Tên tiếng Việt", SqlColumnName = "bnt4_hoatchat_tentiengviet", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40203, GroupId = 2, Name = "Tên tiếng Anh", SqlColumnName = "bnt4_hoatchat_tentienganh", DataType = "NVARCHAR(200)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40204, GroupId = 2, Name = "Nhóm dược lý", SqlColumnName = "bnt4_hoatchat_nhomduocly", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_nhduly(Id)" },
            new SchemaAttribute { Id = 40205, GroupId = 2, Name = "Mã ATC", SqlColumnName = "bnt4_hoatchat_maatc", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40206, GroupId = 2, Name = "Công thức phân tử", SqlColumnName = "bnt4_hoatchat_congthucphantu", DataType = "VARCHAR(100)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40207, GroupId = 2, Name = "Khối lượng phân tử", SqlColumnName = "bnt4_hoatchat_khoiluongphantu", DataType = "DECIMAL(10,4)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40208, GroupId = 2, Name = "Thời gian bán thải", SqlColumnName = "bnt4_hoatchat_thoigianbanthai", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40209, GroupId = 2, Name = "Sinh khả dụng", SqlColumnName = "bnt4_hoatchat_sinhkhadung", DataType = "DECIMAL(5,2)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40210, GroupId = 2, Name = "Phiên bản", SqlColumnName = "bnt4_hoatchat_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 40211, GroupId = 2, Name = "Trạng thái", SqlColumnName = "bnt4_hoatchat_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },

            // ─── G3: CROSS_REACTIVITY — Dị Ứng Chéo (duungcheo) — 7 attrs ───
            new SchemaAttribute { Id = 40301, GroupId = 3, Name = "Chất nguồn", SqlColumnName = "bnt4_duungcheo_chatnguon", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40302, GroupId = 3, Name = "Chất nhận", SqlColumnName = "bnt4_duungcheo_chatnhan", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40303, GroupId = 3, Name = "Mức độ", SqlColumnName = "bnt4_duungcheo_mucdo", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40304, GroupId = 3, Name = "Mô tả", SqlColumnName = "bnt4_duungcheo_mota", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40305, GroupId = 3, Name = "Mức bằng chứng", SqlColumnName = "bnt4_duungcheo_mucbangchung", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40306, GroupId = 3, Name = "Ngày tạo", SqlColumnName = "bnt4_duungcheo_ngaytao", DataType = "DATETIME", IsRequired = false, IsCore = true, DefaultValue = "GETDATE()" },
            new SchemaAttribute { Id = 40307, GroupId = 3, Name = "Ngày cập nhật", SqlColumnName = "bnt4_duungcheo_ngaycapnhat", DataType = "DATETIME", IsRequired = false, IsCore = true },

            // ─── G4: DRUG_INTERACTION — Tương Tác Thuốc (tuongtacthuoc) — 8 attrs ───
            new SchemaAttribute { Id = 40401, GroupId = 4, Name = "Thuốc 1", SqlColumnName = "bnt4_tuongtacthuoc_thuoc1", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40402, GroupId = 4, Name = "Thuốc 2", SqlColumnName = "bnt4_tuongtacthuoc_thuoc2", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40403, GroupId = 4, Name = "Tác dụng", SqlColumnName = "bnt4_tuongtacthuoc_tacdung", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40404, GroupId = 4, Name = "Mức độ", SqlColumnName = "bnt4_tuongtacthuoc_mucdo", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40405, GroupId = 4, Name = "Xử trí", SqlColumnName = "bnt4_tuongtacthuoc_xutri", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40406, GroupId = 4, Name = "Bằng chứng", SqlColumnName = "bnt4_tuongtacthuoc_bangchung", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40407, GroupId = 4, Name = "Phiên bản", SqlColumnName = "bnt4_tuongtacthuoc_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },
            new SchemaAttribute { Id = 40408, GroupId = 4, Name = "Trạng thái", SqlColumnName = "bnt4_tuongtacthuoc_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },

            // ─── G5: PATIENT_ALLERGY — Dị Ứng BN (diungb) — 9 attrs ───
            new SchemaAttribute { Id = 40501, GroupId = 5, Name = "Mã bệnh nhân", SqlColumnName = "bnt4_diungb_mabenhnhan", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40502, GroupId = 5, Name = "Hoạt chất", SqlColumnName = "bnt4_diungb_hoatchat", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_hoatch(Id)" },
            new SchemaAttribute { Id = 40503, GroupId = 5, Name = "Mức độ", SqlColumnName = "bnt4_diungb_mucdo", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40504, GroupId = 5, Name = "Ngày khởi phát", SqlColumnName = "bnt4_diungb_ngaykhoiphat", DataType = "DATE", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40505, GroupId = 5, Name = "Loại phản ứng", SqlColumnName = "bnt4_diungb_loaiphanung", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40506, GroupId = 5, Name = "Đã khỏi", SqlColumnName = "bnt4_diungb_dakhoi", DataType = "BIT", IsRequired = false, IsCore = true, DefaultValue = "0" },
            new SchemaAttribute { Id = 40507, GroupId = 5, Name = "Ghi chú", SqlColumnName = "bnt4_diungb_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40508, GroupId = 5, Name = "Xác nhận bởi", SqlColumnName = "bnt4_diungb_xacnhanboi", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "AspNetUsers(Id)" },
            new SchemaAttribute { Id = 40509, GroupId = 5, Name = "Ngày xác nhận", SqlColumnName = "bnt4_diungb_ngayxacnhan", DataType = "DATETIME", IsRequired = false, IsCore = true },

            // ─── G6: PATIENT_CONDITION — Bệnh Nền (bnenan) — 8 attrs ───
            new SchemaAttribute { Id = 40601, GroupId = 6, Name = "Mã bệnh nhân", SqlColumnName = "bnt4_bnenan_mabenhnhan", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40602, GroupId = 6, Name = "Mã ICD", SqlColumnName = "bnt4_bnenan_maicd", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40603, GroupId = 6, Name = "Ngày chẩn đoán", SqlColumnName = "bnt4_bnenan_ngaychandoan", DataType = "DATE", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40604, GroupId = 6, Name = "Chẩn đoán bởi", SqlColumnName = "bnt4_bnenan_chandoanboi", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "AspNetUsers(Id)" },
            new SchemaAttribute { Id = 40605, GroupId = 6, Name = "Mức độ", SqlColumnName = "bnt4_bnenan_mucdo", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40606, GroupId = 6, Name = "Trạng thái", SqlColumnName = "bnt4_bnenan_trangthai", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true, DefaultValue = "'ACTIVE'" },
            new SchemaAttribute { Id = 40607, GroupId = 6, Name = "Ghi chú", SqlColumnName = "bnt4_bnenan_ghichu", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40608, GroupId = 6, Name = "Ngày tạo", SqlColumnName = "bnt4_bnenan_ngaytao", DataType = "DATETIME", IsRequired = false, IsCore = true, DefaultValue = "GETDATE()" },

            // ─── G7: DRUG_ALERT_RULE — Quy Tắc Cảnh Báo (qtcanh) — 9 attrs ───
            new SchemaAttribute { Id = 40701, GroupId = 7, Name = "Mã quy tắc", SqlColumnName = "bnt4_qtcanh_maquytac", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40702, GroupId = 7, Name = "Mô tả", SqlColumnName = "bnt4_qtcanh_mota", DataType = "NVARCHAR(MAX)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40703, GroupId = 7, Name = "Mức độ", SqlColumnName = "bnt4_qtcanh_mucdo", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40704, GroupId = 7, Name = "Hành động", SqlColumnName = "bnt4_qtcanh_hanhdong", DataType = "VARCHAR(50)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40705, GroupId = 7, Name = "Điều kiện kích hoạt", SqlColumnName = "bnt4_qtcanh_dieukienkichhoat", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40706, GroupId = 7, Name = "Tuổi tối thiểu", SqlColumnName = "bnt4_qtcanh_tuoitoithieu", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40707, GroupId = 7, Name = "Tuổi tối đa", SqlColumnName = "bnt4_qtcanh_tuoitoida", DataType = "INT", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40708, GroupId = 7, Name = "Giới tính", SqlColumnName = "bnt4_qtcanh_gioitinh", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40709, GroupId = 7, Name = "Phiên bản", SqlColumnName = "bnt4_qtcanh_phienban", DataType = "VARCHAR(10)", IsRequired = false, IsCore = true, DefaultValue = "'1.0'" },

            // ─── G8: ALERT_LOG — Lịch Sử Cảnh Báo (nkcbao) — 11 attrs ───
            new SchemaAttribute { Id = 40801, GroupId = 8, Name = "Mã bệnh nhân", SqlColumnName = "bnt4_nkcbao_mabenhnhan", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "Patient(Id)" },
            new SchemaAttribute { Id = 40802, GroupId = 8, Name = "Đơn thuốc", SqlColumnName = "bnt4_nkcbao_donthuoc", DataType = "INT", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40803, GroupId = 8, Name = "Quy tắc", SqlColumnName = "bnt4_nkcbao_quytac", DataType = "REF", IsRequired = true, IsCore = true, FkTarget = "bnt4_qtcanh(Id)" },
            new SchemaAttribute { Id = 40804, GroupId = 8, Name = "Mã thuốc", SqlColumnName = "bnt4_nkcbao_mathuoc", DataType = "VARCHAR(20)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40805, GroupId = 8, Name = "Mức độ", SqlColumnName = "bnt4_nkcbao_mucdo", DataType = "VARCHAR(20)", IsRequired = true, IsCore = true },
            new SchemaAttribute { Id = 40806, GroupId = 8, Name = "Hành động xử trí", SqlColumnName = "bnt4_nkcbao_hanhdongxutri", DataType = "VARCHAR(50)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40807, GroupId = 8, Name = "Xác nhận bởi", SqlColumnName = "bnt4_nkcbao_xacnhanboi", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "AspNetUsers(Id)" },
            new SchemaAttribute { Id = 40808, GroupId = 8, Name = "Ghi chú xác nhận", SqlColumnName = "bnt4_nkcbao_ghichuxacnhan", DataType = "NVARCHAR(MAX)", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40809, GroupId = 8, Name = "Xem xét bởi", SqlColumnName = "bnt4_nkcbao_xemxetboi", DataType = "REF", IsRequired = false, IsCore = true, FkTarget = "AspNetUsers(Id)" },
            new SchemaAttribute { Id = 40810, GroupId = 8, Name = "Ngày xem xét", SqlColumnName = "bnt4_nkcbao_ngayxemxet", DataType = "DATETIME", IsRequired = false, IsCore = true },
            new SchemaAttribute { Id = 40811, GroupId = 8, Name = "Thời gian", SqlColumnName = "bnt4_nkcbao_thoigian", DataType = "DATETIME", IsRequired = false, IsCore = true, DefaultValue = "GETDATE()" }
        );
    }
}
