using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.PostgreSQL.Entity
{
    /// <summary>
    /// Represents a claim that is granted to all users within a role in the application.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key of the role associated with this claim.</typeparam>
    public class ApplicationRoleClaim<TKey> : IdentityRoleClaim<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
