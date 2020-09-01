using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Underpoem.AccessoryClasses
{
    delegate void ButtonPressedUpHandler(object sender);

    class Button
    {
        public int Ip { get; set; }

        private Vector2f position;
        private Vector2f size;

        private bool isButtonRect = false;
        private Color color;
        private RectangleShape rectangle;

        private bool isButtonSprite = false;
        private Texture texture;
        private Sprite sprite;

        private int borderSize;
        private Color borderColor;
        private RectangleShape borderRectangle;

        private bool isPressed = false;

        public Text Text { get; set; }

        public Mouse.Button MouseClickButton { get; set; }

        public ButtonPressedUpHandler ButtonPressedUpHandler { get; set; }

        public Button(Vector2f _position, Vector2f _size, int _borderSize = 2, string _text = "")
        {
            position = _position;
            size = _size;
            borderSize = _borderSize;
            borderColor = Color.Black;
            borderRectangle = new RectangleShape(new Vector2f(size.X + borderSize, size.Y + borderSize))
            {
                Position = position,
                FillColor = borderColor
            };
            Text = new Text(_text, new Font(SpriteParams.fontDirectory))
            {
                Position = new Vector2f(position.X + borderSize * 3, position.Y + borderSize * 3),
                FillColor = borderColor,
                CharacterSize = (uint)(size.Y / 2)
            };
        }

        public Color Color
        {
            get { return color; }
            set 
            { 
                isButtonRect = true;
                isButtonSprite = false;
                color = value;
                rectangle = new RectangleShape(size)
                {
                    Position = position,
                    FillColor = color
                };
            }
        }

        public Texture Texture
        {
            get { return texture; }
            set
            {
                isButtonRect = false;
                isButtonSprite = true;
                texture = value;
                sprite = new Sprite(texture, new IntRect((Vector2i)position, (Vector2i)size));
            }
        }

        

        public void draw()
        {
            Vector2i MouseCoordinates = Mouse.GetPosition(Program.Window);
            if (Mouse.IsButtonPressed(MouseClickButton) && 
                MouseCoordinates.X > position.X && MouseCoordinates.X < position.X + size.X &&
                MouseCoordinates.Y > position.Y && MouseCoordinates.Y < position.Y + size.Y)
            {
                isPressed = true;
            }
            else
            {
                if(isPressed)
                {
                    isPressed = false;
                    ButtonPressedUpHandler?.Invoke(this);
                }
            }

            if (isPressed)
            {
                if (isButtonRect)
                {
                    rectangle.Position = new Vector2f(position.X + borderSize, position.Y + borderSize);
                    Text.Position = new Vector2f(position.X + borderSize * 4, position.Y + borderSize * 4);
                }
                else if (isButtonSprite)
                {
                    sprite.Position = new Vector2f(position.X + borderSize, position.Y + borderSize);
                    Text.Position = new Vector2f(position.X + borderSize * 4, position.Y + borderSize * 4);
                }
            }
            else
            {
                if (isButtonRect)
                {
                    rectangle.Position = new Vector2f(position.X, position.Y);
                    Text.Position = new Vector2f(position.X + borderSize * 3, position.Y + borderSize * 3);
                }
                else if (isButtonSprite)
                {
                    sprite.Position = new Vector2f(position.X, position.Y);
                    Text.Position = new Vector2f(position.X + borderSize * 3, position.Y + borderSize * 3);
                }
            }

            Program.Window.Draw(borderRectangle);
            if (isButtonRect)
                Program.Window.Draw(rectangle);
            else if (isButtonSprite)
                Program.Window.Draw(sprite);
            Program.Window.Draw(Text);

        }


        /*private Vector2f position;
        private Vector2f size;
        private Vector2f normal;
        private Vector2i textureSize;
        private Vector2i textureStart;
        private Color buttonColor;
        private Color borderColor;
        private bool borderSet = false;
        private bool buttonTextureEnabled = false;
        private bool borderTextureEnabled;
        private bool inside = true;
        private float borderSize = 0;
        private Texture buttonTexture;
        private Sprite buttonSprite;
        private Mouse.Button mouseClickButton;

        public Button(Vector2f pos, Vector2f sizes)
        {
            position = pos;
            size = sizes;
        }

        public Color ButtonColor
        {
            set
            {
                buttonColor = value;
                buttonTextureEnabled = false;
            }
        }

        public void setButtonTexture(string name, Vector2i place, Vector2i siz)
        {
            textureSize = siz; 
            textureStart = place;
            buttonTexture = new Texture(name);
            buttonSprite = new Sprite(buttonTexture);
            buttonTextureEnabled = true;
        }

        public float BorderSize
        {
            set
            {
                borderSize = (value % 2 != 0) ? value + 1 : value;
                borderSet = true;
            }
        }

        public void setBorderColor(Color col)
        {
            borderColor = col;
            borderSet = true;
        }

        public void setMouseClickButton(Mouse.Button click)
        {
            mouseClickButton = click;
        }

        public bool _draw()
        {
            if (inside) 
                normal = size;
            if (size.X > textureSize.X || size.Y > textureSize.Y)
            {
                size.X = textureSize.X;
                size.Y = textureSize.Y;
            }
            if (!borderSet && !buttonTextureEnabled)
            {
                RectangleShape button = new RectangleShape(size)
                {
                    Position = position,
                    FillColor = buttonColor
                };
                Program.Window.Draw(button);
            }
            if (!borderSet && buttonTextureEnabled)
            {
                buttonSprite.Position = position;
                Program.Window.Draw(buttonSprite);
            }
            if (borderSet && !buttonTextureEnabled)
            {
                Vector2f BorderVecSize = new Vector2f(borderSize, borderSize);
                Vector2f BorderVecPos = new Vector2f(borderSize / 2, borderSize / 2);

                RectangleShape button = new RectangleShape(size - BorderVecSize);
                button.Position = position + BorderVecPos;
                button.FillColor = buttonColor;

                RectangleShape border = new RectangleShape(size);
                border.Position = position;
                border.FillColor = borderColor;

                Program.Window.Draw(border);
                Program.Window.Draw(button);
            }
            if (borderSet && buttonTextureEnabled)
            {
                buttonSprite.TextureRect = new IntRect(textureStart.X, textureStart.Y, (int)(size.X - borderSize), (int)(size.Y - borderSize));
                buttonSprite.Position = new Vector2f(position.X + borderSize / 2, position.X + borderSize / 2);

                RectangleShape border = new RectangleShape(normal);
                border.Position = (position);
                border.FillColor = (borderColor);


                RectangleShape mask = new RectangleShape(new Vector2f(normal.X -borderSize, normal.Y - borderSize));
                mask.Position = new Vector2f(position.X + borderSize / 2, position.X + borderSize / 2);
                mask.FillColor = (Color.Black);
                inside = false;

                Program.Window.Draw(border);
                Program.Window.Draw(mask);
                Program.Window.Draw(buttonSprite);
            }

            Vector2i MouseCoords = Mouse.GetPosition(Program.Window);
            Vector2u WinSize = Program.Window.Size;
            if (MouseCoords.X <= WinSize.X && MouseCoords.Y <= WinSize.Y && MouseCoords.X >= position.X && MouseCoords.X <= position.X + normal.X && MouseCoords.Y >= position.Y && MouseCoords.Y <= position.X + normal.Y && Mouse.IsButtonPressed(mouseClickButton))
            {
                return true;
            }
            else return false;
        }*/


    };
}
