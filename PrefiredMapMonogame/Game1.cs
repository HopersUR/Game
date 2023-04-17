using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace PrefiredMapMonogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D Dust2;
        MeinPlayer meinPlayer;
        //private Texture2D meinPlayerLeft;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "PrefMap";
            //Texture2D texture2D;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1240;
            graphics.PreferredBackBufferHeight = 850;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Dust2 = Content.Load<Texture2D>("Dust2");
            meinPlayer = new MeinPlayer(Content.Load<Texture2D>("Player"), new Vector2(100, 100),new Vector2());
            meinPlayer.TextureLeft = Content.Load<Texture2D>("PlayerLeft");
            meinPlayer.TextureRight = Content.Load<Texture2D>("Player");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            meinPlayer.Update(gameTime);
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
                meinPlayer.Texture = meinPlayer.TextureLeft;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                direction.X +=1;
                meinPlayer.Texture = meinPlayer.TextureRight;
            }
            if(keyboardState.IsKeyDown(Keys.Up))
                direction.Y -= 1;
            if (keyboardState.IsKeyDown(Keys.Down))
                direction.Y += 1;
            meinPlayer.Move(direction); 
            if (keyboardState.IsKeyDown(Keys.Space))
            {

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(Dust2,new Rectangle(0,0,1240,800), Color.White);
            spriteBatch.End();
            spriteBatch.Begin();
            meinPlayer.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}