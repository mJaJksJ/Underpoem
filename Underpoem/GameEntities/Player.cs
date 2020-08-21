using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Underpoem.UIGame;

namespace Underpoem.GameEntities
{
    [Serializable]
    class Player: EntityMob
    {
        enum Personality {Frisk, Chara};

        public static int ParamLove { get; private set; }
        public static int ParamLevelOfViolence { get; private set; }
        private Personality personStatus;
        

        private double deceleration = 0;

        public Player(string _spriteDirectory, Frame _firstFrame, int _limHealth = 100, int _positionX = 100, int _positionY = 100, int _speed = 2) :
            base(_spriteDirectory, _firstFrame, _limHealth, _positionX, _positionY, _speed)
        {
            ParamLove = 0;
            ParamLevelOfViolence = 0;
            personStatus = Personality.Frisk;
        }

        public void Update()
        {
            UpdatePersonality();
            UpdateMover();
        }

        private void UpdatePersonality()
        {
            if(Keyboard.IsKeyPressed(Keyboard.Key.G))
            {
                personStatus = Personality.Chara;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.H))
            {
                personStatus = Personality.Frisk;
            }
        }

        private void UpdateMover()
        {
            switch (personStatus)
            {
                case Personality.Frisk:
                    MoveAndStayFrisk();
                    break;
                case Personality.Chara:
                    MoveChara();
                    break;
            }
        }

        private void MoveAndStayFrisk()
        {
            bool isMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool isMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool isMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
            bool isMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
            bool isMoveX = isMoveLeft || isMoveRight;
            bool isMoveY = isMoveDown || isMoveUp;
            
            if (isMoveX)
            {
                double decelerationCoefficient = 0.1;
                deceleration = deceleration < SpriteParams.friskRunLeftStay.MaxCount ? deceleration + decelerationCoefficient : 0;
                frame.CurrentNum = (int)Math.Round(deceleration, MidpointRounding.AwayFromZero);

                if (isMoveLeft)
                {
                    frame.Width = SpriteParams.friskRunLeftStay.Width;
                    frame.Height = SpriteParams.friskRunLeftStay.Height;
                    positionX -= speed;
                    frame.X = SpriteParams.friskRunLeftStay.X + frame.CurrentNum * SpriteParams.friskRunLeftStay.Distance;
                    frame.Y = SpriteParams.friskRunLeftStay.Y;
                }
                else if (isMoveRight)
                {
                    frame.Width = -SpriteParams.friskRunLeftStay.Width;
                    frame.Height = SpriteParams.friskRunLeftStay.Height;
                    positionX += speed;
                    frame.X = (SpriteParams.friskRunLeftStay.X + SpriteParams.friskRunLeftStay.Width) + frame.CurrentNum * SpriteParams.friskRunLeftStay.Distance;
                    frame.Y = SpriteParams.friskRunLeftStay.Y;
                }

                //?change for this action with firstly isMoveY too?
                if(isMoveY)
                {
                    positionY += (Convert.ToInt32(isMoveDown) * speed - Convert.ToInt32(isMoveUp) * speed); 
                }
            }
            else if (isMoveY)
            {
                double decelerationCoefficient = 0.2;

                if (isMoveUp)
                {
                    deceleration = deceleration < SpriteParams.friskRunUpStay.MaxCount ? deceleration + decelerationCoefficient : 0;
                    frame.CurrentNum = (int)Math.Round(deceleration, MidpointRounding.AwayFromZero);

                    frame.Width = SpriteParams.friskRunUpStay.Width;
                    frame.Height = SpriteParams.friskRunUpStay.Height;
                    positionY -= speed;

                    frame.X = SpriteParams.friskRunUpStay.X + frame.CurrentNum * SpriteParams.friskRunUpStay.Distance;
                    frame.Y = SpriteParams.friskRunUpStay.Y;
                }
                else if (isMoveDown)
                {
                    deceleration = deceleration < SpriteParams.friskRunDownStay.MaxCount ? deceleration + decelerationCoefficient : 0;
                    frame.CurrentNum = (int)Math.Round(deceleration, MidpointRounding.AwayFromZero);

                    frame.Width = SpriteParams.friskRunDownStay.Width;
                    frame.Height = SpriteParams.friskRunDownStay.Height;
                    positionY += speed;

                    frame.X = SpriteParams.friskRunDownStay.X + frame.CurrentNum * SpriteParams.friskRunDownStay.Distance;
                    frame.Y = SpriteParams.friskRunDownStay.Y;
                }
            }
            else
            {
                frame.Width = SpriteParams.friskRunDownStay.Width;
                frame.Height = SpriteParams.friskRunDownStay.Height;
                frame.X = SpriteParams.friskRunDownStay.X;
                frame.Y = SpriteParams.friskRunDownStay.Y;
            }
            UpdateFrame();
        }

