using EmployeesSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSoftware.DAO.UserModelDAO
{
    /// <summary>
    /// The employee codes d a o to enable us to separate business and database logic for employee codes access.
    /// </summary>
    internal class EmployeeCodesDAO
    {
        private UsersDBContext usersContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeCodesDAO"/> class.
        /// </summary>
        public EmployeeCodesDAO()
        {
            usersContext = new UsersDBContext();
        }

        // Create a new code
        /// <summary>
        /// Creates the new code.
        /// </summary>
        /// <param name="InscriptionCode">The inscription code.</param>
        public void CreateNewCode(string InscriptionCode)
        {
            var NewCode = new EmployeeCode
            {
                InscriptionCode = InscriptionCode
            };
            usersContext.codes.Add(NewCode);
            usersContext.SaveChanges();
        }

        // Get all codes
        /// <summary>
        /// gets the codes.
        /// </summary>
        /// <returns>A list of EmployeeCodes.</returns>
        public List<EmployeeCode> getCodes()
        {
            return usersContext.codes.ToList();
        }

        // Get code by code
        /// <summary>
        /// gets the code.
        /// </summary>
        /// <param name="Code">The code.</param>
        /// <returns>An EmployeeCode.</returns>
        public EmployeeCode getCode(string Code)
        {

            var query = from EmployeeCode in usersContext.codes
                        where EmployeeCode.InscriptionCode == Code
                        select new { EmployeeCode.Id, EmployeeCode.InscriptionCode };

            // Source : https://stackoverflow.com/questions/11801769/handling-sequence-has-no-elements-exception
            // Utilisation : handling error when the code aint in the database
            if (query.SingleOrDefault() != null)
            {
                var code = new EmployeeCode
                {
                    Id = query.Single().Id,
                    InscriptionCode = query.Single().InscriptionCode
                };
                return code;
            } else
            {
                return null;
            }

        }

        // Delete code
        /// <summary>
        /// Deletes the code.
        /// </summary>
        /// <param name="code">The code.</param>
        public void DeleteCode(EmployeeCode code)
        {
            var codeRemove = usersContext.codes.Find(code.Id);
            usersContext.codes.Remove(codeRemove);
            usersContext.SaveChanges();
        }
    }
}
