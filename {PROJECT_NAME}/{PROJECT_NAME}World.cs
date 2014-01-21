namespace {PROJECT_NAME}
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;

    using Protogame;

    public class {PROJECT_NAME}World : IWorld
    {
        public {PROJECT_NAME}World()
        {
            this.Entities = new List<IEntity>();
        }

        public List<IEntity> Entities { get; private set; }

        public void Dispose()
        {
        }

        public void RenderAbove(IGameContext gameContext, IRenderContext renderContext)
        {
        }

        public void RenderBelow(IGameContext gameContext, IRenderContext renderContext)
        {
            gameContext.Graphics.GraphicsDevice.Clear(Color.Purple);
        }

        public void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
        }
    }
}
