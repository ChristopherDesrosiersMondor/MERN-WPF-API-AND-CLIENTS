using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeesSoftware.Models.APIResponses;
using Newtonsoft.Json;
using System;
using System.Text;

namespace EmployeesSoftware.DAO.ApiDAO
{
    // Source: https://stackoverflow.com/questions/50526018/get-json-array-from-web-api-into-c-sharp
    // Utilisation: utiliser le retour json en string pour le transferer en objets c#
    /// <summary>
    /// The series d a o enabling us to separate business and database logic for the api calls about tv shows.
    /// </summary>
    internal class SeriesDAO
    {
        public HttpClient Client;
        public string url;

        /// <summary>
        /// Initializes a new instance of the <see cref="SeriesDAO"/> class.
        /// </summary>
        public SeriesDAO()
        {
            Client = new HttpClient();
            url = "http://localhost:1312/series/";
        }

        /// <summary>
        /// Gets all shows.
        /// </summary>
        /// <returns>A Task.</returns>
        public async Task<List<Serie>> GetAllShows()
        {
            try
            {
                string response = await Client.GetStringAsync(url);
                var ListOfSeries = JsonConvert.DeserializeObject<List<Serie>>(response);
                return ListOfSeries;
            }
            catch
            {
                Console.WriteLine("Erreur avec le serveur.");
                return null;
            }
        }

        /// <summary>
        /// Adds the show.
        /// </summary>
        /// <param name="UnShow">The un show.</param>
        /// <returns>A Task.</returns>
        public async Task<string> AddShow(Serie UnShow)
        {
            var httpResponse = await Client.PostAsync(url, getBody(UnShow));
            return httpResponse.StatusCode.ToString();
        }

        /// <summary>
        /// Deletes the show.
        /// </summary>
        /// <param name="UnShow">The un show.</param>
        /// <returns>A Task.</returns>
        public async Task<string> DeleteShow(Serie UnShow)
        {
            // Do the actual request and await the response
            var httpResponse = await Client.DeleteAsync(url + UnShow._id);

            return httpResponse.StatusCode.ToString();
        }

        /// <summary>
        /// Updates the show.
        /// </summary>
        /// <param name="UnShow">The un show.</param>
        /// <returns>A Task.</returns>
        public async Task<string> UpdateShow(Serie UnShow)
        {
            var body = getBody(UnShow);

            // Using a different http method
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url + UnShow._id)
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
        /// Returns a stringcontent that we can use as a body for a http request based on a Movie class to be able to use the <see cref="Serie"/> instance 
        /// </summary>
        /// <param name="UnShow">The un show.</param>
        /// <returns>A StringContent.</returns>
        public StringContent getBody(Serie UnShow)
        {
            // Serialize our concrete class into a JSON String
            var stringPayload = JsonConvert.SerializeObject(UnShow);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            return httpContent;
        }
    }
}
