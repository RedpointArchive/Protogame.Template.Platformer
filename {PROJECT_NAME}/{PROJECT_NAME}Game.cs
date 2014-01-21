namespace {PROJECT_NAME}
{
    using Ninject;

    using Protogame;

    public class {PROJECT_NAME}Game : CoreGame<{PROJECT_NAME}World, Default2DWorldManager>
    {
        public {PROJECT_NAME}Game(StandardKernel kernel)
            : base(kernel)
        {
        }
    }
}
