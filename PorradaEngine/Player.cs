using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PorradaEngine.Anim;
using PorradaEngine.Xml;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Input;

namespace PorradaEngine
{
    public class Player
    {
        Animacao parado;

        Animacao andarFrente;
        Animacao andarTraz;

        Animacao socoForte;

        Animacao animacaoAtual;

        int velocidadeAndarFrente;

        public ControllerConfiguration Controller
        {
            get;
            set;
        }

        public Player(PlayerXml xml)
        {

            FaceLeft = true;

            velocidadeAndarFrente = xml.velocidadeAndarFrente;

            parado = new Animacao(xml.parado, this);

            andarFrente = new Animacao(xml.andarFrente, this);
            andarFrente.InLoop = true;

            andarTraz = new Animacao(xml.andarTraz, this);
            andarTraz.InLoop = true;
            
            socoForte = new Animacao(xml.socoForte, this);


            parado.InLoop = true;

            animacaoAtual = parado;
        }

        public int PosX
        {
            get;
            set;
        }

        public int PosY
        {
            get;
            set;
        }

        public bool FaceLeft
        {
            get;
            set;
        }

        public void Update()
        {

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Controller.HardPunch) && animacaoAtual == parado)
            {
                animacaoAtual = socoForte;
            }

            if (state.IsKeyDown(Controller.Right))
            {

                if (FaceLeft)
                {
                    iniciaAnimacaoAndar(andarFrente);
                }
                else
                {
                    iniciaAnimacaoAndar(andarTraz);
                }
                
                PosX += velocidadeAndarFrente;
            }
            else
            {
                if (FaceLeft)
                {
                    paraAnimacaoAndar(andarFrente);
                }
                else
                {
                    paraAnimacaoAndar(andarTraz);
                }
            }

            if (state.IsKeyDown(Controller.Left))
            {
                if (FaceLeft)
                {
                    iniciaAnimacaoAndar(andarTraz);
                }
                else
                {
                    iniciaAnimacaoAndar(andarFrente);
                }

                PosX -= 2;
            }
            else
            {
                if (FaceLeft)
                {
                    paraAnimacaoAndar(andarTraz);
                }
                else
                {
                    paraAnimacaoAndar(andarFrente);
                }
            }



            if (animacaoAtual.Terminou)
            {
                animacaoAtual.Terminou = false;
                animacaoAtual = parado;
            }

            animacaoAtual.Update();

            
        }

        private void iniciaAnimacaoAndar(Animacao anim)
        {
            if (animacaoAtual != anim)
            {
                animacaoAtual = anim;
            }
        }

        private void paraAnimacaoAndar(Animacao anim)
        {
            if (animacaoAtual == anim)
            {
                animacaoAtual = parado;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animacaoAtual.Draw(spriteBatch);
        }
    }
}
