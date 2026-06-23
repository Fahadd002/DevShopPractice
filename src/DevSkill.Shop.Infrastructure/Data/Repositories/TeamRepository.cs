using DevSkill.Shop.Application.Contracts;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Infrastructure.Data.Repositories
{
    public class TeamRepository : Repository<Team, Guid>, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
