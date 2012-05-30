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
    /// <summary>
    /// Engloba todos os estados e acoes do player no game
    /// </summary>
    public class Player
    {
        //tipos de animacao
        Animacao parado;
        Animacao andarFrente;
        Animacao andarTraz;
        Animacao socoForte;

        //Animacao que o personagem esta realizando no momento
        Animacao animacaoAtual;

        int velocidadeAndarFrente;
        bool slowAnimation = false;
        bool f1Pressed = false;
        bool f2Pressed = false;

        public ControllerConfiguration Controller{ get; set;}

        public int PosX              { get; set; }
        public int PosY              { get; set; }
        public bool FaceLeft         { get; set; }
        public bool ShowCollisionBox { get; set; }

        public Player(PlayerXml xml)
        {

            FaceLeft = true;

            velocidadeAndarFrente = xml.velocidadeAndarFrente;

            //criando as animacoes com base nas definicoes do XML do personagem
            parado = new Animacao(xml.parado, this);
            parado.InLoop = true;

            andarFrente = new Animacao(xml.andarFrente, this);
            andarFrente.InLoop = true;

            andarTraz = new Animacao(xml.andarTraz, this);
            andarTraz.InLoop = true;
            
            socoForte = new Animacao(xml.socoForte, this);

            animacaoAtual = parado;
        }


        /// <summary>
        /// Verifica o estado atual do player em cada atualizacao
        /// </summary>
        public void Update()
        {

            //Verifica as teclas pressionadas e seta uma determinada acao.
            KeyboardState state = Keyboard.GetState();
            if (Controller != null)
            {
                //Golpes
                //soco forte
                if (state.IsKeyDown(Controller.HardPunch) && animacaoAtual == parado)
                {
                    animacaoAtual = socoForte;
                }

                //Movimentacao
                //Direita
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

                //Esquerda
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
            }

            //Tecla F1 - Deixar a animacao mais lenta
            if (state.IsKeyDown(Keys.F1))
            {
                f1Pressed = true;
            }
            else if (f1Pressed)
            {
                f1Pressed = false;
                slowAnimation = !slowAnimation;
            }

            //Tecla F2 - Mostrar os boxes de colisao
            if (state.IsKeyDown(Keys.F2))
            {
                f2Pressed = true;
            }
            else if (f2Pressed)
            {
                f2Pressed = false;
                ShowCollisionBox = !ShowCollisionBox;
            }

            //verifica se animacao terminou
            if (animacaoAtual.Terminou)
            {
                animacaoAtual.Terminou = false;
                animacaoAtual = parado;
            }


            animacaoAtual.Slow = slowAnimation;
            animacaoAtual.Update();

            
        }

        //seta a animacao atual para andando
        private void iniciaAnimacaoAndar(Animacao anim)
        {
            if (animacaoAtual != anim)
            {
                animacaoAtual = anim;
            }
        }

        //para a animacao de andar
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
