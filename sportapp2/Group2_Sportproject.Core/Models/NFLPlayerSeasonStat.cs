using System;
using System.Collections.Generic;
using System.Text;

namespace Group2_Sportproject.Core.Models
{
    public class NFLPlayerSeasonStat
    {
        public int PlayerID { get; set; }
        public string Name { get; set; } = "";
        public string Team { get; set; } = "";
        public string Position { get; set; } = "";

        public int? Played { get; set; }

        public double? PassingYards { get; set; }
        public double? PassingTouchdowns { get; set; }
        public double? PassingInterceptions { get; set; }

        public double? RushingYards { get; set; }
        public double? RushingTouchdowns { get; set; }

        public double? ReceivingYards { get; set; }
        public double? ReceivingTouchdowns { get; set; }

        public double? Tackles { get; set; }
        public double? Sacks { get; set; }
        public double? Interceptions { get; set; }
    }
}
