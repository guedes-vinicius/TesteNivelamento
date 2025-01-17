using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year).Result;

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static async Task <int> getTotalScoredGoals(string team, int year)
    {
        int totalGoals = 0;
        int currentPage = 1;
        int totalPages = 1;

        using (HttpClient client = new HttpClient()){
            while (currentPage <= totalPages){
                string url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={currentPage}";
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                foreach (var match in apiResponse.data){
                    totalGoals += match.team1goals;
                }

                url = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team2={team}&page={currentPage}";
                response = await client.GetAsync(url);
                jsonResponse = await response.Content.ReadAsStringAsync();
                apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                foreach (var match in apiResponse.data){
                    totalGoals += match.team2goals;
                }
                totalPages = apiResponse.total_pages;
                currentPage++;

            }
        }
        return totalGoals;
    }

}


public class FootballMatch{
    public string team1 {get;set;}
    public string team2 {get;set;}
    public int team1goals {get;set;}
    public int team2goals {get;set;}
}


public class ApiResponse{
    public int page {get;set;}
    public int per_page {get;set;}
    public int total {get;set;}
    public int total_pages {get;set;}
    public List <FootballMatch> data {get;set;}

}