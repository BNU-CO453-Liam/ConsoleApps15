using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//test

namespace MonoGameRPG
{
    public class PlayerSprite : Sprite
    {
        public PlayerSprite(int x, int y) : base(x, y) { }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keystate = Keyboard.GetState();

            float newX, newY;

            if (keystate.IsKeyDown(Keys.Right))
            {
                newX = Position.X + Speed * deltaTime;
                Position = new Vector2(newX, Position.Y);
            }

            if (keystate.IsKeyDown(Keys.Left))
            {
                newX = Position.X - Speed * deltaTime;
                Position = new Vector2(newX, Position.Y);
            }

            if (keystate.IsKeyDown(Keys.Up))
            {
                newY = Position.Y - Speed * deltaTime;
                Position = new Vector2(Position.X, newY);
            }

            if (keystate.IsKeyDown(Keys.Down))
            {
                newY = Position.Y + Speed * deltaTime;
                Position = new Vector2(Position.X, newY);
            }
        }
    }
}