        private void MoveChara()
        {
            bool isMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
            bool isMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
            bool isMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
            bool isMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
            bool isMoveX = isMoveLeft || isMoveRight;
            bool isMoveY = isMoveDown || isMoveUp;

            if (isMoveX)
            {
                double decelerationCoefficient = 0.1;
                deceleration = deceleration < SpriteParams.charaRunLeftStay.MaxCount ? deceleration + decelerationCoefficient : 0;
                frame.CurrentNum = (int)Math.Round(deceleration, MidpointRounding.AwayFromZero);

                if (isMoveLeft)
                {
                    frame.Width = SpriteParams.charaRunLeftStay.Width;
                    frame.Height = SpriteParams.charaRunLeftStay.Height;
                    positionX -= speed;
                    frame.X = SpriteParams.charaRunLeftStay.X + frame.CurrentNum * SpriteParams.charaRunLeftStay.Distance;
                    frame.Y = SpriteParams.charaRunLeftStay.Y;
                }
                else if (isMoveRight)
                {
                    frame.Width = -SpriteParams.charaRunLeftStay.Width;
                    frame.Height = SpriteParams.charaRunLeftStay.Height;
                    positionX += speed;
                    frame.X = (SpriteParams.charaRunLeftStay.X + SpriteParams.charaRunLeftStay.Width) + frame.CurrentNum * SpriteParams.charaRunLeftStay.Distance;
                    frame.Y = SpriteParams.charaRunLeftStay.Y;
                }

                //?change for this action with firstly isMoveY too?
                if (isMoveY)
                {
                    positionY += (Convert.ToInt32(isMoveDown) * speed - Convert.ToInt32(isMoveUp) * speed);
                }

            }
            else if (isMoveY)
            {
                double decelerationCoefficient = 0.2;

                if (isMoveUp)
                {
                    deceleration = deceleration < SpriteParams.charaRunUpStay.MaxCount ? deceleration + decelerationCoefficient : 0;
                    frame.CurrentNum = (int)Math.Round(deceleration, MidpointRounding.AwayFromZero);

                    frame.Width = SpriteParams.charaRunUpStay.Width;
                    frame.Height = SpriteParams.charaRunUpStay.Height;
                    positionY -= speed;

                    frame.X = SpriteParams.charaRunUpStay.X + frame.CurrentNum * SpriteParams.charaRunUpStay.Distance;
                    frame.Y = SpriteParams.charaRunUpStay.Y;
                }
                else if (isMoveDown)
                {
                    deceleration = deceleration < SpriteParams.charaRunDownStay.MaxCount ? deceleration + decelerationCoefficient : 0;
                    frame.CurrentNum = (int)Math.Round(deceleration, MidpointRounding.AwayFromZero);

                    frame.Width = SpriteParams.charaRunDownStay.Width;
                    frame.Height = SpriteParams.charaRunDownStay.Height;
                    positionY += speed;

                    frame.X = SpriteParams.charaRunDownStay.X + frame.CurrentNum * SpriteParams.charaRunDownStay.Distance;
                    frame.Y = SpriteParams.charaRunDownStay.Y;
                }



            }
            else
            {
                frame.Width = SpriteParams.charaRunDownStay.Width;
                frame.Height = SpriteParams.charaRunDownStay.Height;
                frame.X = SpriteParams.charaRunDownStay.X;
                frame.Y = SpriteParams.charaRunDownStay.Y;
            }
            UpdateFrame();
        }

        public void Killove()
        {
            switch (personStatus)
            {
                case Personality.Frisk:
                    ParamLove++;
                    GameUIPlayerStatistic.UpdateLove();
                    break;
                case Personality.Chara:
                    ParamLevelOfViolence++;
                    GameUIPlayerStatistic.UpdateViolence();
                    break;
            }
        }
            
    }
}
