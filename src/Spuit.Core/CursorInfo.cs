using Spuit.Core.Models;
using System.Drawing.Imaging;

namespace Spuit.Core
{
    /// <summary>
    /// Provides information about the cursor.
    /// </summary>
    public class CursorInfo
    {
        private CursorInfo()
        {
        }

        /// <summary>
        /// The singleton instance of the <see cref="CursorInfo"/> class.
        /// </summary>
        public static CursorInfo Instance { get; } = new CursorInfo();

        /// <summary>
        /// Occurs when the cursor information is updated.
        /// </summary>
        public event EventHandler? Updated;

        private Point _position = Cursor.Position;

        /// <summary>
        /// The position of the cursor.
        /// </summary>
        public Point Position => _position;

        public Color _color = Color.Empty;

        /// <summary>
        /// The color of the pixel under the cursor.
        /// </summary>
        public Color Color => _color;

        /// <summary>
        /// Updates the cursor position.
        /// </summary>
        public void Update()
        {
            _position = Cursor.Position;
            _color = GetColor();
            Updated?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the color of the pixel under the cursor.
        /// </summary>
        /// <returns></returns>
        private Color GetColor()
        {
            int x = _position.X;
            int y = _position.Y;

            using var bitmap = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            using var g = Graphics.FromImage(bitmap);

            g.CopyFromScreen(x, y, 0, 0, new Size(1, 1));
            return bitmap.GetPixel(0, 0);
        }

        /// <summary>
        /// Converts the pixel information to a <see cref="Pixel"/> object.
        /// </summary>
        /// <returns></returns>
        public Pixel ToPixel()
        {
            var info = Color.ToColorInfo();
            return new Pixel()
            {
                Position = new Position()
                {
                    X = Position.X,
                    Y = Position.Y,
                },
                Hex = info.Hex,
                Rgb = new RGB()
                {
                    R = info.Rgba.R,
                    G = info.Rgba.G,
                    B = info.Rgba.B
                },
                Hsl = new HSL()
                {
                    H = info.Hsl.H,
                    S = info.Hsl.S,
                    L = info.Hsl.L
                }
            };
        }
    }
}