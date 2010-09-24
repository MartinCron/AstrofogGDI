using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AstrofogGDI.Core
{
    public class Star: SpaceItem
    {
        private static Random rand = new Random();
        public static Star Create(Field field)
        {
            return new Star(field);
        }

        private Star(Field field)
        {
            this.field = field;
            this.x_pos = rand.Next(field.Left, field.Width);
            this.y_pos = rand.Next(field.Top, field.Height);
        }
        public override System.Drawing.Point[] EdgePoints
        {
            get
            {
                Point p1 = new Point(0, 0);
                Point p2 = new Point(1, 0);

                return new Point[]{p1, p2};
            }
        }
    }
}
