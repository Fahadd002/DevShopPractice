using Mapster;

namespace DevSkill.Shop.Web
{
    public class MapsterConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            //config.NewConfig<ProductAddCommand, Product>();
            //config.NewConfig<ProductCreateModel, ProductAddCommand>();
        }
    }
}
