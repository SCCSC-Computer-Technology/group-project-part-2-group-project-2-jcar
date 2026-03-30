using System;
using System.Collections.Generic;
using System.Text;

namespace Group2_Sportproject.Core.Models
{
    public class NFLMatchResults
    {
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}