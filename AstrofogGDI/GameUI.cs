using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AstrofogGDI.Core;

namespace AstrofogGDI
{
    public partial class GameUI : Form
    {

        private Rocket rocketItem;
        private List<SpaceItem> asteroidCollection = new List<SpaceItem>();
        private List<SpaceItem> bulletCollection = new List<SpaceItem>();
        private List<SpaceItem> starCollection = new List<SpaceItem>();
        private long Score;
        private long HighScore;
        private int Lives;
        private int CurrentWaveSize;
        private int CurrentWaveCount;
        private const int MAX_WAVE_SIZE = 50;
        protected bool IsPaused;
        protected bool IsGameOn;
        private const int MAX_BULLETS = 20;
        private Field field;
        private int Wave;



        public GameUI()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
        }

        protected int GetBrightnes(SpaceItem item)
        {
            int distance = item.GetDistance(rocketItem);
            int brightness = 100 - (int)(distance / 3.5);
            if (brightness < 0)
            {
                brightness = 0;
            }
            return brightness;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (this.IsGameOn)
            {
                const int MAX_BRIGHTNESS = 100;
                if (!rocketItem.IsDead)
                {
                    DrawSpaceItem(e.Graphics, rocketItem, rocketItem.field, MAX_BRIGHTNESS);
                }
                foreach (Asteroid asteroid in this.asteroidCollection)
                {
                    int brightness = GetBrightnes(asteroid);
                    if (brightness > 2)
                    {
                        DrawSpaceItem(e.Graphics, asteroid, asteroid.field, brightness);
                    }
                }

                foreach (Bullet b in this.bulletCollection)
                {
                    DrawSpaceItem(e.Graphics, b, b.field, MAX_BRIGHTNESS);
                }

                Random rand = new Random();

                foreach (Star s in this.starCollection)
                {
                    int brightness = GetBrightnes(s);
                    int twinkle_factor = rand.Next(-50, 0);
                    brightness += twinkle_factor;
                    if (brightness > 100)
                    {
                        brightness = 100;
                    }
                    if (brightness > 2)
                    {
                        DrawSpaceItem(e.Graphics, s, s.field, brightness);
                    }
                }

                int TextBuffer = 25;
                int LivesPosition = TextBuffer;
                int ScorePosition = (int)((double)this.Width * .2);
                int HighScorePosition = (int)((double)this.Width * .4);
                int WavePosition = (int)((double)Width * .6);
                int AsteroidCountPosition = (int)((double)this.Width * .8);
                this.DrawMessage(e.Graphics, LivesPosition, "Lives: " + this.Lives.ToString(), MAX_BRIGHTNESS);
                this.DrawMessage(e.Graphics, ScorePosition, "Score: " + this.Score.ToString(), MAX_BRIGHTNESS);
                this.DrawMessage(e.Graphics, HighScorePosition, "High Score: " + this.HighScore.ToString(), MAX_BRIGHTNESS);
                this.DrawMessage(e.Graphics, WavePosition, "Wave: " + this.Wave.ToString(), MAX_BRIGHTNESS);
                this.DrawMessage(e.Graphics, AsteroidCountPosition, "Asteroids: " + this.asteroidCollection.Count.ToString(), MAX_BRIGHTNESS);
            }
        }

        private void DrawMessage(Graphics g, int X_position, string Message, int brightness)
        {
            Font fnt = new Font("OCR A Extended", 10);
            Point pnt = new Point(X_position,  25);

            g.DrawString(Message, fnt, Brushes.Wheat, pnt);

        }
        private void DrawSpaceItem(Graphics g, SpaceItem item, Field field, int brightness)
        {
            double scale = brightness / 100.0;
            int newRed = (int)(item.ItemColor.R * scale);
            int newGreen = (int)(item.ItemColor.G * scale);
            int newBlue = (int)(item.ItemColor.B * scale);

            Color penColor = Color.FromArgb(newRed, newGreen, newBlue);
            Pen pen = new Pen(penColor);

            Point[] points = item.EdgePoints;
            Point[] relativePoints = getRelativePoints(points, item);
            Point[] rotatedPoints = getRotatedPoints(relativePoints, item);

            g.DrawLines(pen, rotatedPoints);
        }

