using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PorradaEngine
{
    public class ResourceManager
    {

        Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        string pastaTextura = "";

        private static ResourceManager instance = new ResourceManager();

        public static ResourceManager Instance
        {
            get { return instance; }
        }

        private ResourceManager()
        {
        }

        public string PastaTextura
        {
            set { pastaTextura = value; }
        }

        public void AddTextureToLoad(string textureName)
        {
            textures.Add(textureName, null);
        }

        public void LoadTextures(ContentManager content, GraphicsDevice graphicsDevice)
        {
            foreach (string key in new List<String>(textures.Keys))
            {
                if (key == "rectangle")
                {
                    Texture2D rect = new Texture2D(graphicsDevice, 1, 1);
                    rect.SetData(new[] { Color.White });
                    textures[key] = rect;
                }
                else
                {
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
