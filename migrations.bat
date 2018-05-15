cd src/Crispy.AdminApi.Host
rmdir /S /Q Migrations
dotnet ef migrations add Crispy -c CrispyDbContext -o Migrations/CrispyDb
dotnet ef migrations script -c -v CrispyDbContext -o Migrations/CrispyDb.sql
cd ../..