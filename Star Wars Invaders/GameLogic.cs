namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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

        public GameLogic(Size size)
        {
            this.Size = size;
            this.ToStartState();
        }

        public Player Player
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

        public List<Enemy> EnemyList
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

        private void ToStartState()
        {
            this.player = new Player(this.size.Width / 2, this.size.Height - 100);
            this.enemyList = new List<Enemy>();
            this.mainMenu = new Menu();
            this.playerScores = new List<Scores>();
        }

        public Menu MainMenu
        {
            get
            {
                return this.mainMenu;
            }
        }

        public bool GameOver
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

        public Size Size
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

        public void GenerateEnemy()
        {
            if (this.enemyList.Count < 4)
            {
                for (int i = 0; i < 2; i++)
                {
                    this.enemyList.Add(new Enemy(this.r.Next(20, 490), 0, EnemyType.Easy));
                }
            }
        }

        public void DoTurn()
        {
            if (this.mainMenu.GameActive)
            {
                this.Move();
                this.PlayerBullettCollideWithEnemy();
                this.FindInactiveEnemies();
                this.FindInactiveBullet(this.Player.Bullets);
                this.EnemyCollideWithPlayer();
                if (this.Player.LifeScore <= 0)
                {
                    this.gameOver = true;
                }
            }
        }

        public void Billentyunyomas(Key e)
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
                    LeaderBoardWindow leaderBoardWindow = new LeaderBoardWindow(this.Player.Score);
                    leaderBoardWindow.ShowDialog();
                    this.playerScores.Add(leaderBoardWindow.Score);
                    this.ToStartState();
                    this.gameOver = false;
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

        private void LofaszAPicsadba()
        {
            this.gameOver = false;
        }

        private void Move()
        {
            foreach (Bullet item in this.Player.Bullets)
            {
                item.MovePlayerBullets();
            }

            foreach (Enemy item in this.enemyList)
            {
                item.Move();
            }
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

        private void FindInactiveEnemies()
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

        private void PlayerBullettCollideWithEnemy()
        {
            this.enemyToDelete = new List<Enemy>();
            foreach (Bullet bullet in this.Player.Bullets)
            {
                foreach (Enemy enemy in this.enemyList)
                {
                    if (bullet.Shape.IntersectsWith(enemy.Shape))
                    {
                        this.enemyToDelete.Add(enemy);
                    }
                }
            }

            foreach (Enemy enemy in this.enemyToDelete)
            {
                this.enemyList.Remove(enemy);
                this.player.Score += 10;
            }
        }

        private void EnemyBulletsCollisionWithPlayer()
        {
            // Some code here
        }

        private void PlayerCollisionWithPickableElement()
        {
            // Some Code Here
        }

        private void EnemyCollideWithPlayer()
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
                this.Player.Damage();
            }
        }
    }
}