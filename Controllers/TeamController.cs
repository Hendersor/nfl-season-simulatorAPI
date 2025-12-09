using Microsoft.AspNetCore.Mvc;

namespace NFLSeasonSimulator.Controllers
{
    [Route("simulate/team/[controller]")]
    public class TeamController: ControllerBase
    {

        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = _teamService.GetAllTeams();
            return Ok(teams);
        }

        [HttpPost("{id}")]
        public IActionResult SelectTeam(int id)
        {
            var team = _teamService.GetTeamById(id);

            if(team == null)
            {
                return NotFound($"Team with ID {id} not found");
            }

            return Ok($"Team selected: {team.Name}"); 
        }
    }
}