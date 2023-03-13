using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeesSoftware.Views
{
    /// <summary>
    /// Logique d'interaction pour AccueilWindow.xaml
    /// </summary>
    public partial class AccueilWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccueilWindow"/> class.
        /// </summary>
        public AccueilWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new <see cref="FilmWindow"/> and closes this one.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_film_accueil_Click(object sender, RoutedEventArgs e)
        {
            var filmTool = new FilmWindow();
            filmTool.ShowDialog();
        }

        /// <summary>
        /// Creates a new <see cref="SeriesWindow"/> and closes this one.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_serie_accueil_Click(object sender, RoutedEventArgs e)
        {
            var serieTool = new SeriesWindow();
            Visibility = Visibility.Collapsed;
            serieTool.ShowDialog();
            Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Does nothing cause we are already in <see cref="AccueilWindow"/> view.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_item_accueil_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        /// <summary>
        /// Creates a new <see cref="ConnectionWindow"/> and closes this one.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_item_deconnect_Click(object sender, RoutedEventArgs e)
        {
            var connexion = new ConnectionWindow();
            connexion.Show();
            Close();
        }

        /// <summary>
        /// Exits the program.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_item_quitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
