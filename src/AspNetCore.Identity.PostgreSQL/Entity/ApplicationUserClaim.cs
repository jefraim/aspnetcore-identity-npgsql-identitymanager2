using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.PostgreSQL.Entity
{
    /// <summary>
    /// Represents a claim that a user possesses in the application.
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for this user that possesses this claim.</typeparam>
    public class ApplicationUserClaim<TKey> : IdentityUserClaim<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
