namespace Star_Wars_Invaders
{
    using System.Collections.Generic;
    using System.Windows;

    public class Player /// egy játékost reprezentáló osztály
    {
        private List<Bullet> bullets; /// játékos lövedékei
        private Point playerPoint; /// játékos kezdőpontja
        private BulletType actualType; // lövedék típusa
        private Rect shape; /// Játékost reprezentáló alakzat
        private int score; /// pontszámot reprenztál
        private int lifeScore; /// életpontot reprezentál
        private bool immortal; /// felvehető elemnél fontos ezzel állítjuk be hogy hallhatatlan

        public Player(double x, double y) /// konstruktor a játékosnak
        {
            this.playerPoint = new Point(x, y);
            this.Bullets = new List<Bullet>();
            this.actualType = BulletType.Simple;
            this.Shape = new Rect(x, y, 50, 50);
            this.score = 0;
            this.lifeScore = 10;
        }

        public Point PlayerPoint /// Tulajdonság a játékos kezdőpontjára
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

        public List<Bullet> Bullets /// Játékos lövedékei tulajdonság
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

        public BulletType ActualType /// Golyótípus tulajdonsága
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

        public int Score /// pontszám tulajdonsága
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

        public int LifeScore /// életpont tulajdonsága
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

        public Rect Shape /// játékos alakzatot reprenzentál
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

        public bool Immortal /// hallhatatlanság tulajdonsága
        {
            get
            {
                return this.immortal;
            }

            set
            {
                this.immortal = value;
            }
        }

        public void Move(int value) /// játékost mozgatása
        {
            this.playerPoint.X += value;
            this.shape.X += value;
        }

        public void Shoot() /// játékos lőv
        {
            int damageLevel = 1;
            this.bullets.Add(new Bullet(new Point(this.PlayerPoint.X + 30, this.PlayerPoint.Y), this.actualType, damageLevel));
        }

        public void ChangeWeapon() /// fegyvertcserél
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

        public void Damage(int value) /// sérül a játékost
        {
            if (!this.Immortal)
            {
                this.lifeScore -= value;
            }
            else
            {
                return;
            }
        }
    }
}
