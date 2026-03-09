# Seed Data Structure — Tầng 4 & Tầng 5

> S&H Schema Builder — Seed data reference for Tier 4 (Dược học) and Tier 5 (Sinh học)

---

## Tầng 4: Dược học (Pharmacology)

### Cấu trúc cây phân cấp

```
Tầng 4
├── Danh mục dược học (ID: 401, parent category)
│   ├── DRUG_GROUP (Nhóm dược lý)              → bnt4_nhduly   (ID: 1,  10 attrs)
│   ├── DRUG_SUBSTANCE (Hoạt chất)             → bnt4_hoatch   (ID: 2,  11 attrs)
│   ├── CROSS_REACTIVITY (Dị ứng chéo)         → bnt4_ducheo   (ID: 3,   7 attrs)
│   └── DRUG_INTERACTION (Tương tác thuốc)     → bnt4_tuatac   (ID: 4,   8 attrs)
├── Dữ liệu dược học bệnh nhân (ID: 402, parent category)
│   ├── PATIENT_ALLERGY (Dị ứng ADR)           → bnt4_diungb   (ID: 5,   9 attrs)
│   └── PATIENT_CONDITION (Bệnh nền)           → bnt4_bnenan   (ID: 6,   8 attrs)
└── Cảnh báo & Lịch sử dược (ID: 403, parent category)
    ├── DRUG_ALERT_RULE (Quy tắc cảnh báo)     → bnt4_qtcanh   (ID: 7,   9 attrs)
    └── ALERT_LOG (Lịch sử cảnh báo)           → bnt4_nkcbao   (ID: 8,  11 attrs)
```

### Chi tiết thuộc tính

#### G1: DRUG_GROUP — Nhóm Dược Lý (`bnt4_nhduly` / TableNameFull: `nhomduocly`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 40101 | Mã nhóm | bnt4_nhomduocly_manhom | VARCHAR(50) | Yes | | |
| 40102 | Tên tiếng Việt | bnt4_nhomduocly_tentiengviet | NVARCHAR(200) | Yes | | |
| 40103 | Tên tiếng Anh | bnt4_nhomduocly_tentienganh | NVARCHAR(200) | Yes | | |
| 40104 | Nhóm cha | bnt4_nhomduocly_nhomcha | REF | No | | bnt4_nhduly(Id) |
| 40105 | Mục tiêu sinh học | bnt4_nhomduocly_muctieusinhhoc | NVARCHAR(MAX) | No | | |
| 40106 | Cơ chế TV | bnt4_nhomduocly_cochetv | NVARCHAR(MAX) | No | | |
| 40107 | Cơ chế TA | bnt4_nhomduocly_cocheta | NVARCHAR(MAX) | No | | |
| 40108 | Cấu trúc hóa học | bnt4_nhomduocly_cautruchoahoc | VARCHAR(100) | No | | |
| 40109 | Phiên bản | bnt4_nhomduocly_phienban | VARCHAR(10) | No | '1.0' | |
| 40110 | Trạng thái | bnt4_nhomduocly_trangthai | VARCHAR(20) | No | 'ACTIVE' | |

#### G2: DRUG_SUBSTANCE — Hoạt Chất (`bnt4_hoatch` / TableNameFull: `hoatchat`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 40201 | Mã hoạt chất | bnt4_hoatchat_mahoatchat | VARCHAR(50) | Yes | | |
| 40202 | Tên tiếng Việt | bnt4_hoatchat_tentiengviet | NVARCHAR(200) | Yes | | |
| 40203 | Tên tiếng Anh | bnt4_hoatchat_tentienganh | NVARCHAR(200) | Yes | | |
| 40204 | Nhóm dược lý | bnt4_hoatchat_nhomduocly | REF | Yes | | bnt4_nhduly(Id) |
| 40205 | Mã ATC | bnt4_hoatchat_maatc | VARCHAR(20) | No | | |
| 40206 | Công thức phân tử | bnt4_hoatchat_congthucphantu | VARCHAR(100) | No | | |
| 40207 | Khối lượng phân tử | bnt4_hoatchat_khoiluongphantu | DECIMAL(10,4) | No | | |
| 40208 | Thời gian bán thải | bnt4_hoatchat_thoigianbanthai | VARCHAR(50) | No | | |
| 40209 | Sinh khả dụng | bnt4_hoatchat_sinhkhadung | DECIMAL(5,2) | No | | |
| 40210 | Phiên bản | bnt4_hoatchat_phienban | VARCHAR(10) | No | '1.0' | |
| 40211 | Trạng thái | bnt4_hoatchat_trangthai | VARCHAR(20) | No | 'ACTIVE' | |

