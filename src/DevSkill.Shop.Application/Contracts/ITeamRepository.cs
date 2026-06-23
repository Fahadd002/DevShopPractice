using DevSkill.Shop.Domain.Contracts;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Application.Contracts
{
    public interface ITeamRepository: IRepository<Team, Guid>
    {
    }
}

