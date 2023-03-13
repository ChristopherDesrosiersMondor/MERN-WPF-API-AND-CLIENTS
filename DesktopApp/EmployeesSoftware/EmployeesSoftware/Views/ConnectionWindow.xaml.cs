using EmployeesSoftware.Views;
using EmployeesSoftware.DAO.UserModelDAO;
using System.Windows;

namespace EmployeesSoftware.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class ConnectionWindow : Window
    {
        private UserDAO userDao;
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionWindow"/> class.
        /// </summary>
        public ConnectionWindow()
        {
            InitializeComponent();
            userDao = new UserDAO();
        }

        /// <summary>
        /// Creates a new <see cref="SignUpWindow"/> and close this one.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_item_signup_connection_Click(object sender, RoutedEventArgs e)
        {
            var signup = new SignUpWindow();
            signup.Show();
            this.Close();
        }

        /// <summary>
        /// Exits the program.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_item_quitter_login_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Checks if the form is valid. If not, shows a message saying you need to enter all informations.
        /// Checks if the info is linked to a user account and if so, open the <see cref="AccueilWindow"/> and close this one.
        /// If all that fail, shows a message saying you dont have access to the program.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_connexion_login_Click(object sender, RoutedEventArgs e)
        {
            if (!FormIsValid())
            {
                MessageBox.Show("Entrez les informations necessaires.");
                return;
            }
            if (userDao.IsUser(txt_username_login.Text, txt_password_login.Password)) {
                var accueil = new AccueilWindow();
                accueil.txt_block_username_accueil.Text = txt_username_login.Text;
                accueil.Show();
                Close();
                return;
            }
            MessageBox.Show("Vous n'avez pas acces au programme.");
        }


        /// <summary>
        /// Check if the form is valid.
        /// </summary>
        /// <returns>A bool.</returns>
        private bool FormIsValid()
        {
            bool valid = true;
            if (txt_username_login.Text == string.Empty ||
                txt_password_login.Password == string.Empty)
            {
                valid = false;
            }
            return valid;
        }
    }
}
