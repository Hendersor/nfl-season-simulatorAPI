using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NFLSeasonSimulator.Models;

namespace NFLSeasonSimulator.Services
{
    public class TeamService : ITeamService
    {
        public List<Team> GetAllTeams()
        {
            var csvPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "NFLTeams.csv");
            var lines = File.ReadAllLines(csvPath);

            var dataLines = lines.Skip(1);

        var teams = dataLines.Select((line, index) => 
        {
            var columns = line.Split(',');
            return new Team
            {
                Id = index + 1, 
                Name = columns[0],
                Abbreviation = columns[1],
                Division = columns[9],
                Conference = columns[10]
            };
        }).ToList();

            return teams;
        }


        public Team? GetTeamById(int id)
        {
            var teams = GetAllTeams();
            var team = teams.FirstOrDefault(t => t.Id == id);
            return team;
        }
    }
}