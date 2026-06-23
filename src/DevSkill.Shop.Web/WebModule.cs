
using Autofac;
using DevSkill.Shop.Domain.Interface;

namespace DevSkill.Shop.Web
{
    public class WebModule: Module
    {
        public WebModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<TeamMembers>().As<ITeamMembers>().InstancePerLifetimeScope();

            //builder.RegisterType<TeamMembers>().As<ITeamMembers>().InstancePerLifetimeScope()
            //    .WithParameter("...", "----");
            base.Load(builder);
        }
    }
}
