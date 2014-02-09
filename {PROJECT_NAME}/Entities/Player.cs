namespace {PROJECT_NAME}
{
    using System;
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    using Protogame;

    public class Player : Entity
    {
        private IPlatforming m_Platforming;
        private IAssetManager m_AssetManager;
        private I2DRenderUtilities m_RenderUtilities;
        private IAudioUtilities m_AudioUtilities;
        private TextureAsset m_Texture;
        private AudioAsset m_JumpSound;
        private IAudioHandle m_JumpHandle;

        public Player(
            IPlatforming platforming,
            IAssetManagerProvider assetManagerProvider,
            I2DRenderUtilities renderUtilities,
            IAudioUtilities audioUtilities)
        {
            this.m_Platforming = platforming;
            this.m_AssetManager = assetManagerProvider.GetAssetManager();
            this.m_RenderUtilities = renderUtilities;
            this.m_AudioUtilities = audioUtilities;

            this.m_Texture = this.m_AssetManager.Get<TextureAsset>("texture.Player");
            this.m_JumpSound = this.m_AssetManager.Get<AudioAsset>("audio.Jump");

            this.m_JumpHandle = this.m_AudioUtilities.GetHandle(this.m_JumpSound);

            this.Width = 32;
            this.Height = 32;
        }

        private bool OnGround(IGameContext gameContext)
        {
            return this.m_Platforming.IsOnGround(
                this,
                gameContext.World.Entities.OfType<IBoundingBox>(),
                x => x is Solid);
        }

        public void Teleport(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.XSpeed = 0;
            this.YSpeed = 0;
            this.m_JumpHandle.Play();
        }

        public void MoveLeft(IGameContext gameContext)
        {
            this.m_Platforming.ApplyMovement(this, -4, 0, gameContext.World.Entities.OfType<IBoundingBox>(), x => x is Solid);
        }

        public void MoveRight(IGameContext gameContext)
        {
            this.m_Platforming.ApplyMovement(this, 4, 0, gameContext.World.Entities.OfType<IBoundingBox>(), x => x is Solid);
        }

        public void Jump(IGameContext gameContext)
        {
            if (this.OnGround(gameContext))
            {
                this.YSpeed = -6;
                this.m_JumpHandle.Play();
            }
        }

        public override void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
            base.Update(gameContext, updateContext);

            if (!this.OnGround(gameContext))
            {
                this.m_Platforming.ApplyGravity(this, 0, 0.5f);
            }
            else if (this.YSpeed > 0)
            {
                this.YSpeed = 0;
                this.m_Platforming.ApplyActionUntil(this, a => a.Y += 1, a => this.OnGround(gameContext), 12);
            }

            this.m_Platforming.ClampSpeed(this, null, 12);
        }

        public override void Render(IGameContext gameContext, IRenderContext renderContext)
        {
            base.Render(gameContext, renderContext);

            this.m_RenderUtilities.RenderTexture(
                renderContext,
                new Vector2(this.X, this.Y),
                this.m_Texture);
        }
    }
}

