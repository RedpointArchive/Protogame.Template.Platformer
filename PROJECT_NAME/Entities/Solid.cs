namespace PROJECT_SAFE_NAME
{
    using Microsoft.Xna.Framework;

    using Protogame;

    /// <summary>
    /// This entity is mapped to the solid layer in the Ogmo Editor.
    /// Generally you don't want this class to do any work as it'll be
    /// used quite heavily in the system.
    /// </summary>
    public class Solid : Entity, ISolidEntity
    {
        private I2DRenderUtilities m_RenderUtilities;

        public Solid(I2DRenderUtilities renderUtilities, float x, float y, float width, float height)
        {
            this.m_RenderUtilities = renderUtilities;
            this.Transform.LocalPosition = new Vector3(x, y, 0);
            this.Width = width;
            this.Height = height;
        }
    }
}
