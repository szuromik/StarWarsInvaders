namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public enum EnemyType
    {
        Easy, Medium, Hard
    }

    public class Enemy
    {
        private Rect shape;
        private List<Bullet> bullets;
        private Point enemyPoint;
        private Random random = new Random();
        private EnemyType type;
        private int lifeScore;
        private bool directionRight;
        private bool directionLeft;
        public int param;

        public Enemy(double x, double y, EnemyType type)
        {
            this.enemyPoint = new Point(x, y);
            this.bullets = new List<Bullet>();
            this.type = type;
            if (this.type == EnemyType.Easy)
            {
                this.shape = new Rect(x, y, 60, 90);
                this.lifeScore = 2;
            }
            else if (this.type == EnemyType.Medium)
            {
                this.shape = new Rect(x, y, 30, 75);
                this.lifeScore = 5;
            }
            else
            {
                this.shape = new Rect(x, y, 70, 105);
                this.lifeScore = 10;
            }

            this.param = 20;
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

        public Point EnemyPoint
        {
            get
            {
                return this.enemyPoint;
            }

            set
            {
                this.enemyPoint = value;
            }
        }

        public Rect Shape
        {
            get
            {
                return this.shape;
            }

            set
            {
                this.shape = value;
            }
        }

        public EnemyType Type
        {
            get
            {
                return this.type;
            }
        }

        public int LifeScore
        {
            get
            {
                return this.lifeScore;
            }

            set
            {
                this.lifeScore = value;
            }
        }

        public void Move()
        {
            if (this.type == EnemyType.Easy)
            {
                this.enemyPoint.Y += 60;
                this.shape.Y += 60;
            }
            else
            {
                if (!this.directionLeft && !this.directionRight)
                {
                    if (this.random.Next(0, 2) == 0)
                    {
                        this.directionLeft = true;
                    }
                    else
                    {
                        this.directionRight = true;
                    }
                }

                if (this.directionRight)
                {
                    if (this.enemyPoint.X > 500)
                    {
                        this.directionRight = false;
                        this.directionLeft = true;
                    }
                    else
                    {
                        this.enemyPoint.X += this.param;
                        this.shape.X += this.param;
                    }
                }
                else
                {
                    if (this.enemyPoint.X < 0)
                    {
                        this.directionRight = true;
                        this.directionLeft = false;
                    }
                    else
                    {
                        this.enemyPoint.X -= this.param;
                        this.shape.X -= this.param;
                    }
                }
            }
        }

        public void Shoot()
        {
            int damageLevel = 1;
            if (this.type != EnemyType.Easy)
            {
                this.bullets.Add(new Bullet(new Point(this.enemyPoint.X + (this.shape.Width / 2), this.enemyPoint.Y + this.shape.Height), BulletType.Imperial, damageLevel));
            }
        }
    }
}