using Microsoft.Xna.Framework;

namespace PROJECT_SAFE_NAME
{
    using Protoinject;

    using Protogame;

    public class PROJECT_SAFE_NAMEGame : CoreGame<PROJECT_SAFE_NAMEWorld>
    {
        public PROJECT_SAFE_NAMEGame(IKernel kernel)
            : base(kernel)
        {
            this.IsMouseVisible = true;
        }

        protected override void ConfigureRenderPipeline(IRenderPipeline pipeline, IKernel kernel)
        {
            pipeline.AddFixedRenderPass(kernel.Get<I2DBatchedRenderPass>());
        }

        protected override void PrepareGraphicsDeviceManager(GraphicsDeviceManager graphicsDeviceManager)
        {
            base.PrepareGraphicsDeviceManager(graphicsDeviceManager);

            graphicsDeviceManager.PreferredBackBufferWidth = 800;
            graphicsDeviceManager.PreferredBackBufferHeight = 600;
        }
    }
}
