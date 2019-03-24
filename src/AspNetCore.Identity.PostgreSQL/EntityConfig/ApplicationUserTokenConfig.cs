using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Identity.PostgreSQL.EntityConfig
{
    /// <summary>
    /// Application's entity configuration for the authentication token for a user of the application
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key used for users.</typeparam>
    public class ApplicationUserTokenConfig<TKey> : IEntityTypeConfiguration<Entity.ApplicationUserToken<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Configures the entity of type ApplicationUserToken<TKey>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ApplicationUserToken<TKey>> builder)
        {
            builder.ToTable("user_tokens");

            builder.HasKey(ut => ut.UserId);

            builder.Property(ut => ut.UserId)
                .HasColumnName("user_id");

            builder.Property(ut => ut.LoginProvider)
                .HasColumnName("login_provider");

            builder.Property(ut => ut.Name)
                .HasColumnName("name");

            builder.Property(ut => ut.Value)
                .HasColumnName("value");
        }
    }
}
