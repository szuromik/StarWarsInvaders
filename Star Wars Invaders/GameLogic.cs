namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    public class GameLogic
    {
        private Player player;
        private Size size;
        private List<Bullet> bulletsToDelete;
        private List<Enemy> enemyList;
        private Random r = new Random();
        private List<Enemy> enemyToDelete;
        private Menu mainMenu;
        private bool gameOver;
        private List<Scores> playerScores;
        private double makeItDifficult;
        private bool leaderBoardOpen;
        private List<PickableElement> pickableElementCollection;
        private bool isPlayerImmortal;

        public GameLogic(Size size) // GameLogic konstruktor. Elsődleges paraméter a size ez alapján fogja a játékost példányosítani
        {
            this.Size = size;
            this.playerScores = new List<Scores>();
            this.ToStartState();
            this.ReadScore();
        }

        public Player Player // írható olvasható tulajdonság a játékoshoz
        {
            get
            {
                return this.player;
            }

            set
            {
                this.player = value;
            }
        }

        public List<Enemy> EnemyList // a pályán elhelyezkedő ellenségeket reprezentáló írható/olvasható tulajdonság
        {
            get
            {
                return this.enemyList;
            }

            set
            {
                this.enemyList = value;
            }
        }

        public Menu MainMenu // Egy menüt reprezentáló írható és olvasható tulajdonság
        {
            get
            {
                return this.mainMenu;
            }
        }

        public bool GameOver // Bool változó ami akkor lesz true ha az ellenfél megvan a pályán(elfogy az összes életpontja)
        {
            get
            {
                return this.gameOver;
            }

            set
            {
                this.gameOver = value;
            }
        }

        public Size Size // Ez reprezentálja a játéktérnek a méretét
        {
            get
            {
                return this.size;
            }

            set
            {
                this.size = value;
            }
        }

        public bool LeaderBoardOpen // Ha meghalunk a pályán akkor ez a változó true lesz, a főablak code behind-ba a következő ticknél megnyílik egy új ablak ahol be lehet írni magunkat a ranglistára
        {
            get
            {
                return this.leaderBoardOpen;
            }

            set
            {
                this.leaderBoardOpen = value;
            }
        }

        public List<Scores> PlayerScores
        {
            get
            {
                return this.playerScores;
            }

            set
            {
                this.playerScores = value;
            }
        }

        public List<PickableElement> PickableElementCollection
        {
            get
            {
                return this.pickableElementCollection;
            }

            set
            {
                this.pickableElementCollection = value;
            }
        }

        public bool IsPlayerImmortal
        {
            get
            {
                return this.player.Immortal;
            }

            set
            {
                this.player.Immortal = value;
            }
        }

        public void EnemyShoot() // ellenség lövése
        {
            foreach (Enemy enemy in this.EnemyList)
            {
                    enemy.Shoot();
            }
        }

        public void ToStartState() // Segédfüggvény. Nem átláthatatlan kódsor hanem egy különfüggvénybe ki van szervezve. Nagy szerepe van a ranglista utánni újbóli játéknál
        {
            this.player = new Player(this.size.Width / 2, this.size.Height - 100);
            this.enemyList = new List<Enemy>();
            this.mainMenu = new Menu();
            this.makeItDifficult = 0;
            this.pickableElementCollection = new List<PickableElement>();
        }

        public void GenerateEnemy() // generálja az ellenfeleket
        {
            EnemyType enemytypehelper = (EnemyType)this.r.Next(0, 3);
            if (this.enemyList.Count < 4 + (int)this.makeItDifficult)
            {
                switch (enemytypehelper)
                {
                    case EnemyType.Easy: this.enemyList.Add(new Enemy(this.r.Next(20, 490), 0, enemytypehelper)); break;
                    case EnemyType.Medium: this.enemyList.Add(new Enemy(this.r.Next(20, 490), this.r.Next(0, 200), enemytypehelper)); break;
                    case EnemyType.Hard: this.enemyList.Add(new Enemy(this.r.Next(20, 490), this.r.Next(0, 200), enemytypehelper)); break;
                    default: return;
                }
            }
        }

        public void SaveScores() // ez menti el a pontokat
        {
            StreamWriter sw = new StreamWriter("Rekordok.txt");
            for (int i = 0; i < this.playerScores.Count; i++)
            {
                sw.WriteLine(this.playerScores[i].Name + "#" + this.playerScores[i].Score);
            }

            sw.Close();
        }

        public void DoTurn() // osszefoglaló függvény hogy egy periódus alatt milyen függvények hívódjanak
        {
            if (this.mainMenu.GameActive)
            {
                this.Move();
                this.PlayerBullettCollideWithEnemy();
                this.GenerateEnemy();
                this.FindInactiveEnemies();
                this.FindInactiveBullet(this.Player.Bullets);
                this.EnemyCollideWithPlayer();
                this.EnemyBulletsCollisionWithPlayer();
                this.GeneratePickableElement();
                this.MovePickableElement();
                this.FindInactivePickableElement();
                this.PlayerCollisionWithPickableElement();

                if (this.Player.LifeScore <= 0)
                {
                    this.gameOver = true;
                }

                foreach (Enemy enemy in this.EnemyList)
                {
                    foreach (Bullet bullet in enemy.Bullets)
                    {
                        bullet.MoveEnemyBullets();
                    }
                }

                foreach (Enemy enemy in this.EnemyList)
                {
                    this.FindInactiveBullet(enemy.Bullets);
                }
            }
        }

        public int ActualScore()
        {
            return this.player.Score;
        } // Az adott játszma alatt elért pontot visszaadó függvény

        public void EnemyMove() // Ez mozgatja az ellensége
        {
            foreach (Enemy enemy in this.enemyList)
            {
                enemy.Move();
            }
        }

        public void Billentyunyomas(Key e) // Ezt a függvényt hívja meg a fő code behind ez kezeli a különböző billentyűnyomásokat
        {
            if (e == Key.Left)
            {
                int value = -20;
                if (this.Player.PlayerPoint.X + value > 0)
                {
                    this.Player.Move(value);
                }
                else
                {
                    return;
                }
            }

            if (e == Key.Right)
            {
                int value = 20;
                if (this.Player.PlayerPoint.X + 60 + value < this.size.Width)
                {
                    this.Player.Move(value);
                }
                else
                {
                    return;
                }
            }

            if (e == Key.LeftShift || e == Key.RightShift)
            {
                this.Player.ChangeWeapon();
            }
            else if (e == Key.Space)
            {
                this.Player.Shoot();
            }

            if (e == Key.Down)
            {
                this.MainMenu.MenuDown();
            }

            if (e == Key.Up)
            {
                this.MainMenu.MenuUp();
            }

            if (e == Key.Enter)
            {
                if (this.gameOver)
                {
                    this.LeaderBoardOpen = true;
                    this.GameOver = false;
                }
                else
                {
                    this.MainMenu.ChooseMenuElement();
                }
            }

            if (e == Key.Escape)
            {
                this.MainMenu.LeaderBoardActive = false;
                this.mainMenu.ControlMenuElementActive = false;
            }
        }

        private void GeneratePickableElement() // generál felvehető elemet
        {
            PickableElementType type = (PickableElementType)this.r.Next(0, 2);
            int seged = this.r.Next(0, 50);
            if (seged > 48)
            {
                this.pickableElementCollection.Add(new PickableElement(this.r.Next(0, 450), 30, type));
            }
        }

        private void MovePickableElement() // ez mozgatja a felvehető elemeket
        {
            foreach (PickableElement pick in this.PickableElementCollection)
            {
                pick.Move();
            }
        }

        private void Move() // Ez mozgatja a játékos lövedékeit
        {
            foreach (Bullet item in this.Player.Bullets)
            {
                item.MovePlayerBullets();
            }
        }

        private void ReadScore() // segédfüggvény. Ez olvassa be a rekordok txt-t és ezt tölti be a ranglistába
        {
            StreamReader sr = new StreamReader("rekordok.txt");
            while (!sr.EndOfStream)
            {
                string oneLine = sr.ReadLine();
                string[] splitted = oneLine.Split('#');
                int scoreValue = int.Parse(splitted[1]);
                Scores score = new Scores(splitted[0], scoreValue);
                this.playerScores.Add(score);
            }

            sr.Close();
        }

        private void FindInactiveBullet(List<Bullet> bulletToInvestigate) // Ez fogja megtalálni és kitörölni azon a lövedékeket amelyek elhagyták a pályát
        {
            this.bulletsToDelete = new List<Bullet>();
            foreach (Bullet bullet in bulletToInvestigate)
            {
                if (bullet.Location.X < 0 ||
                    bullet.Location.Y < 0 ||
                    bullet.Location.Y > this.size.Height ||
                    bullet.Location.X > this.size.Width)
                {
                    this.bulletsToDelete.Add(bullet);
                }
            }

            foreach (Bullet item in this.bulletsToDelete)
            {
                bulletToInvestigate.Remove(item);
            }
        }

        private void FindInactiveEnemies() // Törli azokat az ellenségeket akik kimentek a pályáról. Ezt a könnyű ellenfeleknél kell detektálni
        {
            this.enemyToDelete = new List<Enemy>();
            foreach (Enemy enemy in this.enemyList)
            {
                if (enemy.EnemyPoint.Y > this.size.Height)
                {
                    this.enemyToDelete.Add(enemy);
                }
            }

            foreach (Enemy enemy in this.enemyToDelete)
            {
                this.enemyList.Remove(enemy);
            }
        }

        private void PlayerBullettCollideWithEnemy() // detektálja hogy a lövésünk lelőtt-e egy ellenfelet. Ha igen a golyót is törli ha az ellenségnek elfogyott a pontja akkor őt is( de ha nem akkor csak sebzi)
        {
            this.enemyToDelete = new List<Enemy>();
            this.bulletsToDelete = new List<Bullet>();
            foreach (Bullet bullet in this.Player.Bullets)
            {
                foreach (Enemy enemy in this.enemyList)
                {
                    if (bullet.Shape.IntersectsWith(enemy.Shape))
                    {
                        enemy.LifeScore -= bullet.DamageLevel;
                        if (enemy.LifeScore <= 0)
                        {
                            this.enemyToDelete.Add(enemy);
                        }

                        this.bulletsToDelete.Add(bullet);
                    }
                }
            }

            foreach (Enemy enemy in this.enemyToDelete)
            {
                this.enemyList.Remove(enemy);
                this.PointIncrease(10);
            }

            foreach (Bullet bullet in this.bulletsToDelete)
            {
                this.Player.Bullets.Remove(bullet);
            }
        }

        private void PointIncrease(int value) // Növeli a játékos pontját
        {
            this.Player.Score += value;
            this.makeItDifficult += 0.05;
        }

        private void EnemyBulletsCollisionWithPlayer() // detekálja hogy kaptunk-e be találatot
        {
            foreach (Enemy enemy in this.enemyList)
            {
                foreach (Bullet bullet in enemy.Bullets)
                {
                    if (bullet.Shape.IntersectsWith(this.player.Shape))
                    {
                        this.player.Damage(bullet.DamageLevel);
                        this.bulletsToDelete.Add(bullet);
                    }
                }
            }

            foreach (Enemy enemy in this.enemyList)
            {
                foreach (Bullet bullet in this.bulletsToDelete)
                {
                    enemy.Bullets.Remove(bullet);
                }
            }
        }

        private void PlayerCollisionWithPickableElement() // detektálja és kezeli ha felvettünk egy boost elemet
        {
            List<PickableElement> toDelete = new List<PickableElement>();
            foreach (PickableElement pick in this.pickableElementCollection)
            {
                if (pick.Shape.IntersectsWith(this.player.Shape))
                {
                    toDelete.Add(pick);
                    if (pick.PickType == PickableElementType.Life)
                    {
                        this.player.LifeScore += 5;
                    }
                    else
                    {
                        this.player.Immortal = true;
                    }
                }
            }

            foreach (PickableElement pick in toDelete)
            {
                this.pickableElementCollection.Remove(pick);
            }
        }

        private void FindInactivePickableElement()
        {
            List<PickableElement> toDelete = new List<PickableElement>();
            foreach (PickableElement pick in this.pickableElementCollection)
            {
                if (pick.Location.Y > this.size.Height)
                {
                    toDelete.Add(pick);
                }
            }

            foreach (PickableElement pick in toDelete)
            {
                this.pickableElementCollection.Remove(pick);
            }
        }

        private void EnemyCollideWithPlayer() // detektálja hogy a lezuhanó ellenfelek ütköztek-e velünk. ha igen sebesíti ha 0 az életpontja akkor törli
        {
            this.enemyToDelete = new List<Enemy>();
            foreach (Enemy enemy in this.enemyList)
            {
                if (enemy.Shape.IntersectsWith(this.Player.Shape))
                {
                    this.enemyToDelete.Add(enemy);
                }
            }

            foreach (Enemy enemy in this.enemyToDelete)
            {
                this.enemyList.Remove(enemy);
                this.Player.Damage(1);
            }
        }
    }
}