namespace {PROJECT_SAFE_NAME}
{
    using Protoinject;

    using Protogame;

    public class {PROJECT_SAFE_NAME}Game : CoreGame<{PROJECT_SAFE_NAME}World>
    {
        public {PROJECT_SAFE_NAME}Game(StandardKernel kernel)
            : base(kernel)
        {
            this.IsMouseVisible = true;
        }

        protected override void ConfigureRenderPipeline(IRenderPipeline pipeline, IKernel kernel)
        {
            pipeline.AddFixedRenderPass(kernel.Get<I2DBatchedRenderPass>());
        }
    }
}
