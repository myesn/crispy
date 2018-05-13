cd src/Crispy.AdminApi.Host
rmdir /S /Q Migrations
dotnet ef migrations add Crispy -c CrispyMySQLDbContext -o Migrations/CrispyDb
dotnet ef migrations script -c -v CrispyMySQLDbContext -o Migrations/CrispyDb.sql
cd ../..