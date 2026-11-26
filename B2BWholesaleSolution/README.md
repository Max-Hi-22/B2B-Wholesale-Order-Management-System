# B2B Wholesale Solution

Ứng dụng quản lý bán buôn B2B trên Windows, được xây dựng bằng Windows Forms và .NET Framework. Ứng dụng cung cấp các chức năng đăng nhập, quản lý mặt hàng, đại lý, đơn hàng, dashboard và xem báo cáo phiếu giao hàng.

## Công nghệ

- C# / Windows Forms
- .NET Framework 4.8.1
- Entity Framework 6.5.2
- SQL Server
- Microsoft ReportViewer WinForms 15.0
- RDLC local report
- iTextSharp 5.5.13.7

## Cấu trúc solution

```text
B2BWholesaleSolution/
├── BLL/          # Business Logic Layer: các service nghiệp vụ
├── DAL/          # Data Access Layer: Entity Framework, repository, DTO
└── WinFormUI/    # Giao diện Windows Forms và báo cáo RDLC
```

### Các chức năng chính

- Đăng nhập và quản lý session người dùng.
- Quản lý mặt hàng.
- Quản lý đại lý.
- Quản lý đơn hàng.
- Dashboard thống kê.
- Xem phiếu giao hàng bằng `ShippingManifest.rdlc`.

## Yêu cầu môi trường

- Windows.
- Visual Studio hỗ trợ .NET Framework 4.8.1.
- .NET Framework 4.8.1 Developer Pack.
- SQL Server hoặc SQL Server Express.
- Quyền truy cập cơ sở dữ liệu `B2BWholesaleDB`.

## Cấu hình cơ sở dữ liệu

Connection string hiện tại nằm trong:

```text
WinFormUI/App.config
```

Giá trị mặc định đang sử dụng SQL Server instance `TVC` và cơ sở dữ liệu `B2BWholesaleDB`:

```xml
<connectionStrings>
  <add name="B2BWholesaleDBEntities"
	   connectionString="metadata=res://*/B2BModel.csdl|res://*/B2BModel.ssdl|res://*/B2BModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=TVC;initial catalog=B2BWholesaleDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
	   providerName="System.Data.EntityClient" />
</connectionStrings>
```

Hãy thay `data source=TVC` bằng SQL Server instance của môi trường chạy ứng dụng. Với cơ chế đăng nhập Windows, tài khoản chạy ứng dụng phải có quyền truy cập cơ sở dữ liệu.

> Không nên commit thông tin đăng nhập cơ sở dữ liệu hoặc connection string chứa mật khẩu vào repository.

## Cài đặt và chạy

1. Mở solution trong Visual Studio.
2. Khôi phục NuGet packages bằng **Restore NuGet Packages** hoặc chạy:

   ```powershell
   nuget restore
   ```

3. Kiểm tra connection string trong `WinFormUI/App.config`.
4. Đặt `WinFormUI` làm **Startup Project**.
5. Chọn cấu hình `Debug` hoặc `Release` và nền tảng phù hợp.
6. Build solution bằng **Build > Build Solution**.
7. Chạy ứng dụng bằng `F5` hoặc `Ctrl+F5`.

Ứng dụng bắt đầu từ form đăng nhập (`FrmLogin`). Sau khi đăng nhập thành công, màn hình chính (`FrmMain`) sẽ được mở.

## Packages chính

Các package được khai báo trong `WinFormUI/packages.config`:

- `EntityFramework` 6.5.2
- `Microsoft.ReportingServices.ReportViewerControl.Winforms` 150.1652.0
- `Microsoft.SqlServer.Types` 14.0.314.76
- `iTextSharp` 5.5.13.7
- `BouncyCastle.Cryptography` 2.7.0

## Báo cáo

Báo cáo phiếu giao hàng sử dụng file:

```text
WinFormUI/ShippingManifest.rdlc
```

Report được nạp dưới dạng embedded resource với tên:

```text
WinFormUI.ShippingManifest.rdlc
```

Dữ liệu được truyền vào dataset `ManifestDataSet` thông qua `ShippingManifestDTO`.

## Xử lý lỗi ReportViewer `PInvokeStackImbalance`

Khi debug, có thể xuất hiện cảnh báo Managed Debugging Assistant:

```text
PInvokeStackImbalance:
A call to PInvoke function ... FontPackage::CreateFontPackage has unbalanced the stack.
```

Lỗi này thường phát sinh từ sự không tương thích giữa native P/Invoke trong ReportViewer và cấu hình runtime/kiến trúc tiến trình, không phải từ dữ liệu của báo cáo. Có thể thử các bước sau:

1. Đảm bảo tất cả assembly ReportViewer sử dụng cùng một phiên bản `15.0`.
2. Xóa thư mục `bin` và `obj`, sau đó restore packages và build lại.
3. Kiểm tra mục tiêu nền tảng (`Any CPU`, `x86` hoặc `x64`) phù hợp với môi trường triển khai.
4. Cập nhật hoặc đồng bộ package `Microsoft.ReportingServices.ReportViewerControl.Winforms`.
5. Nếu chỉ là cảnh báo trong lúc debug và chức năng vẫn chạy, có thể tắt riêng MDA `PInvokeStackImbalance` trong cấu hình Exception Settings của Visual Studio. Đây chỉ là biện pháp ẩn cảnh báo, không sửa lỗi ABI thực sự.

Không nên tự thay đổi chữ ký P/Invoke bên trong assembly ReportViewer nếu không có native API và tài liệu tương ứng.

## Build output

Sau khi build, file thực thi thường nằm tại:

```text
WinFormUI/bin/Debug/WinFormUI.exe
WinFormUI/bin/Release/WinFormUI.exe
```

Khi triển khai, cần phân phối đầy đủ các DLL phụ thuộc, file cấu hình, tài nguyên RDLC và các native DLL cần thiết.

## Lưu ý bảo mật

- Không lưu mật khẩu dạng plain text trong source code hoặc file cấu hình đã commit.
- Giới hạn quyền của tài khoản SQL Server theo nguyên tắc tối thiểu cần thiết.
- Không tắt kiểm tra chứng chỉ hoặc dùng `trustservercertificate=True` trong môi trường production nếu không đánh giá đầy đủ rủi ro.
