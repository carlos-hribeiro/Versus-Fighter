using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PorradaEngine.Collision
{
    public abstract class CollisionBox
    {
        protected Rectangle rectangle;

        public CollisionBox(int x, int y, int w, int h)
        {
            rectangle = new Rectangle(x, y, w, h);
        }

        protected abstract Color getColorRectangle();
        protected abstract Color getColorBorderRectangle();

        public Rectangle GlobalRectangle(int posPersonagemX, int posPersonagemY, bool faceLeft)
        {
            int x;
            if (faceLeft)
            {
                x = rectangle.X + posPersonagemX;
            }
            else
            {
                x = -rectangle.X - rectangle.Width + posPersonagemX;
            }
            Rectangle r = new Rectangle(x, rectangle.Y + posPersonagemY, rectangle.Width, rectangle.Height);

            return r;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y, bool faceLeft)
        {
            Texture2D rect = ResourceManager.Instance.GetTexture("rectangle");

            Rectangle r = GlobalRectangle(x, y, faceLeft);

            //spriteBatch.Draw(rect, r, new Color(0, 0, 200, 100));
            spriteBatch.Draw(rect, r, getColorRectangle());

            //desenha borda do retangulo
            int bw = 1;
            spriteBatch.Draw(rect, new Rectangle(r.Left, r.Top, bw, r.Height), getColorBorderRectangle()); // Left
            spriteBatch.Draw(rect, new Rectangle(r.Right, r.Top, bw, r.Height), getColorBorderRectangle()); // Right
            spriteBatch.Draw(rect, new Rectangle(r.Left, r.Top, r.Width, bw), getColorBorderRectangle()); // Top
            spriteBatch.Draw(rect, new Rectangle(r.Left, r.Bottom, r.Width, bw), getColorBorderRectangle()); // Bottom

        }
    }
}
