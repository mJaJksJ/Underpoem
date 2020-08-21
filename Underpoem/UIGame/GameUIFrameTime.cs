using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;

namespace Underpoem.UIGame
{
    class GameUIFrameTime
    {
        private int ticks = 0;
        private readonly Clock FpsTimer = new Clock();
        private readonly Clock GameTimer = new Clock();

        private int elapsedHours;
        private int elapsedMinuts;
        private int elapsedSeconds;

        public Text Time { get; private set; }
        public Text Fps { get; private set; }

        public void Start()
        {
            FpsTimer.Restart();
            GameTimer.Restart();

            elapsedHours = 0;
            elapsedMinuts = 0;
            elapsedSeconds = 0;

            Time = new Text
            {
                FillColor = Color.Black,
                Position = new Vector2f(20, 20),
                CharacterSize = 15,
                DisplayedString = "Time",
                Font = new Font(SpriteParams.fontDirectory)
            };
            Fps = new Text
            {
                FillColor = Color.Black,
                Position = new Vector2f(20, 40),
                CharacterSize = 15,
                DisplayedString = "FPS",
                Font = new Font(SpriteParams.fontDirectory)
            };
        }

        public void Update()
        {
            ticks++;
            if (FpsTimer.ElapsedTime.AsMilliseconds() > 500)
            {
                Fps.DisplayedString = $"FPS: {ticks*1000 / FpsTimer.ElapsedTime.AsMilliseconds()}";
                ticks = 0;
                FpsTimer.Restart();
            }

            elapsedHours = (int)(GameTimer.ElapsedTime.AsSeconds() / 3600 % 3600);
            elapsedMinuts = (int)(GameTimer.ElapsedTime.AsSeconds() / 60 % 60);
            elapsedSeconds = (int)(GameTimer.ElapsedTime.AsSeconds() % 60);

            Time.DisplayedString = $"Time: {elapsedHours}:{elapsedMinuts:D2}:{elapsedSeconds:D2}";
        }
    }
}
