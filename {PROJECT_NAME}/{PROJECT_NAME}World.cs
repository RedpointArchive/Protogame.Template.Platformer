namespace {PROJECT_NAME}
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    using Protogame;

    public class {PROJECT_NAME}World : IWorld
    {
        private I2DRenderUtilities m_RenderUtilities;
        private IAssetManager m_AssetManager;
        private IProfiler m_Profiler;
        private ILevelManager m_LevelManager;

        public List<IEntity> Entities { get; private set; }

        public {PROJECT_NAME}World(
            IPlatforming platforming,
            I2DRenderUtilities renderUtilities,
            IAssetManagerProvider assetManagerProvider,
            IAudioUtilities audioUtilities,
            IProfiler profiler,
            ILevelManager levelManager)
        {
            this.m_RenderUtilities = renderUtilities;
            this.m_Profiler = profiler;
            this.m_LevelManager = levelManager;
            this.m_AssetManager = assetManagerProvider.GetAssetManager(false);
            this.Entities = new List<IEntity>();

            this.m_LevelManager.Load(this, "level.Level0");
        }

        public void Dispose()
        {
        }

        public void RenderBelow(IGameContext gameContext, IRenderContext renderContext)
        {
            using (this.m_Profiler.Measure("resize_window"))
            {
                gameContext.ResizeWindow(800, 600);
            }
            using (this.m_Profiler.Measure("clear"))
            {
                gameContext.Graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            }
        }

        public void RenderAbove(IGameContext gameContext, IRenderContext renderContext)
        {
            this.m_RenderUtilities.RenderText(
                renderContext,
                new Vector2(gameContext.Window.ClientBounds.Width / 2, 10),
                "{PROJECT_NAME}",
                this.m_AssetManager.Get<FontAsset>("font.Main"),
                horizontalAlignment: HorizontalAlignment.Center);
            this.m_RenderUtilities.RenderText(
                renderContext,
                new Vector2(gameContext.Window.ClientBounds.Width / 2, 30),
                gameContext.FPS + " FPS",
                this.m_AssetManager.Get<FontAsset>("font.Main"),
                horizontalAlignment: HorizontalAlignment.Center);
            this.m_RenderUtilities.RenderText(
                renderContext,
                new Vector2(gameContext.Window.ClientBounds.Width / 2, 50),
                gameContext.FrameCount + " Frames",
                this.m_AssetManager.Get<FontAsset>("font.Main"),
                horizontalAlignment: HorizontalAlignment.Center);
        }

        public void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
        }
    }
}
