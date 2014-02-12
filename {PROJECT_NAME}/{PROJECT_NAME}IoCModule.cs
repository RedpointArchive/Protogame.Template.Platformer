namespace {PROJECT_NAME}
{
    using Ninject.Extensions.Factory;
    using Ninject.Modules;

    using Protogame;

    public class {PROJECT_NAME}IoCModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEntityFactory>().ToFactory();

            this.Bind<ISolidEntity>().To<Solid>();
            this.Bind<ITileEntity>().To<Dirt>().Named("Dirt");
            this.Bind<IEntity>().To<Spawn>().Named("Spawn");

            // TODO: Define an event binder suitable for mapping mobile input to the game.
            this.Bind<IEventBinder<IGameContext>>().To<DesktopEventBinder>();
        }
    }
}
