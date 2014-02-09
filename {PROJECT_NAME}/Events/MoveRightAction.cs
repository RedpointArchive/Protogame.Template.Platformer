namespace {PROJECT_NAME}
{
    using Protogame;

    public class MoveRightAction : IEventEntityAction<Player>
    {
        public void Handle(IGameContext context, Player entity, Event @event)
        {
            entity.MoveRight(context);
        }
    }
}

