# DapperTest

Create a SQL image with docker:

```
docker run --memory=2G -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1435:1433 -d --name DapperTest mcr.microsoft.com/mssql/server:2019-latest
```
