using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Identity.PostgreSQL.EntityConfig
{
    /// <summary>
    /// Application's entity configuration for a claim that a user possesses in the application.
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the user that possesses the claim.</typeparam>
    public class ApplicationUserClaimConfig<TKey> : IEntityTypeConfiguration<Entity.ApplicationUserClaim<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Configures the entity of type ApplicationUserClaim<TKey>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ApplicationUserClaim<TKey>> builder)
        {
            builder.ToTable("user_claims");

            builder.HasKey(uc => uc.Id);
            builder.HasIndex(uc => uc.UserId);

            builder.Property(uc => uc.Id)
                .HasColumnName("id");
            
            builder.Property(uc => uc.UserId)
                .HasColumnName("user_id");

            builder.Property(uc => uc.ClaimType)
                .HasColumnName("claim_type");

            builder.Property(uc => uc.ClaimValue)
                .HasColumnName("claim_value");
        }
    }
}