        private Point[] getRotatedPoints(Point[] points, SpaceItem item)
        {
            Point[] rotatedPoints = new Point[points.Length];
            for (int index = 0; index < points.Length; index++)
            {
                rotatedPoints[index] = rotatePoint(points[index], item);
            }
            return rotatedPoints;
        }

        private Point rotatePoint(Point point, SpaceItem item)
        {
            Point rotated = new Point();
            Point origin = new Point(item.X, item.Y);
            double radians = item.Rotation / 57.32;

            rotated.X = origin.X + (int)(Math.Cos(radians) * (point.X - origin.X) - 
                Math.Sin(radians) * (point.Y - origin.Y) );

            rotated.Y = origin.Y + (int)(Math.Sin(radians) * (point.X - origin.X) +
                Math.Cos(radians) * (point.Y - origin.Y));

            return rotated;
        }

        private Point[] getRelativePoints(Point[] points, SpaceItem item)
        {
            Point[] adjustedPoints = new Point[points.Length];
            for (int index = 0; index < points.Length; index++)
            {
                adjustedPoints[index] = new Point(points[index].X + item.X, points[index].Y + item.Y);
            }
            return adjustedPoints;
        }


        private void HandleKeyInput()
        {
            if (Keyboard.IsKeyDown(Keys.F2))
            {
                this.StartGame();
            }

            if (this.IsGameOn)
            {
                if (Keyboard.IsKeyDown(Keys.P))
                {
                    this.IsPaused = !this.IsPaused;
                }

                if (Keyboard.IsKeyDown(Keys.Up))
                {
                    rocketItem.Thrust();
                }

                if (Keyboard.IsKeyDown(Keys.Down))
                {
                    rocketItem.Brake();
                }

                if (Keyboard.IsKeyDown(Keys.Left))
                {
                    rocketItem.Rotate(-5);
                }

                if (Keyboard.IsKeyDown(Keys.Right))
                {
                    rocketItem.Rotate(5);
                }


                if (Keyboard.IsKeyDown(Keys.Space))
                {
                    if (bulletCollection.Count < MAX_BULLETS)
                    {
                        if (!this.rocketItem.IsDead)
                        {
                            bulletCollection.Add(this.rocketItem.Fire());
                        }
                    }
                }

            }

            if (Keyboard.IsKeyDown(Keys.Escape))
            {
                Application.Exit();
            }
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            HandleKeyInput();
            if (IsGameOn)
            {
                if (IsPaused)
                {
                    this.messageLabel.Visible = true;
                    this.messageLabel.Text = "paused";
                }
                else
                {
                    this.messageLabel.Visible = false;
                    rocketItem.Move();

                    foreach (Asteroid asteroid in this.asteroidCollection)
                    {
                        asteroid.Rotate(1);
                        asteroid.Move();
                    }

                    List<SpaceItem> deadBullets = new List<SpaceItem>();
                    List<SpaceItem> deadAsteroids = new List<SpaceItem>();

                    foreach (Bullet b in this.bulletCollection)
                    {
                        if (b.IsDead())
                        {
                            deadBullets.Add(b);
                        }

                        List<SpaceItem> newAsteroids = null;
                        foreach (Asteroid asteroid in asteroidCollection)
                        {
                            if (b.CheckCollision(asteroid))
                            {
                                newAsteroids = asteroid.Hit();
                                this.Score = this.Score + 50 / asteroid.Radius;
                                if (this.Score > this.HighScore)
                                {
                                    this.HighScore = this.Score;
                                }
                                deadAsteroids.Add(asteroid);
                                deadBullets.Add(b);
                            }
                        }
                        if (newAsteroids != null)
                        {
                            foreach (Asteroid a in newAsteroids)
                            {
                                asteroidCollection.Add(a);
                            }
                        }
                        b.Move();
                    }

                    foreach (SpaceItem asteroid in asteroidCollection)
                    {
                        //only check if we're still alive
                        if (!this.rocketItem.IsDead)
                        {
                            if (asteroid.CheckCollision(this.rocketItem))
                            {
                                //this.rocketItem = Rocket.Create(this.field);
                                this.rocketItem.IsDead = true;
                                this.Lives = this.Lives - 1;
                            }
                        }
                    }

                    foreach (SpaceItem deadBullet in deadBullets)
                    {
                        this.bulletCollection.Remove(deadBullet);
                    }

                    foreach (SpaceItem deadAsteroid in deadAsteroids)
                    {
                        this.asteroidCollection.Remove(deadAsteroid);
                    }

                    this.Invalidate();
                }
            }
        }