#### G3: CROSS_REACTIVITY — Dị Ứng Chéo (`bnt4_ducheo` / TableNameFull: `duungcheo`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 40301 | Chất nguồn | bnt4_duungcheo_chatnguon | REF | Yes | | bnt4_hoatch(Id) |
| 40302 | Chất nhận | bnt4_duungcheo_chatnhan | REF | Yes | | bnt4_hoatch(Id) |
| 40303 | Mức độ | bnt4_duungcheo_mucdo | VARCHAR(20) | Yes | | |
| 40304 | Mô tả | bnt4_duungcheo_mota | NVARCHAR(MAX) | No | | |
| 40305 | Mức bằng chứng | bnt4_duungcheo_mucbangchung | VARCHAR(20) | No | | |
| 40306 | Ngày tạo | bnt4_duungcheo_ngaytao | DATETIME | No | GETDATE() | |
| 40307 | Ngày cập nhật | bnt4_duungcheo_ngaycapnhat | DATETIME | No | | |

#### G4: DRUG_INTERACTION — Tương Tác Thuốc (`bnt4_tuatac` / TableNameFull: `tuongtacthuoc`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 40401 | Thuốc 1 | bnt4_tuongtacthuoc_thuoc1 | REF | Yes | | bnt4_hoatch(Id) |
| 40402 | Thuốc 2 | bnt4_tuongtacthuoc_thuoc2 | REF | Yes | | bnt4_hoatch(Id) |
| 40403 | Tác dụng | bnt4_tuongtacthuoc_tacdung | NVARCHAR(MAX) | Yes | | |
| 40404 | Mức độ | bnt4_tuongtacthuoc_mucdo | VARCHAR(20) | Yes | | |
| 40405 | Xử trí | bnt4_tuongtacthuoc_xutri | NVARCHAR(MAX) | No | | |
| 40406 | Bằng chứng | bnt4_tuongtacthuoc_bangchung | NVARCHAR(MAX) | No | | |
| 40407 | Phiên bản | bnt4_tuongtacthuoc_phienban | VARCHAR(10) | No | '1.0' | |
| 40408 | Trạng thái | bnt4_tuongtacthuoc_trangthai | VARCHAR(20) | No | 'ACTIVE' | |

#### G5: PATIENT_ALLERGY — Dị Ứng ADR (`bnt4_diungb` / TableNameFull: `diungb`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 40501 | Mã bệnh nhân | bnt4_diungb_mabenhnhan | REF | Yes | | Patient(Id) |
| 40502 | Hoạt chất | bnt4_diungb_hoatchat | REF | Yes | | bnt4_hoatch(Id) |
| 40503 | Mức độ | bnt4_diungb_mucdo | VARCHAR(20) | Yes | | |
| 40504 | Ngày khởi phát | bnt4_diungb_ngaykhoiphat | DATE | No | | |
| 40505 | Loại phản ứng | bnt4_diungb_loaiphanung | VARCHAR(50) | No | | |
| 40506 | Đã khỏi | bnt4_diungb_dakhoi | BIT | No | 0 | |
| 40507 | Ghi chú | bnt4_diungb_ghichu | NVARCHAR(MAX) | No | | |
| 40508 | Xác nhận bởi | bnt4_diungb_xacnhanboi | REF | No | | AspNetUsers(Id) |
| 40509 | Ngày xác nhận | bnt4_diungb_ngayxacnhan | DATETIME | No | | |

