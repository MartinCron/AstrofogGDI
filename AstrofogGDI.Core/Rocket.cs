using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AstrofogGDI.Core
{
    public class Rocket: SpaceItem
    {
        public static Rocket Create(Field field)
        {
            return new Rocket(field);
        }

        private bool isDead;
        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }


        private Rocket  (Field field)
        {
            this.field = field;
            //place in the exact center, to start
            this.y_pos = (field.Height - field.Top) / 2;
            this.x_pos = (field.Width - field.Left) / 2;
            this.Radius = 10;
        }
        public override void Collide(SpaceItem item)
        {
            this.DrawColor = Color.Red;
        
            Console.Beep();
        }

        public Bullet Fire()
        {

            Bullet b = Bullet.Create(this);
            b.Thrust();
            return b;
        }

        public override System.Drawing.Point[] EdgePoints
        {
            get
            {
                if (edgePoints != null)
                {
                    return edgePoints;
                }
                Point[] rocketPoints = new Point[3];
                rocketPoints[0] = new Point(-5, -10);
                rocketPoints[1] = new Point(0, 10);
                rocketPoints[2] = new Point(5, -10);
                edgePoints = rocketPoints;
                return edgePoints;
            }
        }
    }
}
