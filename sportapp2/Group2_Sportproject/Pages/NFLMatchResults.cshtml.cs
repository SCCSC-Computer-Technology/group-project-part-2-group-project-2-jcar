using Group2_Sportproject.Core.Models;
using Group2_Sportproject.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group2_Sportproject.Pages
{
    public class NFLMatchResultsModel : PageModel
    {
        private readonly SportsApiService _apiService;

        public NFLMatchResultsModel(SportsApiService apiService)
        {
            _apiService = apiService;
        }

        public List<NFLMatchResults> Games { get; set; } = new List<NFLMatchResults>();

        public async Task OnGetAsync()
        {
            Games = (await _apiService.GetNFLGamesAsync())
                    .OrderByDescending(g => g.Date)
                    .ToList();
        }
    }
}