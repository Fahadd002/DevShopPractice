using Cortex.Mediator;
using DevSkill.Shop.Application.Features.Teams.Query;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Utilities;
using DevSkill.Shop.Web.Areas.Admin.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Web;

namespace DevSkill.Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamsController : Controller
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TeamsController(ILogger<TeamsController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: /Admin/Teams
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetPageTeam([FromBody] TeamListModel model)
        {
            try
            {
                var query = _mapper.Map<GetAllTeamByPagingQuery>(model);
                query.SearchText = model.Search.Value;
                query.SortText = model.FormatSortExpression("Name", "Designation", "Email", "Phone", "Gender", "Joining Date");

                var (items, total, totalDisplay) = await _mediator.SendQueryAsync<GetAllTeamByPagingQuery,
                    (IList<Team>, int, int)>(query);

                var team = new
                {
                    recordsTotal = total,
                    recordsFiltered = totalDisplay,
                    data = (from item in items
                            select new string[]
                            {
                                $"<img src='{item.ImageUrl}' style='width:50px;height:50px;object-fit:cover;' />",
                                HttpUtility.HtmlEncode(item.Name),
                                HttpUtility.HtmlEncode(item.Designation),
                                HttpUtility.HtmlEncode(item.Email),
                                HttpUtility.HtmlEncode(item.Phone),
                                HttpUtility.HtmlEncode(item.Gender),
                                item.JoiningDate.ToString("yyyy-MM-dd"),
                                item.Id.ToString()  
                            }).ToArray()
                };

                return Json(team);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get product list");

                return Json(DataTables.EmptyResult);
            }
        }
    }
}
