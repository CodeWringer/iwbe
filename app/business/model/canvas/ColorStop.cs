using Godot;

namespace iwbe.business.model
{
    /// <summary>
    /// Defines a color stop. 
    /// </summary>
    public class ColorStop
    {
        /// <summary>
        /// The color at full strength of the color stop. 
        /// </summary>
        public Color Color;

        private float _position;
        /// <summary>
        /// From 0.0 to 1.0, where the color stop is at full strength. 
        /// </summary>
        public float Position
        {
            get { return _position; }
            set { _position = Mathf.Clamp(value, 0.0f, 1.0f); }
        }
    }
}
