using Newtonsoft.Json;
using Group2_Sportproject.Core.Models;
using System.Net.Http;

namespace Group2_Sportproject.Core.Services
{
    public class SportsApiService
    {
        private static readonly HttpClient _client = new HttpClient();
        private const string ApiKey = "f6d43bd8239c4fe7a38abcac1c0cb30c";

        private const string FixedNFLSeason = "2025REG";

        private void SetApiKeyHeader()
        {
            const string headerName = "Ocp-Apim-Subscription-Key";

            if (_client.DefaultRequestHeaders.Contains(headerName))
                _client.DefaultRequestHeaders.Remove(headerName);

            _client.DefaultRequestHeaders.Add(headerName, ApiKey);
        }

        private async Task<string> GetJsonAsync(string url)
        {
            SetApiKeyHeader();

            HttpResponseMessage response = await _client.GetAsync(url);
            string body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode} - {body}");

            return body;
        }

        public async Task<List<NFLTeam>> GetNFLTeamsAsync()
        {
            string url = "https://api.sportsdata.io/v3/nfl/scores/json/Teams";
            string json = await GetJsonAsync(url);

            return JsonConvert.DeserializeObject<List<NFLTeam>>(json)
                   ?? new List<NFLTeam>();
        }

        public async Task<List<NBATeams>> GetNBATeamsAsync()
        {
            string url = "https://api.sportsdata.io/v3/nba/scores/json/Teams";
            string json = await GetJsonAsync(url);

            return JsonConvert.DeserializeObject<List<NBATeams>>(json)
                   ?? new List<NBATeams>();
        }

        public async Task<List<NBAStanding>> GetNBAStandingsAsync(string season)
        {
            string url = $"https://api.sportsdata.io/v3/nba/scores/json/Standings/{season}";
            string json = await GetJsonAsync(url);

            return JsonConvert.DeserializeObject<List<NBAStanding>>(json)
                   ?? new List<NBAStanding>();
        }

        public async Task<List<NFLStanding>> GetNFLStandingsAsync(string season)
        {
            string url = $"https://api.sportsdata.io/v3/nfl/scores/json/Standings/{season}";
            string json = await GetJsonAsync(url);

            return JsonConvert.DeserializeObject<List<NFLStanding>>(json)
                   ?? new List<NFLStanding>();
        }

        public async Task<List<NFLPlayerSeasonStat>> GetNFLPlayerStatsAsync()
        {
            string season = "2025REG";
            string url = $"https://api.sportsdata.io/v3/nfl/stats/json/PlayerSeasonStats/{season}";
            Console.WriteLine($"Request URL: {url}");
            string json = await GetJsonAsync(url);

            return JsonConvert.DeserializeObject<List<NFLPlayerSeasonStat>>(json)
                   ?? new List<NFLPlayerSeasonStat>();
        }

        public async Task<List<NFLMatchResults>> GetNFLGamesAsync()
        {
            string season = "2025REG";
            string url = $"https://api.sportsdata.io/v3/nfl/scores/json/Scores/{season}";

            string json = await GetJsonAsync(url);

            return JsonConvert.DeserializeObject<List<NFLMatchResults>>(json)
                   ?? new List<NFLMatchResults>();
        }

        public async Task<List<NBAMatchResults>> GetNBAGamesAsync(string season)
        {
            string url = $"https://api.sportsdata.io/v3/nba/scores/json/Games/{season}";
            string json = await GetJsonAsync(url);

            return JsonConvert.DeserializeObject<List<NBAMatchResults>>(json)
                   ?? new List<NBAMatchResults>();
        }
    }
}