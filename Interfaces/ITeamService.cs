using NFLSeasonSimulator.Models;

public interface ITeamService
{
    List<Team> GetAllTeams();
    Team? GetTeamById(int id);
}