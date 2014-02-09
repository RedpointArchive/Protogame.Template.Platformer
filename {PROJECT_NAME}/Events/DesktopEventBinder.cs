namespace {PROJECT_NAME}
{
    using Microsoft.Xna.Framework.Input;

    using Protogame;

    public class DesktopEventBinder : StaticEventBinder<IGameContext>
    {
        public override void Configure()
        {
            this.Bind<MousePressEvent>(x => x.Button == MouseButton.Left).On<Player>().To<TeleportAction>();
            this.Bind<KeyHeldEvent>(x => x.Key == Keys.Left).On<Player>().To<MoveLeftAction>();
            this.Bind<KeyHeldEvent>(x => x.Key == Keys.Right).On<Player>().To<MoveRightAction>();
            this.Bind<KeyPressEvent>(x => x.Key == Keys.Up).On<Player>().To<JumpAction>();
        }
    }
}

