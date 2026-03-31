using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Group2_Sportproject.Core.Models;
using Group2_Sportproject.Core.Services;

namespace Group2_Sportproject.Pages.Players
{
    public class NBAPlayerModel : PageModel
    {
        private readonly SportsApiService _sportsApiService;

        public List<NBAPlayerSeasonStat> PlayerStats { get; set; } = new();
        public string ErrorMessage { get; set; } = "";
        public string SelectedSeason { get; set; } = "2026";

        public string SearchTerm { get; set; } = "";

        public Dictionary<string, string> AvailableSeasons { get; set; } = new()
        {
            { "2026", "2025-2026" },
            { "2025", "2024-2025" }
        };

        public NBAPlayerModel(SportsApiService sportsApiService)
        {
            _sportsApiService = sportsApiService;
        }

        public async Task OnGetAsync(string? season, string? team, string? search)
        {
            SelectedSeason = string.IsNullOrWhiteSpace(season) ? "2026" : season;
            SearchTerm = search ?? "";

            try
            {
                var stats = await _sportsApiService.GetNBAPlayerSeasonStatsAsync(SelectedSeason);

                if (!string.IsNullOrWhiteSpace(team))
                {
                    stats = stats.Where(p => p.Team == team).ToList();
                }

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    stats = stats
                        .Where(p => p.Name != null &&
                                    p.Name.ToLower().Contains(SearchTerm.ToLower()))
                        .ToList();
                }

                PlayerStats = stats
                    .OrderByDescending(p => p.Points ?? 0)
                    .Take(100)
                    .ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}