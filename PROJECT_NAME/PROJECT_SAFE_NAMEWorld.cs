namespace PROJECT_SAFE_NAME
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Protogame;

    public class PROJECT_SAFE_NAMEWorld : IWorld
    {
        private readonly I2DRenderUtilities _renderUtilities;
        private readonly IAssetManager _assetManager;
        private readonly IProfiler _profiler;
        private readonly ILevelManager _levelManager;
        private readonly IAssetReference<LevelAsset> _levelAsset;
        private bool _hasLoadedLevel;

        public PROJECT_SAFE_NAMEWorld(
            I2DRenderUtilities renderUtilities,
            IAssetManager assetManager,
            IProfiler profiler,
            ILevelManager levelManager)
        {
            _renderUtilities = renderUtilities;
            _profiler = profiler;
            _levelManager = levelManager;
            _assetManager = assetManager;

            _levelAsset = assetManager.Get<LevelAsset>("level.Level0");
        }

        public void Dispose()
        {
        }

        public void RenderBelow(IGameContext gameContext, IRenderContext renderContext)
        {
            using (_profiler.Measure("clear"))
            {
                renderContext.GraphicsDevice.Clear(Color.CornflowerBlue);
            }
        }

        public void RenderAbove(IGameContext gameContext, IRenderContext renderContext)
        {
            _renderUtilities.RenderText(
                renderContext,
                new Vector2(gameContext.Window.ClientBounds.Width / 2, 10),
                "PROJECT_NAME",
                _assetManager.Get<FontAsset>("font.Main"),
                horizontalAlignment: HorizontalAlignment.Center);
            _renderUtilities.RenderText(
                renderContext,
                new Vector2(gameContext.Window.ClientBounds.Width / 2, 30),
                gameContext.FPS + " FPS",
                _assetManager.Get<FontAsset>("font.Main"),
                horizontalAlignment: HorizontalAlignment.Center);
            _renderUtilities.RenderText(
                renderContext,
                new Vector2(gameContext.Window.ClientBounds.Width / 2, 50),
                gameContext.FrameCount + " Frames",
                _assetManager.Get<FontAsset>("font.Main"),
                horizontalAlignment: HorizontalAlignment.Center);
        }

        public void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
            if (!_hasLoadedLevel && _levelAsset.IsReady)
            {
                _levelManager.Load(this, _levelAsset.Asset);
                _hasLoadedLevel = true;
            }
        }
    }
}
