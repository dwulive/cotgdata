using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VF.Cotg.Data.Models
{

    /// <summary>
    /// The Current Empire Ranking Model
    /// </summary>
    public class CurrentEmpireRankingModel
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
        /// The Player Name
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// The Player Rank
        /// </summary>
        public int Rank { get; set; }

        /// <summary>
        /// The Player Score
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The Alliance Name
        /// </summary>
        public string AllianceName { get; set; }

        /// <summary>
        /// The Number of Cities
        /// </summary>
        public int CitiesNumber { get; set; }

        /// <summary>
        /// Again, not sure yet if this is the Number of conteninets, or the continent number, but I think it's the number of continents
        /// </summary>
        public int Continent { get; set; }

        /// <summary>
        /// The Number of Unit Kills
        /// </summary>
        public long UnitsKills { get; set; }

        /// <summary>
        /// The Units Kills Rank
        /// </summary>
        public int UnitsKillsRank { get; set; }

        /// <summary>
        /// The Number of Caverns
        /// </summary>
        public long Caverns { get; set; }

        /// <summary>
        /// The Caverns Rank
        /// </summary>
        public int CavernsRank { get; set; }

        /// <summary>
        /// The Unit Kills Difference Average
        /// </summary>
        /// <remarks>
        /// This might be a way of claculating differences between polls? or perhaps between set amounts of time
        /// I'll have to investigate it a bit.
        /// </remarks>
        public float UnitsKillsDiffAvg { get; set; }

        /// <summary>
        /// The Score Difference Average
        /// </summary>
        public float ScoreDiffAvg { get; set; }

        /// <summary>
        /// The Defense Reputation
        /// </summary>
        public long DefReputation { get; set; }

        /// <summary>
        /// The Defense Reputation Rank
        /// </summary>
        public int DefReputationRank { get; set; }

        /// <summary>
        /// The Offensive Reputation
        /// </summary>
        public long OffReputation { get; set; }

        /// <summary>
        /// The Offensive Reputation Rank
        /// </summary>
        public int OffReputationRank { get; set; }

        /// <summary>
        /// The Defense Reputation Difference Average
        /// </summary>
        public float DefReputationDiffAvg { get; set; }

        /// <summary>
        /// The Offensive Reputation Difference Average
        /// </summary>
        public float OffReputationDiffAvg { get; set; }

        /// <summary>
        /// I think this is the last polled rank
        /// </summary>
        public int RankLastChange { get; set; }

        /// <summary>
        /// I think this is the last polled score
        /// </summary>
        public int ScoreLastChange { get; set; }

        /// <summary>
        /// I think this is the last polled number of cities
        /// </summary>
        public int CitiesLastChange { get; set; }

        /// <summary>
        /// I think this is the last polled Defense Reputation
        /// </summary>
        public int DefReputationRankLastChange { get; set; }

    }
}
