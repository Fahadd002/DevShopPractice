using Cortex.Mediator;
using DevSkill.Shop.Application.Features.Teams.Command;
using DevSkill.Shop.Application.Features.Teams.Query;
using DevSkill.Shop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DevSkill.Shop.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        private readonly IMediator _mediator;

        public TeamController(ILogger<TeamController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var allTeamMembers =await _mediator.SendQueryAsync<TeamGetAllQuery, List<Team>>(new TeamGetAllQuery());

                if (!allTeamMembers.Any())
                {
                    List<TeamAddCommand> teamMembers = new()
                    {
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Fahim Rahman", Designation = "CEO", ImageUrl = "/team/e1.jpg", Email = "fahim.rahman@gmail.com", Phone = "01700000001", Gender = Gender.Male, JoiningDate = new DateTime(2018, 1, 10) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Nusrat Jahan", Designation = "CTO", ImageUrl = "/team/e4.jpg", Email = "nusrat.jahan@gmail.com", Phone = "01700000002", Gender = Gender.Female, JoiningDate = new DateTime(2019, 3, 15) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Tanvir Hasan", Designation = "Lead Developer", ImageUrl = "/team/e2.jpg", Email = "tanvir.hasan@gmail.com", Phone = "01700000003", Gender = Gender.Male, JoiningDate = new DateTime(2020, 6, 20) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Sadia Islam", Designation = "UI/UX Designer", ImageUrl = "/team/e6.jpg", Email = "sadia.islam@gmail.com", Phone = "01700000004", Gender = Gender.Female, JoiningDate = new DateTime(2021, 9, 5) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Rakib Hossain", Designation = "Backend Developer", ImageUrl = "/team/e3.jpg", Email = "rakib.hossain@gmail.com", Phone = "01700000005", Gender = Gender.Male, JoiningDate = new DateTime(2020, 11, 12) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Farzana Akter", Designation = "Frontend Developer", ImageUrl = "/team/e9.jpg", Email = "farzana.akter@gmail.com", Phone = "01700000006", Gender = Gender.Female, JoiningDate = new DateTime(2022, 2, 18) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Mahmudul Hasan", Designation = "DevOps Engineer", ImageUrl = "/team/e5.jpg", Email = "mahmudul.hasan@gmail.com", Phone = "01700000007", Gender = Gender.Male, JoiningDate = new DateTime(2019, 7, 25) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Shamima Sultana", Designation = "QA Engineer", ImageUrl = "/team/e4.jpg", Email = "shamima.sultana@gmail.com", Phone = "01700000008", Gender = Gender.Female, JoiningDate = new DateTime(2021, 4, 30) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Imran Khan", Designation = "Product Manager", ImageUrl = "/team/e8.jpg", Email = "imran.khan@gmail.com", Phone = "01700000009", Gender = Gender.Male, JoiningDate = new DateTime(2018, 8, 14) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Jannatul Ferdous", Designation = "Business Analyst", ImageUrl = "/team/e6.jpg", Email = "jannatul.ferdous@gmail.com", Phone = "01700000010", Gender = Gender.Female, JoiningDate = new DateTime(2020, 5, 9) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Saiful Islam", Designation = "Support Engineer", ImageUrl = "/team/e7.jpg", Email = "saiful.islam@gmail.com", Phone = "01700000011", Gender = Gender.Male, JoiningDate = new DateTime(2022, 1, 3) },
                        new TeamAddCommand { Id = Guid.NewGuid(), Name = "Mst. Rina Begum", Designation = "HR Manager", ImageUrl = "/team/e9.jpg", Email = "rina.begum@gmail.com", Phone = "01700000012", Gender = Gender.Female, JoiningDate = new DateTime(2019, 10, 21) }
                    };

                    foreach (var member in teamMembers)
                    {
                        await _mediator.SendCommandAsync(member);
                    }

                    allTeamMembers =  await _mediator.SendQueryAsync<TeamGetAllQuery, List<Team>>(new TeamGetAllQuery());
                }

                return View(allTeamMembers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading team members");
                return View("Error");
            }
        }
    }
}