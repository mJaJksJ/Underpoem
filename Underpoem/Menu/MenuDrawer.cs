using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Underpoem.AccessoryClasses;
using Underpoem.Menu;
using Underpoem.Params;

namespace Underpoem.UIMenu
{
    abstract class MenuDrawer
    {
        private static RectangleShape backGround;


        public static void Init()
        {
            backGround = new RectangleShape(new SFML.System.Vector2f(MenuParams.backWidth, MenuParams.backHeight))
            {
                Position = new SFML.System.Vector2f(MenuParams.backX, MenuParams.backY),
                FillColor = Program.backColor
            };
            
        }
    

        private static void Draw()
        {
            Program.Window.Clear(Program.clearColor);
            Program.Window.Draw(backGround);
            switch(Program.Game.Status)
            {
                case GameStatus.MenuMain:
                    foreach (Button button in MenuMain.Buttons)
                    {
                        button.draw();
                    }
                    break;
                case GameStatus.MenuSave:
                case GameStatus.MenuLoad:
                    foreach (Button button in MenuLoadAndSave.Buttons)
                    {
                        button.draw();
                    }
                    break;
                case GameStatus.MenuAbout:
                    MenuAbout.Draw();
                    break;
            }

        }

        public static void Update()
        {
            Draw();
        }
    }
}
