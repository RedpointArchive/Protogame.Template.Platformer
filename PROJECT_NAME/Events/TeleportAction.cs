namespace PROJECT_SAFE_NAME
{
    using Protogame;

    public class TeleportAction : IEventEntityAction<Player>
    {
        public void Handle(IGameContext context, Player entity, Event @event)
        {
            var mouseEvent = @event as MousePressEvent;
            var touchEvent = @event as TouchPressEvent;

            if (mouseEvent != null)
            {
                entity.Teleport(mouseEvent.MouseState.X, mouseEvent.MouseState.Y);
            }
            else if (touchEvent != null)
            {
                entity.Teleport((int)touchEvent.X, (int)touchEvent.Y);
            }
        }
    }
}

