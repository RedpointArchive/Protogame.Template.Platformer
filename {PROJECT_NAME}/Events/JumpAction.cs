namespace {PROJECT_NAME}
{
    using Protogame;

    public class JumpAction : IEventEntityAction<Player>
    {
        public void Handle(IGameContext context, Player entity, Event @event)
        {
            entity.Jump(context);
        }
    }
}

