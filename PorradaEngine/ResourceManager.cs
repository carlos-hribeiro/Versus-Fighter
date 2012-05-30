using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PorradaEngine
{
    /// <summary>
    /// Classe que gerencia os Resources/arquivos/texturas do game
    /// </summary>
    public class ResourceManager
    {

        private ResourceManager()
        {
        }

        //armazena todas as texturas do game
        Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public const string rectangleColision = "rectangle";

        public const string spritePersonagemRyu = "Ryu1";
        public const string spritePersonagemAkumaHD = "Akuma_moveHD";

        public const string pastaSprites = "Sprites";

        string pastaTextura = "";

        public string PastaTextura { set { pastaTextura = value; } }

        private static ResourceManager instance = new ResourceManager();

        public static ResourceManager Instance{ get { return instance; } }


        /// <summary>
        /// Armazena as texturas para carregar futuramente
        /// </summary>
        public void AddTextureToLoad(string textureName)
        {
            textures.Add(textureName, null);
        }

        /// <summary>
        /// Carregas as texturas do game
        /// </summary>
        public void LoadTextures(ContentManager content, GraphicsDevice graphicsDevice)
        {
            foreach (string key in new List<String>(textures.Keys))
            {
                //Criando o box de colisao
                if (key == rectangleColision)
                {
                    Texture2D rect = new Texture2D(graphicsDevice, 1, 1); //1x1 pixel
                    rect.SetData(new[] { Color.White }); //setando cor branca
                    textures[key] = rect;
                }
                else
                {
                    //carregando as texturas de determinada pasta
                    textures[key] = content.Load<Texture2D>(pastaTextura + "/" + key);
                }
            }
        }

        public Texture2D GetTexture(string textureName)
        {
            return textures[textureName];
        }
        
    }
}
