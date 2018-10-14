using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Cotg.Data.Models
{

    /// <summary>
    /// The Params Model
    /// </summary>
    /// <remarks>
    /// I believe this is used as application settings, but I might be wrong.
    /// For the moment this is not temporal, but if it turns out to be used in the statistics
    /// gathering, it might have to be made temporal.
    /// </remarks>
    public class ParamsModel
    {

        /// <summary>
        /// The Row Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Player Name
        /// </summary>
        public string ParamName { get; set; }

        /// <summary>
        /// The Player Name
        /// </summary>
        public string ParamValue { get; set; }

    }
}
