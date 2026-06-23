using Cortex.Mediator.Queries;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSkill.Shop.Application.Features.Teams.Query
{
    public class TeamGetAllQueryHandler : IQueryHandler<TeamGetAllQuery, List<Team>>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public TeamGetAllQueryHandler(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Team>> Handle(TeamGetAllQuery query, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.TeamRepository.GetAllAsync();

            return result.ToList();
        }
    }
}
