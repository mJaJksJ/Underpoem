using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Underpoem.GameEntities
{
    [Serializable]
    class DemoFactory: IMonsterFactory
    { 
        private static Random rnd = new Random();
        enum Monsters { Froggy, MonsterKid };
        private int monstersLength = Enum.GetNames(typeof(Monsters)).Length;
        private static int ip = 0;

        /// <summary>
        /// create Froggy or MonsterKid with random color
        /// </summary>
        /// <returns>new object of IMonster</returns>
        public IMonster Create()
        {
            IMonster monster = ((Monsters)(rnd.Next(0, monstersLength))) switch
            {
                Monsters.Froggy => 
                new Froggy(SpriteParams.spriteDirectory, new Frame(SpriteParams.froggyStay), 
                _positionX: rnd.Next(ArenaParams.x + 0 + SpriteParams.froggyStay.Width, ArenaParams.x + ArenaParams.width - SpriteParams.froggyStay.Width), 
                _positionY: rnd.Next(ArenaParams.y + 0 + SpriteParams.froggyStay.Height, ArenaParams.y + ArenaParams.height - SpriteParams.froggyStay.Height))
                {
                    Ip = "Froggy" + (++ip)
                },
                Monsters.MonsterKid => new MonsterKid(SpriteParams.spriteDirectory, new Frame(SpriteParams.monsterKidRunDown), _positionX: rnd.Next(ArenaParams.x, ArenaParams.width), _positionY: rnd.Next(ArenaParams.y, ArenaParams.height))
                {
                    Ip = "MonsterKid" + (++ip)
                },
                _ => throw new Exception("Таких монстров нет")
            };
            
            ((EntityMob)monster).Sprite.Color = new Color((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255));
            return monster;
        }
    }
}
