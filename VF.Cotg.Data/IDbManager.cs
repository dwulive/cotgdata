using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Cotg.Data
{

    /// <summary>
    /// The Database Manager
    /// </summary>
    public interface IDbManager
    {

        /// <summary>
        /// Create Database
        /// </summary>
        void CreateDatabase();

        /// <summary>
        /// Determine if Database Exists
        /// </summary>
        /// <returns>True if the database exists</returns>
        bool DatabaseExists();

    }
}
