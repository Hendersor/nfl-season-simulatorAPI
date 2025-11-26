using Microsoft.AspNetCore.Mvc;

namespace NFLSeasonSimulator.Controllers
{
    [Route("simulate/[controller]")]
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
    }
}