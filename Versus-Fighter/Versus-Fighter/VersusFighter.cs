using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using PorradaEngine.Anim;
using PorradaEngine;
using PorradaEngine.Xml;

namespace Versus_Fighter
{
    /// <summary>
    /// This is the main type for your game - ai caramba!!!
    /// </summary>
    public class VersusFighter : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player1;
        Player player2;
       // Texture2D ryu;

        public VersusFighter()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            

            ResourceManager.Instance.PastaTextura = "Sprites";
            ResourceManager.Instance.AddTextureToLoad("Ryu1");
            ResourceManager.Instance.AddTextureToLoad("rectangle");


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            
            ResourceManager.Instance.LoadTextures(Content, GraphicsDevice);

            PlayerXml xml = Content.Load<PlayerXml>(@"Personagens/Ryu");

            player1 = new Player(xml);
            player1.PosX = 50;
            player1.PosY = 100;

            ControllerConfiguration controller1 = new ControllerConfiguration();
            controller1.HardPunch = Keys.Q;
            controller1.Left = Keys.J;
            controller1.Right = Keys.L;
            player1.Controller = controller1;

            player2 = new Player(xml);
            player2.PosX = 250;
            player2.PosY = 100;
            player2.FaceLeft = false;

            ControllerConfiguration controller2 = new ControllerConfiguration();
            controller2.HardPunch = Keys.D9;
            controller2.Left = Keys.Left;
            controller2.Right = Keys.Right;
            player2.Controller = controller2;

        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            player1.Update();
            player2.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
