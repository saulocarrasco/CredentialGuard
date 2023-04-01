# CredentialGuard

## Run Migrations

# go to Api project and change server variable into appsettings.json
# go to database server and create CredentialGuardDbContext

### go to nuget console and run:
```dotnet ef migrations add Init --project CredentialGuard.Infrastructure.Data```
### then
```dotnet ef database update --project CredentialGuard.Infrastructure.Data```
