using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using Underpoem.GameEntities;
using Underpoem.UIGame;
using Underpoem.UIMenu;

namespace Underpoem
{
    enum GameStatus { Game, MenuMain, MenuLoad, MenuSave, MenuAbout };
    [Serializable]
    class Game
    {
        public GameStatus Status { get; set; }
        private DemoFactory monstersFactory;
        public Dictionary<string, IMonster> Monsters { get; private set; }
        public Player Player { get; private set; }
        
        //is these temp variable field and property that in future will be in class Level?
        private int entitiesMaxCount;
        public RectangleShape Arena { get; private set; }

        /// <summary>
        /// create arena, player and monsters 
        /// </summary>
        public Game()
        {
            Status = GameStatus.MenuMain;
            Arena = new RectangleShape(new Vector2f(Underpoem.ArenaParams.width, Underpoem.ArenaParams.height))
            {
                Position = new Vector2f(Underpoem.ArenaParams.x, Underpoem.ArenaParams.y),
                FillColor = Program.backColor
            };

            monstersFactory = new DemoFactory();
            Monsters = new Dictionary<string, IMonster>();
            entitiesMaxCount = 10;
            while (Monsters.Count < entitiesMaxCount)
            {
                IMonster monster = monstersFactory.Create();
                Monsters.Add(monster.Ip, monster);
            }

            Player = new Player(SpriteParams.spriteDirectory, new Frame(SpriteParams.friskRunDownStay));

            Update();
        }

        public void Run()
        {
            while (Program.Window.IsOpen)
            {
                Program.Window.DispatchEvents();

                switch(Status)
                {
                    case GameStatus.MenuMain:
                    case GameStatus.MenuSave:
                    case GameStatus.MenuLoad:
                    case GameStatus.MenuAbout:
                        MenuDrawer.Update();
                        break;

                    case GameStatus.Game:
                        Update();
                        GameDrawer.Update();
                        break;
                }

                Program.Window.Display();
            }
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                Status = GameStatus.MenuMain;
            }
            Player.Update();
            foreach(IMonster monster in Monsters.Values)
            {
                monster.Update();
                if(Intersect(Player, (EntityMob)monster))
                {
                    Monsters.Remove(monster.Ip);
                    Player.Killove();
                }
            }
            
            while(Monsters.Count < entitiesMaxCount)
            {
                IMonster monster = monstersFactory.Create();
                Monsters.Add(monster.Ip, monster);
            }

            
        }



        public void DeepCopy(Game copy)
        {
            Status = copy.Status;
            monstersFactory = copy.monstersFactory;
            Monsters.Clear();
            foreach (IMonster monster in copy.Monsters.Values)
            {
                Monsters.Add(monster.Ip, monster);
            }
            Player.DeepCopy(copy.Player);
            entitiesMaxCount = copy.entitiesMaxCount;
            Arena = copy.Arena;
        }





        private bool Intersect(EntityMob entity1, EntityMob entity2)
        {
            bool isIntersect = false;

            int x11 = entity1.positionX;
            int x12 = entity1.positionX + entity1.frame.Width;
            int y11 = entity1.positionY;
            int y12 = entity1.positionY + entity1.frame.Height;

            int x21 = entity2.positionX;
            int x22 = entity2.positionX + entity2.frame.Width;
            int y21 = entity2.positionY;
            int y22 = entity2.positionY + entity2.frame.Height;

            if (x11 >= x21 && x11 <= x22 && y11 >= y21 && y11 <= y22)
                isIntersect = true;
            else if (x12 >= x21 && x12 <= x22 && y11 >= y21 && y11 <= y22)
                isIntersect = true;
            else if (x11 >= x21 && x11 <= x22 && y12 >= y21 && y12 <= y22)
                isIntersect = true;
            else if (x12 >= x21 && x12 <= x22 && y12 >= y21 && y12 <= y22)
                isIntersect = true;

            return isIntersect;
        }

        
    }
}
