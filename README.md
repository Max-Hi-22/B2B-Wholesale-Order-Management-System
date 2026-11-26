# B2B Wholesale Solution

A Windows desktop application for B2B wholesale management built with Windows Forms and .NET Framework. The application provides user authentication, inventory management, distributor agent management, order processing, analytical dashboards, and shipping manifest reporting.

## Technologies

- C# / Windows Forms
- .NET Framework 4.8.1
- Entity Framework 6.5.2
- SQL Server
- Microsoft ReportViewer WinForms 15.0
- RDLC Local Report
- iTextSharp 5.5.13.7

## Solution Structure

```text
B2B-Wholesale-Order-Management-System/
├── B2BWholesaleSolution/
│   ├── B2BWholesaleSolution.slnx
│   ├── BLL/
│   │   ├── Services/
│   │   │   ├── AgentService.cs
│   │   │   ├── AuthService.cs
│   │   │   ├── DashboardService.cs
│   │   │   ├── ItemService.cs
│   │   │   └── OrderService.cs
│   │   ├── Properties/
│   │   ├── App.config
│   │   ├── BLL.csproj
│   │   └── packages.config
│   ├── DAL/
│   │   ├── Repositories/
│   │   │   ├── AgentRepository.cs
│   │   │   ├── DashboardRepository.cs
│   │   │   ├── ItemRepository.cs
│   │   │   ├── OrderRepository.cs
│   │   │   └── UserRepository.cs
│   │   ├── DTOs/
│   │   │   ├── DashboardDTOs.cs
│   │   │   └── ShippingManifestDTO.cs
│   │   ├── B2BModel.edmx
│   │   ├── B2BModel.Context.cs
│   │   ├── B2BModel.cs
│   │   ├── Agent.cs
│   │   ├── Item.cs
│   │   ├── Order.cs
│   │   ├── OrderDetail.cs
│   │   ├── User.cs
│   │   ├── Properties/
│   │   ├── App.config
│   │   ├── DAL.csproj
│   │   └── packages.config
│   ├── WinFormUI/
│   │   ├── FrmLogin.cs
│   │   ├── FrmMain.cs
│   │   ├── FrmAgentManagement.cs
│   │   ├── FrmItemManagement.cs
│   │   ├── FrmOrderManagement.cs
│   │   ├── FrmDashboard.cs
│   │   ├── FrmReportViewer.cs
│   │   ├── ShippingManifest.rdlc
│   │   ├── SqlServerTypes/
│   │   ├── Utils/
│   │   │   └── SessionManager.cs
│   │   ├── Properties/
│   │   ├── App.config
│   │   ├── app.manifest
│   │   ├── Program.cs
│   │   ├── WinFormUI.csproj
│   │   └── packages.config
│   ├── packages/
│   └── README.md
├── sql/
│   ├── 01_schema_and_constraints.sql
│   └── 02_seed_data.sql
└── README.md
```

### Project Responsibilities

- `BLL/BLL.csproj`: Business Logic Layer. Defines application services for authentication, agents, items, orders, and dashboard statistics. It references `DAL`.
- `DAL/DAL.csproj`: Data Access Layer. Contains the Entity Framework model, generated entities, repositories, and data transfer objects. It owns database access and data mapping.
- `WinFormUI/WinFormUI.csproj`: Presentation project and startup application. Contains Windows Forms screens, session state, ReportViewer integration, RDLC reporting, and native SQL Server Types assets. It references both `BLL` and `DAL`.

### Project Dependencies

```text
WinFormUI -> BLL -> DAL
          \------------------> DAL
```

### Core Features

* User authentication and session management.
* Inventory item management.
* Distributor agent management.
* Order management.
* Analytical statistics dashboard.
* Shipping manifest viewing and export via `ShippingManifest.rdlc`.

## Prerequisites

