using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Group2_Sportproject.Core.Services;
using Group2_Sportproject.Core.Models;
using NuGet.Common;
using System;

namespace Group2_Sportproject.Pages
{
    public class NFLPlayersModel : PageModel
    {
    
        private readonly  SportsApiService _apiService;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } 

        public string SelectedTeam { get; set; }
        public List<NFLPlayerSeasonStat> Players { get; set; }

        public NFLPlayersModel(SportsApiService apiService)
        {
            _apiService = apiService;
        }

        // Accept team & season from query string
        public async Task OnGetAsync(string team)
        {
            SelectedTeam = team;

            var allPlayers = await _apiService.GetNFLPlayerStatsAsync();

            // FILTER HERE (not in service yet)
            var filtered = allPlayers
                .Where(p => p.Team == team);

            if(!string.IsNullOrWhiteSpace(SearchTerm))
            {
                filtered = filtered
                    .Where(p => p.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase));
            }
            Players = filtered.ToList();
        }
    }
    }