#### G6: PATIENT_CONDITION — Bệnh Nền (`bnt4_bnenan` / TableNameFull: `bnenan`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 40601 | Mã bệnh nhân | bnt4_bnenan_mabenhnhan | REF | Yes | | Patient(Id) |
| 40602 | Mã ICD | bnt4_bnenan_maicd | VARCHAR(20) | Yes | | |
| 40603 | Ngày chẩn đoán | bnt4_bnenan_ngaychandoan | DATE | No | | |
| 40604 | Chẩn đoán bởi | bnt4_bnenan_chandoanboi | REF | No | | AspNetUsers(Id) |
| 40605 | Mức độ | bnt4_bnenan_mucdo | VARCHAR(20) | No | | |
| 40606 | Trạng thái | bnt4_bnenan_trangthai | VARCHAR(20) | No | 'ACTIVE' | |
| 40607 | Ghi chú | bnt4_bnenan_ghichu | NVARCHAR(MAX) | No | | |
| 40608 | Ngày tạo | bnt4_bnenan_ngaytao | DATETIME | No | GETDATE() | |

#### G7: DRUG_ALERT_RULE — Quy Tắc Cảnh Báo (`bnt4_qtcanh` / TableNameFull: `qtcanh`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 40701 | Mã quy tắc | bnt4_qtcanh_maquytac | VARCHAR(50) | Yes | | |
| 40702 | Mô tả | bnt4_qtcanh_mota | NVARCHAR(MAX) | Yes | | |
| 40703 | Mức độ | bnt4_qtcanh_mucdo | VARCHAR(20) | Yes | | |
| 40704 | Hành động | bnt4_qtcanh_hanhdong | VARCHAR(50) | Yes | | |
| 40705 | Điều kiện kích hoạt | bnt4_qtcanh_dieukienkichhoat | NVARCHAR(MAX) | No | | |
| 40706 | Tuổi tối thiểu | bnt4_qtcanh_tuoitoithieu | INT | No | | |
| 40707 | Tuổi tối đa | bnt4_qtcanh_tuoitoida | INT | No | | |
| 40708 | Giới tính | bnt4_qtcanh_gioitinh | VARCHAR(10) | No | | |
| 40709 | Phiên bản | bnt4_qtcanh_phienban | VARCHAR(10) | No | '1.0' | |

#### G8: ALERT_LOG — Lịch Sử Cảnh Báo (`bnt4_nkcbao` / TableNameFull: `nkcbao`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 40801 | Mã bệnh nhân | bnt4_nkcbao_mabenhnhan | REF | Yes | | Patient(Id) |
| 40802 | Đơn thuốc | bnt4_nkcbao_donthuoc | INT | Yes | | |
| 40803 | Quy tắc | bnt4_nkcbao_quytac | REF | Yes | | bnt4_qtcanh(Id) |
| 40804 | Mã thuốc | bnt4_nkcbao_mathuoc | VARCHAR(20) | No | | |
| 40805 | Mức độ | bnt4_nkcbao_mucdo | VARCHAR(20) | Yes | | |
| 40806 | Hành động xử trí | bnt4_nkcbao_hanhdongxutri | VARCHAR(50) | No | | |
| 40807 | Xác nhận bởi | bnt4_nkcbao_xacnhanboi | REF | No | | AspNetUsers(Id) |
| 40808 | Ghi chú xác nhận | bnt4_nkcbao_ghichuxacnhan | NVARCHAR(MAX) | No | | |
| 40809 | Xem xét bởi | bnt4_nkcbao_xemxetboi | REF | No | | AspNetUsers(Id) |
| 40810 | Ngày xem xét | bnt4_nkcbao_ngayxemxet | DATETIME | No | | |
| 40811 | Thời gian | bnt4_nkcbao_thoigian | DATETIME | No | GETDATE() | |

---

## Tầng 5: Sinh học (Biology / Measurements)

### Cấu trúc cây phân cấp

