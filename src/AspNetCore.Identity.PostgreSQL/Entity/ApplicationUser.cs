using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.PostgreSQL.Entity
{
    /// <summary>
    /// Represents a user in the identity system of the application.
    /// </summary>
    /// <typeparam name="TKey">The type used for the primary key for the user.</typeparam>
    public class ApplicationUser<TKey> : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
