using Microsoft.Xna.Framework;
using Protogame;
using Protoinject;

namespace {PROJECT_SAFE_NAME}
{
    public class {PROJECT_SAFE_NAME}GameConfiguration : IGameConfiguration
    {
        public void ConfigureKernel(IKernel kernel)
        {
            kernel.Load<ProtogameCoreModule>();
            kernel.Load<ProtogameAssetIoCModule>();
            kernel.Load<ProtogamePlatformingIoCModule>();
            kernel.Load<ProtogameLevelIoCModule>();
            kernel.Load<ProtogameEventsIoCModule>();
            kernel.Load<{PROJECT_SAFE_NAME}Module>();
        }

        public void InitializeAssetManagerProvider(IAssetManagerProviderInitializer initializer)
        {
            initializer.Initialize<GameAssetManagerProvider>();
        }

        public Game ConstructGame(IKernel kernel)
        {
            return new {PROJECT_SAFE_NAME}Game(kernel);
        }
    }
}