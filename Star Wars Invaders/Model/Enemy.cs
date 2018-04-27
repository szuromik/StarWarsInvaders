namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public class Enemy
    {
        // Need a location Point
        // Need a bullet List
        // Need Move method
        // Need a shoot method
        private Rect shape;
        private List<Bullet> bullets;
        private Point enemyPoint;

        public Enemy(double x, double y)
        {
            this.enemyPoint = new Point(x, y);
            this.bullets = new List<Bullet>();
            this.shape = new Rect(x, y, 20, 20);
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
    }
}
