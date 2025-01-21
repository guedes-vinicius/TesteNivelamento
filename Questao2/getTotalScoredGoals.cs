using Newtonsoft.Json;
using System;
public class getTotalScored
{
    public static async Task<int> getTotalScoredGoals(string team, int year)
    {
        int totalGoals = 0;
        int currentPage = 1;
        int totalPages = 1;

        using (HttpClient client = new HttpClient())
        {
            while (currentPage <= totalPages)
            {
                string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={currentPage}";
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                foreach (var match in apiResponse.data)
                {
                    totalGoals += match.team1goals;
                }

                url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}&page={currentPage}";
                response = await client.GetAsync(url);
                jsonResponse = await response.Content.ReadAsStringAsync();
                apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                foreach (var match in apiResponse.data)
                {
                    totalGoals += match.team2goals;
                }
                totalPages = apiResponse.total_pages;
                currentPage++;

            }
        }
        return totalGoals;
    }
}