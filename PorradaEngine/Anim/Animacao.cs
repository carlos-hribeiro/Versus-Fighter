using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PorradaEngine.Xml;
using PorradaEngine.Collision;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



namespace PorradaEngine.Anim
{
    public class Animacao
    {
        List<FrameAnimacao> frames = new List<FrameAnimacao>();
        int frameAtual = 0;
        int f = 0;
        bool terminou = false;
        bool inLoop = false;
        Player player;

        

        public Animacao(AnimacaoXml animacaoXml, Player player)
        {
            foreach (FrameAnimacaoXml frame in animacaoXml.frames)
            {
                AddFrame(new FrameAnimacao(frame));
            }
            this.player = player;

        }

        public bool Terminou
        {
            get { return terminou; }
            set { terminou = value; }
        }

        public bool InLoop
        {
            get { return inLoop; }
            set { inLoop = value; }
        }

        public void AddFrame(FrameAnimacao frame)
        {
            frame.Animacao = this;
            frames.Add(frame);
        }

        public bool Slow
        {
            get;
            set;
        }

        public int PosX
        {
            get { return player.PosX; }
        }

        public int PosY
        {
            get { return player.PosY; }
        }

        public bool FaceLeft
        {
            get { return player.FaceLeft; }
        }

        public void Update()
        {
            f++;
            if (f >= frames.ElementAt(frameAtual).MaxFrame)
            {
                
                    f = 0;
                    frameAtual++;
                    if (frameAtual >= frames.Count)
                    {
                        frameAtual = 0;

                        if (!inLoop)
                        {
                            f = 0;
                            terminou = true;
                        }
                    }
                
            }

            frames.ElementAt(frameAtual).Slow = Slow;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            FrameAnimacao frame = frames.ElementAt(frameAtual);
            
            frame.Draw(spriteBatch);

            frame.DrawCollisionBoxes(spriteBatch);

            
        }

    }
}
