#MerchStore API
This is a basic implementation of a Minimal REST API using the Repository Pattern and dependency injection.

## Starting SQL Server
```powershell
$sa_password = "[SA PASSWORD HERE]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```
## Setting the connection string to secret manager
```powershell
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:MerchStoreContext" "Server=localhost; Database=MerchStore; User Id=sa; Password=$sa_password; TrustServerCertificate=TrustServerCertificate=True"
```