using System;
using System.Collections.Generic;
using System.Text;

namespace Group2_Sportproject.Core.Models
{
    public class NBAStanding
    {
        public int TeamID { get; set; }
        public string Key { get; set; } = "";
        public string City { get; set; } = "";
        public string Name { get; set; } = "";
        public string Conference { get; set; } = "";
        public string Division { get; set; } = "";

        public int Wins { get; set; }
        public int Losses { get; set; }
        public double Percentage { get; set; }

        public int ConferenceWins { get; set; }
        public int ConferenceLosses { get; set; }

        public int DivisionWins { get; set; }
        public int DivisionLosses { get; set; }

        public int HomeWins { get; set; }
        public int HomeLosses { get; set; }
        public int AwayWins { get; set; }
        public int AwayLosses { get; set; }

        public int LastTenWins { get; set; }
        public int LastTenLosses { get; set; }

        public int Streak { get; set; }

        public int ConferenceRank { get; set; }
        public int DivisionRank { get; set; }

        public double PointsPerGameFor { get; set; }
        public double PointsPerGameAgainst { get; set; }

        public bool ClinchedPlayoffBirth { get; set; }
    }
}