        private void StartGame()
        {
            this.Wave = 1;
            this.messageLabel.Visible = false;
            this.messageLabel.Top = this.Height / 2;
            this.messageLabel.Left = this.Width / 2;
            this.Lives = 3;
            this.Score = 0;

            const int PADDING = 25;
            this.field = Field.create(this.Top + PADDING, this.Left + PADDING, this.Height - PADDING, this.Width - PADDING);
            rocketItem = Rocket.Create(this.field);
            rocketItem.Radius = 10;


            const int ASTEROID_SIZE = 60;
            const int ASTEROID_COUNT = 7;
            
            CurrentWaveCount = ASTEROID_COUNT;
            this.CurrentWaveSize = ASTEROID_SIZE;
            this.CreateAsteroidWave(ASTEROID_COUNT, ASTEROID_SIZE);
            this.starCollection.Clear();
            this.bulletCollection.Clear();
            const int STAR_COUNT = 55;
            for (int i = 0; i < STAR_COUNT; i++)
            {
                Star star = Star.Create(this.field);
                starCollection.Add(star);
            }
            this.IsGameOn = true;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.IsGameOn = false;
            this.messageLabel.Visible = true;
            this.messageLabel.Text = "F2 to start";

            Cursor.Hide();
            this.HighScore = 500;
        }

        private void replacementTimer_Tick(object sender, EventArgs e)
        {
            if (this.IsGameOn)
            {
                if (this.asteroidCollection.Count == 0)
                {
                    this.Wave++;
                    CurrentWaveSize=CurrentWaveSize + 4;

                    if (CurrentWaveSize > MAX_WAVE_SIZE)
                    {
                        CurrentWaveSize = MAX_WAVE_SIZE;
                    }
                    CurrentWaveCount++;
                    CreateAsteroidWave(CurrentWaveCount, CurrentWaveSize);
                }
            }

            if (this.IsGameOn)
            {
                if (this.Lives == 0)
                {
                    this.IsGameOn = false;
                    this.messageLabel.Visible = true;
                    this.messageLabel.Text = "GAME OVER (f2 to start)";
                }
                else
                {
                    if (rocketItem.IsDead)
                    {
                        const int SAFE_DISTANCE = 80;
                        bool isSafeToMaterialize = true;
                        foreach (Asteroid a in this.asteroidCollection)
                        {
                            if (a.GetDistance(rocketItem) < SAFE_DISTANCE)
                            {
                                isSafeToMaterialize = false;
                            }
                        }
                        if (isSafeToMaterialize)
                        {
                            this.rocketItem = Rocket.Create(this.field);
                            rocketItem.IsDead = false;
                        }
                    }
                }
            }
        }

        private void CreateAsteroidWave(int AsteroidCount, int AsteroidSize)
        {
            this.asteroidCollection.Clear();
            Random rand = new Random();
            const int SAFE_DISTANCE = 100;
            for (int i = 0; i < AsteroidCount; i++)
            {
                bool hasBeenPlaced = false;
                while (!hasBeenPlaced)
                {
                    Asteroid asteroid = Asteroid.Create(this.field);
                    if (asteroid.GetDistance(this.rocketItem) >= SAFE_DISTANCE)
                    {
                        asteroid.Radius = AsteroidSize;
                        asteroid.Rotate(rand.Next(0, 360));
                        asteroid.Thrust();
                        asteroid.Thrust();
                        asteroidCollection.Add(asteroid);
                        hasBeenPlaced = true;
                    }
                }
            }
        }
    }
}