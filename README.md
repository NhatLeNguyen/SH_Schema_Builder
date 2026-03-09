# SH Schema Builder

Dự án quản lý cấu trúc Schema y tế chuyên sâu, bao gồm cả Frontend (React + Vite) và Backend (.NET 8 API), kết nối cơ sở dữ liệu SQL Server.

## Yêu cầu hệ thống (Prerequisites)
Bạn có thể chạy dự án trực tiếp trên máy host hoặc sử dụng Docker để đồng bộ môi trường.

**Cách 1: Chạy bằng Docker (Khuyến nghị)**
- Cần cài đặt [Docker Desktop](https://www.docker.com/products/docker-desktop/) hoặc Docker Engine.

**Cách 2: Chạy thủ công trên máy thật**
- [Node.js](https://nodejs.org/) v18 trở lên (khuyến nghị v20).
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) hoặc .NET 10 SDK (nếu có config preview).
- SQL Server (hoặc LocalDB).

---

## 🚀 Hướng Dẫn Chạy Dự Án Bằng Docker

Đây là phương thức nhanh nhất và ít gặp lỗi môi trường nhất. Toàn bộ SQL Server, Web API (Server) và Frontend (Client) đã được đóng gói sẵn.

1. Mở Terminal / PowerShell tại thư mục gốc của dự án (`SH_Schema_Builder`).
2. Chạy lệnh:
   ```bash
   docker-compose up -d --build
   ```
3. Chờ cho quá trình build hoàn tất và các container khởi động (Lần đầu tiên sẽ mất khoảng 2-5 phút để tải Image mssql và dotnet).
4. Truy cập ứng dụng:
   - **Frontend (Web UI)**: http://localhost:3000
   - **Backend API**: http://localhost:8080
   - **Cơ sở dữ liệu (MSSQL)**: Kết nối qua SSMS hoặc DataGrip với cổng `1433`, tài khoản `sa`, mật khẩu `Your_password123`.

*Lưu ý: Dữ liệu Database SQL Server được lưu vào volume của Docker (`sqlvolume`). Để reset lại DB trắng, bạn có thể chạy: `docker-compose down -v`*

---

## 🛠 Hướng Dẫn Chạy Thủ Công (Dành cho Development)

Nếu bạn cần sửa code live, hãy chạy theo các bước sau:

### 1. Database & Backend (Server)
Mở cửa sổ terminal thứ nhất:
```bash
cd Server
# Cài đặt công cụ EF Core nếu chưa có
dotnet tool install --global dotnet-ef

# Cập nhật và seed dữ liệu vào DB (Cấu hình chuỗi kết nối trong appsettings.json)
dotnet ef database update

# Chạy ứng dụng server
dotnet run
```
*Backend mặc định chạy ở cổng: http://localhost:5254 (hoặc tương tự tuỳ cài đặt).*

### 2. Frontend (Client)
Mở cửa sổ terminal thứ hai:
```bash
cd Client
# Cài đặt các gói npm
npm install

# Chạy live server của React Vite
npm run dev
```
*Frontend sẽ tự động mở ở: http://localhost:5173. Đảm bảo cấu hình proxy trong `vite.config.ts` trỏ đúng vào cổng của Backend nếu thay đổi.*

---

## 🏗 Kiến trúc sơ bộ
- **Tầng 1-3**: Cấu trúc bệnh nhân đơn giản (Hành chính, Pháp lý, BHYT).
- **Tầng 4**: Cấu trúc bệnh lý bất biến (Dược lý, Hoạt chất, Dị ứng, Bệnh nền..).
- **Tầng 5**: Cấu trúc sinh học phân nhánh, mở rộng theo Context đo lường tự động sinh cột SQL `bnt...`.

## 📌 Lưu ý Naming Convention
Mã nguồn chứa sẵn các file `update_seeds.js` và `update_fk.js` để tự động hóa việc gán tên cột bảng thành cấu trúc `bnt[Tier]_[GroupSlug]_[AttrSlug]` nhằm đồng nhất hoá ngôn ngữ tiếng Việt (snake_case).
