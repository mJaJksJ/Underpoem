using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using Underpoem.AccessoryClasses;

namespace Underpoem
{
    static class MenuMain
    {
        //New game, continue, save, load, about, exit
        public static Button[] Buttons { get; private set; }
        private static string[] buttonsName = { "new game", "continue", "save game", "load game", "about", "exit" };
        private static ButtonPressedUpHandler[] buttonClicks = { NewGame, Continue, Save, Load, About, Exit };
        private static bool isGameExists;

        static MenuMain()
        {
            isGameExists = false;
            Buttons = new Button[6];
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i] = new Button(new Vector2f(300, 80 + 60 * i), new Vector2f(200, 45), _text: buttonsName[i])
                {
                    ButtonPressedUpHandler = buttonClicks[i],
                    Color = Color.Cyan,
                    MouseClickButton = Mouse.Button.Left,
                };
            }
            if(!isGameExists)
            {
                Buttons[1].ButtonPressedUpHandler -= buttonClicks[1];
                Buttons[1].Color = Color.White;
            }
        }

        private static void NewGame(object sender)
        {
            Program.Game.Status = GameStatus.Game;
            isGameExists = true;
            Buttons[1].ButtonPressedUpHandler += buttonClicks[1];
            Buttons[1].Color = Buttons[0].Color;
        }

        private static void Continue(object sender)
        {
            Program.Game.Status = GameStatus.Game;
        }

        private static void Save(object sender)
        {
            Program.Game.Status = GameStatus.MenuSave;
        }

        private static void Load(object sender)
        {
            Program.Game.Status = GameStatus.MenuLoad;
            isGameExists = true;
            Buttons[1].ButtonPressedUpHandler += buttonClicks[1];
            Buttons[1].Color = Buttons[0].Color;
        }

        private static void About(object sender)
        {
            Program.Game.Status = GameStatus.MenuAbout;
        }

        private static void Exit(object sender)
        {
            Program.Window.Close();
        }
    }
}
