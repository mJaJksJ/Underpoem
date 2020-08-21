using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Underpoem.AccessoryClasses;
using Underpoem.Params;

namespace Underpoem.UIMenu
{
    abstract class MenuDrawer
    {
        private static RectangleShape backGround;
        private static Button button;

        public static void Init()
        {
            backGround = new RectangleShape(new SFML.System.Vector2f(MenuParams.backWidth, MenuParams.backHeight))
            {
                Position = new SFML.System.Vector2f(MenuParams.backX, MenuParams.backY),
                FillColor = Program.backColor
            };


            button = new Button(new Vector2f(300, 80), new Vector2f(200, 45), _text: "new game")
            {
                ButtonPressedUpHandler = delegate ()
                {
                    /*Random ran = new Random();
                    backGround.FillColor = new Color((byte)ran.Next(0, 255), (byte)ran.Next(0, 255), (byte)ran.Next(0, 255));*/
                    Program.Game.Status = GameStatus.Game;
                },
                Color = Color.Cyan,
                MouseClickButton = Mouse.Button.Left,
            };
        }
    

        private static void Draw()
        {
            Program.Window.Clear(Program.clearColor);
            Program.Window.Draw(backGround);

            button.draw();
        }

        public static void Update()
        {

            Draw();
        }
    }
}
