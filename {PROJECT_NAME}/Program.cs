#if PLATFORM_WINDOWS || PLATFORM_MACOS || PLATFORM_LINUX

namespace {PROJECT_NAME}
{
    using Ninject;

    using Protogame;

    public static class Program
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load<Protogame2DIoCModule>();
            kernel.Load<ProtogameAssetIoCModule>();
            kernel.Load<ProtogamePlatformingIoCModule>();
            kernel.Load<ProtogameLevelIoCModule>();
            kernel.Load<ProtogameEventsIoCModule>();
            kernel.Load<{PROJECT_NAME}IoCModule>();
            AssetManagerClient.AcceptArgumentsAndSetup<GameAssetManagerProvider>(kernel, args);

            using (var game = new {PROJECT_NAME}Game(kernel))
            {
                game.Run();
            }
        }
    }
}

#endif
