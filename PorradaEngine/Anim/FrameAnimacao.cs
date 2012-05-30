using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using PorradaEngine.Collision;
using PorradaEngine.Xml;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PorradaEngine.Anim
{
    /// <summary>
    /// Representa um frame da animacao
    /// </summary>
    public class FrameAnimacao
    {
        Rectangle posicaoImagem;
        int maxFrame;
        Animacao animacao;
        bool slow = false; //para o frame ficar mais tempo na tela
        string spriteFile = null;

        List<HittableBox> hittableBoxes = new List<HittableBox>();
        List<AttackBox> attackBoxes = new List<AttackBox>();

        public Animacao Animacao
        {
            set { this.animacao = value; }
        }

        public int MaxFrame
        {
            get { return slow ? maxFrame * 5 : maxFrame; }
        }

        //para o frame ficar mais tempo na tela
        public bool Slow
        {
            get { return slow; }
            set { slow = value; }
        }


        public FrameAnimacao(Rectangle posicaoImagem, int maxFrame)
        {
            this.posicaoImagem = posicaoImagem;
            this.maxFrame = maxFrame;

        }

        public FrameAnimacao(FrameAnimacaoXml frameXml)
        {
            this.posicaoImagem = frameXml.posicaoImagem;
            this.maxFrame = frameXml.maxFrame;
            this.spriteFile = frameXml.spriteFile;

            //pega os boxes de colisao do frame com base no xml
            foreach (Rectangle rectHittable in frameXml.hittableBoxes)
            {
                hittableBoxes.Add(
                    new HittableBox(rectHittable.X, rectHittable.Y, rectHittable.Width, rectHittable.Height));
            }

            //pega os boxes de ataque do frame com base no xml
            foreach (Rectangle rectAttack in frameXml.attackBoxes)
            {
                attackBoxes.Add(
                    new AttackBox(rectAttack.X, rectAttack.Y, rectAttack.Width, rectAttack.Height));
            }
        }


        /// <summary>
        /// Desenha o frame
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (spriteFile != null)
            {
                Texture2D texture = ResourceManager.Instance.GetTexture(spriteFile);

                if (animacao.FaceLeft)
                {
                    spriteBatch.Draw(texture,
                        new Vector2(animacao.PosX, animacao.PosY), posicaoImagem, Color.White);
                }
                else
                {
                    //inverte a posicao do frame para o lado oposto
                    spriteBatch.Draw(texture,
                        new Vector2(animacao.PosX - posicaoImagem.Width, animacao.PosY), posicaoImagem, Color.White, 0, Vector2.Zero, 1, SpriteEffects.FlipHorizontally, 0);
                }
            }
            
        }

        /// <summary>
        /// Desenha os boxes de colisao
        /// </summary>
        public void DrawCollisionBoxes(SpriteBatch spriteBatch)
        {
            foreach (HittableBox hbox in hittableBoxes)
            {
                hbox.Draw(spriteBatch, animacao.PosX, animacao.PosY, animacao.FaceLeft);
            }

            foreach (AttackBox abox in attackBoxes)
            {
                abox.Draw(spriteBatch, animacao.PosX, animacao.PosY, animacao.FaceLeft);
            }
        }


    }
}
