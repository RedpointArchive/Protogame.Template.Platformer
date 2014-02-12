namespace {PROJECT_NAME}
{
    using Ninject;
    using Ninject.Parameters;
    using Ninject.Syntax;

    public class DefaultEntityFactory : IEntityFactory
    {
        private readonly IResolutionRoot m_ResolutionRoot;

        public DefaultEntityFactory(IResolutionRoot resolutionRoot)
        {
            this.m_ResolutionRoot = resolutionRoot;
        }

        Player IEntityFactory.CreatePlayer()
        {
            return this.m_ResolutionRoot.Get<Player>();
        }
    }
}
