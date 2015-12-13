using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public abstract class Sprite : Game1
    {
        /// <summary>
        /// Represents size of the Sprite on the screen (in pixels).
        /// Rectangle type is defined in Monogame framework.
        /// </summary>
        public Rectangle Size;
        /// <summary>
        /// Represents position of the Sprite on the screen
        /// Vector2 is two-dimensional vector (X and Y component)
        /// defined in Monogame framework.
        /// </summary>
        public Vector2 Position;

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    Texture.Width,
                    Texture.Height);
            }
        }
       
        /// <summary>
        /// Represents the texture of the Sprite on the screen.
        /// Texture2D is a type defined in Monogame framework.
        /// </summary>
        public Texture2D Texture { get; set; }
        protected Sprite(Texture2D spriteTexture, int width, int height)
        {
            Texture = spriteTexture;
            Size = new Rectangle(0, 0, width, height);
            Position = new Vector2(0, 0);
        }
        /// <summary>
        /// Base draw method
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Size, Color.White);
        }
    }
}
