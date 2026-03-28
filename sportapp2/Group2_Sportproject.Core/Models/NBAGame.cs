using System;
using System.Collections.Generic;
using System.Text;

namespace Group2_Sportproject.Core.Models
{
    public class NBAGame
    {
        public int GameID { get; set; }
        public int Season { get; set; }
        public int SeasonType { get; set; }  

        public string Status { get; set; } = "";

        public DateTime? DateTime { get; set; }

        public string AwayTeam { get; set; } = "";
        public string HomeTeam { get; set; } = "";

        public string Matchup => $"{AwayTeam} @ {HomeTeam}"; 

        public int? AwayTeamScore { get; set; }
        public int? HomeTeamScore { get; set; }

        public string Channel { get; set; } = "";
    }
}
