using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.Identity.PostgreSQL.EntityConfig
{
    /// <summary>
    /// Application's entity configuration for the role in the application's identity system
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the role.</typeparam>
    public class ApplicationRoleConfig<TKey> : IEntityTypeConfiguration<Entity.ApplicationRole<TKey>>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Configures the entity of type ApplicationRole<TKey>.
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ApplicationRole<TKey>> builder)
        {
            builder.ToTable("roles");

            builder.HasKey(rc => rc.Id);

            builder.Property(rc => rc.Id)
                .HasColumnName("id");

            builder.Property(r => r.Name)
                .HasColumnName("name");

            builder.Property(r => r.NormalizedName)
                .HasColumnName("normalized_name");

            builder.Property(r => r.ConcurrencyStamp)
                .HasColumnName("concurrency_stamp");
        }
    }
}
