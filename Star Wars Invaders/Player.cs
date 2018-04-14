namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public class Player
    {
        public Rect playerRect;
        private Point playerPoint;

        public Player()
        {
            this.playerPoint = new Point(200, 200);
            this.playerRect = new Rect(this.PlayerPoint.X, this.PlayerPoint.Y, 60, 100);
        }

        public Rect PlayerRect
        {
            get
            {
                return this.playerRect;
            }

            set
            {
                this.playerRect = value;
            }
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

        public void Move(int value)
        {
            this.playerPoint.X += value;
            //this.playerRect = new Rect(this.PlayerPoint.X, this.playerPoint.Y, 60, 100);
        }
    }
}
