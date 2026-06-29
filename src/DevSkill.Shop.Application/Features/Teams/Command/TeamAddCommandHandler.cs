using Cortex.Mediator.Commands;
using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;
using DevSkill.Shop.Domain.Utilities;
using MapsterMapper;

namespace DevSkill.Shop.Application.Features.Teams.Command
{
    public class TeamAddCommandHandler : ICommandHandler<TeamAddCommand, Team>
    {
        private readonly IApplicationUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeamAddCommandHandler(IApplicationUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Team> Handle(TeamAddCommand command, CancellationToken cancellationToken)
        {
            var isDuplicateName = await _unitOfWork.TeamRepository.IsDuplicateTeamName(command.Name, cancellationToken);

            if (!isDuplicateName)
            {
                var team = _mapper.Map<Team>(command);
                team.Id = IdentityGenerator.NewSequentialGuid();

                await _unitOfWork.TeamRepository.AddAsync(team, cancellationToken);
                await _unitOfWork.SaveAsync();

                return team;
            }
            else
                //throw new DuplicateDataException("Team  name is duplicate");
                throw new Exception("Team name is duplicate");

        }
    }
}
