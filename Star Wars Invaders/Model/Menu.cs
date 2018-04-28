namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Menu
    {
        private List<string> menuElements;
        private bool isMenuInactive;

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

        public Menu()
        {
            this.menuElements = new List<string>();
            this.menuElements.Add("Indítás");
            this.menuElements.Add("Játékleírás");
            this.menuElements.Add("Ranglista");
            this.menuElements.Add("Kilépés");
        }
    }
}
