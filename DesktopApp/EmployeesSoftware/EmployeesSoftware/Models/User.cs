using System;

namespace EmployeesSoftware.Models
{
    /// <summary>
    /// A user model to be used with the dbcontext <see cref="UsersDBContext"/> class
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the user since.
        /// </summary>
        public DateTime? UserSince { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}
