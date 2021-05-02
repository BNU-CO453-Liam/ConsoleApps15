using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameRPG
{
    public class RPG_Game : Game
    {

        // constants

        public const int HD_Height = 720;
        public const int HD_Width = 1280;

        // attributes/ vars

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Vector2 position;


        private Texture2D PlayerImage;

        private Texture2D walkDownImages;
        private Texture2D walkLeftImages;
        private Texture2D walkRightImages;
        private Texture2D walkUpImages;

        private PlayerSprite player;


        public RPG_Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            graphics.PreferredBackBufferWidth = HD_Width;
            graphics.PreferredBackBufferHeight = HD_Height;
            graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            PlayerImage = Content.Load<Texture2D>("Player/player");
            walkDownImages = Content.Load<Texture2D>("Player/Player-walk-down");
            walkLeftImages = Content.Load<Texture2D>("Player/Player-walk-left");
            walkRightImages = Content.Load<Texture2D>("Player/Player-walk-right");
            walkUpImages = Content.Load<Texture2D>("Player/Player-walk-up");

            SetupSprites();
        }

        private void SetupSprites()
        {
            player = new PlayerSprite(200, 300);
            player.Image = PlayerImage;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //Vector2 position = new Vector2(0, 0);

            // draw background image

            spriteBatch.Draw(player.Image, player.Position, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
