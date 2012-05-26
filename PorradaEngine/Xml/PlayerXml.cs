using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PorradaEngine.Xml
{
    /// <summary>
    /// Classe com a mesma estrutura em XML do personagem
    /// As propriedades da estrutura XML serao carregadas aqui.
    /// </summary>
    public class PlayerXml
    {
        public int velocidadeAndarFrente;

        //movimentacao
        public AnimacaoXml parado;
        public AnimacaoXml andarFrente;
        public AnimacaoXml andarTraz;

        //golpes normais
        public AnimacaoXml socoForte;
        
    }
}
