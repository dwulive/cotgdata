using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Cotg.Data.Models
{

    /// <summary>
    /// The Alliance Score History Model
    /// </summary>
    public class AllianceScoreHistoryModel
    {

        /// <summary>
        /// The Row Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Effective Date
        /// </summary>
        public DateTime EffectiveDate { get; set; }

        /// <summary>
        /// The Alliance Name
        /// </summary>
        public string AllianceName { get; set; }

        /// <summary>
        /// The Score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The Cities Number
        /// </summary>
        public int CitiesNumber { get; set; }

        /// <summary>
        /// Not sure if this means 'the continent', if these stats are broken down by cont.
        /// Or if it means the number of contenints.
        /// </summary>
        public int Continent { get; set; }

        /// <summary>
        /// The Number of Players
        /// </summary>
        public int Players { get; set; }

        /// <summary>
        /// The Rank
        /// </summary>
        public int Rank { get; set; }

    }
}
