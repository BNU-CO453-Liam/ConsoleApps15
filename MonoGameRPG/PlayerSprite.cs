using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameRPG
{
    public class PlayerSprite : Sprite
    {
        public PlayerSprite(int x, int y) : base(x, y) { }
        private float newX;
        private float newY;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            KeyboardState keystate = Keyboard.GetState();

            
            //float newX, newY;

            if (keystate.IsKeyDown(Keys.Right))
            {
                newX = Position.X + Speed * deltaTime;
                //Position = new Vector2(newX, Position.Y);
            }

            if (keystate.IsKeyDown(Keys.Left))
            {
                newX = Position.X - Speed * deltaTime;
                //Position = new Vector2(newX, Position.Y);
            }

            if (keystate.IsKeyDown(Keys.Up))
            {
                newY = Position.Y - Speed * deltaTime;
                //Position = new Vector2(Position.X, newY);
            }

            if (keystate.IsKeyDown(Keys.Down))
            {
                newY = Position.Y + Speed * deltaTime;

                //Position = new Vector2(Position.X, newY);
            }

            if (Position.X > RPG_Game.HD_Width)
            {
                newX = RPG_Game.HD_Width;
            }

            else if (Position.X < RPG_Game.player.Width)
            {
                newX = RPG_Game.player.Width;
            }
                
            if (Position.Y > RPG_Game.HD_Height)
            {
                newY = RPG_Game.HD_Height;
            }
                
            else if (Position.Y < RPG_Game.player.Height)
            {
                newY = RPG_Game.player.Height;
            }

            Position = new Vector2(newX, newY);
        }
    }
}
