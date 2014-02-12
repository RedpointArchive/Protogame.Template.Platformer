namespace {PROJECT_NAME}
{
#if PLATFORM_WINDOWS || PLATFORM_MACOS || PLATFORM_LINUX
    using Ninject.Extensions.Factory;
#endif
    using Ninject.Modules;

    using Protogame;

    public class {PROJECT_NAME}IoCModule : NinjectModule
    {
        public override void Load()
        {
            // If you are only targeting desktop platforms, you can
            // use automatic factories.  However, they are not supported
            // on mobile platforms.
            //
            // See http://protogame.org/docs/targeting_mobile.html#implementing_factories
            // for more information.
#if PLATFORM_WINDOWS || PLATFORM_MACOS || PLATFORM_LINUX
            this.Bind<IEntityFactory>().ToFactory();
#else
            this.Bind<IEntityFactory>().To<DefaultEntityFactory>();
#endif

            this.Bind<ISolidEntity>().To<Solid>();
            this.Bind<ITileEntity>().To<Dirt>().Named("Dirt");
            this.Bind<IEntity>().To<Spawn>().Named("Spawn");

            // TODO: Define an event binder suitable for mapping mobile input to the game.
            this.Bind<IEventBinder<IGameContext>>().To<DesktopEventBinder>();
        }
    }
}

