using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.PostgreSQL.Entity
{
    /// <summary>
    /// Represents the link between a user and a role of the application.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key used for users and roles.</typeparam>
    public class ApplicationUserRole<TKey> : IdentityUserRole<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
