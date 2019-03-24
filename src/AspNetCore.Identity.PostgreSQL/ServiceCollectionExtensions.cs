using System;
using System.Collections.Generic;
using System.Text;
using AspNetCore.Identity.PostgreSQL.Entity;
using AspNetCore.Identity.PostgreSQL.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.Identity.PostgreSQL
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configure the identity store using Npgsql.
        /// </summary>
        /// <typeparam name="TKey">The type of the primary key for users and roles.</typeparam>
        /// <param name="services"></param>
        /// <param name="connectionString">The datastore connection string</param>
        public static void ConfigureNpgsqlIdentityForAspNetIdentity<TKey>(this IServiceCollection services, string connectionString)
            where TKey : IEquatable<TKey>
        {
            services.ConfigureNpgsqlIdentityForAspNetIdentity<TKey, NpgsqlIdentityDbContext<TKey>, ApplicationUser<TKey>, ApplicationRole<TKey>>(connectionString);
        }
        /// <summary>
        /// Configure the identity store using Npgsql. Use this if you need to subclass the Identity entities (e.g. you have to add more fields to the <see cref="ApplicationUser{TKey}"/>
        /// </summary>
        /// <typeparam name="TKey">The type of the primary key for users and roles.</typeparam>
        /// <typeparam name="TContext"></typeparam>
        /// <typeparam name="TUser"></typeparam>
        /// <typeparam name="TRole"></typeparam>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void ConfigureNpgsqlIdentityForAspNetIdentity<TKey, TContext, TUser, TRole>(this IServiceCollection services, string connectionString)
            where TKey : IEquatable<TKey>
            where TContext : NpgsqlIdentityDbContext<TKey>
            where TUser : ApplicationUser<TKey>
            where TRole : ApplicationRole<TKey>
        {
            services.AddIdentity<TUser, TRole>()
                .AddEntityFrameworkStores<TContext>()
                .AddDefaultTokenProviders();

            services.AddEntityFrameworkNpgsql()
               .AddDbContext<TContext>(options =>
               {
                   options.UseNpgsql(connectionString);
               })
               .BuildServiceProvider();
        }
    }
}
