namespace {PROJECT_SAFE_NAME}
{
    using System;
    using System.Collections.Generic;
    
    using Microsoft.Xna.Framework;
    
    using Protoinject;
    
    using Protogame;

    public class Spawn : Entity
    {
        private readonly IHierarchy _hierarchy;
        private readonly IEntityFactory m_EntityFactory;

        private bool m_Spawned = false;

        public Spawn(
            IHierarchy hierarchy,
            IEntityFactory entityFactory,
            string name,
            int id,
            int x, 
            int y, 
            Dictionary<string, string> attributes)
        {
            _hierarchy = hierarchy;
            this.m_EntityFactory = entityFactory;

            this.LocalMatrix = Matrix.CreateTranslation(x, y, 0);
        }
        
        public override void Update(IGameContext gameContext, IUpdateContext updateContext)
        {
            if (this.m_Spawned)
            {
                return;
            }

            var player = this.m_EntityFactory.CreatePlayer();
            player.LocalMatrix = LocalMatrix;
            _hierarchy.AddChildNode(
                _hierarchy.Lookup(gameContext.World),
                _hierarchy.CreateNodeForObject(player));

            this.m_Spawned = true;
        }
    }
}

