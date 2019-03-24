using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace AspNetCore.Identity.PostgreSQL.Entity
{
    /// <summary>
    /// Represents an authentication token for a user of the application.
    /// </summary>
    /// <typeparam name="TKey">The type of the primary key used for users.</typeparam>
    public class ApplicationUserToken<TKey> : IdentityUserToken<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
