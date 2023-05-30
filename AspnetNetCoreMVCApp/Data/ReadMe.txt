

Script-Migration -context CustomerContext -From 20230530114132_CustomerInit  -To 20230530120948_AccountConfig -Output "Migrations/migrationscript.sql"

Update-Database -context CustomerContext 

Add-Migration AccountConfig -context CustomerContext