```
Tầng 5
├── Danh mục gốc sinh học (ID: 501, parent category)
│   ├── BIO_SYSTEM (Hệ cơ quan)              → bnt5_hecoquan     (ID: 101,  9 attrs)
│   ├── BIO_STRUCTURE (Cấu trúc sinh học)    → bnt5_cautruc      (ID: 102,  9 attrs)
│   └── BIO_SUBSTANCE (Chất / Tín hiệu)      → bnt5_chatinhieu   (ID: 103, 10 attrs)
├── Danh mục xét nghiệm & tham chiếu (ID: 502, parent category)
│   ├── TEST_CATALOG (Danh mục XN)           → bnt5_dmxnghiem    (ID: 104, 10 attrs)
│   └── REF_RANGE (Khoảng tham chiếu)        → bnt5_ktchieucu    (ID: 105, 12 attrs)
├── Dữ liệu đo lường bệnh nhân (ID: 503, parent category)
│   ├── MEASUREMENT_ORDER (Lệnh chỉ định)    → bnt5_ychidinh     (ID: 106,  8 attrs)
│   └── MEASUREMENT_RESULT (Kết quả đo lường)→ bnt5_ketqua       (ID: 107,  9 attrs)
├── Context đặc thù theo loại XN (ID: 504, parent category)
│   ├── CTX_CHEMICAL (Sinh hóa)              → bnt5_csinhhoa     (ID: 108,  5 attrs)
│   ├── CTX_VITAL_SIGN (Sinh hiệu)           → bnt5_cshieusinh   (ID: 109,  7 attrs)
│   ├── CTX_CELL (Tế bào)                    → bnt5_ctebao       (ID: 110,  5 attrs)
│   ├── CTX_IMAGE (Hình ảnh)                 → bnt5_chinhanh     (ID: 111,  6 attrs)
│   └── CTX_ELECTRICAL (Điện sinh lý)        → bnt5_diensinhly   (ID: 112,  6 attrs)
└── Liên kết thông minh & Cảnh báo XN (ID: 505, parent category)
    ├── TEST_RELATION (XN liên quan)         → bnt5_xnlienquan   (ID: 113,  5 attrs)
    └── ALERT_RULE (Cảnh báo XN)             → bnt5_qtcbxn       (ID: 114,  8 attrs)
```

### Chi tiết thuộc tính

#### G101: BIO_SYSTEM — Hệ Cơ Quan (`bnt5_hecoquan` / TableNameFull: `hecoquan`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50101 | Mã hệ | bnt5_hecoquan_mahe | VARCHAR(50) | Yes | | |
| 50102 | Tên tiếng Việt | bnt5_hecoquan_tentiengviet | NVARCHAR(200) | Yes | | |
| 50103 | Tên tiếng Anh | bnt5_hecoquan_tentienganh | NVARCHAR(200) | Yes | | |
| 50104 | Mô tả | bnt5_hecoquan_mota | NVARCHAR(MAX) | No | | |
| 50105 | Thứ tự sắp xếp | bnt5_hecoquan_thutusapxep | INT | No | 0 | |
| 50106 | Phiên bản | bnt5_hecoquan_phienban | VARCHAR(10) | No | '1.0' | |
| 50107 | Trạng thái | bnt5_hecoquan_trangthai | VARCHAR(20) | No | 'ACTIVE' | |
| 50108 | Ngày tạo | bnt5_hecoquan_ngaytao | DATETIME | No | GETDATE() | |
| 50109 | Ngày cập nhật | bnt5_hecoquan_ngaycapnhat | DATETIME | No | | |

#### G102: BIO_STRUCTURE — Cấu Trúc Sinh Học (`bnt5_cautruc` / TableNameFull: `cautruc`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50201 | Hệ cơ quan | bnt5_cautruc_hecoquan | REF | Yes | | bnt5_hecoquan(Id) |
| 50202 | Mã cấu trúc | bnt5_cautruc_macautruc | VARCHAR(50) | Yes | | |
| 50203 | Tên tiếng Việt | bnt5_cautruc_tentiengviet | NVARCHAR(200) | Yes | | |
| 50204 | Tên tiếng Anh | bnt5_cautruc_tentienganh | NVARCHAR(200) | Yes | | |
| 50205 | Cấu trúc cha | bnt5_cautruc_cautruccha | REF | No | | bnt5_cautruc(Id) |
| 50206 | Mô tả | bnt5_cautruc_mota | NVARCHAR(MAX) | No | | |
| 50207 | Cấp độ | bnt5_cautruc_capdo | INT | No | | |
| 50208 | Phiên bản | bnt5_cautruc_phienban | VARCHAR(10) | No | '1.0' | |
| 50209 | Trạng thái | bnt5_cautruc_trangthai | VARCHAR(20) | No | 'ACTIVE' | |

