namespace PROJECT_SAFE_NAME
{
    using Protoinject;

    using Protogame;

    public class PROJECT_SAFE_NAMEModule : IProtoinjectModule
    {
        public void Load(IKernel kernel)
        {
            kernel.Bind<IEntityFactory>().ToFactory();

            kernel.Bind<ISolidEntity>().To<Solid>().AllowManyPerScope();
            kernel.Bind<ITileEntity>().To<Dirt>().Named("Dirt").AllowManyPerScope();
            kernel.Bind<IEntity>().To<Spawn>().Named("Spawn").AllowManyPerScope();

            // TODO: Define an event binder suitable for mapping mobile input to the game.
            kernel.Bind<IEventBinder<IGameContext>>().To<DesktopEventBinder>();
        }
    }
}

