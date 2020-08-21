using System;
using System.Collections.Generic;
using System.Text;
using Underpoem.GameEntities;

namespace Underpoem.UIGame
{
    abstract class GameDrawer
    {
        private static GameUIFrameTime frameTime;

        public static void Init()
        {
            frameTime = new GameUIFrameTime();
            frameTime.Start();
            GameUIPlayerStatistic.Create();
        }


        private static void Draw()
        {
            Program.Window.Clear(Program.clearColor);
            Program.Window.Draw(Program.Game.Arena);

            foreach (IMonster monster in Program.Game.Monsters.Values)
            {
                Program.Window.Draw(((EntityMob)monster).Sprite);
            }
            Program.Window.Draw(Program.Game.Player.Sprite);

            Program.Window.Draw(frameTime.Time);
            Program.Window.Draw(frameTime.Fps);
            Program.Window.Draw(GameUIPlayerStatistic.Love);
            Program.Window.Draw(GameUIPlayerStatistic.Violence);
        }

        public static void Update()
        {
            Draw();
            frameTime.Update();
        }
    }
}