#### G103: BIO_SUBSTANCE — Chất / Tín Hiệu (`bnt5_chatinhieu` / TableNameFull: `chatinhieu`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50301 | Cấu trúc | bnt5_chatinhieu_cautruc | REF | Yes | | bnt5_cautruc(Id) |
| 50302 | Mã chất | bnt5_chatinhieu_machat | VARCHAR(50) | Yes | | |
| 50303 | Tên tiếng Việt | bnt5_chatinhieu_tentiengviet | NVARCHAR(200) | Yes | | |
| 50304 | Tên tiếng Anh | bnt5_chatinhieu_tentienganh | NVARCHAR(200) | Yes | | |
| 50305 | Đơn vị | bnt5_chatinhieu_donvi | VARCHAR(50) | No | | |
| 50306 | Khoảng bình thường | bnt5_chatinhieu_khoangbinhthuong | NVARCHAR(100) | No | | |
| 50307 | Mô tả | bnt5_chatinhieu_mota | NVARCHAR(MAX) | No | | |
| 50308 | Loại | bnt5_chatinhieu_loai | VARCHAR(50) | No | | |
| 50309 | Phiên bản | bnt5_chatinhieu_phienban | VARCHAR(10) | No | '1.0' | |
| 50310 | Trạng thái | bnt5_chatinhieu_trangthai | VARCHAR(20) | No | 'ACTIVE' | |

#### G104: TEST_CATALOG — Danh Mục XN (`bnt5_dmxnghiem` / TableNameFull: `dmxnghiem`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50401 | Mã xét nghiệm | bnt5_dmxnghiem_maxetnghiem | VARCHAR(50) | Yes | | |
| 50402 | Tên tiếng Việt | bnt5_dmxnghiem_tentiengviet | NVARCHAR(200) | Yes | | |
| 50403 | Tên tiếng Anh | bnt5_dmxnghiem_tentienganh | NVARCHAR(200) | Yes | | |
| 50404 | Phương pháp | bnt5_dmxnghiem_phuongphap | VARCHAR(50) | No | | |
| 50405 | Loại mẫu | bnt5_dmxnghiem_loaimau | VARCHAR(50) | No | | |
| 50406 | Thời gian trả KQ | bnt5_dmxnghiem_thoigiantrakq | VARCHAR(50) | No | | |
| 50407 | Giá thành | bnt5_dmxnghiem_giathanh | DECIMAL(18,2) | No | | |
| 50408 | Mô tả | bnt5_dmxnghiem_mota | NVARCHAR(MAX) | No | | |
| 50409 | Phiên bản | bnt5_dmxnghiem_phienban | VARCHAR(10) | No | '1.0' | |
| 50410 | Trạng thái | bnt5_dmxnghiem_trangthai | VARCHAR(20) | No | 'ACTIVE' | |

#### G105: REF_RANGE — Khoảng Tham Chiếu (`bnt5_ktchieucu` / TableNameFull: `ktchieucu`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50501 | Xét nghiệm | bnt5_ktchieucu_xetnghiem | REF | Yes | | bnt5_dmxnghiem(Id) |
| 50502 | Tuổi tối thiểu | bnt5_ktchieucu_tuoitoithieu | INT | No | | |
| 50503 | Tuổi tối đa | bnt5_ktchieucu_tuoitoida | INT | No | | |
| 50504 | Giới tính | bnt5_ktchieucu_gioitinh | VARCHAR(10) | No | | |
| 50505 | Giá trị thấp | bnt5_ktchieucu_giatrithap | DECIMAL(18,4) | No | | |
| 50506 | Giá trị cao | bnt5_ktchieucu_giatricao | DECIMAL(18,4) | No | | |
| 50507 | Đơn vị | bnt5_ktchieucu_donvi | VARCHAR(50) | No | | |
| 50508 | Nguy kịch thấp | bnt5_ktchieucu_nguykichthap | DECIMAL(18,4) | No | | |
| 50509 | Nguy kịch cao | bnt5_ktchieucu_nguykichcao | DECIMAL(18,4) | No | | |
| 50510 | Ghi chú | bnt5_ktchieucu_ghichu | NVARCHAR(MAX) | No | | |
| 50511 | Phiên bản | bnt5_ktchieucu_phienban | VARCHAR(10) | No | '1.0' | |
| 50512 | Trạng thái | bnt5_ktchieucu_trangthai | VARCHAR(20) | No | 'ACTIVE' | |

