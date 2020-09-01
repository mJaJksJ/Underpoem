using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Underpoem.AccessoryClasses;

namespace Underpoem
{
    static class MenuLoadAndSave
    {
        public static Button[] Buttons { get; private set; }

        static MenuLoadAndSave()
        {
            Buttons = new Button[6];
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i] = new Button(new Vector2f(300, 80 + 60 * i), new Vector2f(200, 45), _text: $"empty file {i}")
                {
                    Ip = i,
                    ButtonPressedUpHandler = LoadAndSave,
                    Color = Color.Cyan,
                    MouseClickButton = Mouse.Button.Left,
                };
                if (File.Exists("Flowey\'s save" + Buttons[i].Ip + ".dat"))
                {
                    Buttons[i].Text.DisplayedString = File.GetLastWriteTime("Flowey\'s save" + Buttons[i].Ip + ".dat").ToString();
                    Buttons[i].Text.CharacterSize -= 3;
                }
            }
        }

        private static void LoadAndSave(object sender)
        {
            switch(Program.Game.Status)
            {
                case GameStatus.MenuLoad:
                    Load("Flowey\'s save" + ((Button)sender).Ip + ".dat");
                    Program.Game.Status = GameStatus.Game;
                    break;
                case GameStatus.MenuSave:
                    Save("Flowey\'s save" + ((Button)sender).Ip + ".dat");
                    ((Button)sender).Text.DisplayedString = DateTime.Now.ToString();
                    ((Button)sender).Text.CharacterSize -= 3;
                    break;
            }
        }

        private static bool Save(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Program.Game);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool Load(string filename)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    Game gm = (Game)formatter.Deserialize(fs);
                    Program.Game.DeepCopy(gm);

                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
