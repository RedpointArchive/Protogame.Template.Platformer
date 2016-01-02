namespace {PROJECT_NAME}
{
    using Protoinject;
    
    using System;
    
    public interface IEntityFactory : IGenerateFactory
    {
        Player CreatePlayer();
    }
}

