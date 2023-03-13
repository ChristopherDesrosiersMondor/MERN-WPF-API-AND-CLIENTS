using EmployeesSoftware.Models.APIResponses;
using EmployeesSoftware.DAO.ApiDAO;
using System.Windows;
using System.Windows.Controls;

namespace EmployeesSoftware.Views
{
    /// <summary>
    /// Logique d'interaction pour SeriesWindow.xaml
    /// </summary>
    public partial class SeriesWindow : Window
    {
        SeriesDAO showsDao;
        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesWindow"/> class.
        /// </summary>
        public SeriesWindow()
        {
            InitializeComponent();
            showsDao = new SeriesDAO();
            refreshShows();
        }

        /// <summary>
        /// Send a request to the api for all stored series in api db and reset the view.
        /// </summary>
        public async void refreshShows()
        {
            var response = await showsDao.GetAllShows();
            datagrid_view_series.ItemsSource = response;
            datagrid_view_series.Columns[0].Visibility = Visibility.Hidden;
            datagrid_view_series.Columns[2].Visibility = Visibility.Hidden;
            datagrid_view_series.Columns[5].Visibility = Visibility.Hidden;
            datagrid_view_series.Columns[8].Visibility = Visibility.Hidden;
            btn_modifier_serie.Content = "Modifier";
            txt_titre_serie.Text = "Titre";
            txt_synopsis_serie.Text = "Synopsis";
            txt_annee_serie.Text = "Annees de difusions";
            txt_duree_serie.Text = "Duree en minutes";
            txt_nbSaisons_serie.Text = "Nb de saisons";
            txt_posterImage.Text = "PosterImage";
            cb_status_production_serie.SelectedItem = null;

        }

        /// <summary>
        /// Creates a new <see cref="FilmWindow"/> and closes this one.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_film_series_Click(object sender, RoutedEventArgs e)
        {
            var filmTool = new FilmWindow();
            filmTool.Show();
            Close();
        }

        /// <summary>
        /// Does nothing cause we are already in <see cref="SeriesWindow"/> view.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_serie_series_Click(object sender, RoutedEventArgs e)
        {
            return;
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

        /// <summary>
        /// Deletes a show from api db.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private async void btn_delete_serie_Click(object sender, RoutedEventArgs e)
        {
            var response = await showsDao.DeleteShow((Serie)datagrid_view_series.SelectedItem);
            txt_block_mode_edition_or_creation_film.Text = response;
            refreshShows();
        }

        /// <summary>
        /// Calls <see cref="SeriesDAO.AddShow(Serie)"/> and <see cref="refreshShows"/> with this view form informations
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private async void btn_ajouter_serie_Click(object sender, RoutedEventArgs e)
        {
            Serie newShow = new Serie
            {
                titre = txt_titre_serie.Text,
                synopsis = txt_synopsis_serie.Text,
                annee = txt_annee_serie.Text,
                duree = txt_duree_serie.Text,
                posterImage = txt_posterImage.Text,
                productionStatus = ((ComboBoxItem)cb_status_production_serie.SelectedItem).Content.ToString(),
                nombreSaisons = int.Parse(txt_nbSaisons_serie.Text)
            };

            var response = await showsDao.AddShow(newShow);
            txt_block_mode_edition_or_creation_film.Text = response;
            refreshShows();
        }

        /// <summary>
        /// Calls <see cref="SeriesDAO.UpdateShow(Serie)"/> and <see cref="refreshShows"/> 
        /// with this view form informations updated based on the <see cref="datagrid_view_series"/> selected item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private async void btn_modifier_serie_Click(object sender, RoutedEventArgs e)
        {
            if (btn_modifier_serie.Content.ToString() == "Modifier")
            {
                var show = (Serie)datagrid_view_series.SelectedItem;
                btn_modifier_serie.Content = "Sauvegarder";
                txt_titre_serie.Text = show.titre;
                txt_synopsis_serie.Text = show.synopsis;
                txt_annee_serie.Text = show.annee;
                txt_duree_serie.Text = show.duree;
                txt_nbSaisons_serie.Text = show.nombreSaisons.ToString();
                txt_posterImage.Text = show.posterImage;
                foreach (ComboBoxItem selection in cb_status_production_serie.Items)
                {
                    if (selection.Content.ToString() == show.productionStatus)
                    {
                        cb_status_production_serie.SelectedItem = selection;
                        break;
                    }
                }
            }
            else
            {
                btn_modifier_serie.Content = "Modifier";
                var show = (Serie)datagrid_view_series.SelectedItem;
                show.titre = txt_titre_serie.Text;
                show.synopsis = txt_synopsis_serie.Text;
                show.annee = txt_annee_serie.Text;
                show.duree = txt_duree_serie.Text;
                show.nombreSaisons = int.Parse(txt_nbSaisons_serie.Text);
                show.posterImage = txt_posterImage.Text;
                show.productionStatus = ((ComboBoxItem)cb_status_production_serie.SelectedItem).Content.ToString();

                var response = await showsDao.UpdateShow(show);
                txt_block_mode_edition_or_creation_film.Text = response;
                refreshShows();
            }
        }

        /// <summary>
        /// Cancels all current actions by reseting view with <see cref="refreshShows"/>
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void btn_cancl_action_serie_Click(object sender, RoutedEventArgs e)
        {
            refreshShows();

            txt_block_mode_edition_or_creation_film.Text = "Ready";
        }
    }
}
