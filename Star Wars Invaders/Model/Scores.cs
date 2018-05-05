namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Scores /// Pontot reprezentáló publikus láthatóságú osztály
    {
        private string name; /// rekorder neve
        private int score; /// rekorder pontja

        public Scores(string name, int score) /// beállító konstruktor
        {
            this.name = name;
            this.score = score;
        }

        public string Name /// tulajdonság a névnek
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public int Score /// tulajdonság a pontnak
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
    }
}
