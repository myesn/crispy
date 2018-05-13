cd src/Crispy.AdminApi.Host
dotnet ef database update -c CrispyMySQLDbContext
rmdir /S /Q Migrations
cd ../..