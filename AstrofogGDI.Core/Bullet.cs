using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AstrofogGDI.Core
{
    public class Bullet: SpaceItem
    {
        public static Bullet Create(SpaceItem firedFrom)
        {
            return new Bullet(firedFrom);
        }
        private SpaceItem firedFrom;
        public override double Base_Speed
        {
            get
            {
                return 3.5;
            }
        }

        public override double Max_Speed
        {
            get
            {
                return 50;
            }
        }
        public bool IsDead()
        {
            return (this.bulletAge >= MAX_BULLET_AGE);
        }


        private Bullet(SpaceItem firedFrom)
        {
            //to used in friendly-fire collision detection
            this.firedFrom=firedFrom;

            this.field = firedFrom.field;
            this._rotation = firedFrom.Rotation;
            this.Thrust();

            //add in the inertia of the thing I was fired from
            //makes the physics look more realistic
            this.x_speed = this.x_speed + firedFrom.x_speed;
            this.y_speed = this.y_speed + firedFrom.y_speed;


            this.x_pos = firedFrom.X;
            this.y_pos = firedFrom.Y;

            //place in the exact center, to start
            this.Radius = 3;
        }

        private const int MAX_BULLET_AGE=40;
        private int bulletAge =0;
        public override System.Drawing.Point[] EdgePoints
        {
            get
            {
                if (edgePoints != null)
                {
                    return edgePoints;
                }
                Point[] rocketPoints = new Point[2];
                rocketPoints[0] = new Point(0, 0);
                rocketPoints[1] = new Point(1, 1);

                edgePoints = rocketPoints;
                return edgePoints;
            }
        }
        public override void Move()
        {
            if (this.bulletAge < MAX_BULLET_AGE)
            {
                this.bulletAge++;
                base.Move();
            }
        }
    }
}
