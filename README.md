The project is basic setup of online shop in which users can order and see products, and administrators can create/change/delete products.

Users do not have access to admin panel.

Test accounts:

User /
login: test@test.com / 
password: Test1!

Admin /
login: admin@admin.com /
password: Admin1! 

1. Change this connection string in appsettings.json:
   
    "DevConnection": "Server=MATI\\MSSQLSERVER03;Database=shop;Trusted_Connection=True;TrustServerCertificate=True;",

3. Install below nuget packs:

- Microsoft.AspNetCore.Identity.EntityFrameworkCore (6.0.23)
- Microsoft.AspNetCore.Identity.UI (6.0.23)
- Microsoft.EntityFramweorkCore (7.0.0)
- Microsoft.EntityFramweorkCoreDesign (7.0.0)
- Microsoft.EntityFrameworkCore.SqlServer (7.0.0)
- Microsoft.EntityFrameworkCore.Tools (7.0.0)
- NuGet.CommandLine (6.8.0)

3. To create migration execute nuget commands below:

- Update-Database -Context CategoriesDbContext
- Update-Databse -Context IdentityDbContext
- Update-Database -Context OrdersDbContext
- Update-Database -Context ProductsDbContext
