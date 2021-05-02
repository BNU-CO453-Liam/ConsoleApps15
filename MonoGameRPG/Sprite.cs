using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameRPG
{
    public class Sprite
    {
        public Rectangle Boundary { get; set; }
        public Vector2 StartPosition { get; set; }
        public Vector2 Position { get; set; }


        // properties

        public int MaxSpeed { get; set; }
        public int MinSpeed { get; set; }
        public int Speed { get; set; }
        public Texture2D Image { get; set; }

        public bool IsVisible { get; set; }

        public bool IsAlive { get; set; }

        public int Width
        {
            get { return Image.Width; }
        }

        public int Height
        {
            get { return Image.Height; }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)Position.X, (int)Position.Y, Width, Height);
            }
        }

        // variables

        protected float deltaTime;

        public Sprite(int x, int y)
        {
            Position = new Vector2(x, y);
            StartPosition = Position;

            MaxSpeed = 1000;
            MinSpeed = 200;
            Speed = MinSpeed;

            IsVisible = true;
            IsAlive = true;
        }

        public Vector2 GetCenterPosition()
        {
            return new Vector2(Position.X - Image.Width / 2,
                Position.Y - Image.Height / 2);
        }

        public void ResetPosition()
        {
            Position = StartPosition;
        }

        public virtual void Update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

    }
}
