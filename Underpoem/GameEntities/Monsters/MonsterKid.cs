using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Underpoem.GameEntities
{
    [Serializable]
    class MonsterKid: EntityMob, IMonster
    {
        public string Ip { get; set; }

        private double deceleration = 0;

        public MonsterKid(string _spriteDirectory, Frame _firstFrame, int _limHealth = 15, int _positionX = 100, int _positionY = 100, int _speed = 2) :
            base(_spriteDirectory, _firstFrame, _limHealth, _positionX, _positionY, _speed)
        { }

        public void Move()
        {
            double decelerationCoefficient = 0.1;
            deceleration = deceleration < SpriteParams.monsterKidRunDown.MaxCount ? deceleration + decelerationCoefficient : 0;
            frame.CurrentNum = (int)Math.Round(deceleration, MidpointRounding.AwayFromZero);
            frame.X = SpriteParams.monsterKidRunDown.X + frame.CurrentNum * SpriteParams.monsterKidRunDown.Distance;
            UpdateFrame();
        }

        public void Update()
        {
            Move();
        }

        public void Die()
        {
            throw new Exception("method unwork");
        }
    }
}
