using DevSkill.Shop.Application.Features.Teams.Query;
using DevSkill.Shop.Domain.Contracts;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Application.Contracts
{
    public interface ITeamRepository : IRepository<Team, Guid>
    {
        Task<(IList<Team>, int, int)> GetPagedTeams(GetAllTeamByPagingQuery query,
           CancellationToken cancellationToken);
        Task<bool> IsDuplicateTeamName(string name, CancellationToken cancellationToken);
    }
}

