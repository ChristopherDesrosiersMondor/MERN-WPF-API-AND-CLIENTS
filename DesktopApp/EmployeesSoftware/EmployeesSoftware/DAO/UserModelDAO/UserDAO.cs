using EmployeesSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSoftware.DAO.UserModelDAO
{
    /// <summary>
    /// A dao class to separate business and database logic for user interaction in the .sdf database of the project.
    /// </summary>
    internal class UserDAO
    {
        private UsersDBContext usersContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDAO"/> class.
        /// </summary>
        public UserDAO()
        {
            usersContext = new UsersDBContext();
        }

        // Create user account
        /// <summary>
        /// Adds the user to the database.
        /// </summary>
        /// <param name="UserSince">The user since.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Username">The username.</param>
        /// <param name="Password">The password.</param>
        public void AddUser(DateTime UserSince, string Name, string Username, string Password)
        {
            User newUser = new User
            {
                UserSince = UserSince,
                Name = Name,
                Username = Username,
                Password = Password
            };
            usersContext.users.Add(newUser);
            usersContext.SaveChanges();
        }

        // Get user by id
        /// <summary>
        /// Gets the user by id from database.
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <returns>An User.</returns>
        public User GetUser(int Id)
        {
            return usersContext.users.Find(Id);
        }

        // check if login info is good
        /// <summary>
        /// Check if a user exists in the database with the information given to us
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>A bool.</returns>
        public bool IsUser(string username, string password)
        {
            var query = from User in usersContext.users
                        where User.Username == username
                        where User.Password == password
                        select User;

            if (query.SingleOrDefault() != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a user is already in the database
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>A bool.</returns>
        public bool AlreadyExists(User user)
        {
            return usersContext.users.Any<User>(u => u.Password == user.Password && u.Name == user.Name);
        }

        // Get a list of all users
        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of Users.</returns>
        public List<User> GetAllUsers()
        {
            return usersContext.users.ToList();
        }

        // Update a user account
        /// <summary>
        /// Updates the user in the database.
        /// </summary>
        /// <param name="Id">The id.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Username">The username.</param>
        /// <param name="Password">The password.</param>
        public void UpdateUser(int Id, string Name, string Username, string Password)
        {
            var UserToUpdate = usersContext.users.Find(Id);
            UserToUpdate.Name = Name;
            UserToUpdate.Username = Username;
            UserToUpdate.Password = Password;
            usersContext.SaveChanges();
        }

        // Delete user
        /// <summary>
        /// Deletes the user in the database.
        /// </summary>
        /// <param name="Id">The id.</param>
        public void DeleteUser(int Id)
        {
            var UserToDelete = usersContext.users.Find(Id);
            usersContext.users.Remove(UserToDelete);
            usersContext.SaveChanges();
        }
    }
}
