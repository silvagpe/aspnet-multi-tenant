# EF Core - Multi Tenancy asp net web api

In this example I show how to implement multi-tenancy with Asp.net WebApi, EF Core and Postgres.

This is a simple example, but fully functional

### Features:

* .net 5
* EF Core 5
* Postgres
    * Administrative DB
    * Tenant DB
* Migrations

---

## .env

In the `.env` file, I add three informations, project name, database user and database password. 

## Docker Compose

In the `docker-compose.yml` file, I added all the settings we need to start the Postgres database, I also commented out all the lines to make it easier to understand

```bash
cd docker
docker-compose up 

#or
docker-compose up -d

```

## How to create migrations

```bash

#AdminDataContex
dotnet ef migrations add AdminMigration -c AdminDataContext

#TenantDataContext
dotnet ef migrations add TenantMigration -c TenantDataContext 

For creating migrations is necessary to alter on startup.cs and add fake context.

```

`Startup.cs`
```
//Add this
services.AddDbContext<TenantDataContext>(x => 
                x.UseNpgsql(Configuration.GetConnectionString("AdminConnection")));            

//Comment this
// services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// services.AddCustomDataContext(Configuration);

After migrations where generated, revert these lines.
```


