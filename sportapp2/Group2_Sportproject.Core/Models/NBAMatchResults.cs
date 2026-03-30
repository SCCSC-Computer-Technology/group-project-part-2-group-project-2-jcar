using System;
using System.Collections.Generic;
using System.Text;

namespace Group2_Sportproject.Core.Models
{
    public class NBAMatchResults
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public string Status { get; set; }
        public DateTime Day { get; set; }
    }
}