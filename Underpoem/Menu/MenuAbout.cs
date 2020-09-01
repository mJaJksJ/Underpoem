using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Underpoem.Menu
{
    static class MenuAbout
    {
        private static List<Text> aboutMe;

        private static string[] messages = {"Hello", "I\'m The Simka Littleduck", "Also you will know not now"};
        static MenuAbout()
        {
            aboutMe = new List<Text>();
            for(int i = 0; i < messages.Length; i++)
            {
                aboutMe.Add
                    (
                    new Text("", new Font(SpriteParams.fontDirectory))
                    {
                        Position = new Vector2f(280, 80 + 40 * i),
                        FillColor = Color.Black,
                        DisplayedString = messages[i],
                        CharacterSize = (uint)(20)
                    }
                    );
            }
        }

        public static void Draw()
        {
            foreach (Text mes in aboutMe)
                Program.Window.Draw(mes);
        }
    }
}
