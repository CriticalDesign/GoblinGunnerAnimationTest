using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GoblinGunnerAnimationTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        //A goblin gunner for our animation test.
        private GoblinGunner _gunner1;
        private GoblinGunner _gunner2;
        private GoblinGunner _gunner3;
        private GoblinGunner _gunner4;
        private GoblinGunner _gunner5;
        private GoblinGunner _gunner6;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //these two statement control the framerate of the game. You 
            //can take them out and it will go back to the default.
            this.IsFixedTimeStep = true;//false;
            this.TargetElapsedTime = TimeSpan.FromSeconds(1d / 15d); //60);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //create our gunner object - loat the texture and pass the
            //number of rows and columns in the spritesheet. The last two arguments 
            //are the x and y coordinates of the object.
            //Give each gunner a different start state.
            _gunner1 = new GoblinGunner(Content.Load <Texture2D> ("GoblinGunnerSprites"), 6, 8, 0, 0);
            _gunner1.ChangeState(state.idle);

            _gunner2 = new GoblinGunner(Content.Load<Texture2D>("GoblinGunnerSprites"), 6, 8, 250, 0);
            _gunner2.ChangeState(state.moving);

            _gunner3 = new GoblinGunner(Content.Load<Texture2D>("GoblinGunnerSprites"), 6, 8, 500, 0);
            _gunner3.ChangeState(state.attack);

            _gunner4 = new GoblinGunner(Content.Load<Texture2D>("GoblinGunnerSprites"), 6, 8, 0, 200);
            _gunner4.ChangeState(state.recover);

            _gunner5 = new GoblinGunner(Content.Load<Texture2D>("GoblinGunnerSprites"), 6, 8, 250, 200);
            _gunner5.ChangeState(state.damage);

            _gunner6 = new GoblinGunner(Content.Load<Texture2D>("GoblinGunnerSprites"), 6, 8, 500, 200);
            _gunner6.ChangeState(state.death);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //call the gunner updates
            _gunner1.Update(gameTime);
            _gunner2.Update(gameTime);
            _gunner3.Update(gameTime);
            _gunner4.Update(gameTime);
            _gunner5.Update(gameTime);
            _gunner6.Update(gameTime);




            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //and...action!
            _gunner1.Draw(_spriteBatch);
            _gunner2.Draw(_spriteBatch);
            _gunner3.Draw(_spriteBatch);
            _gunner4.Draw(_spriteBatch);
            _gunner5.Draw(_spriteBatch);
            _gunner6.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
