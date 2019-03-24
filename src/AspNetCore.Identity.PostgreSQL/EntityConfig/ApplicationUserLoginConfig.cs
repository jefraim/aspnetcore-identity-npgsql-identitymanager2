using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Identity.PostgreSQL.EntityConfig
{
    /// <summary>
    /// Application's entity configuration for a login and its associated provider for a user of the application
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the user.</typeparam>
    public class ApplicationUserLoginConfig<TKey> : IEntityTypeConfiguration<Entity.ApplicationUserLogin<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Configures the entity of type ApplicationUserLogin<TKey>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ApplicationUserLogin<TKey>> builder)
        {
            builder.ToTable("user_logins");

            builder.HasKey(ul => ul.UserId);

            builder.Property(ul => ul.UserId)
                .HasColumnName("user_id");

            builder.Property(ul => ul.LoginProvider)
                .HasColumnName("login_provider");

            builder.Property(ul => ul.ProviderKey)
                .HasColumnName("provider_key");

            builder.Property(ul => ul.ProviderDisplayName)
                .HasColumnName("provider_display_name");
        }
    }
}
