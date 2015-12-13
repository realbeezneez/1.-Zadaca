using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Paddle : Sprite
    {
        /// <summary>
        /// Initial paddle speed. Constant
        /// </summary>
        private const float InitialSpeed = 0.9f;
        /// <summary>
        /// Paddle height. Constant
        /// </summary>
        private const int PaddleHeight = 20;
        /// <summary>
        /// Paddle width. Constant
        /// </summary>
        private const int PaddleWidth = 200;
        /// <summary>
        /// Current paddle speed in time
        /// </summary>
        public float Speed { get; set; }
        public Paddle(Texture2D spriteTexture)
        : base(spriteTexture, PaddleWidth, PaddleHeight)
        {
            Speed = InitialSpeed;
        }
       
       
    }
}
