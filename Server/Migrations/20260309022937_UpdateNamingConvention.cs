using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNamingConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableNameFull",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40101,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_ma_nhom");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40102,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_ten_tieng_viet");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40103,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_ten_tieng_anh");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40104,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_nhom_cha_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40105,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_muc_tieu_sinh_hoc");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40106,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_co_che_tv");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40107,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_co_che_ta");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40108,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_cau_truc_hoa_hoc");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40109,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_phien_ban");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40110,
                column: "SqlColumnName",
                value: "bnt4_nhom_duoc_ly_trang_thai");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40201,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_ma_hoat_chat");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40202,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_ten_tieng_viet");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40203,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_ten_tieng_anh");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40204,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_nhom_duoc_ly_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40205,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_atc_code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40206,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_cong_thuc_phan_tu");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40207,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_khoi_luong_ptu");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40208,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_thoi_gian_ban_thai");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40209,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_sinh_kha_dung");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40210,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_phien_ban");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40211,
                column: "SqlColumnName",
                value: "bnt4_hoat_chat_trang_thai");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40301,
                column: "SqlColumnName",
                value: "bnt4_di_ung_cheo_chat_gay_di_ung_source");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40302,
                column: "SqlColumnName",
                value: "bnt4_di_ung_cheo_chat_di_ung_cheo_target");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40303,
                column: "SqlColumnName",
                value: "bnt4_di_ung_cheo_muc_do");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40304,
                column: "SqlColumnName",
                value: "bnt4_di_ung_cheo_mo_ta");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40305,
                column: "SqlColumnName",
                value: "bnt4_di_ung_cheo_muc_do_bang_chung");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40306,
                column: "SqlColumnName",
                value: "bnt4_di_ung_cheo_ngay_tao");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40401,
                column: "SqlColumnName",
                value: "bnt4_tuong_tac_thuoc_thuoc_1");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40402,
                column: "SqlColumnName",
                value: "bnt4_tuong_tac_thuoc_thuoc_2");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40403,
                column: "SqlColumnName",
                value: "bnt4_tuong_tac_thuoc_tac_dung");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40404,
                column: "SqlColumnName",
                value: "bnt4_tuong_tac_thuoc_muc_do");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40405,
                column: "SqlColumnName",
                value: "bnt4_tuong_tac_thuoc_xu_tri");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40406,
                column: "SqlColumnName",
                value: "bnt4_tuong_tac_thuoc_bang_chung");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40501,
                column: "SqlColumnName",
                value: "bnt4_di_ung_benh_nhan_benh_nhan_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40502,
                column: "SqlColumnName",
                value: "bnt4_di_ung_benh_nhan_hoat_chat_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40503,
                column: "SqlColumnName",
                value: "bnt4_di_ung_benh_nhan_muc_do");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40504,
                column: "SqlColumnName",
                value: "bnt4_di_ung_benh_nhan_loai_phan_ung");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40505,
                column: "SqlColumnName",
                value: "bnt4_di_ung_benh_nhan_ngay_phat_hien");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40506,
                column: "SqlColumnName",
                value: "bnt4_di_ung_benh_nhan_da_khoi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40507,
                column: "SqlColumnName",
                value: "bnt4_di_ung_benh_nhan_ghi_chu");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40601,
                column: "SqlColumnName",
                value: "bnt4_benh_nen_benh_nhan_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40602,
                column: "SqlColumnName",
                value: "bnt4_benh_nen_ma_icd");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40603,
                column: "SqlColumnName",
                value: "bnt4_benh_nen_ngay_chan_doan");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40604,
                column: "SqlColumnName",
                value: "bnt4_benh_nen_muc_do");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40605,
                column: "SqlColumnName",
                value: "bnt4_benh_nen_trang_thai");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40606,
                column: "SqlColumnName",
                value: "bnt4_benh_nen_ghi_chu");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40701,
                column: "SqlColumnName",
                value: "bnt4_quy_tac_canh_bao_ma_quy_tac");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40702,
                column: "SqlColumnName",
                value: "bnt4_quy_tac_canh_bao_mo_ta");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40703,
                column: "SqlColumnName",
                value: "bnt4_quy_tac_canh_bao_muc_do");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40704,
                column: "SqlColumnName",
                value: "bnt4_quy_tac_canh_bao_hanh_dong");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40705,
                column: "SqlColumnName",
                value: "bnt4_quy_tac_canh_bao_dieu_kien_json");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40706,
                column: "SqlColumnName",
                value: "bnt4_quy_tac_canh_bao_tuoi_ap_dung_min");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40707,
                column: "SqlColumnName",
                value: "bnt4_quy_tac_canh_bao_tuoi_ap_dung_max");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40708,
                column: "SqlColumnName",
                value: "bnt4_quy_tac_canh_bao_gioi_tinh");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40801,
                column: "SqlColumnName",
                value: "bnt4_nhat_ky_canh_bao_benh_nhan_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40802,
                column: "SqlColumnName",
                value: "bnt4_nhat_ky_canh_bao_don_thuoc_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40803,
                column: "SqlColumnName",
                value: "bnt4_nhat_ky_canh_bao_quy_tac_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40804,
                column: "SqlColumnName",
                value: "bnt4_nhat_ky_canh_bao_ma_thuoc");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40805,
                column: "SqlColumnName",
                value: "bnt4_nhat_ky_canh_bao_quyet_dinh_cua_bs");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50101,
                column: "SqlColumnName",
                value: "bnt5_he_co_quan_ma_he");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50102,
                column: "SqlColumnName",
                value: "bnt5_he_co_quan_ten_tieng_viet");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50103,
                column: "SqlColumnName",
                value: "bnt5_he_co_quan_ten_tieng_anh");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50104,
                column: "SqlColumnName",
                value: "bnt5_he_co_quan_mo_ta");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50105,
                column: "SqlColumnName",
                value: "bnt5_he_co_quan_sap_xep");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50106,
                column: "SqlColumnName",
                value: "bnt5_he_co_quan_phien_ban");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50107,
                column: "SqlColumnName",
                value: "bnt5_he_co_quan_trang_thai");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50201,
                column: "SqlColumnName",
                value: "bnt5_cau_truc_sinh_hoc_he_co_quan_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50202,
                column: "SqlColumnName",
                value: "bnt5_cau_truc_sinh_hoc_ma_cau_truc");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50203,
                column: "SqlColumnName",
                value: "bnt5_cau_truc_sinh_hoc_ten_tieng_viet");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50204,
                column: "SqlColumnName",
                value: "bnt5_cau_truc_sinh_hoc_ten_tieng_anh");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50205,
                column: "SqlColumnName",
                value: "bnt5_cau_truc_sinh_hoc_cau_truc_cha_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50206,
                column: "SqlColumnName",
                value: "bnt5_cau_truc_sinh_hoc_mo_ta");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50207,
                column: "SqlColumnName",
                value: "bnt5_cau_truc_sinh_hoc_cap_do_phan_cap");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50301,
                column: "SqlColumnName",
                value: "bnt5_chat_tin_hieu_cau_truc_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50302,
                column: "SqlColumnName",
                value: "bnt5_chat_tin_hieu_ma_chattin_hieu");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50303,
                column: "SqlColumnName",
                value: "bnt5_chat_tin_hieu_ten_tv");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50304,
                column: "SqlColumnName",
                value: "bnt5_chat_tin_hieu_don_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50305,
                column: "SqlColumnName",
                value: "bnt5_chat_tin_hieu_gioi_han_bt");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50306,
                column: "SqlColumnName",
                value: "bnt5_chat_tin_hieu_loai_tin_hieu");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50401,
                column: "SqlColumnName",
                value: "bnt5_dm_xet_nghiem_ma_xet_nghiem");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50402,
                column: "SqlColumnName",
                value: "bnt5_dm_xet_nghiem_ten_xet_nghiem");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50403,
                column: "SqlColumnName",
                value: "bnt5_dm_xet_nghiem_ten_tieng_anh");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50404,
                column: "SqlColumnName",
                value: "bnt5_dm_xet_nghiem_phuong_phap_do");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50405,
                column: "SqlColumnName",
                value: "bnt5_dm_xet_nghiem_loai_mau");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50406,
                column: "SqlColumnName",
                value: "bnt5_dm_xet_nghiem_gia_thanh_cost");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50501,
                column: "SqlColumnName",
                value: "bnt5_khoang_tham_chieu_xet_nghiem_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50502,
                column: "SqlColumnName",
                value: "bnt5_khoang_tham_chieu_do_tuoi_min");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50503,
                column: "SqlColumnName",
                value: "bnt5_khoang_tham_chieu_do_tuoi_max");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50504,
                column: "SqlColumnName",
                value: "bnt5_khoang_tham_chieu_gioi_tinh");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50505,
                column: "SqlColumnName",
                value: "bnt5_khoang_tham_chieu_can_duoi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50506,
                column: "SqlColumnName",
                value: "bnt5_khoang_tham_chieu_can_tren");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50507,
                column: "SqlColumnName",
                value: "bnt5_khoang_tham_chieu_nguy_hiem_low");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50508,
                column: "SqlColumnName",
                value: "bnt5_khoang_tham_chieu_nguy_hiem_high");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50601,
                column: "SqlColumnName",
                value: "bnt5_chi_dinh_do_luong_benh_nhan_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50602,
                column: "SqlColumnName",
                value: "bnt5_chi_dinh_do_luong_xet_nghiem_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50603,
                column: "SqlColumnName",
                value: "bnt5_chi_dinh_do_luong_ngay_yeu_cau");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50604,
                column: "SqlColumnName",
                value: "bnt5_chi_dinh_do_luong_do_uu_tien");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50605,
                column: "SqlColumnName",
                value: "bnt5_chi_dinh_do_luong_trang_thai");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50701,
                column: "SqlColumnName",
                value: "bnt5_ket_qua_do_luong_phieu_chi_dinh_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50702,
                column: "SqlColumnName",
                value: "bnt5_ket_qua_do_luong_gia_tri_do_duoc");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50703,
                column: "SqlColumnName",
                value: "bnt5_ket_qua_do_luong_don_vi_thuc_te");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50704,
                column: "SqlColumnName",
                value: "bnt5_ket_qua_do_luong_ngay_co_ket_qua");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50705,
                column: "SqlColumnName",
                value: "bnt5_ket_qua_do_luong_danh_gia_flag");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50801,
                column: "SqlColumnName",
                value: "bnt5_context_sinh_hoa_ket_qua_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50802,
                column: "SqlColumnName",
                value: "bnt5_context_sinh_hoa_do_ph");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50803,
                column: "SqlColumnName",
                value: "bnt5_context_sinh_hoa_ion_balance");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50901,
                column: "SqlColumnName",
                value: "bnt5_context_sinh_hieu_ket_qua_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50902,
                column: "SqlColumnName",
                value: "bnt5_context_sinh_hieu_huyet_ap");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50903,
                column: "SqlColumnName",
                value: "bnt5_context_sinh_hieu_nhip_tim");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50904,
                column: "SqlColumnName",
                value: "bnt5_context_sinh_hieu_spo2");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51001,
                column: "SqlColumnName",
                value: "bnt5_context_te_bao_ket_qua_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51002,
                column: "SqlColumnName",
                value: "bnt5_context_te_bao_so_luong_tb");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51101,
                column: "SqlColumnName",
                value: "bnt5_context_hinh_anh_ket_qua_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51102,
                column: "SqlColumnName",
                value: "bnt5_context_hinh_anh_duong_dan_file");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51103,
                column: "SqlColumnName",
                value: "bnt5_context_hinh_anh_vi_tri");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51201,
                column: "SqlColumnName",
                value: "bnt5_context_dien_sinh_ly_ket_qua_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51202,
                column: "SqlColumnName",
                value: "bnt5_context_dien_sinh_ly_tan_so_dien");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51203,
                column: "SqlColumnName",
                value: "bnt5_context_dien_sinh_ly_waveform_file");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51301,
                column: "SqlColumnName",
                value: "bnt5_lien_ket_xet_nghiem_xet_nghiem_goc_from");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51302,
                column: "SqlColumnName",
                value: "bnt5_lien_ket_xet_nghiem_xet_nghiem_dich_to");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51303,
                column: "SqlColumnName",
                value: "bnt5_lien_ket_xet_nghiem_loai_lien_ket");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51304,
                column: "SqlColumnName",
                value: "bnt5_lien_ket_xet_nghiem_do_tin_cay");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51401,
                column: "SqlColumnName",
                value: "bnt5_quy_tac_canh_bao_xn_ma_quy_tac");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51402,
                column: "SqlColumnName",
                value: "bnt5_quy_tac_canh_bao_xn_bieu_thuc_dieu_kien");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51403,
                column: "SqlColumnName",
                value: "bnt5_quy_tac_canh_bao_xn_canh_bao_message");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51404,
                column: "SqlColumnName",
                value: "bnt5_quy_tac_canh_bao_xn_nhom_xn_khuyen_giai_json");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "SqlTableName",
                value: "bnt4_nhom_duoc_ly");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "SqlTableName",
                value: "bnt4_hoat_chat");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                column: "SqlTableName",
                value: "bnt4_di_ung_cheo");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4,
                column: "SqlTableName",
                value: "bnt4_tuong_tac_thuoc");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5,
                column: "SqlTableName",
                value: "bnt4_di_ung_benh_nhan");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6,
                column: "SqlTableName",
                value: "bnt4_benh_nen");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7,
                column: "SqlTableName",
                value: "bnt4_quy_tac_canh_bao");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8,
                column: "SqlTableName",
                value: "bnt4_nhat_ky_canh_bao");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 101,
                column: "SqlTableName",
                value: "bnt5_he_co_quan");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 102,
                column: "SqlTableName",
                value: "bnt5_cau_truc_sinh_hoc");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 103,
                column: "SqlTableName",
                value: "bnt5_chat_tin_hieu");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 104,
                column: "SqlTableName",
                value: "bnt5_dm_xet_nghiem");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 105,
                column: "SqlTableName",
                value: "bnt5_khoang_tham_chieu");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 106,
                column: "SqlTableName",
                value: "bnt5_chi_dinh_do_luong");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 107,
                column: "SqlTableName",
                value: "bnt5_ket_qua_do_luong");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 108,
                column: "SqlTableName",
                value: "bnt5_context_sinh_hoa");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 109,
                column: "SqlTableName",
                value: "bnt5_context_sinh_hieu");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 110,
                column: "SqlTableName",
                value: "bnt5_context_te_bao");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 111,
                column: "SqlTableName",
                value: "bnt5_context_hinh_anh");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 112,
                column: "SqlTableName",
                value: "bnt5_context_dien_sinh_ly");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 113,
                column: "SqlTableName",
                value: "bnt5_lien_ket_xet_nghiem");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 114,
                column: "SqlTableName",
                value: "bnt5_quy_tac_canh_bao_xn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 40101,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40102,
                column: "SqlColumnName",
                value: "name_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40103,
                column: "SqlColumnName",
                value: "name_en");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40104,
                column: "SqlColumnName",
                value: "parent_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40105,
                column: "SqlColumnName",
                value: "bio_target");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40106,
                column: "SqlColumnName",
                value: "mechanism_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40107,
                column: "SqlColumnName",
                value: "mechanism_en");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40108,
                column: "SqlColumnName",
                value: "chemical_structure");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40109,
                column: "SqlColumnName",
                value: "version");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40110,
                column: "SqlColumnName",
                value: "status");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40201,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40202,
                column: "SqlColumnName",
                value: "name_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40203,
                column: "SqlColumnName",
                value: "name_en");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40204,
                column: "SqlColumnName",
                value: "group_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40205,
                column: "SqlColumnName",
                value: "atc_code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40206,
                column: "SqlColumnName",
                value: "molecular_formula");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40207,
                column: "SqlColumnName",
                value: "molecular_weight");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40208,
                column: "SqlColumnName",
                value: "half_life");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40209,
                column: "SqlColumnName",
                value: "bioavailability");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40210,
                column: "SqlColumnName",
                value: "version");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40211,
                column: "SqlColumnName",
                value: "status");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40301,
                column: "SqlColumnName",
                value: "substance_from_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40302,
                column: "SqlColumnName",
                value: "substance_to_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40303,
                column: "SqlColumnName",
                value: "severity");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40304,
                column: "SqlColumnName",
                value: "description");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40305,
                column: "SqlColumnName",
                value: "evidence_level");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40306,
                column: "SqlColumnName",
                value: "created_at");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40401,
                column: "SqlColumnName",
                value: "drug1_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40402,
                column: "SqlColumnName",
                value: "drug2_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40403,
                column: "SqlColumnName",
                value: "effect");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40404,
                column: "SqlColumnName",
                value: "severity");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40405,
                column: "SqlColumnName",
                value: "management");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40406,
                column: "SqlColumnName",
                value: "evidence");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40501,
                column: "SqlColumnName",
                value: "patient_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40502,
                column: "SqlColumnName",
                value: "substance_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40503,
                column: "SqlColumnName",
                value: "severity");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40504,
                column: "SqlColumnName",
                value: "reaction_type");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40505,
                column: "SqlColumnName",
                value: "onset_date");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40506,
                column: "SqlColumnName",
                value: "resolved");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40507,
                column: "SqlColumnName",
                value: "notes");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40601,
                column: "SqlColumnName",
                value: "patient_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40602,
                column: "SqlColumnName",
                value: "condition_code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40603,
                column: "SqlColumnName",
                value: "diagnosed_at");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40604,
                column: "SqlColumnName",
                value: "severity_level");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40605,
                column: "SqlColumnName",
                value: "status");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40606,
                column: "SqlColumnName",
                value: "notes");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40701,
                column: "SqlColumnName",
                value: "rule_code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40702,
                column: "SqlColumnName",
                value: "description");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40703,
                column: "SqlColumnName",
                value: "severity");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40704,
                column: "SqlColumnName",
                value: "action");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40705,
                column: "SqlColumnName",
                value: "trigger_condition");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40706,
                column: "SqlColumnName",
                value: "applicable_age_min");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40707,
                column: "SqlColumnName",
                value: "applicable_age_max");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40708,
                column: "SqlColumnName",
                value: "applicable_gender");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40801,
                column: "SqlColumnName",
                value: "patient_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40802,
                column: "SqlColumnName",
                value: "prescription_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40803,
                column: "SqlColumnName",
                value: "rule_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40804,
                column: "SqlColumnName",
                value: "drug_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 40805,
                column: "SqlColumnName",
                value: "action_taken");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50101,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50102,
                column: "SqlColumnName",
                value: "name_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50103,
                column: "SqlColumnName",
                value: "name_en");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50104,
                column: "SqlColumnName",
                value: "description");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50105,
                column: "SqlColumnName",
                value: "sort_order");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50106,
                column: "SqlColumnName",
                value: "version");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50107,
                column: "SqlColumnName",
                value: "status");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50201,
                column: "SqlColumnName",
                value: "system_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50202,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50203,
                column: "SqlColumnName",
                value: "name_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50204,
                column: "SqlColumnName",
                value: "name_en");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50205,
                column: "SqlColumnName",
                value: "parent_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50206,
                column: "SqlColumnName",
                value: "description");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50207,
                column: "SqlColumnName",
                value: "level");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50301,
                column: "SqlColumnName",
                value: "structure_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50302,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50303,
                column: "SqlColumnName",
                value: "name_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50304,
                column: "SqlColumnName",
                value: "unit");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50305,
                column: "SqlColumnName",
                value: "normal_range");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50306,
                column: "SqlColumnName",
                value: "type");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50401,
                column: "SqlColumnName",
                value: "code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50402,
                column: "SqlColumnName",
                value: "name_vi");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50403,
                column: "SqlColumnName",
                value: "name_en");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50404,
                column: "SqlColumnName",
                value: "method");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50405,
                column: "SqlColumnName",
                value: "sample_type");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50406,
                column: "SqlColumnName",
                value: "cost");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50501,
                column: "SqlColumnName",
                value: "test_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50502,
                column: "SqlColumnName",
                value: "age_min");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50503,
                column: "SqlColumnName",
                value: "age_max");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50504,
                column: "SqlColumnName",
                value: "gender");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50505,
                column: "SqlColumnName",
                value: "low");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50506,
                column: "SqlColumnName",
                value: "high");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50507,
                column: "SqlColumnName",
                value: "critical_low");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50508,
                column: "SqlColumnName",
                value: "critical_high");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50601,
                column: "SqlColumnName",
                value: "patient_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50602,
                column: "SqlColumnName",
                value: "test_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50603,
                column: "SqlColumnName",
                value: "order_date");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50604,
                column: "SqlColumnName",
                value: "priority");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50605,
                column: "SqlColumnName",
                value: "status");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50701,
                column: "SqlColumnName",
                value: "order_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50702,
                column: "SqlColumnName",
                value: "result_value");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50703,
                column: "SqlColumnName",
                value: "unit");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50704,
                column: "SqlColumnName",
                value: "result_date");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50705,
                column: "SqlColumnName",
                value: "flags");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50801,
                column: "SqlColumnName",
                value: "result_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50802,
                column: "SqlColumnName",
                value: "ph");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50803,
                column: "SqlColumnName",
                value: "ion_balance");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50901,
                column: "SqlColumnName",
                value: "result_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50902,
                column: "SqlColumnName",
                value: "blood_pressure");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50903,
                column: "SqlColumnName",
                value: "heart_rate");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 50904,
                column: "SqlColumnName",
                value: "oxygen_sat");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51001,
                column: "SqlColumnName",
                value: "result_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51002,
                column: "SqlColumnName",
                value: "cell_count");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51101,
                column: "SqlColumnName",
                value: "result_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51102,
                column: "SqlColumnName",
                value: "image_file");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51103,
                column: "SqlColumnName",
                value: "modality");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51201,
                column: "SqlColumnName",
                value: "result_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51202,
                column: "SqlColumnName",
                value: "frequency");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51203,
                column: "SqlColumnName",
                value: "waveform");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51301,
                column: "SqlColumnName",
                value: "test_from_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51302,
                column: "SqlColumnName",
                value: "test_to_id");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51303,
                column: "SqlColumnName",
                value: "relation_type");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51304,
                column: "SqlColumnName",
                value: "strength");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51401,
                column: "SqlColumnName",
                value: "rule_code");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51402,
                column: "SqlColumnName",
                value: "condition");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51403,
                column: "SqlColumnName",
                value: "message");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 51404,
                column: "SqlColumnName",
                value: "suggested_tests");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt4_nhduly", "nhomduocly" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt4_hoatch", "hoatchat" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt4_ducheo", "diungcheo" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt4_tuatac", "tuongtacthuoc" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt4_diungb", "diungbenhnhan" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt4_bnenan", "benhnen" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt4_qtcanh", "quytaccanhbao" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt4_nkcbao", "nhatkycanhbao" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_hecqua", "hecoquan" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_cautru", "cautruc" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_chatin", "chatinhieu" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_dmxngh", "dmxnghiem" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_ktchie", "ktchieucu" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_ychidi", "ychidinh" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_ketqua", "ketqua" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_cshoah", "csinhhoa" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_cshieu", "cshieusinh" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_ctebao", "ctebao" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_hhaanh", "chinhanh" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_dsnlyl", "diensinhly" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_xnlqua", "xnlienquan" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "SqlTableName", "TableNameFull" },
                values: new object[] { "bnt5_qtcbxn", "qtcbxn" });
        }
    }
}
