using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.PostgreSQL.Entity
{
    /// <summary>
    /// Represents a login and its associated provider for a user of the application.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key of the user associated with this login.</typeparam>
    public class ApplicationUserLogin<TKey> : IdentityUserLogin<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
