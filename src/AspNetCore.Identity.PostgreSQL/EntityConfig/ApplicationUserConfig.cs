using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Identity.PostgreSQL.EntityConfig
{
    /// <summary>
    /// Application's entity configuration for a user in the identity system of the application
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the user.</typeparam>
    public class ApplicationUserConfig<TKey> : IEntityTypeConfiguration<Entity.ApplicationUser<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Configures the entity of type ApplicationUser<TKey>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ApplicationUser<TKey>> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id");

            builder.Property(u => u.LockoutEnd)
                .HasColumnName("lockout_end");

            builder.Property(u => u.TwoFactorEnabled)
                .HasColumnName("two_factor_enabled");

            builder.Property(u => u.PhoneNumberConfirmed)
                .HasColumnName("phone_number_confirmed");

            builder.Property(u => u.PhoneNumber)
                .HasColumnName("phone_number");

            builder.Property(u => u.ConcurrencyStamp)
                .HasColumnName("concurrency_stamp");

            builder.Property(u => u.SecurityStamp)
                .HasColumnName("security_stamp");

            builder.Property(u => u.PasswordHash)
                .HasColumnName("password_hash");

            builder.Property(u => u.EmailConfirmed)
                .HasColumnName("email_confirmed");

            builder.Property(u => u.NormalizedEmail)
                .HasColumnName("normalized_email");

            builder.Property(u => u.Email)
                .HasColumnName("email");

            builder.Property(u => u.NormalizedUserName)
                .HasColumnName("normalized_user_name");

            builder.Property(u => u.UserName)
                .HasColumnName("user_name");

            builder.Property(u => u.LockoutEnabled)
                .HasColumnName("lockout_enabled");

            builder.Property(u => u.AccessFailedCount)
                .HasColumnName("access_failed_count");
        }
    }
}