#### G106: MEASUREMENT_ORDER — Lệnh Chỉ Định (`bnt5_ychidinh` / TableNameFull: `ychidinh`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50601 | Mã bệnh nhân | bnt5_ychidinh_mabenhnhan | REF | Yes | | Patient(Id) |
| 50602 | Xét nghiệm | bnt5_ychidinh_xetnghiem | REF | Yes | | bnt5_dmxnghiem(Id) |
| 50603 | Ngày chỉ định | bnt5_ychidinh_ngaychidinh | DATETIME | Yes | GETDATE() | |
| 50604 | Chỉ định bởi | bnt5_ychidinh_chidinhboi | REF | No | | AspNetUsers(Id) |
| 50605 | Độ ưu tiên | bnt5_ychidinh_douutien | VARCHAR(20) | No | | |
| 50606 | Trạng thái | bnt5_ychidinh_trangthai | VARCHAR(20) | No | 'PENDING' | |
| 50607 | Ghi chú | bnt5_ychidinh_ghichu | NVARCHAR(MAX) | No | | |
| 50608 | Ngày tạo | bnt5_ychidinh_ngaytao | DATETIME | No | GETDATE() | |

#### G107: MEASUREMENT_RESULT — Kết Quả Đo Lường (`bnt5_ketqua` / TableNameFull: `ketqua`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50701 | Mã chỉ định | bnt5_ketqua_machidinh | REF | Yes | | bnt5_ychidinh(Id) |
| 50702 | Giá trị | bnt5_ketqua_giatri | DECIMAL(18,4) | Yes | | |
| 50703 | Đơn vị | bnt5_ketqua_donvi | VARCHAR(50) | No | | |
| 50704 | Ngày kết quả | bnt5_ketqua_ngayketqua | DATETIME | Yes | | |
| 50705 | Nhận định bởi | bnt5_ketqua_nhandinhboi | REF | No | | AspNetUsers(Id) |
| 50706 | Cờ báo động | bnt5_ketqua_cobaodong | VARCHAR(20) | No | | |
| 50707 | Ghi chú | bnt5_ketqua_ghichu | NVARCHAR(MAX) | No | | |
| 50708 | Phiên bản | bnt5_ketqua_phienban | VARCHAR(10) | No | '1.0' | |
| 50709 | Trạng thái | bnt5_ketqua_trangthai | VARCHAR(20) | No | 'ACTIVE' | |

#### G108: CTX_CHEMICAL — Sinh Hóa (`bnt5_csinhhoa` / TableNameFull: `csinhhoa`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50801 | Mã kết quả | bnt5_csinhhoa_maketqua | REF | Yes | | bnt5_ketqua(Id) |
| 50802 | Độ pH | bnt5_csinhhoa_doph | DECIMAL(5,2) | No | | |
| 50803 | Cân bằng ion | bnt5_csinhhoa_canbangion | DECIMAL(18,4) | No | | |
| 50804 | Nồng độ enzyme | bnt5_csinhhoa_nongdoenzyme | DECIMAL(18,4) | No | | |
| 50805 | Ghi chú | bnt5_csinhhoa_ghichu | NVARCHAR(MAX) | No | | |

#### G109: CTX_VITAL_SIGN — Sinh Hiệu (`bnt5_cshieusinh` / TableNameFull: `cshieusinh`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 50901 | Mã kết quả | bnt5_cshieusinh_maketqua | REF | Yes | | bnt5_ketqua(Id) |
| 50902 | Huyết áp | bnt5_cshieusinh_huyetap | VARCHAR(20) | No | | |
| 50903 | Nhịp tim | bnt5_cshieusinh_nhiptim | INT | No | | |
| 50904 | Nhiệt độ | bnt5_cshieusinh_nhietdo | DECIMAL(5,2) | No | | |
| 50905 | Nhịp thở | bnt5_cshieusinh_nhiptho | INT | No | | |
| 50906 | SPO2 | bnt5_cshieusinh_spo2 | DECIMAL(5,2) | No | | |
| 50907 | Ghi chú | bnt5_cshieusinh_ghichu | NVARCHAR(MAX) | No | | |

