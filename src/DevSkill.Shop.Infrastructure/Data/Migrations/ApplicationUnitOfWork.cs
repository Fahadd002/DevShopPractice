using DevSkill.Shop.Application.Contracts;

namespace DevSkill.Shop.Infrastructure.Data.Migrations
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public ITeamRepository TeamRepository { get; private set; }
        public ApplicationUnitOfWork(ApplicationDbContext dbContext, ITeamRepository teamRepository)
           : base(dbContext)
        {
            TeamRepository = teamRepository;
        }
    }
}
