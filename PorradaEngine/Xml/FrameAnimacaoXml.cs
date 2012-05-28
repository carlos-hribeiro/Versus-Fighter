using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace PorradaEngine.Xml
{
    /// <summary>
    /// Representa as propriedades de um frame da animacao com base no XML do personagem
    /// </summary>
    public class FrameAnimacaoXml
    {
        //tamano e posicao da imagem
        public Rectangle posicaoImagem;

        //velocidade de animacao do frame
        public int maxFrame;
        
        //boxes de colisao
        public List<Rectangle> hittableBoxes;

        //boxes de ataque
        public List<Rectangle> attackBoxes;

    }
}
