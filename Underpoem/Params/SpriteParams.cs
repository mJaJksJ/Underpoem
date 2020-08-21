using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Underpoem.GameEntities;

namespace Underpoem
{
    static class SpriteParams
    {
        public static readonly string spriteDirectory = "Sprites.png";
        public static readonly string fontDirectory = "comic.ttf";

        public static readonly Frame friskRunDownStay = new Frame(0, 3, 0, 0, 19, 29, 20);
        public static readonly Frame friskRunUpStay = new Frame(0, 3, 0, 30, 19, 29, 20);
        public static readonly Frame friskRunLeftStay = new Frame(0, 1, 0, 60, 17, 29, 20);
        public static readonly Frame friskRunDownLie = new Frame(0, 3, 0, 90, 29, 19, 30);
        public static readonly Frame friskRunUpLie = new Frame(0, 3, 0, 110, 29, 19, 30);
        public static readonly Frame friskRunLeftLie = new Frame(0, 1, 0, 130, 29, 27, 30);

        public static readonly Frame charaRunDownStay = new Frame(0, 3, 0, 150, 19, 29, 20);
        public static readonly Frame charaRunUpStay = new Frame(0, 3, 0, 180, 19, 29, 20);
        public static readonly Frame charaRunLeftStay = new Frame(0, 1, 0, 210, 17, 29, 20);
        public static readonly Frame charaRunDownLie = new Frame(0, 3, 0, 240, 29, 19, 30);
        public static readonly Frame charaRunUpLie = new Frame(0, 3, 0, 260, 29, 19, 30);
        public static readonly Frame charaRunLeftLie = new Frame(0, 1, 0, 280, 29, 27, 30);

        public static readonly Frame monsterKidRunDown = new Frame(0, 3, 80, 0, 21, 27, 25);
        public static readonly Frame monsterKidRunUp = new Frame(0, 3, 80, 30, 19, 27, 25);
        public static readonly Frame monsterKidRunLeft = new Frame(0, 3, 80, 60, 20, 17, 25);
        public static readonly Frame froggyStay = new Frame(0, 3, 180, 0, 19, 20, 20);
        public static readonly Frame froggyLie = new Frame(0, 3, 180, 25, 20, 19, 25);

    }
}
