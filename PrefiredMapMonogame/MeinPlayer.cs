using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PrefiredMapMonogame
{
    internal class MeinPlayer
    {
        public Texture2D Texture { get; set; }
        public Texture2D TextureLeft { get; set; }
        public Texture2D TextureRight { get; set; }
        Vector2 position;
        Vector2 velocity;
        float speed = 150f;
        float scale = 0.05f;

        public MeinPlayer(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            this.Texture=texture;
            this.position=position;
            this.velocity=velocity;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity*(float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            //spriteBatch.Draw(texture, position, Color.White);
            //spriteBatch.End();  
            spriteBatch.Draw(Texture, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public void Move(Vector2 direction)
        {
            velocity= direction*speed;
        }
    }
}