#### G110: CTX_CELL — Tế Bào (`bnt5_ctebao` / TableNameFull: `ctebao`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 51001 | Mã kết quả | bnt5_ctebao_maketqua | REF | Yes | | bnt5_ketqua(Id) |
| 51002 | Số lượng tế bào | bnt5_ctebao_soluongtebao | INT | No | | |
| 51003 | Hình thái | bnt5_ctebao_hinhthai | VARCHAR(50) | No | | |
| 51004 | Markers | bnt5_ctebao_markers | NVARCHAR(MAX) | No | | |
| 51005 | Ghi chú | bnt5_ctebao_ghichu | NVARCHAR(MAX) | No | | |

#### G111: CTX_IMAGE — Hình Ảnh (`bnt5_chinhanh` / TableNameFull: `chinhanh`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 51101 | Mã kết quả | bnt5_chinhanh_maketqua | REF | Yes | | bnt5_ketqua(Id) |
| 51102 | Loại hình | bnt5_chinhanh_loaihinh | VARCHAR(50) | No | | |
| 51103 | Phát hiện | bnt5_chinhanh_phathien | NVARCHAR(MAX) | No | | |
| 51104 | Đường dẫn file | bnt5_chinhanh_duongdanfile | VARCHAR(200) | No | | |
| 51105 | Kích thước | bnt5_chinhanh_kichthuoc | VARCHAR(50) | No | | |
| 51106 | Ghi chú | bnt5_chinhanh_ghichu | NVARCHAR(MAX) | No | | |

#### G112: CTX_ELECTRICAL — Điện Sinh Lý (`bnt5_diensinhly` / TableNameFull: `diensinhly`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 51201 | Mã kết quả | bnt5_diensinhly_maketqua | REF | Yes | | bnt5_ketqua(Id) |
| 51202 | Dạng sóng | bnt5_diensinhly_dangsong | NVARCHAR(MAX) | No | | |
| 51203 | Biên độ | bnt5_diensinhly_biendo | DECIMAL(18,4) | No | | |
| 51204 | Tần số | bnt5_diensinhly_tanso | DECIMAL(18,4) | No | | |
| 51205 | Thời lượng | bnt5_diensinhly_thoiluong | INT | No | | |
| 51206 | Ghi chú | bnt5_diensinhly_ghichu | NVARCHAR(MAX) | No | | |

#### G113: TEST_RELATION — XN Liên Quan (`bnt5_xnlienquan` / TableNameFull: `xnlienquan`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 51301 | XN gốc | bnt5_xnlienquan_xngoc | REF | Yes | | bnt5_dmxnghiem(Id) |
| 51302 | XN đích | bnt5_xnlienquan_xndich | REF | Yes | | bnt5_dmxnghiem(Id) |
| 51303 | Loại liên hệ | bnt5_xnlienquan_loailienhe | VARCHAR(50) | No | | |
| 51304 | Mô tả | bnt5_xnlienquan_mota | NVARCHAR(MAX) | No | | |
| 51305 | Độ mạnh | bnt5_xnlienquan_domanh | DECIMAL(5,2) | No | | |

#### G114: ALERT_RULE — Cảnh Báo XN (`bnt5_qtcbxn` / TableNameFull: `qtcbxn`)

| ID | Name | SqlColumnName | DataType | Required | Default | FK Target |
|----|------|---------------|----------|----------|---------|-----------|
| 51401 | Mã quy tắc | bnt5_qtcbxn_maquytac | VARCHAR(50) | Yes | | |
| 51402 | Điều kiện | bnt5_qtcbxn_dieukien | NVARCHAR(MAX) | Yes | | |
| 51403 | Mức độ | bnt5_qtcbxn_mucdo | VARCHAR(20) | Yes | | |
| 51404 | Thông điệp | bnt5_qtcbxn_thongdiep | NVARCHAR(MAX) | No | | |
| 51405 | XN gợi ý | bnt5_qtcbxn_xngoiy | NVARCHAR(MAX) | No | | |
| 51406 | XN áp dụng | bnt5_qtcbxn_xnapdung | NVARCHAR(MAX) | No | | |
| 51407 | Phiên bản | bnt5_qtcbxn_phienban | VARCHAR(10) | No | '1.0' | |
| 51408 | Trạng thái | bnt5_qtcbxn_trangthai | VARCHAR(20) | No | 'DRAFT' | |

