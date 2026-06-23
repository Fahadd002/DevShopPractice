using DevSkill.Shop.Domain.Contracts;

namespace DevSkill.Shop.Application.Contracts
{
    public interface IApplicationUnitOfWork: IUnitOfWork
    {
        public ITeamRepository TeamRepository { get; }
    }
}
