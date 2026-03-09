using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tiers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SqlTableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TableNameFull = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cardinality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCore = table.Column<bool>(type: "bit", nullable: false),
                    TierId = table.Column<int>(type: "int", nullable: false),
                    ParentGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_ParentGroupId",
                        column: x => x.ParentGroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Groups_Tiers_TierId",
                        column: x => x.TierId,
                        principalTable: "Tiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SqlColumnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cardinality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DefaultValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkTarget = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHidden = table.Column<bool>(type: "bit", nullable: false),
                    HasPermission = table.Column<bool>(type: "bit", nullable: false),
                    Scope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCore = table.Column<bool>(type: "bit", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attributes_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tiers",
                columns: new[] { "Id", "Color", "Description", "Name", "Nature" },
                values: new object[,]
                {
                    { 1, "#2196F3", "Thông tin không thay đổi (Họ tên, ngày sinh, giới tính...)", "Định danh cá nhân", "Cố định" },
                    { 2, "#4CAF50", "Thông tin pháp lý (CMND/CCCD, hộ chiếu...)", "Pháp lý", "Ít thay đổi" },
                    { 3, "#9C27B0", "Thông tin bảo hiểm, thẻ ưu đãi...", "BHYT & Quyền lợi", "Thay đổi định kỳ" },
                    { 4, "#FF9800", "\"Đặc điểm gốc?\" — Bất biến", "Di truyền", "Bất biến" },
                    { 5, "#F44336", "\"Hiện trạng?\" — Biến động liên tục", "Sinh học biến động", "Biến động liên tục" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Cardinality", "Description", "IsCore", "Name", "ParentGroupId", "SqlTableName", "TableNameFull", "TierId" },
                values: new object[,]
                {
                    { 401, "1:N", "Danh mục gốc về dược phẩm", true, "Danh mục dược học", null, "", "", 4 },
                    { 402, "1:N", "Dữ liệu dược lâm sàng của bệnh nhân", true, "Dữ liệu dược học bệnh nhân", null, "", "", 4 },
                    { 403, "1:N", "Quy tắc cảnh báo và nhật ký dược", true, "Cảnh báo & Lịch sử dược", null, "", "", 4 },
                    { 501, "1:N", "Danh mục gốc về sinh học", true, "Danh mục gốc sinh học", null, "", "", 5 },
                    { 502, "1:N", "Danh mục xét nghiệm và khoảng tham chiếu", true, "Danh mục xét nghiệm & tham chiếu", null, "", "", 5 },
                    { 503, "1:N", "Chỉ định và kết quả đo lường", true, "Dữ liệu đo lường bệnh nhân", null, "", "", 5 },
                    { 504, "1:N", "Bối cảnh chuyên sâu theo loại xét nghiệm", true, "Context đặc thù theo loại XN", null, "", "", 5 },
                    { 505, "1:N", "Liên kết tương quan và quy tắc cảnh báo", true, "Liên kết thông minh & Cảnh báo XN", null, "", "", 5 },
                    { 1, "1:N", "Danh mục nhóm dược lý", true, "DRUG_GROUP (Nhóm dược lý)", 401, "bnt4_nhduly", "nhomduocly", 4 },
                    { 2, "1:N", "Danh mục hoạt chất", true, "DRUG_SUBSTANCE (Hoạt chất)", 401, "bnt4_hoatch", "hoatchat", 4 },
                    { 3, "1:N", "Quy tắc dị ứng chéo", true, "CROSS_REACTIVITY (Dị ứng chéo)", 401, "bnt4_ducheo", "duungcheo", 4 },
                    { 4, "1:N", "Tương tác giữa các hoạt chất", true, "DRUG_INTERACTION (Tương tác thuốc)", 401, "bnt4_tuatac", "tuongtacthuoc", 4 },
                    { 5, "1:N", "Hồ sơ dị ứng của bệnh nhân", true, "PATIENT_ALLERGY (Dị ứng ADR)", 402, "bnt4_diungb", "diungb", 4 },
                    { 6, "1:N", "Bệnh lý nền bất biến", true, "PATIENT_CONDITION (Bệnh nền)", 402, "bnt4_bnenan", "bnenan", 4 },
                    { 7, "1:N", "Bộ quy tắc cảnh báo lâm sàng", true, "DRUG_ALERT_RULE (Quy tắc cảnh báo)", 403, "bnt4_qtcanh", "qtcanh", 4 },
                    { 8, "1:N", "Lịch sử cảnh báo đã phát cho bệnh nhân", true, "ALERT_LOG (Lịch sử cảnh báo)", 403, "bnt4_nkcbao", "nkcbao", 4 },
                    { 101, "1:N", "Hệ cơ quan sinh học", true, "BIO_SYSTEM (Hệ cơ quan)", 501, "bnt5_hecoquan", "hecoquan", 5 },
                    { 102, "1:N", "Cấu trúc chi tiết cơ quan", true, "BIO_STRUCTURE (Cấu trúc sinh học)", 501, "bnt5_cautruc", "cautruc", 5 },
                    { 103, "1:N", "Chất hóa học hoặc tín hiệu đo lường", true, "BIO_SUBSTANCE (Chất / Tín hiệu)", 501, "bnt5_chatinhieu", "chatinhieu", 5 },
                    { 104, "1:N", "Danh mục xét nghiệm đo lường", true, "TEST_CATALOG (Danh mục XN)", 502, "bnt5_dmxnghiem", "dmxnghiem", 5 },
                    { 105, "1:N", "Reference ranges cho XN", true, "REF_RANGE (Khoảng tham chiếu)", 502, "bnt5_ktchieucu", "ktchieucu", 5 },
                    { 106, "1:N", "Y lệnh chỉ định XN", true, "MEASUREMENT_ORDER (Lệnh chỉ định)", 503, "bnt5_ychidinh", "ychidinh", 5 },
                    { 107, "1:N", "Kết quả đo lường sinh học", true, "MEASUREMENT_RESULT (Kết quả đo lường)", 503, "bnt5_ketqua", "ketqua", 5 },
                    { 108, "1:1", "Bối cảnh đo sinh hóa", true, "CTX_CHEMICAL (Sinh hóa)", 504, "bnt5_csinhhoa", "csinhhoa", 5 },
                    { 109, "1:1", "Bối cảnh định kỳ của sinh hiệu", true, "CTX_VITAL_SIGN (Sinh hiệu)", 504, "bnt5_cshieusinh", "cshieusinh", 5 },
                    { 110, "1:1", "Bối cảnh tế bào", true, "CTX_CELL (Tế bào)", 504, "bnt5_ctebao", "ctebao", 5 },
                    { 111, "1:1", "Bối cảnh hình ảnh", true, "CTX_IMAGE (Hình ảnh)", 504, "bnt5_chinhanh", "chinhanh", 5 },
                    { 112, "1:1", "Bối cảnh điện sinh lý", true, "CTX_ELECTRICAL (Điện sinh lý)", 504, "bnt5_diensinhly", "diensinhly", 5 },
                    { 113, "1:N", "Mối liên hệ tương quan giữa các xét nghiệm", true, "TEST_RELATION (XN liên quan)", 505, "bnt5_xnlienquan", "xnlienquan", 5 },
                    { 114, "1:N", "Quy tắc cảnh báo XN sinh học", true, "ALERT_RULE (Cảnh báo XN)", 505, "bnt5_qtcbxn", "qtcbxn", 5 }
                });

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "Cardinality", "DataType", "DefaultValue", "Description", "FkTarget", "GroupId", "HasPermission", "IsCore", "IsHidden", "IsRequired", "Name", "Scope", "SqlColumnName" },
                values: new object[,]
                {
                    { 40101, "1:1", "VARCHAR(50)", null, "", null, 1, false, true, false, true, "Mã nhóm", "System", "bnt4_nhomduocly_manhom" },
                    { 40102, "1:1", "NVARCHAR(200)", null, "", null, 1, false, true, false, true, "Tên tiếng Việt", "System", "bnt4_nhomduocly_tentiengviet" },
                    { 40103, "1:1", "NVARCHAR(200)", null, "", null, 1, false, true, false, true, "Tên tiếng Anh", "System", "bnt4_nhomduocly_tentienganh" },
                    { 40104, "1:1", "REF", null, "", "bnt4_nhduly(Id)", 1, false, true, false, false, "Nhóm cha", "System", "bnt4_nhomduocly_nhomcha" },
                    { 40105, "1:1", "NVARCHAR(MAX)", null, "", null, 1, false, true, false, false, "Mục tiêu sinh học", "System", "bnt4_nhomduocly_muctieusinhhoc" },
                    { 40106, "1:1", "NVARCHAR(MAX)", null, "", null, 1, false, true, false, false, "Cơ chế TV", "System", "bnt4_nhomduocly_cochetv" },
                    { 40107, "1:1", "NVARCHAR(MAX)", null, "", null, 1, false, true, false, false, "Cơ chế TA", "System", "bnt4_nhomduocly_cocheta" },
                    { 40108, "1:1", "VARCHAR(100)", null, "", null, 1, false, true, false, false, "Cấu trúc hóa học", "System", "bnt4_nhomduocly_cautruchoahoc" },
                    { 40109, "1:1", "VARCHAR(10)", "'1.0'", "", null, 1, false, true, false, false, "Phiên bản", "System", "bnt4_nhomduocly_phienban" },
                    { 40110, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 1, false, true, false, false, "Trạng thái", "System", "bnt4_nhomduocly_trangthai" },
                    { 40201, "1:1", "VARCHAR(50)", null, "", null, 2, false, true, false, true, "Mã hoạt chất", "System", "bnt4_hoatchat_mahoatchat" },
                    { 40202, "1:1", "NVARCHAR(200)", null, "", null, 2, false, true, false, true, "Tên tiếng Việt", "System", "bnt4_hoatchat_tentiengviet" },
                    { 40203, "1:1", "NVARCHAR(200)", null, "", null, 2, false, true, false, true, "Tên tiếng Anh", "System", "bnt4_hoatchat_tentienganh" },
                    { 40204, "1:1", "REF", null, "", "bnt4_nhduly(Id)", 2, false, true, false, true, "Nhóm dược lý", "System", "bnt4_hoatchat_nhomduocly" },
                    { 40205, "1:1", "VARCHAR(20)", null, "", null, 2, false, true, false, false, "Mã ATC", "System", "bnt4_hoatchat_maatc" },
                    { 40206, "1:1", "VARCHAR(100)", null, "", null, 2, false, true, false, false, "Công thức phân tử", "System", "bnt4_hoatchat_congthucphantu" },
                    { 40207, "1:1", "DECIMAL(10,4)", null, "", null, 2, false, true, false, false, "Khối lượng phân tử", "System", "bnt4_hoatchat_khoiluongphantu" },
                    { 40208, "1:1", "VARCHAR(50)", null, "", null, 2, false, true, false, false, "Thời gian bán thải", "System", "bnt4_hoatchat_thoigianbanthai" },
                    { 40209, "1:1", "DECIMAL(5,2)", null, "", null, 2, false, true, false, false, "Sinh khả dụng", "System", "bnt4_hoatchat_sinhkhadung" },
                    { 40210, "1:1", "VARCHAR(10)", "'1.0'", "", null, 2, false, true, false, false, "Phiên bản", "System", "bnt4_hoatchat_phienban" },
                    { 40211, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 2, false, true, false, false, "Trạng thái", "System", "bnt4_hoatchat_trangthai" },
                    { 40301, "1:1", "REF", null, "", "bnt4_hoatch(Id)", 3, false, true, false, true, "Chất nguồn", "System", "bnt4_duungcheo_chatnguon" },
                    { 40302, "1:1", "REF", null, "", "bnt4_hoatch(Id)", 3, false, true, false, true, "Chất nhận", "System", "bnt4_duungcheo_chatnhan" },
                    { 40303, "1:1", "VARCHAR(20)", null, "", null, 3, false, true, false, true, "Mức độ", "System", "bnt4_duungcheo_mucdo" },
                    { 40304, "1:1", "NVARCHAR(MAX)", null, "", null, 3, false, true, false, false, "Mô tả", "System", "bnt4_duungcheo_mota" },
                    { 40305, "1:1", "VARCHAR(20)", null, "", null, 3, false, true, false, false, "Mức bằng chứng", "System", "bnt4_duungcheo_mucbangchung" },
                    { 40306, "1:1", "DATETIME", "GETDATE()", "", null, 3, false, true, false, false, "Ngày tạo", "System", "bnt4_duungcheo_ngaytao" },
                    { 40307, "1:1", "DATETIME", null, "", null, 3, false, true, false, false, "Ngày cập nhật", "System", "bnt4_duungcheo_ngaycapnhat" },
                    { 40401, "1:1", "REF", null, "", "bnt4_hoatch(Id)", 4, false, true, false, true, "Thuốc 1", "System", "bnt4_tuongtacthuoc_thuoc1" },
                    { 40402, "1:1", "REF", null, "", "bnt4_hoatch(Id)", 4, false, true, false, true, "Thuốc 2", "System", "bnt4_tuongtacthuoc_thuoc2" },
                    { 40403, "1:1", "NVARCHAR(MAX)", null, "", null, 4, false, true, false, true, "Tác dụng", "System", "bnt4_tuongtacthuoc_tacdung" },
                    { 40404, "1:1", "VARCHAR(20)", null, "", null, 4, false, true, false, true, "Mức độ", "System", "bnt4_tuongtacthuoc_mucdo" },
                    { 40405, "1:1", "NVARCHAR(MAX)", null, "", null, 4, false, true, false, false, "Xử trí", "System", "bnt4_tuongtacthuoc_xutri" },
                    { 40406, "1:1", "NVARCHAR(MAX)", null, "", null, 4, false, true, false, false, "Bằng chứng", "System", "bnt4_tuongtacthuoc_bangchung" },
                    { 40407, "1:1", "VARCHAR(10)", "'1.0'", "", null, 4, false, true, false, false, "Phiên bản", "System", "bnt4_tuongtacthuoc_phienban" },
                    { 40408, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 4, false, true, false, false, "Trạng thái", "System", "bnt4_tuongtacthuoc_trangthai" },
                    { 40501, "1:1", "REF", null, "", "Patient(Id)", 5, false, true, false, true, "Mã bệnh nhân", "System", "bnt4_diungb_mabenhnhan" },
                    { 40502, "1:1", "REF", null, "", "bnt4_hoatch(Id)", 5, false, true, false, true, "Hoạt chất", "System", "bnt4_diungb_hoatchat" },
                    { 40503, "1:1", "VARCHAR(20)", null, "", null, 5, false, true, false, true, "Mức độ", "System", "bnt4_diungb_mucdo" },
                    { 40504, "1:1", "DATE", null, "", null, 5, false, true, false, false, "Ngày khởi phát", "System", "bnt4_diungb_ngaykhoiphat" },
                    { 40505, "1:1", "VARCHAR(50)", null, "", null, 5, false, true, false, false, "Loại phản ứng", "System", "bnt4_diungb_loaiphanung" },
                    { 40506, "1:1", "BIT", "0", "", null, 5, false, true, false, false, "Đã khỏi", "System", "bnt4_diungb_dakhoi" },
                    { 40507, "1:1", "NVARCHAR(MAX)", null, "", null, 5, false, true, false, false, "Ghi chú", "System", "bnt4_diungb_ghichu" },
                    { 40508, "1:1", "REF", null, "", "AspNetUsers(Id)", 5, false, true, false, false, "Xác nhận bởi", "System", "bnt4_diungb_xacnhanboi" },
                    { 40509, "1:1", "DATETIME", null, "", null, 5, false, true, false, false, "Ngày xác nhận", "System", "bnt4_diungb_ngayxacnhan" },
                    { 40601, "1:1", "REF", null, "", "Patient(Id)", 6, false, true, false, true, "Mã bệnh nhân", "System", "bnt4_bnenan_mabenhnhan" },
                    { 40602, "1:1", "VARCHAR(20)", null, "", null, 6, false, true, false, true, "Mã ICD", "System", "bnt4_bnenan_maicd" },
                    { 40603, "1:1", "DATE", null, "", null, 6, false, true, false, false, "Ngày chẩn đoán", "System", "bnt4_bnenan_ngaychandoan" },
                    { 40604, "1:1", "REF", null, "", "AspNetUsers(Id)", 6, false, true, false, false, "Chẩn đoán bởi", "System", "bnt4_bnenan_chandoanboi" },
                    { 40605, "1:1", "VARCHAR(20)", null, "", null, 6, false, true, false, false, "Mức độ", "System", "bnt4_bnenan_mucdo" },
                    { 40606, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 6, false, true, false, false, "Trạng thái", "System", "bnt4_bnenan_trangthai" },
                    { 40607, "1:1", "NVARCHAR(MAX)", null, "", null, 6, false, true, false, false, "Ghi chú", "System", "bnt4_bnenan_ghichu" },
                    { 40608, "1:1", "DATETIME", "GETDATE()", "", null, 6, false, true, false, false, "Ngày tạo", "System", "bnt4_bnenan_ngaytao" },
                    { 40701, "1:1", "VARCHAR(50)", null, "", null, 7, false, true, false, true, "Mã quy tắc", "System", "bnt4_qtcanh_maquytac" },
                    { 40702, "1:1", "NVARCHAR(MAX)", null, "", null, 7, false, true, false, true, "Mô tả", "System", "bnt4_qtcanh_mota" },
                    { 40703, "1:1", "VARCHAR(20)", null, "", null, 7, false, true, false, true, "Mức độ", "System", "bnt4_qtcanh_mucdo" },
                    { 40704, "1:1", "VARCHAR(50)", null, "", null, 7, false, true, false, true, "Hành động", "System", "bnt4_qtcanh_hanhdong" },
                    { 40705, "1:1", "NVARCHAR(MAX)", null, "", null, 7, false, true, false, false, "Điều kiện kích hoạt", "System", "bnt4_qtcanh_dieukienkichhoat" },
                    { 40706, "1:1", "INT", null, "", null, 7, false, true, false, false, "Tuổi tối thiểu", "System", "bnt4_qtcanh_tuoitoithieu" },
                    { 40707, "1:1", "INT", null, "", null, 7, false, true, false, false, "Tuổi tối đa", "System", "bnt4_qtcanh_tuoitoida" },
                    { 40708, "1:1", "VARCHAR(10)", null, "", null, 7, false, true, false, false, "Giới tính", "System", "bnt4_qtcanh_gioitinh" },
                    { 40709, "1:1", "VARCHAR(10)", "'1.0'", "", null, 7, false, true, false, false, "Phiên bản", "System", "bnt4_qtcanh_phienban" },
                    { 40801, "1:1", "REF", null, "", "Patient(Id)", 8, false, true, false, true, "Mã bệnh nhân", "System", "bnt4_nkcbao_mabenhnhan" },
                    { 40802, "1:1", "INT", null, "", null, 8, false, true, false, true, "Đơn thuốc", "System", "bnt4_nkcbao_donthuoc" },
                    { 40803, "1:1", "REF", null, "", "bnt4_qtcanh(Id)", 8, false, true, false, true, "Quy tắc", "System", "bnt4_nkcbao_quytac" },
                    { 40804, "1:1", "VARCHAR(20)", null, "", null, 8, false, true, false, false, "Mã thuốc", "System", "bnt4_nkcbao_mathuoc" },
                    { 40805, "1:1", "VARCHAR(20)", null, "", null, 8, false, true, false, true, "Mức độ", "System", "bnt4_nkcbao_mucdo" },
                    { 40806, "1:1", "VARCHAR(50)", null, "", null, 8, false, true, false, false, "Hành động xử trí", "System", "bnt4_nkcbao_hanhdongxutri" },
                    { 40807, "1:1", "REF", null, "", "AspNetUsers(Id)", 8, false, true, false, false, "Xác nhận bởi", "System", "bnt4_nkcbao_xacnhanboi" },
                    { 40808, "1:1", "NVARCHAR(MAX)", null, "", null, 8, false, true, false, false, "Ghi chú xác nhận", "System", "bnt4_nkcbao_ghichuxacnhan" },
                    { 40809, "1:1", "REF", null, "", "AspNetUsers(Id)", 8, false, true, false, false, "Xem xét bởi", "System", "bnt4_nkcbao_xemxetboi" },
                    { 40810, "1:1", "DATETIME", null, "", null, 8, false, true, false, false, "Ngày xem xét", "System", "bnt4_nkcbao_ngayxemxet" },
                    { 40811, "1:1", "DATETIME", "GETDATE()", "", null, 8, false, true, false, false, "Thời gian", "System", "bnt4_nkcbao_thoigian" },
                    { 50101, "1:1", "VARCHAR(50)", null, "", null, 101, false, true, false, true, "Mã hệ", "System", "bnt5_hecoquan_mahe" },
                    { 50102, "1:1", "NVARCHAR(200)", null, "", null, 101, false, true, false, true, "Tên tiếng Việt", "System", "bnt5_hecoquan_tentiengviet" },
                    { 50103, "1:1", "NVARCHAR(200)", null, "", null, 101, false, true, false, true, "Tên tiếng Anh", "System", "bnt5_hecoquan_tentienganh" },
                    { 50104, "1:1", "NVARCHAR(MAX)", null, "", null, 101, false, true, false, false, "Mô tả", "System", "bnt5_hecoquan_mota" },
                    { 50105, "1:1", "INT", "0", "", null, 101, false, true, false, false, "Thứ tự sắp xếp", "System", "bnt5_hecoquan_thutusapxep" },
                    { 50106, "1:1", "VARCHAR(10)", "'1.0'", "", null, 101, false, true, false, false, "Phiên bản", "System", "bnt5_hecoquan_phienban" },
                    { 50107, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 101, false, true, false, false, "Trạng thái", "System", "bnt5_hecoquan_trangthai" },
                    { 50108, "1:1", "DATETIME", "GETDATE()", "", null, 101, false, true, false, false, "Ngày tạo", "System", "bnt5_hecoquan_ngaytao" },
                    { 50109, "1:1", "DATETIME", null, "", null, 101, false, true, false, false, "Ngày cập nhật", "System", "bnt5_hecoquan_ngaycapnhat" },
                    { 50201, "1:1", "REF", null, "", "bnt5_hecoquan(Id)", 102, false, true, false, true, "Hệ cơ quan", "System", "bnt5_cautruc_hecoquan" },
                    { 50202, "1:1", "VARCHAR(50)", null, "", null, 102, false, true, false, true, "Mã cấu trúc", "System", "bnt5_cautruc_macautruc" },
                    { 50203, "1:1", "NVARCHAR(200)", null, "", null, 102, false, true, false, true, "Tên tiếng Việt", "System", "bnt5_cautruc_tentiengviet" },
                    { 50204, "1:1", "NVARCHAR(200)", null, "", null, 102, false, true, false, true, "Tên tiếng Anh", "System", "bnt5_cautruc_tentienganh" },
                    { 50205, "1:1", "REF", null, "", "bnt5_cautruc(Id)", 102, false, true, false, false, "Cấu trúc cha", "System", "bnt5_cautruc_cautruccha" },
                    { 50206, "1:1", "NVARCHAR(MAX)", null, "", null, 102, false, true, false, false, "Mô tả", "System", "bnt5_cautruc_mota" },
                    { 50207, "1:1", "INT", null, "", null, 102, false, true, false, false, "Cấp độ", "System", "bnt5_cautruc_capdo" },
                    { 50208, "1:1", "VARCHAR(10)", "'1.0'", "", null, 102, false, true, false, false, "Phiên bản", "System", "bnt5_cautruc_phienban" },
                    { 50209, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 102, false, true, false, false, "Trạng thái", "System", "bnt5_cautruc_trangthai" },
                    { 50301, "1:1", "REF", null, "", "bnt5_cautruc(Id)", 103, false, true, false, true, "Cấu trúc", "System", "bnt5_chatinhieu_cautruc" },
                    { 50302, "1:1", "VARCHAR(50)", null, "", null, 103, false, true, false, true, "Mã chất", "System", "bnt5_chatinhieu_machat" },
                    { 50303, "1:1", "NVARCHAR(200)", null, "", null, 103, false, true, false, true, "Tên tiếng Việt", "System", "bnt5_chatinhieu_tentiengviet" },
                    { 50304, "1:1", "NVARCHAR(200)", null, "", null, 103, false, true, false, true, "Tên tiếng Anh", "System", "bnt5_chatinhieu_tentienganh" },
                    { 50305, "1:1", "VARCHAR(50)", null, "", null, 103, false, true, false, false, "Đơn vị", "System", "bnt5_chatinhieu_donvi" },
                    { 50306, "1:1", "NVARCHAR(100)", null, "", null, 103, false, true, false, false, "Khoảng bình thường", "System", "bnt5_chatinhieu_khoangbinhthuong" },
                    { 50307, "1:1", "NVARCHAR(MAX)", null, "", null, 103, false, true, false, false, "Mô tả", "System", "bnt5_chatinhieu_mota" },
                    { 50308, "1:1", "VARCHAR(50)", null, "", null, 103, false, true, false, false, "Loại", "System", "bnt5_chatinhieu_loai" },
                    { 50309, "1:1", "VARCHAR(10)", "'1.0'", "", null, 103, false, true, false, false, "Phiên bản", "System", "bnt5_chatinhieu_phienban" },
                    { 50310, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 103, false, true, false, false, "Trạng thái", "System", "bnt5_chatinhieu_trangthai" },
                    { 50401, "1:1", "VARCHAR(50)", null, "", null, 104, false, true, false, true, "Mã xét nghiệm", "System", "bnt5_dmxnghiem_maxetnghiem" },
                    { 50402, "1:1", "NVARCHAR(200)", null, "", null, 104, false, true, false, true, "Tên tiếng Việt", "System", "bnt5_dmxnghiem_tentiengviet" },
                    { 50403, "1:1", "NVARCHAR(200)", null, "", null, 104, false, true, false, true, "Tên tiếng Anh", "System", "bnt5_dmxnghiem_tentienganh" },
                    { 50404, "1:1", "VARCHAR(50)", null, "", null, 104, false, true, false, false, "Phương pháp", "System", "bnt5_dmxnghiem_phuongphap" },
                    { 50405, "1:1", "VARCHAR(50)", null, "", null, 104, false, true, false, false, "Loại mẫu", "System", "bnt5_dmxnghiem_loaimau" },
                    { 50406, "1:1", "VARCHAR(50)", null, "", null, 104, false, true, false, false, "Thời gian trả KQ", "System", "bnt5_dmxnghiem_thoigiantrakq" },
                    { 50407, "1:1", "DECIMAL(18,2)", null, "", null, 104, false, true, false, false, "Giá thành", "System", "bnt5_dmxnghiem_giathanh" },
                    { 50408, "1:1", "NVARCHAR(MAX)", null, "", null, 104, false, true, false, false, "Mô tả", "System", "bnt5_dmxnghiem_mota" },
                    { 50409, "1:1", "VARCHAR(10)", "'1.0'", "", null, 104, false, true, false, false, "Phiên bản", "System", "bnt5_dmxnghiem_phienban" },
                    { 50410, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 104, false, true, false, false, "Trạng thái", "System", "bnt5_dmxnghiem_trangthai" },
                    { 50501, "1:1", "REF", null, "", "bnt5_dmxnghiem(Id)", 105, false, true, false, true, "Xét nghiệm", "System", "bnt5_ktchieucu_xetnghiem" },
                    { 50502, "1:1", "INT", null, "", null, 105, false, true, false, false, "Tuổi tối thiểu", "System", "bnt5_ktchieucu_tuoitoithieu" },
                    { 50503, "1:1", "INT", null, "", null, 105, false, true, false, false, "Tuổi tối đa", "System", "bnt5_ktchieucu_tuoitoida" },
                    { 50504, "1:1", "VARCHAR(10)", null, "", null, 105, false, true, false, false, "Giới tính", "System", "bnt5_ktchieucu_gioitinh" },
                    { 50505, "1:1", "DECIMAL(18,4)", null, "", null, 105, false, true, false, false, "Giá trị thấp", "System", "bnt5_ktchieucu_giatrithap" },
                    { 50506, "1:1", "DECIMAL(18,4)", null, "", null, 105, false, true, false, false, "Giá trị cao", "System", "bnt5_ktchieucu_giatricao" },
                    { 50507, "1:1", "VARCHAR(50)", null, "", null, 105, false, true, false, false, "Đơn vị", "System", "bnt5_ktchieucu_donvi" },
                    { 50508, "1:1", "DECIMAL(18,4)", null, "", null, 105, false, true, false, false, "Nguy kịch thấp", "System", "bnt5_ktchieucu_nguykichthap" },
                    { 50509, "1:1", "DECIMAL(18,4)", null, "", null, 105, false, true, false, false, "Nguy kịch cao", "System", "bnt5_ktchieucu_nguykichcao" },
                    { 50510, "1:1", "NVARCHAR(MAX)", null, "", null, 105, false, true, false, false, "Ghi chú", "System", "bnt5_ktchieucu_ghichu" },
                    { 50511, "1:1", "VARCHAR(10)", "'1.0'", "", null, 105, false, true, false, false, "Phiên bản", "System", "bnt5_ktchieucu_phienban" },
                    { 50512, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 105, false, true, false, false, "Trạng thái", "System", "bnt5_ktchieucu_trangthai" },
                    { 50601, "1:1", "REF", null, "", "Patient(Id)", 106, false, true, false, true, "Mã bệnh nhân", "System", "bnt5_ychidinh_mabenhnhan" },
                    { 50602, "1:1", "REF", null, "", "bnt5_dmxnghiem(Id)", 106, false, true, false, true, "Xét nghiệm", "System", "bnt5_ychidinh_xetnghiem" },
                    { 50603, "1:1", "DATETIME", "GETDATE()", "", null, 106, false, true, false, true, "Ngày chỉ định", "System", "bnt5_ychidinh_ngaychidinh" },
                    { 50604, "1:1", "REF", null, "", "AspNetUsers(Id)", 106, false, true, false, false, "Chỉ định bởi", "System", "bnt5_ychidinh_chidinhboi" },
                    { 50605, "1:1", "VARCHAR(20)", null, "", null, 106, false, true, false, false, "Độ ưu tiên", "System", "bnt5_ychidinh_douutien" },
                    { 50606, "1:1", "VARCHAR(20)", "'PENDING'", "", null, 106, false, true, false, false, "Trạng thái", "System", "bnt5_ychidinh_trangthai" },
                    { 50607, "1:1", "NVARCHAR(MAX)", null, "", null, 106, false, true, false, false, "Ghi chú", "System", "bnt5_ychidinh_ghichu" },
                    { 50608, "1:1", "DATETIME", "GETDATE()", "", null, 106, false, true, false, false, "Ngày tạo", "System", "bnt5_ychidinh_ngaytao" },
                    { 50701, "1:1", "REF", null, "", "bnt5_ychidinh(Id)", 107, false, true, false, true, "Mã chỉ định", "System", "bnt5_ketqua_machidinh" },
                    { 50702, "1:1", "DECIMAL(18,4)", null, "", null, 107, false, true, false, true, "Giá trị", "System", "bnt5_ketqua_giatri" },
                    { 50703, "1:1", "VARCHAR(50)", null, "", null, 107, false, true, false, false, "Đơn vị", "System", "bnt5_ketqua_donvi" },
                    { 50704, "1:1", "DATETIME", null, "", null, 107, false, true, false, true, "Ngày kết quả", "System", "bnt5_ketqua_ngayketqua" },
                    { 50705, "1:1", "REF", null, "", "AspNetUsers(Id)", 107, false, true, false, false, "Nhận định bởi", "System", "bnt5_ketqua_nhandinhboi" },
                    { 50706, "1:1", "VARCHAR(20)", null, "", null, 107, false, true, false, false, "Cờ báo động", "System", "bnt5_ketqua_cobaodong" },
                    { 50707, "1:1", "NVARCHAR(MAX)", null, "", null, 107, false, true, false, false, "Ghi chú", "System", "bnt5_ketqua_ghichu" },
                    { 50708, "1:1", "VARCHAR(10)", "'1.0'", "", null, 107, false, true, false, false, "Phiên bản", "System", "bnt5_ketqua_phienban" },
                    { 50709, "1:1", "VARCHAR(20)", "'ACTIVE'", "", null, 107, false, true, false, false, "Trạng thái", "System", "bnt5_ketqua_trangthai" },
                    { 50801, "1:1", "REF", null, "", "bnt5_ketqua(Id)", 108, false, true, false, true, "Mã kết quả", "System", "bnt5_csinhhoa_maketqua" },
                    { 50802, "1:1", "DECIMAL(5,2)", null, "", null, 108, false, true, false, false, "Độ pH", "System", "bnt5_csinhhoa_doph" },
                    { 50803, "1:1", "DECIMAL(18,4)", null, "", null, 108, false, true, false, false, "Cân bằng ion", "System", "bnt5_csinhhoa_canbangion" },
                    { 50804, "1:1", "DECIMAL(18,4)", null, "", null, 108, false, true, false, false, "Nồng độ enzyme", "System", "bnt5_csinhhoa_nongdoenzyme" },
                    { 50805, "1:1", "NVARCHAR(MAX)", null, "", null, 108, false, true, false, false, "Ghi chú", "System", "bnt5_csinhhoa_ghichu" },
                    { 50901, "1:1", "REF", null, "", "bnt5_ketqua(Id)", 109, false, true, false, true, "Mã kết quả", "System", "bnt5_cshieusinh_maketqua" },
                    { 50902, "1:1", "VARCHAR(20)", null, "", null, 109, false, true, false, false, "Huyết áp", "System", "bnt5_cshieusinh_huyetap" },
                    { 50903, "1:1", "INT", null, "", null, 109, false, true, false, false, "Nhịp tim", "System", "bnt5_cshieusinh_nhiptim" },
                    { 50904, "1:1", "DECIMAL(5,2)", null, "", null, 109, false, true, false, false, "Nhiệt độ", "System", "bnt5_cshieusinh_nhietdo" },
                    { 50905, "1:1", "INT", null, "", null, 109, false, true, false, false, "Nhịp thở", "System", "bnt5_cshieusinh_nhiptho" },
                    { 50906, "1:1", "DECIMAL(5,2)", null, "", null, 109, false, true, false, false, "SPO2", "System", "bnt5_cshieusinh_spo2" },
                    { 50907, "1:1", "NVARCHAR(MAX)", null, "", null, 109, false, true, false, false, "Ghi chú", "System", "bnt5_cshieusinh_ghichu" },
                    { 51001, "1:1", "REF", null, "", "bnt5_ketqua(Id)", 110, false, true, false, true, "Mã kết quả", "System", "bnt5_ctebao_maketqua" },
                    { 51002, "1:1", "INT", null, "", null, 110, false, true, false, false, "Số lượng tế bào", "System", "bnt5_ctebao_soluongtebao" },
                    { 51003, "1:1", "VARCHAR(50)", null, "", null, 110, false, true, false, false, "Hình thái", "System", "bnt5_ctebao_hinhthai" },
                    { 51004, "1:1", "NVARCHAR(MAX)", null, "", null, 110, false, true, false, false, "Markers", "System", "bnt5_ctebao_markers" },
                    { 51005, "1:1", "NVARCHAR(MAX)", null, "", null, 110, false, true, false, false, "Ghi chú", "System", "bnt5_ctebao_ghichu" },
                    { 51101, "1:1", "REF", null, "", "bnt5_ketqua(Id)", 111, false, true, false, true, "Mã kết quả", "System", "bnt5_chinhanh_maketqua" },
                    { 51102, "1:1", "VARCHAR(50)", null, "", null, 111, false, true, false, false, "Loại hình", "System", "bnt5_chinhanh_loaihinh" },
                    { 51103, "1:1", "NVARCHAR(MAX)", null, "", null, 111, false, true, false, false, "Phát hiện", "System", "bnt5_chinhanh_phathien" },
                    { 51104, "1:1", "VARCHAR(200)", null, "", null, 111, false, true, false, false, "Đường dẫn file", "System", "bnt5_chinhanh_duongdanfile" },
                    { 51105, "1:1", "VARCHAR(50)", null, "", null, 111, false, true, false, false, "Kích thước", "System", "bnt5_chinhanh_kichthuoc" },
                    { 51106, "1:1", "NVARCHAR(MAX)", null, "", null, 111, false, true, false, false, "Ghi chú", "System", "bnt5_chinhanh_ghichu" },
                    { 51201, "1:1", "REF", null, "", "bnt5_ketqua(Id)", 112, false, true, false, true, "Mã kết quả", "System", "bnt5_diensinhly_maketqua" },
                    { 51202, "1:1", "NVARCHAR(MAX)", null, "", null, 112, false, true, false, false, "Dạng sóng", "System", "bnt5_diensinhly_dangsong" },
                    { 51203, "1:1", "DECIMAL(18,4)", null, "", null, 112, false, true, false, false, "Biên độ", "System", "bnt5_diensinhly_biendo" },
                    { 51204, "1:1", "DECIMAL(18,4)", null, "", null, 112, false, true, false, false, "Tần số", "System", "bnt5_diensinhly_tanso" },
                    { 51205, "1:1", "INT", null, "", null, 112, false, true, false, false, "Thời lượng", "System", "bnt5_diensinhly_thoiluong" },
                    { 51206, "1:1", "NVARCHAR(MAX)", null, "", null, 112, false, true, false, false, "Ghi chú", "System", "bnt5_diensinhly_ghichu" },
                    { 51301, "1:1", "REF", null, "", "bnt5_dmxnghiem(Id)", 113, false, true, false, true, "XN gốc", "System", "bnt5_xnlienquan_xngoc" },
                    { 51302, "1:1", "REF", null, "", "bnt5_dmxnghiem(Id)", 113, false, true, false, true, "XN đích", "System", "bnt5_xnlienquan_xndich" },
                    { 51303, "1:1", "VARCHAR(50)", null, "", null, 113, false, true, false, false, "Loại liên hệ", "System", "bnt5_xnlienquan_loailienhe" },
                    { 51304, "1:1", "NVARCHAR(MAX)", null, "", null, 113, false, true, false, false, "Mô tả", "System", "bnt5_xnlienquan_mota" },
                    { 51305, "1:1", "DECIMAL(5,2)", null, "", null, 113, false, true, false, false, "Độ mạnh", "System", "bnt5_xnlienquan_domanh" },
                    { 51401, "1:1", "VARCHAR(50)", null, "", null, 114, false, true, false, true, "Mã quy tắc", "System", "bnt5_qtcbxn_maquytac" },
                    { 51402, "1:1", "NVARCHAR(MAX)", null, "", null, 114, false, true, false, true, "Điều kiện", "System", "bnt5_qtcbxn_dieukien" },
                    { 51403, "1:1", "VARCHAR(20)", null, "", null, 114, false, true, false, true, "Mức độ", "System", "bnt5_qtcbxn_mucdo" },
                    { 51404, "1:1", "NVARCHAR(MAX)", null, "", null, 114, false, true, false, false, "Thông điệp", "System", "bnt5_qtcbxn_thongdiep" },
                    { 51405, "1:1", "NVARCHAR(MAX)", null, "", null, 114, false, true, false, false, "XN gợi ý", "System", "bnt5_qtcbxn_xngoiy" },
                    { 51406, "1:1", "NVARCHAR(MAX)", null, "", null, 114, false, true, false, false, "XN áp dụng", "System", "bnt5_qtcbxn_xnapdung" },
                    { 51407, "1:1", "VARCHAR(10)", "'1.0'", "", null, 114, false, true, false, false, "Phiên bản", "System", "bnt5_qtcbxn_phienban" },
                    { 51408, "1:1", "VARCHAR(20)", "'DRAFT'", "", null, 114, false, true, false, false, "Trạng thái", "System", "bnt5_qtcbxn_trangthai" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_GroupId",
                table: "Attributes",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentGroupId",
                table: "Groups",
                column: "ParentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TierId",
                table: "Groups",
                column: "TierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Tiers");
        }
    }
}
