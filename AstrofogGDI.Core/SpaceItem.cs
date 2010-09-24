using System;
using System.Drawing;

namespace AstrofogGDI.Core
{
    public abstract class SpaceItem
    {
        protected Point[] edgePoints = null;
        protected int radius;
        public virtual double Base_Speed
        {
            get
            {
                return .75;
            }
        }
        public virtual Color ItemColor
        {
            get {
                return Color.White;
            }
        }
        public virtual double Max_Speed
        {
            get{
                return 10;
            }
        }

        public int GetDistance(SpaceItem otherItem)
        {
            int x_gap = Math.Abs(this.X - otherItem.X);
            int y_gap = Math.Abs(this.Y - otherItem.Y);
            return (int)Math.Sqrt((x_gap * x_gap) + (y_gap * y_gap));
        }
        public bool CheckCollision(SpaceItem otherItem)
        {
            int distance = GetDistance(otherItem);
            if (distance <= this.radius + otherItem.Radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public virtual void Collide(SpaceItem item)
        {

        }

        protected Color drawColor = Color.White;
        public virtual Color DrawColor
        {
            get { return drawColor; }
            set { drawColor = value; }
        }
        
        
        public virtual int Radius
        {
            get { return radius; }
            set { radius = value;  }
        }
    
        public virtual Point[] EdgePoints{
            get{
                return edgePoints;
            }
        }

        public Field field;

        protected int x_pos;
        protected int y_pos;
        internal double x_speed=0;
        internal double y_speed=0;
        public double _rotation = 0;

        public int X
        {
            get{return x_pos;}
        }

        public int Y
        {
            get { return y_pos; }
        }


        public double Rotation
        {
            get
            {
                return _rotation;
            }
        }

        public virtual void Move()
        {
            x_pos = Convert.ToInt32(x_pos + x_speed);
            y_pos = Convert.ToInt32(y_pos + y_speed);
            HandleFieldEdges();
        }


        public virtual void Thrust()
        {
            double new_x_speed = x_speed - (Math.Sin(toRadians(Rotation)) * Base_Speed);
            double new_y_speed = y_speed + (Math.Cos(toRadians(Rotation)) * Base_Speed);

            if (Math.Abs(new_x_speed) < this.Max_Speed)
            {
                x_speed = new_x_speed;
            }

            if (Math.Abs(new_y_speed) < this.Max_Speed)
            {
                y_speed = new_y_speed;
            }
        }

        public void Brake()
        {
            const double BRAKE_FACTOR = 1.1;
            x_speed = x_speed / BRAKE_FACTOR;
            y_speed = y_speed / BRAKE_FACTOR;
        }
   
        public void Rotate(int degreesToRotate)
        {
            const int MAX_DEGREES=360;
            const int MIN_DEGREES=-360;
            _rotation = _rotation + degreesToRotate;
            if (_rotation > MAX_DEGREES)
            {
                _rotation = _rotation - MAX_DEGREES;
            }

            if (_rotation < MIN_DEGREES)
            {
                _rotation = _rotation - MIN_DEGREES;
            }
        }

        protected void HandleFieldEdges()
        {
            const int buffer = 30;
            if (x_pos > this.field.Width + buffer)
            {
                x_pos = this.field.Left;
            }

            if (x_pos < this.field.Left - buffer)
            {
                x_pos = this.field.Width;
            }

            if (y_pos > this.field.Height + buffer)
            {
                y_pos = this.field.Top;
            }

            if (y_pos < this.field.Top - buffer)
            {
                y_pos = this.field.Height;
            }
        }
        protected double toRadians(double degrees)
        {
            //return degrees;
            return degrees / 57.32;
        }

    }
}
