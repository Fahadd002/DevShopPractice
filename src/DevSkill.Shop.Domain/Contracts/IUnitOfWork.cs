namespace DevSkill.Shop.Domain.Contracts
{
    public interface IUnitOfWork
    {
        void Save();
        Task SaveAsync();
    }
}
