namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GameLogic
    {
        private Player kristof;
        private int screenHeight;
        private int screenWidth;

        public GameLogic()
        {
            this.kristof = new Player();
        }

        public Player Kristof
        {
            get
            {
                return kristof;
            }

            set
            {
                kristof = value;
            }
        }
    }
}
