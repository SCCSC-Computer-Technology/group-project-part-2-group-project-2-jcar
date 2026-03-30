using Group2_Sportproject.Core.Models;
using Group2_Sportproject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group2_Sportproject.Pages
{
    public class NBAMatchResultsModel : PageModel
    {
        private readonly SportsApiService _apiService;

        public NBAMatchResultsModel(SportsApiService apiService)
        {
            _apiService = apiService;
        }

        public List<NBAMatchResults> Games { get; set; } = new List<NBAMatchResults>();

        public async Task OnGetAsync()
        {
            Games = (await _apiService.GetNBAGamesAsync("2025"))
                    .Where(g => g.Day != DateTime.MinValue)
                    .OrderByDescending(g => g.Day)
                    .ToList();
        }
    }
}