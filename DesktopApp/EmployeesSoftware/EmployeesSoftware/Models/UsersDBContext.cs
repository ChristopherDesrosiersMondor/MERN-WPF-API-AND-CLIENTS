using System.Data.Entity;
using EmployeesSoftware.Models;

namespace EmployeesSoftware.Models
{
    /// <summary>
    /// A custom dbcontext with a set of users and codes
    /// </summary>
    internal class UsersDBContext : DbContext
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> users { get; set; }

        /// <summary>
        /// Gets or sets the codes.
        /// </summary>
        public DbSet<EmployeeCode> codes { get; set; }
    }
}
