using Cortex.Mediator.Queries;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;


namespace DevSkill.Shop.Application.Features.Teams.Query
{
    public class GetAllTeamByPagingQueryHandler : IQueryHandler<GetAllTeamByPagingQuery, (IList<Team>, int, int)>
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;

        public GetAllTeamByPagingQueryHandler(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
        }

        public async Task<(IList<Team>, int, int)> Handle(GetAllTeamByPagingQuery query,
            CancellationToken cancellationToken)
        {
            return await _applicationUnitOfWork.TeamRepository.GetPagedTeams(query, cancellationToken);
        }
    }
}