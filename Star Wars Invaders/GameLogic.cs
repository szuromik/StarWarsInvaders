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
        public Player Kristof // represent one Player
        {
            get
            {
                return this.kristof;
            }

            set
            {
                this.kristof = value;
            }
        }

        public void Init()
        {
            this.kristof = new Player(683, 600);
        }

        public void Move(System.Windows.Input.Key pressed)
        {
            if (pressed == System.Windows.Input.Key.Left)
            {
                this.Kristof.Move(-5);
            }

            if (pressed == System.Windows.Input.Key.Right)
            {
                this.Kristof.Move(5);
            }
        }
    }
}
