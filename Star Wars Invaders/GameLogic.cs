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
        private bool gameEnd;
        private List<Enemy> enemyToDelete;

        public GameLogic(Size size)
        {
            this.size = size;
            this.player = new Player(this.size.Width / 2, this.size.Height - 100);
            this.enemyList = new List<Enemy>();
            for (int i = 0; i < 120; i++)
            {
                this.enemyList.Add(new Enemy(this.r.Next(20, 500), this.r.Next(20, 450)));
            }
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

        public bool GameEnd
        {
            get
            {
                return this.gameEnd;
            }

            set
            {
                this.gameEnd = value;
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

        public void DoTurn()
        {
            this.CollisionDetection();
            this.Move();
            this.FindInactiveBullet(this.Player.Bullets);
            this.PlayerBullettCollideWithEnemy();
        }

        public void Billentyunyomas(Key e)
        {
            if (e == Key.Left)
            {
                int value = -10;
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
                int value = 10;
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
        }

        private void Move()
        {
            foreach (Bullet item in this.Player.Bullets)
            {
                item.MovePlayerBullets();
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

        private void CollisionDetection()
        {
            this.PlayerBullettCollideWithEnemy();
            this.EnemyBulletsCollisionWithPlayer();
            this.PlayerCollisionWithPickableElement();
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

    }
}