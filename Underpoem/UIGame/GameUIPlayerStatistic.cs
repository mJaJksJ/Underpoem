using System;
using System.Collections.Generic;
using System.Text;
using Underpoem.GameEntities;
using SFML.Graphics;
using SFML.System;

namespace Underpoem.UIGame
{
    static class GameUIPlayerStatistic
    {
        public static Text Love { get; private set; }
        public static Text Violence { get; private set; }

        public static void Create()
        {
            Love = new Text
            {
                FillColor = Color.Black,
                Position = new Vector2f(20, 80),
                CharacterSize = 15,
                DisplayedString = "Love",
                Font = new Font(SpriteParams.fontDirectory)
            };
            UpdateLove();
            Violence = new Text
            {
                FillColor = Color.Black,
                Position = new Vector2f(20, 100),
                CharacterSize = 15,
                DisplayedString = "Violence",
                Font = new Font(SpriteParams.fontDirectory)
            };
            UpdateViolence();
        }

        public static void UpdateLove()
        {
            Love.DisplayedString = $"Love: {Program.Game.Player.ParamLove}";
        }

        public static void UpdateViolence()
        {
            Violence.DisplayedString = $"Violence: {Program.Game.Player.ParamLevelOfViolence}";
        }

    }
}
