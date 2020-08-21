using System;
using System.Collections.Generic;
using System.Text;

namespace Underpoem.GameEntities
{
    [Serializable]
    class Frame
    {
        public int CurrentNum { get; set; }
        public int MaxCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Distance { get; set; }


        public Frame(int _currentNum = 0, int _maxCount = 2, int _x = 0, int _y = 0, int _width = 20, int _height = 30, int _distance = 20)
        {
            CurrentNum = _currentNum;
            MaxCount = _maxCount;
            X = _x;
            Y = _y;
            Width = _width;
            Height = _height;
            Distance = _distance;
        }

        public Frame(Frame _frame)
        {
            CurrentNum = _frame.CurrentNum;
            MaxCount = _frame.MaxCount;
            X = _frame.X;
            Y = _frame.Y;
            Width = _frame.Width;
            Height = _frame.Height;
            Distance = _frame.Distance;
        }
    }
}
