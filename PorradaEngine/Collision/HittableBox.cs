using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PorradaEngine.Collision
{
    /// <summary>
    /// Representa os boxes de colisao do tipo Hit
    /// </summary>
    public class HittableBox : CollisionBox
    {

        public HittableBox(int x, int y, int w, int h)
            : base(x, y, w, h)
        {
        }

        protected override Color getColorRectangle()
        {
            return new Color(0, 0, 200, 100);
        }

        protected override Color getColorBorderRectangle()
        {
            return new Color(0, 0, 220);
        }
    }
}
