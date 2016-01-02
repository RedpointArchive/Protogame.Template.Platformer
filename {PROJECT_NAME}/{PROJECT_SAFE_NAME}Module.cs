namespace {PROJECT_NAME}
{
    using Protoinject;

    using Protogame;

    public class {PROJECT_NAME}Module : IProtoinjectModule
    {
        public void Load(IKernel kernel)
        {
            kernel.Bind<IEntityFactory>().ToFactory();

            kernel.Bind<ISolidEntity>().To<Solid>();
            kernel.Bind<ITileEntity>().To<Dirt>().Named("Dirt");
            kernel.Bind<IEntity>().To<Spawn>().Named("Spawn");

            // TODO: Define an event binder suitable for mapping mobile input to the game.
            kernel.Bind<IEventBinder<IGameContext>>().To<DesktopEventBinder>();
        }
    }
}

