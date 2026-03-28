using System;
using System.Collections.Generic;
using System.Text;

namespace Group2_Sportproject.Core.Models
{
    public class NBAPlayerSeasonStat
    {
        public int PlayerID { get; set; }
        public string Name { get; set; } = "";
        public string Team { get; set; } = "";
        public string Position { get; set; } = "";

        public int? Games { get; set; }

        public double? Points { get; set; }
        public double? Assists { get; set; }
        public double? Rebounds { get; set; }

        public double? FieldGoalsMade { get; set; }
        public double? FieldGoalsAttempted { get; set; }
        public double? FieldGoalsPercentage { get; set; }

        public double? ThreePointersMade { get; set; }
        public double? ThreePointersAttempted { get; set; }
        public double? ThreePointersPercentage { get; set; }

        public double? FreeThrowsMade { get; set; }
        public double? FreeThrowsAttempted { get; set; }
        public double? FreeThrowsPercentage { get; set; }

        public double? Steals { get; set; }
        public double? BlockedShots { get; set; }
        public double? Turnovers { get; set; }
    }
}
