using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AstrofogGDI.Core
{
    public class Asteroid: SpaceItem
    {
        private static Random rand = new Random();
        public List<SpaceItem> Hit()
        {
            List<SpaceItem> retVal = new List<SpaceItem>();
            const int CHILD_ASTEROID_COUNT = 2;
            const double MIN_ASTEROID_SIZE = 5;
            const double SIZE_REDUCTION_FACTOR = 1.5; 

            for (int i = 0; i < CHILD_ASTEROID_COUNT; i++)
            {
                if( (double)(this.radius / SIZE_REDUCTION_FACTOR) >= MIN_ASTEROID_SIZE) {
                    Asteroid newAsteroid = Asteroid.Create(field);
                    newAsteroid.x_pos = this.x_pos;
                    newAsteroid.y_pos = this.y_pos;

                    newAsteroid.Radius =(int) ( (double)this.radius / SIZE_REDUCTION_FACTOR );
                    newAsteroid.Rotate(rand.Next(0, 360));
                    newAsteroid.Thrust();
                    newAsteroid.Thrust();

                    retVal.Add(newAsteroid);
                }
            }
            return retVal;
        }

        public static Asteroid Create(Field field)
        {
            return new Asteroid(field);
        }
        public override void Move()
        {
            base.Move();
        }

        public override double Max_Speed
        {
            get
            {
                return 2;
            }
        }

        public override double Base_Speed
        {
            get
            {
                return rand.Next(1,3);
            }
        }

        private Asteroid(Field field)
        {
            this.field = field;
            //place in the exact center, to start
            this.y_pos = rand.Next(field.Left, field.Width);
            this.x_pos = rand.Next(field.Top, field.Height);
        }

        public override System.Drawing.Point[] EdgePoints
        {
            get
            {
                {
                    if (edgePoints != null)
                    {
                        return edgePoints;
                    }
                    const double FULL_CIRCLE = 6.28;
                    int count = Randomizer.GetInstance().Next(14, 16);
                    Point[] retVal = new Point[count];

                    double incrementInterval = FULL_CIRCLE / count;
                    double rads = 0;

                    for (int index = 0; index < count; index++)
                    {
                        retVal[index] = getRandomPoint(this.Radius, rads);
                        rads = rads + incrementInterval;
                    }

                    //set the start and end points to be the same
                    retVal[count - 1].X = retVal[0].X;
                    retVal[count - 1].Y = retVal[0].Y;

                    edgePoints = retVal;
                    return retVal;
                }
            }
        }
        private Point getRandomPoint(int AverageRadius, double radians)
        {
            double size = Randomizer.GetInstance().NextDouble();
            double newRadius = AverageRadius + (AverageRadius * size);
            double x = Math.Sin(radians) * newRadius;
            double y = Math.Cos(radians) * newRadius;
            return new Point((int)x, (int)y);
        }
    }

}
