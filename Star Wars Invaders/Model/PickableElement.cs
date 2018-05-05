namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public enum PickableElementType /// felvehető elem enum
    {
        Life, Immortal
    }

    public class PickableElement /// Felvehető elemet reprezentáló osztály
    {
        private Point location;
        private Rect shape;
        private PickableElementType pickType;

        public PickableElement(double x, double y, PickableElementType pickType) /// felvehető elem konstruktora
        {
            this.location = new Point(x, y);
            this.shape = new Rect(x, y, 40, 40);
            this.pickType = pickType;
        }

        public Point Location /// reprezántlja a kezdő pont tulajdonságát
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

        public Rect Shape /// reprezentálja a felvehető elem alakjának a tulajdonságát
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

        public PickableElementType PickType /// olvasható írható tulajdonság a felvehető elem típusához
        {
            get
            {
                return this.pickType;
            }

            set
            {
                this.pickType = value;
            }
        }

        public void Move() /// Ez mozgatja a felvehető elemet
        {
            this.location.Y += 5;
            this.shape.Y += 5;
        }
    }
}
