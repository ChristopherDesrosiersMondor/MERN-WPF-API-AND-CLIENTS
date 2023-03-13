using System;
using System.Windows;
using EmployeesSoftware.Models;
using EmployeesSoftware.DAO.UserModelDAO;

namespace EmployeesSoftware.Views
{
    /// <summary>
    /// Logique d'interaction pour SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private UsersDBContext context;
        private EmployeeCodesDAO codesDao;
        private UserDAO userDao;
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpWindow"/> class.
        /// </summary>
        public SignUpWindow()
        {
            InitializeComponent();
            context = new UsersDBContext();
            codesDao = new EmployeeCodesDAO();
            userDao = new UserDAO();
        }

        /// <summary>
        /// Creates a new <see cref="ConnectionWindow"/> and closes this one
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_connexion_signup_Click(object sender, RoutedEventArgs e)
        {
            var login = new ConnectionWindow();
            login.Show();
            Close();
        }

        /// <summary>
        /// Exits the program
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_quitter_signup_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 1. Checks the form validity with <see cref="FormValidity"/>
        /// 2. Creates a <see cref="User"/> object from form informations
        /// 3. If the user doesnt already exists <see cref="UserDAO.AlreadyExists(User)"/> and the given code 
        /// exists <see cref="EmployeeCodesDAO.getCode(string)"/> it adds the user 
        /// <see cref="UserDAO.AddUser(DateTime, string, string, string)"/> to the db 
        /// and deletes <see cref="EmployeeCodesDAO.DeleteCode(EmployeeCode)"/> the code used from the db causes the codes
        /// are a one time key to add an account.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_connexion_signup_Click(object sender, RoutedEventArgs e)
        {
            if (!FormValidity())
            {
                _ = MessageBox.Show("Les informations ne sont pas valides. Assurez vous de completer tous les champs.");
                return;
            }
            var user = new User
            {
                UserSince = DateTime.Now,
                Name = txt_name.Text,
                Username = txt_username.Text,
                Password = txt_password.Password
            };

            var code = codesDao.getCode(txt_inscription_code.Text);

            if (!userDao.AlreadyExists(user) && code != null)
            {
                userDao.AddUser(DateTime.Now, txt_name.Text, txt_username.Text, txt_password.Password);
                codesDao.DeleteCode(code);

                MessageBox.Show("Votre compte est ajoutee a la base de donnees.");

                ConnectionWindow login = new ConnectionWindow();
                login.Show();
                Close();
            }
            else
            {
                _ = MessageBox.Show("Soit le compte existe deja, soit votre code est invalide.");
            }
        }

        /// <summary>
        /// Checks the validity of the form
        /// </summary>
        /// <returns>A bool.</returns>
        public bool FormValidity()
        {
            bool valid = true;

            if (txt_name.Text == string.Empty ||
                txt_username.Text == string.Empty ||
                txt_password.Password == string.Empty ||
                txt_inscription_code.Text == string.Empty)
            {
                valid = false;
            }

            return valid;
        }
    }
}
