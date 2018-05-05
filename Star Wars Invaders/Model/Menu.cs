namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static System.Net.Mime.MediaTypeNames;

    public class Menu /// egy menüt reprezentáló publikus láthatóságú osztály
    {
        private List<string> menuElements; /// stringeből álló menürendszer
        private bool isMenuInactive; /// menü aktiív-e
        private int choosenMenuElement; /// kiválasztott menüpont
        private bool exit; /// Kilépést detektál
        private bool leaderBoardActive; /// Nyitható-e a ranglista ablak
        private bool controlMenuElementActive; /// Ha ez be van kapcsolva akkor kirajzolja az onrender a irányítás menüpontot
        private bool gameActive; /// ha a játék még nem lett elindítva akkor ez false

        public Menu() /// beállító konstruktor
        {
            this.menuElements = new List<string>();
            this.menuElements.Add("Indítás");
            this.menuElements.Add("Játékleírás");
            this.menuElements.Add("Ranglista");
            this.menuElements.Add("Kilépés");
            this.ChoosenMenuElement = 0;
        }

        public List<string> MenuElements /// tulajdonsága a menüelemeknek
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

        public bool IsMenuInactive /// menüaktivitás bool
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

        public int ChoosenMenuElement /// kiválasztott menüpont bool
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

        public bool Exit /// kilépést detektáló bool
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

        public bool LeaderBoardActive /// nyitható-e a ranglista bool
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

        public bool ControlMenuElementActive /// irányító menü rajzolható-e bool
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

        public bool GameActive /// játék aktivitását reprezentáló bool
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

        public void MenuDown() /// menüben lefelé léptetés
        {
            if (this.choosenMenuElement + 1 < this.menuElements.Count)
            {
                this.choosenMenuElement++;
            }
        }

        public void MenuUp() /// menüben felfelé léptetés
        {
            if (this.choosenMenuElement - 1 > -1)
            {
                this.choosenMenuElement--;
            }
        }

        public void ChooseMenuElement() /// menüléptetés kezelése
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