---

## FK Chain Summary

```
Tầng 4:
  DRUG_GROUP.nhomcha              → bnt4_nhduly(Id)        (self-ref)
  DRUG_SUBSTANCE.nhomduocly       → bnt4_nhduly(Id)
  CROSS_REACTIVITY.chatnguon      → bnt4_hoatch(Id)
  CROSS_REACTIVITY.chatnhan       → bnt4_hoatch(Id)
  DRUG_INTERACTION.thuoc1          → bnt4_hoatch(Id)
  DRUG_INTERACTION.thuoc2          → bnt4_hoatch(Id)
  PATIENT_ALLERGY.mabenhnhan       → Patient(Id)
  PATIENT_ALLERGY.hoatchat         → bnt4_hoatch(Id)
  PATIENT_ALLERGY.xacnhanboi      → AspNetUsers(Id)
  PATIENT_CONDITION.mabenhnhan     → Patient(Id)
  PATIENT_CONDITION.chandoanboi    → AspNetUsers(Id)
  ALERT_LOG.mabenhnhan             → Patient(Id)
  ALERT_LOG.quytac                 → bnt4_qtcanh(Id)
  ALERT_LOG.xacnhanboi            → AspNetUsers(Id)
  ALERT_LOG.xemxetboi             → AspNetUsers(Id)

Tầng 5:
  BIO_STRUCTURE.hecoquan           → bnt5_hecoquan(Id)
  BIO_STRUCTURE.cautruccha         → bnt5_cautruc(Id)       (self-ref)
  BIO_SUBSTANCE.cautruc            → bnt5_cautruc(Id)
  REF_RANGE.xetnghiem              → bnt5_dmxnghiem(Id)
  MEASUREMENT_ORDER.mabenhnhan     → Patient(Id)
  MEASUREMENT_ORDER.xetnghiem      → bnt5_dmxnghiem(Id)
  MEASUREMENT_ORDER.chidinhboi     → AspNetUsers(Id)
  MEASUREMENT_RESULT.machidinh     → bnt5_ychidinh(Id)
  MEASUREMENT_RESULT.nhandinhboi   → AspNetUsers(Id)
  CTX_CHEMICAL.maketqua            → bnt5_ketqua(Id)
  CTX_VITAL_SIGN.maketqua          → bnt5_ketqua(Id)
  CTX_CELL.maketqua                → bnt5_ketqua(Id)
  CTX_IMAGE.maketqua               → bnt5_ketqua(Id)
  CTX_ELECTRICAL.maketqua          → bnt5_ketqua(Id)
  TEST_RELATION.xngoc              → bnt5_dmxnghiem(Id)
  TEST_RELATION.xndich             → bnt5_dmxnghiem(Id)
```

---

## Notes

- All core groups and attributes have `IsCore = true`
- Parent category groups (401-403, 501-505) have empty `SqlTableName` and `TableNameFull` -- used only for tree structure
- Naming convention for SqlColumnName: `bnt{tier}_{tableNameFull}_{vietnamese_slug}`
  - Example: `bnt4_nhomduocly_manhom` = tier 4, table "nhomduocly", column "manhom"
  - Example: `bnt5_chatinhieu_khoangbinhthuong` = tier 5, table "chatinhieu", column "khoangbinhthuong"
- SqlTableName uses abbreviated Vietnamese: `bnt4_nhduly`, `bnt5_hecoquan`, etc.
- TableNameFull uses full Vietnamese without diacritics: `nhomduocly`, `hecoquan`, etc.
- REF data type indicates a foreign key column; the target is specified in FkTarget
- External FK targets: `Patient(Id)` and `AspNetUsers(Id)`
- Seed runs once via EF Core `HasData()` in `OnModelCreating`
