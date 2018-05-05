namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public enum EnemyType /// ellenség típust reprezentál
    {
        Easy, Medium, Hard
    }

    public class Enemy /// Ellenség osztály. publikus láthatóságú
    {
        private Rect shape; /// Ellenseg formát reprezentál
        private List<Bullet> bullets; /// Ellenség lövedékei
        private Point enemyPoint; /// ellenség kezdőpont
        private Random random = new Random(); /// Segítő random szám
        private EnemyType enemytype; /// Ellenség típust reprezentál
        private int lifeScore; /// életpontot mutat
        private bool directionRight; /// Jobbra tart-e? segéd bool
        private bool directionLeft; /// balra tart-e? Segéd bool

        public Enemy(double x, double y, EnemyType type) /// Ellenség konstruktor
        {
            this.enemyPoint = new Point(x, y);
            this.bullets = new List<Bullet>();
            this.enemytype = type;
            if (this.enemytype == EnemyType.Easy)
            {
                this.shape = new Rect(x, y, 60, 90);
                this.lifeScore = 2;
            }
            else if (this.enemytype == EnemyType.Medium)
            {
                this.shape = new Rect(x, y, 30, 75);
                this.lifeScore = 5;
            }
            else
            {
                this.shape = new Rect(x, y, 70, 105);
                this.lifeScore = 10;
            }
        }

        public List<Bullet> Bullets /// Ellenség lövedékeinek az írható olvasható tulajdonsága
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

        public Point EnemyPoint /// Kezdőpont tulajdonsága
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

        public Rect Shape /// rect olvasható írhatü tulajdonság
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

        public EnemyType EnemyType /// ellenség típus tulajdonság írható és olvasható
        {
            get
            {
                return this.enemytype;
            }
        }

        public int LifeScore /// életpont tulajdonság
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

        public void Move() /// ellenséget mozgatja
        {
            if (this.enemytype == EnemyType.Easy)
            {
                this.enemyPoint.Y += 20;
                this.shape.Y += 20;
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
                        this.enemyPoint.X += 15;
                        this.shape.X += 15;
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
                        this.enemyPoint.X -= 15;
                        this.shape.X -= 15;
                    }
                }
            }
        }

        public void Shoot() /// Ellenség lövése
        {
            int damageLevel = 1;
            if (this.enemytype != EnemyType.Easy)
            {
                this.bullets.Add(new Bullet(new Point(this.enemyPoint.X + (this.shape.Width / 2), this.enemyPoint.Y + this.shape.Height), BulletType.Imperial, damageLevel));
            }
        }
    }
}