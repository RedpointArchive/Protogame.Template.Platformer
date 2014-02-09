namespace {PROJECT_NAME}
{
    using Protogame;

    public class MoveLeftAction : IEventEntityAction<Player>
    {
        public void Handle(IGameContext context, Player entity, Event @event)
        {
            entity.MoveLeft(context);
        }
    }
}

