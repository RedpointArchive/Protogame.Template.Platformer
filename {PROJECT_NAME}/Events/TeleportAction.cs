namespace {PROJECT_NAME}
{
    using Protogame;

    public class TeleportAction : IEventEntityAction<Player>
    {
        public void Handle(IGameContext context, Player entity, Event @event)
        {
            var mouseEvent = (MousePressEvent)@event;

            entity.Teleport(mouseEvent.MouseState.X, mouseEvent.MouseState.Y);
        }
    }
}

