using System;
using System.Collections.Generic;
using System.Text;

namespace AstrofogGDI.Core
{
    public class Field
    {
        private int top;
        private int left;
        private int height;
        private int width;

        public static Field create(int top, int left, int height, int width)
        {
            return new Field(top, left, height, width);
        }

        private Field(int top, int left, int height, int width)
        {
            this.top = top;
            this.height = height;
            this.left = left;
            this.width = width;
        }


        public int Top
        { get { return top; }}

        public int Left
        { get { return left; } }

        public int Height
        { get { return height; } }

        public int Width
        { get { return width; } }

    }
}
