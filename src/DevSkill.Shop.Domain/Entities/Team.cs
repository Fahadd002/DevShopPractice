using DevSkill.Shop.Domain.Contracts;

namespace DevSkill.Shop.Domain.Entities
{
    public class Team : IAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Designation { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public Gender Gender { get; set; }
        public DateTime JoiningDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
    public enum Gender
    {
        Male = 1,
        Female = 2,
    }
}
