cd src/Crispy.AdminApi.Host
dotnet ef database update -c CrispyDbContext
rmdir /S /Q Migrations
cd ../..