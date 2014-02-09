namespace {PROJECT_NAME}
{
    using System;
    using System.Collections.Generic;

    using Protogame;

    public class Spawn : IEntity
    {
        private readonly IEntityFactory m_EntityFactory;

        private bool m_Spawned = false;

        public Spawn(
            IEntityFactory entityFactory,
            string name,
            int id,
            int x, 
            int y, 
            Dictionary<string, string> attributes)
        {
            this.m_EntityFactory = entityFactory;

            this.X = x;
            this.Y = y;
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }

        public float Z
        {
            get;
            set;
        }

        public void Render(IGameContext gameContext, IRenderContext renderContext)
        {
        }

        public void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
            if (this.m_Spawned)
            {
                return;
            }

            var player = this.m_EntityFactory.CreatePlayer();
            player.X = this.X;
            player.Y = this.Y;
            gameContext.World.Entities.Add(player);

            this.m_Spawned = true;
        }
    }
}

