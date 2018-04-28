namespace Star_Wars_Invaders
{
    using System.Collections.Generic;
    using System.Windows;

    public class Player
    {
        private List<Bullet> bullets;
        private Point playerPoint;
        private BulletType actualType;
        private Rect shape;
        private int score;

        public Player(double x, double y)
        {
            this.playerPoint = new Point(x, y);
            this.Bullets = new List<Bullet>();
            this.actualType = BulletType.Simple;
            this.shape = new Rect(x, y, 50, 50);
            this.score = 0;
        }

        public Point PlayerPoint
        {
            get
            {
                return this.playerPoint;
            }

            set
            {
                this.playerPoint = value;
            }
        }

        public List<Bullet> Bullets
        {
            get
            {
                return this.bullets;
            }

            set
            {
                this.bullets = value;
            }
        }

        public BulletType ActualType
        {
            get
            {
                return this.actualType;
            }

            set
            {
                this.actualType = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            set
            {
                this.score = value;
            }
        }

        public void Move(int value)
        {
            this.playerPoint.X += value;
            this.shape.X += value;
        }

        public void Shoot()
        {
            this.bullets.Add(new Bullet(new Point(this.PlayerPoint.X + 30, this.PlayerPoint.Y), this.actualType));
        }

        public void ChangeWeapon()
         {
             if (this.actualType == BulletType.Laser)
            {
                this.actualType = BulletType.Simple;
            }
            else if (this.actualType == BulletType.Simple)
            {
                this.actualType = BulletType.Laser;
            }
        }
    }
}
