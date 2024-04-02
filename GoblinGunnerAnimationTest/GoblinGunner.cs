using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GoblinGunnerAnimationTest
{
    //This is called an enum. It is essentially a bunch of 
    //ints that are associated with names.
    enum state{
        idle,       //value = 0
        moving,     //value = 1
        attack,     //value = 2
        recover,    //value = 3
        damage,     //value = 4
        death       //value = 5
        }

    internal class GoblinGunner
    {
        //attributes
        private Texture2D _myTexture;
        private int _textureRows, _textureCols, _frameIndex;
        private int _frameHeight, _frameWidth;
        private float _myX, _myY;
        private state _myState;  //here's our enum

        private Random _rng;

        public GoblinGunner(Texture2D myTexture, int numRows, int numCols, int myX, int myY)
        {
            _myTexture = myTexture;
            _textureRows = numRows;
            _textureCols = numCols;

            _frameHeight = _myTexture.Height / _textureRows;
            _frameWidth = _myTexture.Width / _textureCols;

            _frameIndex = 0;

            _myX = myX;
            _myY = myY;

            _myState = state.idle;  //default state

            _rng = new Random();
        }

        //state mutator
        public void ChangeState(state newState) { _myState = newState; }

        //update method
        public void Update(GameTime gameTime) 
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                //look at this clever code!!! Random state when
                //space is pressed.
                _myState = (state)_rng.Next(0, 6);
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {            
            spritebatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);  //special begin to scale the sprites without fuzzing.

            //a variable for the number of frames in the animation cycle
            int numFrames = 8;

            //use the enums to determine the state of the character and 
            //to change the number of animation frames accordingly.
            if (_myState == state.idle || _myState == state.moving || _myState == state.attack)
                numFrames = 8;
            else if (_myState == state.recover || _myState == state.damage)
                numFrames = 5;
            else
                numFrames = 6;

            //draw the sprite.
            spritebatch.Draw(
            _myTexture,                     //spritesheet
            new Vector2(_myX, _myY),        //on-screen location
            new Rectangle(_frameWidth * _frameIndex, //which column
            _frameHeight * (int)_myState, //which row, uses enums
            _frameWidth,                    //frame width
            _frameHeight),                  //frame height
            Color.White,                    //color overlay/blend
            0,                              //rotation
            new Vector2(0, 0),              //origin (top left corner)
            7.5f,                           //scale
            SpriteEffects.None,             //flip or no flip
            0                               //layer
            );

            _frameIndex++;              //move to the next frame

            //when we run out of frames, restart.
            if (_frameIndex >= numFrames)
                _frameIndex = 0;

            spritebatch.End();
        }

    }
}
