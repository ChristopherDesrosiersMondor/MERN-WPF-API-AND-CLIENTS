using EmployeesSoftware.Models.APIResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSoftware.DAO.ApiDAO
{
    /// <summary>
    /// The movies d a o that enables us to separate business and database logic for the api calls concerning movies.
    /// </summary>
    internal class MoviesDAO
    {
        public HttpClient Client;
        public string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="MoviesDAO"/> class.
        /// </summary>
        public MoviesDAO()
        {
            Client = new HttpClient();
            url = "http://localhost:1312/films/";
        }

        /// <summary>
        /// Gets all movies.
        /// </summary>
        /// <returns>A list of <see cref="Movie"/> objects</returns>
        public async Task<List<Movie>> GetAllMovies()
        {
            try
            {
                string response = await Client.GetStringAsync(url);
                var ListOfMovies = JsonConvert.DeserializeObject<List<Movie>>(response);
                return ListOfMovies;
            }
            catch
            {
                Console.WriteLine("Erreur avec le serveur.");
                return null;
            }
        }

        /// <summary>
        /// Adds the movie.
        /// </summary>
        /// <param name="UnMovie">The movie.</param>
        /// <returns>The responses code string representaion</returns>
        public async Task<string> AddMovie(Movie UnMovie)
        {
            var httpResponse = await Client.PostAsync(url, getBody(UnMovie));
            return httpResponse.StatusCode.ToString();
        }

        /// <summary>
        /// Deletes the movie.
        /// </summary>
        /// <param name="UnMovie">The movie.</param>
        /// <returns>The responses code string representaion</returns>
        public async Task<string> DeleteMovie(Movie UnMovie)
        {
            // Do the actual request and await the response
            var httpResponse = await Client.DeleteAsync(url + UnMovie._id);

            return httpResponse.StatusCode.ToString();
        }

        /// <summary>
        /// Updates the movie.
        /// </summary>
        /// <param name="UnMovie">The movie.</param>
        /// <returns>The responses code string representaion</returns>
        public async Task<string> UpdateMovie(Movie UnMovie)
        {
            var body = getBody(UnMovie);

            // Using a different http method
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url + UnMovie._id)
            {
                Content = body
            };

            // Do the actual request and await the response
            var httpResponse = await Client.SendAsync(request);

            return httpResponse.StatusCode.ToString();
        }

        //Source : https://stackoverflow.com/questions/65064342/how-to-make-an-http-patch-request-from-c-sharp-with-a-parameter-frombody
        // Utilisation: utiliser des methodes non proposes par .Net
        // Source : https://stackoverflow.com/questions/23585919/send-json-via-post-in-c-sharp-and-receive-the-json-returned
        /// <summary>
        /// Returns a stringcontent that we can use as a body for a http request based on a Movie class to be able to use the <see cref="Movie"/> instance 
        /// </summary>
        /// <param name="UnMovie">The movie.</param>
        /// <returns>A StringContent.</returns>
        public StringContent getBody(Movie UnMovie)
        {
            // Serialize our concrete class into a JSON String
            var stringPayload = JsonConvert.SerializeObject(UnMovie);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            return httpContent;
        }
    }
}
