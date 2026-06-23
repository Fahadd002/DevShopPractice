using Cortex.Mediator.Commands;
using DevSkill.Shop.Domain.Entities;

namespace DevSkill.Shop.Application.Features.Teams.Command
{
    public class TeamAddCommand: ICommand<Team>
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
}
