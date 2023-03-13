using EmployeesSoftware.DAO.ApiDAO;
using EmployeesSoftware.Models.APIResponses;
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
    /// Logique d'interaction pour FilmWindow.xaml
    /// </summary>
    public partial class FilmWindow : Window
    {
        MoviesDAO movieDao;
        /// <summary>
        /// Initializes a new instance of the <see cref="FilmWindow"/> class.
        /// </summary>
        public FilmWindow()
        {
            InitializeComponent();
            movieDao = new MoviesDAO();
            refreshMovies();
        }

        /// <summary>
        /// Send a request to the api for all stored movies in api db and reset the view.
        /// </summary>
        public async void refreshMovies()
        {
            var response = await movieDao.GetAllMovies();
            datagrid_view_films.ItemsSource = response;
            datagrid_view_films.Columns[0].Visibility = Visibility.Hidden;
            datagrid_view_films.Columns[2].Visibility = Visibility.Hidden;
            datagrid_view_films.Columns[5].Visibility = Visibility.Hidden;
            datagrid_view_films.Columns[6].Visibility = Visibility.Hidden;
            btn_modifier_film.Content = "Modifier";
            txt_titre_film.Text = "Titre";
            txt_synopsis_film.Text = "Synopsis";
            txt_annee_film.Text = "Annees de difusions";
            txt_duree_film.Text = "Duree en minutes";
            txt_posterImage.Text = "PosterImage";

        }

        /// <summary>
        /// Does nothing cause we are already in film view.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_film_film_Click(object sender, RoutedEventArgs e)
        {
            return;
        }

        /// <summary>
        /// Creates a new <see cref="SeriesWindow"/> and closes this one
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_serie_films_Click(object sender, RoutedEventArgs e)
        {
            var serieTool = new SeriesWindow();
            serieTool.Show();
            Close();
        }

        /// <summary>
        /// Creates a new <see cref="AccueilWindow"/> and closes this one.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_item_accueil_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Creates a new <see cref="ConnectionWindow"/> and closes this one
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
        /// Closes the program.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void menu_item_quitter_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Adds film to db using a dedicated dao for the api calls.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private async void btn_ajouter_film_Click(object sender, RoutedEventArgs e)
        {
            Movie newMovie = new Movie
            {
                titre = txt_titre_film.Text,
                synopsis = txt_synopsis_film.Text,
                annee = txt_annee_film.Text,
                duree = txt_duree_film.Text,
                posterImage = txt_posterImage.Text,
            };

            var response = await movieDao.AddMovie(newMovie);
            txt_block_mode_edition_or_creation_film.Text = response;
            refreshMovies();
        }

        /// <summary>
        /// Modify film to db using a dedicated dao for the api calls.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private async void btn_modifier_film_Click(object sender, RoutedEventArgs e)
        {
            if (btn_modifier_film.Content.ToString() == "Modifier")
            {
                var movie = (Movie)datagrid_view_films.SelectedItem;
                btn_modifier_film.Content = "Sauvegarder";
                txt_titre_film.Text = movie.titre;
                txt_synopsis_film.Text = movie.synopsis;
                txt_annee_film.Text = movie.annee;
                txt_duree_film.Text = movie.duree;
                txt_posterImage.Text = movie.posterImage;
            }
            else
            {
                btn_modifier_film.Content = "Modifier";
                var movie = (Movie)datagrid_view_films.SelectedItem;
                movie.titre = txt_titre_film.Text;
                movie.synopsis = txt_synopsis_film.Text;
                movie.annee = txt_annee_film.Text;
                movie.duree = txt_duree_film.Text;
                movie.posterImage = txt_posterImage.Text;

                var response = await movieDao.UpdateMovie(movie);
                txt_block_mode_edition_or_creation_film.Text = response;
                refreshMovies();
            }
        }

        /// <summary>
        /// Deletes film from db using a dedicated dao for the api calls.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private async void btn_delete_film_Click(object sender, RoutedEventArgs e)
        {
            var response = await movieDao.DeleteMovie((Movie)datagrid_view_films.SelectedItem);
            txt_block_mode_edition_or_creation_film.Text = response;
            refreshMovies();
        }

        /// <summary>
        /// Cancel all actual actions by reseting view
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_cancl_action_film_Click(object sender, RoutedEventArgs e)
        {
            refreshMovies();

            txt_block_mode_edition_or_creation_film.Text = "Ready";
        }
    }
}
