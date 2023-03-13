using System;

namespace EmployeesSoftware.Models
{
    /// <summary>
    /// The employee code model to use with <see cref="UsersDBContext"/> class
    /// </summary>
    internal class EmployeeCode
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the inscription code.
        /// </summary>
        public string InscriptionCode { get; set; }
    }
}
