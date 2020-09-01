using System;
using System.Collections.Specialized;
using SFML.Graphics;
using SFML.Window;
using Underpoem.GameEntities;
using Underpoem.UIGame;
using Underpoem.UIMenu;

namespace Underpoem
{
    class Program
    {
        public static readonly Color backColor = new Color(195, 134, 255);
        public static readonly Color clearColor = new Color(132, 25, 125);

        public static RenderWindow Window { get; private set; }
        public static Game Game { get; private set; }

        private static void programInit()
        {
            Window = new RenderWindow(new VideoMode(800, 600), "Underpoem");
            Window.SetVerticalSyncEnabled(true);
            Window.Closed += WindowClose;
            Game = new Game();
            GameDrawer.Init();
            MenuDrawer.Init();
        }

        static void Main(string[] args)
        {
            Froggy megaFroggy = new Froggy(SpriteParams.spriteDirectory, new Frame(SpriteParams.froggyStay), 20, 200, 200, 0);
            MonsterKid yo = new MonsterKid(SpriteParams.spriteDirectory, new Frame(SpriteParams.monsterKidRunDown), 15, 250, 250, 0);

            programInit();
            Game.Run();
            /*while(Window.IsOpen)
            {
                Window.DispatchEvents();

                megaFroggy.Update();
                yo.Update();
                Game.Update();
                Drawer.Update();

                Drawer.Draw();
                Window.Draw(megaFroggy.Sprite);
                Window.Draw(yo.Sprite);

                Window.Display();
            }*/
        }

        private static void WindowClose(object sender, EventArgs e)
        {
            Window.Close();
        }

    }
}
