using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using AspNetCore.Identity.PostgreSQL.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Identity.PostgreSQL.EntityFrameworkCore
{
    /// <summary>
    /// Base class for the Npgsql Entity Framework database context used for identity.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key for users and roles.</typeparam>
    public class NpgsqlIdentityDbContext<TKey> :
        IdentityDbContext<ApplicationUser<TKey>, ApplicationRole<TKey>, TKey, ApplicationUserClaim<TKey>,
            ApplicationUserRole<TKey>, ApplicationUserLogin<TKey>, ApplicationRoleClaim<TKey>, ApplicationUserToken<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// ctor with <see cref="DbContextOptions"/>
        /// </summary>
        /// <param name="options">The options to be used by a Microsoft.EntityFrameworkCore.DbContext</param>
        public NpgsqlIdentityDbContext(DbContextOptions options) : base(options)
        {
        }
        /// <summary>
        /// Configures the schema needed for the identity framework.
        /// </summary>
        /// <param name="builder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationUserClaimConfig<TKey>());
            builder.ApplyConfiguration(new ApplicationRoleConfig<TKey>());
            builder.ApplyConfiguration(new ApplicationRoleClaimConfig<TKey>());
            builder.ApplyConfiguration(new ApplicationUserConfig<TKey>());
            builder.ApplyConfiguration(new ApplicationUserLoginConfig<TKey>());
            builder.ApplyConfiguration(new ApplicationUserRoleConfig<TKey>());
            builder.ApplyConfiguration(new ApplicationUserTokenConfig<TKey>());
        }
    }
}
