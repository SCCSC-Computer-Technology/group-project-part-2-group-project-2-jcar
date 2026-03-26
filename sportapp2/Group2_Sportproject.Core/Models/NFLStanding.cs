using System;
using System.Collections.Generic;
using System.Text;

namespace Group2_Sportproject.Core.Models
{
    public class NFLStanding
    {
        public string Team { get; set; }

        public string Name { get; set; }

        public string Conference { get; set; }

        public string Division { get; set; }

        public int Wins { get; set; }

        public int Losses { get; set; }

        public int Ties { get; set; }

        public double? Percentage { get; set; }

        public int ConferenceRank { get; set; }

        public int DivisionRank { get; set; }

        public int PointsFor { get; set; }

        public int PointsAgainst { get; set; }

        public int NetPoints { get; set; }
    }
}
