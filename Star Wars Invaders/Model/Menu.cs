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
                case 0: this.isMenuInactive = true; break;
                case 3: this.exit = true; break;
            }
        }
    }
}
