namespace Spuit.Core
{
    /// <summary>
    /// Provides information about a color.
    /// </summary>
    /// <param name="color"></param>
    public class ColorInfo(Color color)
    {
        /// <summary>
        /// An empty <see cref="ColorInfo"/>.
        /// </summary>
        public static ColorInfo Empty => new(Color.Empty);

        public class RGBA(ColorInfo colorInfo)
        {
            public byte R => colorInfo._color.R;
            public byte G => colorInfo._color.G;
            public byte B => colorInfo._color.B;
            public byte A => colorInfo._color.A;

            public string CSS()
                => $"rgb({R} {G} {B})";

            /// <summary>
            /// Converts the color to a string representation.
            /// </summary>
            /// <param name="includeAlpha">if true, includes the alpha channel in the string representation.</param>
            /// <returns></returns>
            public string ToString(bool includeAlpha)
                => includeAlpha
                    ? $"R: {R}, G: {G}, B: {B}, A: {A}"
                    : $"R: {R}, G: {G}, B: {B}";

            public override string ToString() => ToString(true);
        }

        public class HSL(ColorInfo colorInfo)
        {
            public float H => colorInfo._color.GetHue();
            public float S => colorInfo._color.GetSaturation();
            public float L => colorInfo._color.GetBrightness();

            public string CSS()
                => $"hsl({H:F0} {S:P0} {L:P0})";

            public override string ToString()
                => $"H: {H:F0}, S: {S:F2}, L: {L:F2}";
        }

        public class HEX(ColorInfo colorInfo)
        {
            public RGBA RGBA => new(colorInfo);

            public string CSS() => ToString();

            public override string ToString()
                => $"#{RGBA.R:X2}{RGBA.G:X2}{RGBA.B:X2}";
        }

        private readonly Color _color = color;

        /// <summary>
        /// RGBA representation of the color.
        /// </summary>
        public RGBA Rgba => new(this);

        /// <summary>
        /// HSL representation of the color.
        /// </summary>
        public HSL Hsl => new(this);

        /// <summary>
        /// Hexadecimal representation of the color.
        /// </summary>
        /// <remarks>
        /// This is a string representation of the color in hex format.<br/>
        /// For example, <c>#FF0000</c> for red.
        /// </remarks>
        public string Hex
            => new HEX(this).ToString();

        public override string ToString()
            => $"{nameof(ColorInfo)}(R: {_color.R}, G: {_color.G}, B: {_color.B}, A: {_color.A})";
    }

    public static class ColorInfoExtensions
    {
        /// <summary>
        /// Converts a <see cref="Color"/> to a <see cref="ColorInfo"/>.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static ColorInfo ToColorInfo(this Color color) => new(color);
    }
}