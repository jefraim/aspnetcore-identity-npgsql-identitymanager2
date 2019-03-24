using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Identity.PostgreSQL.EntityConfig
{
    /// <summary>
    /// Application's entity configuration for the link representation between a user and a role of the application
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key used for users and roles.</typeparam>
    public class ApplicationUserRoleConfig<TKey> : IEntityTypeConfiguration<Entity.ApplicationUserRole<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Configures the entity of type ApplicationUserRole<TKey>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ApplicationUserRole<TKey>> builder)
        {
            builder.ToTable("user_roles");

            builder.HasKey(ur => ur.RoleId);
            builder.HasKey(ur => ur.UserId);

            builder.Property(ur => ur.RoleId)
                .HasColumnName("role_id");
            
            builder.Property(ur => ur.UserId)
                .HasColumnName("user_id");
        }
    }
}