* Windows OS.
* Visual Studio with .NET Framework 4.8.1 support.
* .NET Framework 4.8.1 Developer Pack.
* SQL Server or SQL Server Express.
* Access permissions to the `B2BWholesaleDB` database.

## Database Configuration

The current connection string is located in:

```text
WinFormUI/App.config
```

The default configuration points to the `TVC` SQL Server instance and the `B2BWholesaleDB` database:

```xml
<connectionStrings>
  <add name="B2BWholesaleDBEntities"
	   connectionString="metadata=res://*/B2BModel.csdl|res://*/B2BModel.ssdl|res://*/B2BModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=TVC;initial catalog=B2BWholesaleDB;integrated security=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
	   providerName="System.Data.EntityClient" />
</connectionStrings>
```

Replace `data source=TVC` with the SQL Server instance name for your target environment. When using Windows Authentication, ensure the Windows account running the application has read/write permissions on the database.

> Avoid committing database credentials or connection strings containing passwords to version control.

## Setup and Running

1. Open the solution in Visual Studio.
2. Restore NuGet packages via **Restore NuGet Packages** or run:
```powershell
nuget restore
```


3. Verify the connection string in `WinFormUI/App.config`.
4. Set `WinFormUI` as the **Startup Project**.
5. Select the appropriate build configuration (`Debug` or `Release`) and target platform.
6. Build the solution via **Build > Build Solution**.
7. Run the application by pressing `F5` or `Ctrl+F5`.

The application launches at the login form (`FrmLogin`). Upon successful authentication, the main portal (`FrmMain`) opens.

## Key Packages

The primary packages declared in `WinFormUI/packages.config` include:

* `EntityFramework` 6.5.2
* `Microsoft.ReportingServices.ReportViewerControl.Winforms` 150.1652.0
* `Microsoft.SqlServer.Types` 14.0.314.76
* `iTextSharp` 5.5.13.7
* `BouncyCastle.Cryptography` 2.7.0

## Reporting

The shipping manifest report uses the following definition file:

```text
WinFormUI/ShippingManifest.rdlc
```

The report is loaded as an embedded resource under the name:

```text
WinFormUI.ShippingManifest.rdlc
```

Report data is bound to the `ManifestDataSet` dataset using `ShippingManifestDTO`.

## Troubleshooting ReportViewer `PInvokeStackImbalance`

During debugging, Visual Studio may raise the following Managed Debugging Assistant (MDA) warning:

```text
PInvokeStackImbalance:
A call to PInvoke function ... FontPackage::CreateFontPackage has unbalanced the stack.
```

This issue stems from a calling convention mismatch between native P/Invoke calls inside ReportViewer and the runtime process architecture, rather than the report data itself. Try the following steps to resolve it:

1. Ensure all ReportViewer assemblies use the same `15.0` version.
2. Delete the `bin` and `obj` folders, restore NuGet packages, and rebuild the solution.
3. Verify that the target platform (`Any CPU`, `x86`, or `x64`) matches your runtime environment.
4. Update or synchronize the `Microsoft.ReportingServices.ReportViewerControl.Winforms` package.
5. If this only triggers as a debug-time warning while functionality works as expected, you can disable the `PInvokeStackImbalance` MDA in Visual Studio's **Exception Settings**. Note that this only suppresses the debugger alert without fixing the underlying ABI mismatch.

Do not attempt to manually alter P/Invoke signatures inside ReportViewer assemblies without the corresponding native APIs and documentation.

## Build Output

After building, the compiled executable is located at:

```text
WinFormUI/bin/Debug/WinFormUI.exe
WinFormUI/bin/Release/WinFormUI.exe
```

When deploying the application, ensure all dependent DLLs, configuration files, RDLC resources, and required native assemblies are distributed alongside the executable.

## Security Notes

* Do not store plaintext passwords in source code or committed configuration files.
* Restrict SQL Server account permissions following the principle of least privilege.
* Do not disable certificate validation or use `trustservercertificate=True` in production environments without a thorough risk assessment.
