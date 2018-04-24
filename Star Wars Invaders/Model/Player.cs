namespace Star_Wars_Invaders
{
    using System.Windows;
    public class Player
    {
        private Point playerPoint;

        public Player(double x, double y)
        {
            this.playerPoint = new Point(x, y);
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
        }
    }
}
