using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Group2_Sportproject.Core.Models;
using Group2_Sportproject.Core.Services;

namespace Group2_Sportproject.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly SportsApiService _sportsApiService;

        public List<NBATeams> NBATeams { get; set; } = new();
        public List<NFLTeam> NFLTeams { get; set; } = new();
        public List<NFLStanding> NFLStandings { get; set; } = new();

        public List<NBAStanding> EasternStandings { get; set; } = new();
        public List<NBAStanding> WesternStandings { get; set; } = new();

        public string League { get; set; } = "";
        public string ErrorMessage { get; set; } = "";

        public string SelectedSeason { get; set; } = "2026";
        public string SelectedNFLSeason { get; set; } = "2025REG";

        public Dictionary<string, string> AvailableSeasons { get; set; } = new()
        {
            { "2026", "2025-2026" },
            { "2025", "2024-2025" }
        };

        public Dictionary<string, string> AvailableNFLSeasons { get; set; } = new()
        {
            { "2025REG", "2025 Season" },
            { "2024REG", "2024 Season" }
        };

        public IndexModel(SportsApiService sportsApiService)
        {
            _sportsApiService = sportsApiService;
        }

        public async Task OnGetAsync(string league, string? season, string? nflSeason)
        {
            League = league?.ToLower() ?? "";
            SelectedSeason = string.IsNullOrWhiteSpace(season) ? "2026" : season;
            SelectedNFLSeason = string.IsNullOrWhiteSpace(nflSeason) ? "2025REG" : nflSeason;

            if (!AvailableSeasons.ContainsKey(SelectedSeason))
            {
                SelectedSeason = "2026";
            }

            if (!AvailableNFLSeasons.ContainsKey(SelectedNFLSeason))
            {
                SelectedNFLSeason = "2025REG";
            }

            try
            {
                if (League == "nba")
                {
                    var allStandings = await _sportsApiService.GetNBAStandingsAsync(SelectedSeason);

                    EasternStandings = allStandings
                        .Where(t => !string.IsNullOrWhiteSpace(t.Conference) &&
                                    t.Conference.Equals("Eastern", StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(t => t.Wins)
                        .ThenBy(t => t.Losses)
                        .ToList();

                    WesternStandings = allStandings
                        .Where(t => !string.IsNullOrWhiteSpace(t.Conference) &&
                                    t.Conference.Equals("Western", StringComparison.OrdinalIgnoreCase))
                        .OrderByDescending(t => t.Wins)
                        .ThenBy(t => t.Losses)
                        .ToList();

                    FixRanks(EasternStandings);
                    FixRanks(WesternStandings);
                }
                else if (League == "nfl")
                {
                    var standings = await _sportsApiService.GetNFLStandingsAsync(SelectedNFLSeason);

                    NFLStandings = standings
                        .OrderBy(t => t.Conference)
                        .ThenBy(t => t.Division)
                        .ThenBy(t => t.DivisionRank)
                        .ThenByDescending(t => t.Wins)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void FixRanks(List<NBAStanding> standings)
        {
            for (int i = 0; i < standings.Count; i++)
            {
                standings[i].ConferenceRank = i + 1;
            }
        }

        public string GetGamesBack(NBAStanding team, List<NBAStanding> conferenceStandings)
        {
            if (conferenceStandings == null || conferenceStandings.Count == 0)
                return "-";

            NBAStanding leader = conferenceStandings.First();

            if (team.TeamID == leader.TeamID)
                return "-";

            double gb = ((leader.Wins - team.Wins) + (team.Losses - leader.Losses)) / 2.0;
            return gb.ToString("0.0");
        }

        public string GetStreakText(int streak)
        {
            if (streak > 0)
                return "W" + streak;
            if (streak < 0)
                return "L" + Math.Abs(streak);

            return "-";
        }

        public string GetNBALogoPath(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName))
                return "/images/SportIcons/NBA/nba.png";

            return $"/images/SportIcons/NBA/{teamName}.png";
        }

        public string GetNFLLogoPath(string teamCode)
        {
            var map = new Dictionary<string, string>()
            {
                {"NE", "Patriots"},
                {"BUF", "Bills"},
                {"MIA", "Dolphins"},
                {"NYJ", "Jets"},

                {"PIT", "Steelers"},
                {"BAL", "Ravens"},
                {"CIN", "Bengals"},
                {"CLE", "Browns"},

                {"JAX", "Jaguars"},
                {"HOU", "Texans"},
                {"IND", "Colts"},
                {"TEN", "Titans"},

                {"DEN", "Broncos"},
                {"LAC", "Chargers"},
                {"KC", "Chiefs"},
                {"LV", "Raiders"},

                {"DAL", "Cowboys"},
                {"PHI", "Eagles"},
                {"NYG", "Giants"},
                {"WAS", "Commanders"},

                {"GB", "Packers"},
                {"CHI", "Bears"},
                {"MIN", "Vikings"},
                {"DET", "Lions"},

                {"NO", "Saints"},
                {"ATL", "Falcons"},
                {"CAR", "Panthers"},
                {"TB", "Buccaneers"},

                {"SF", "49ers"},
                {"SEA", "Seahawks"},
                {"LAR", "Rams"},
                {"ARI", "Cardinals"}
            };

            return map.ContainsKey(teamCode)
                ? $"/images/SportIcons/NFL/{map[teamCode]}.png"
                : "/images/SportIcons/nfl.png";
        }
    }
}