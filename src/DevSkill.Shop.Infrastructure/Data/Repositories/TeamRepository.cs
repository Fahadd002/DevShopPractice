using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Application.Features.Teams.Query;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class TeamRepository : Repository<Team, Guid>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<(IList<Team>, int, int)> GetPagedTeams(GetAllTeamByPagingQuery query, CancellationToken cancellationToken)
        {
            return await GetDynamicAsync(x => query.SearchText == null || x.Name.Contains(query.SearchText),
                query.SortText,
                null,
                query.PageIndex,
                query.PageSize,
                true,
                cancellationToken);
        }

        public async Task<bool> IsDuplicateTeamName(string name, CancellationToken cancellationToken)
        {
            return (await GetCountAsync(x => x.Name == name, cancellationToken)) > 0;
        }
    }
}
