using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Identity.PostgreSQL.EntityConfig
{
    /// <summary>
    /// Application's entity configuration for a claim that is granted to all users within a role in the application.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key of the role associated with the claim.</typeparam>
    public class ApplicationRoleClaimConfig<TKey> : IEntityTypeConfiguration<Entity.ApplicationRoleClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Configures the entity of type ApplicationRoleClaimConfig<TKey>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ApplicationRoleClaim<TKey>> builder)
        {
            builder.ToTable("role_claims");

            builder.HasKey(rc => rc.Id);
            builder.HasIndex(rc => rc.RoleId);

            builder.Property(rc => rc.Id)
                .HasColumnName("id");

            builder.Property(rc => rc.RoleId)
                .HasColumnName("role_id");

            builder.Property(rc => rc.ClaimType)
                .HasColumnName("claim_type");

            builder.Property(rc => rc.ClaimValue)
                .HasColumnName("claim_value");
        }
    }
}
