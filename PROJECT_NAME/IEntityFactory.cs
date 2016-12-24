namespace PROJECT_SAFE_NAME
{
    using Protoinject;
    
    using System;
    
    public interface IEntityFactory : IGenerateFactory
    {
        Player CreatePlayer();
    }
}

