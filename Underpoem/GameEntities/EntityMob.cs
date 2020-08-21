using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Underpoem.GameEntities
{
    [Serializable]
    abstract class EntityMob
    {
        public Sprite Sprite { get; }
        public Frame frame;
        public int limHealth;
        public int currentHealth;
        public int positionX;
        public int positionY;
        public int speed;

        public EntityMob(string _spriteDirectory, Frame _firstFrame, int _limHealth, int _positionX, int _positionY, int _speed)
        {
            if (_limHealth <= 0)
            {
                limHealth = _limHealth;
                currentHealth = _limHealth;
            }
            else
            {
                limHealth = Math.Abs(_limHealth);
                currentHealth = Math.Abs(_limHealth);
            }

            positionX = _positionX;
            positionY = _positionY;

            speed = _speed;
            frame = new Frame(_firstFrame);
            Sprite = new Sprite(new Texture(_spriteDirectory), new IntRect(_firstFrame.X, _firstFrame.Y, _firstFrame.Width, _firstFrame.Height));
        }

        public void UpdateFrame()
        {
            Sprite.Position = new Vector2f(positionX, positionY);
            Sprite.TextureRect = new IntRect(frame.X, frame.Y, frame.Width, frame.Height);
        }

    }
}
