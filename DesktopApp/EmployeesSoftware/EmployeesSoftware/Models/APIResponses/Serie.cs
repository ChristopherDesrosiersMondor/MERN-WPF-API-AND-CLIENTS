using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesSoftware.Models.APIResponses
{
    /// <summary>
    /// Movie class to be able to use the <see cref="EmployeesSoftware.DAO.ApiDAO.SeriesDAO"/> class 
    /// </summary>
    internal class Serie
    {
        /// <summary>
        /// Gets or sets the _id.
        /// </summary>
        public string _id { get; set; }
        /// <summary>
        /// Gets or sets the titre.
        /// </summary>
        public string titre { get; set; }
        /// <summary>
        /// Gets or sets the synopsis.
        /// </summary>
        public string synopsis { get; set; }
        /// <summary>
        /// Gets or sets the annee.
        /// </summary>
        public string annee { get; set; }
        /// <summary>
        /// Gets or sets the duree.
        /// </summary>
        public string duree { get; set; }
        /// <summary>
        /// Gets or sets the poster image.
        /// </summary>
        public string posterImage { get; set; }
        /// <summary>
        /// Gets or sets the production status.
        /// </summary>
        public string productionStatus { get; set; }
        /// <summary>
        /// Gets or sets the nombre saisons.
        /// </summary>
        public int nombreSaisons { get; set; }
        /// <summary>
        /// Gets or sets the __v.
        /// </summary>
        public int __v { get; set; }

        /// <summary>
        /// String representation of <see cref="Serie"/> object.
        /// </summary>
        /// <returns>A string.</returns>
        public override string ToString()
        {
            return titre + " " + annee;
        }
    }
}
