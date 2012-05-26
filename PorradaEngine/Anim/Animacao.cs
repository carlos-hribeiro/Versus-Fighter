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

    /// <summary>
    /// Controla a animacao do personagem
    /// </summary>
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
            //cria uma lista de frames de determinada animacao com base no xml do personagem
            foreach (FrameAnimacaoXml frame in animacaoXml.frames)
            {
                AddFrame(new FrameAnimacao(frame));
            }
            this.player = player;

        }

        public bool Terminou {
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

        public bool Slow {
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

        /// <summary>
        /// Controla a atualizacao de cada frame da animacao
        /// </summary>
        public void Update()
        {
            f++;
            //passa para o proximo frame somente se ja acabou seu tempo de exibicao na tela
            if (f >= frames.ElementAt(frameAtual).MaxFrame)
            {
                
                f = 0;
                frameAtual++; //passa para o proximo frame

                //termina a animacao
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

        /// <summary>
        /// Desenha o frame atual da animacao
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            FrameAnimacao frame = frames.ElementAt(frameAtual);

            frame.Draw(spriteBatch);

            if (player.ShowCollisionBox)
            {
                frame.DrawCollisionBoxes(spriteBatch);
            }
        }

    }
}
