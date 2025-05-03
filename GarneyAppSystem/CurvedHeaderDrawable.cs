using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarneyAppSystem
{
    public class CurvedHeaderDrawable : IDrawable
    {
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            canvas.FillColor = Color.FromArgb("#4BA734");

            var path = new PathF();
            path.MoveTo(0, 0);
            path.LineTo(dirtyRect.Width, 0);
            path.LineTo(dirtyRect.Width, 160);
            path.QuadTo(dirtyRect.Width * 0.5f, 210, 0, 160);
            path.Close();

            canvas.FillPath(path);
        }
    }
}
