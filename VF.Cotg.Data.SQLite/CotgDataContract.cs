using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Cotg.Data.SQLite
{

    /// <summary>
    /// The Crown of the Cods DataTracking Database Contract
    /// </summary>
    internal static class CotgDataContract
    {

        /// <summary>
        /// The Unit Kills History Data Contract
        /// </summary>
        public static class UnitKillsHistory
        {

            /// <summary>
            /// The Table Name
            /// </summary>
            public const string TABLE_NAME = "UnitKillsHistory";

            /// <summary>
            /// The ID Column, Column Name
            /// </summary>
            public const string COLUMN_ID_NAME = "ID";

            /// <summary>
            /// The Player Name Colum, Column Name
            /// </summary>
            public const string COLUMN_PLAYERNAME_NAME = "PlayerName";

            /// <summary>
            /// The Effective Date Column, Column Name
            /// </summary>
            public const string COLUMN_EFFECTIVEDATE_NAME = "EffectveDate";

            /// <summary>
            /// The Score Column, Column Name
            /// </summary>
            public const string COLUMN_SCORE_NAME = "Score";

            /// <summary>
            /// The Rank Column, Column Name
            /// </summary>
            public const string COLUMN_RANK_NAME = "Rank";

        }

    }
}
