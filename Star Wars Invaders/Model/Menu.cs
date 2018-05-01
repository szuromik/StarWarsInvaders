namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Net.Mime.MediaTypeNames;

    public class Menu
    {
        private List<string> menuElements;
        private bool isMenuInactive;
        private int choosenMenuElement;
        private bool exit;
        private bool leaderBoardActive;
        private bool controlMenuElementActive;
        private bool gameActive;

        public Menu()
        {
            this.menuElements = new List<string>();
            this.menuElements.Add("Indítás");
            this.menuElements.Add("Játékleírás");
            this.menuElements.Add("Ranglista");
            this.menuElements.Add("Kilépés");
            this.ChoosenMenuElement = 0;
        }

        public List<string> MenuElements
        {
            get
            {
                return this.menuElements;
            }

            set
            {
                this.menuElements = value;
            }
        }

        public bool IsMenuInactive
        {
            get
            {
                return this.isMenuInactive;
            }

            set
            {
                this.isMenuInactive = value;
            }
        }

        public int ChoosenMenuElement
        {
            get
            {
                return this.choosenMenuElement;
            }

            set
            {
                this.choosenMenuElement = value;
            }
        }

        public bool Exit
        {
            get
            {
                return this.exit;
            }

            set
            {
                this.exit = value;
            }
        }

        public bool LeaderBoardActive
        {
            get
            {
                return this.leaderBoardActive;
            }

            set
            {
                this.leaderBoardActive = value;
            }
        }

        public bool ControlMenuElementActive
        {
            get
            {
                return this.controlMenuElementActive;
            }

            set
            {
                this.controlMenuElementActive = value;
            }
        }

        public bool GameActive
        {
            get
            {
                return this.gameActive;
            }

            set
            {
                this.gameActive = value;
            }
        }

        public void MenuDown()
        {
            if (this.choosenMenuElement + 1 < this.menuElements.Count)
            {
                this.choosenMenuElement++;
            }
        }

        public void MenuUp()
        {
            if (this.choosenMenuElement - 1 > -1)
            {
                this.choosenMenuElement--;
            }
        }

        public void ChooseMenuElement()
        {
            switch (this.choosenMenuElement)
            {
                case 0: this.gameActive = true; break;
                case 1: this.controlMenuElementActive = true; break;
                case 2: this.leaderBoardActive = true; break;
                case 3: this.exit = true; break;
            }
        }
    }
}
