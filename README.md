# aspnetcore-identity-npgsql-identitymanager2
Boilerplate for AspNetCore Identity with Postgresql and IdentityManager2

## Create the Asp.Net Core Identity Schema

1. Run the following DB initialization script:

    `psql -U{database user} -f db/init_db.sql`