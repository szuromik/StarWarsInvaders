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
        private Bullet bulletToAdd;

        public GameLogic(Size size)
        {
            this.size = size;
            this.player = new Player(this.size.Width / 2, this.size.Height - 100);
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

        public void Move()
        {
            foreach (Bullet item in this.Player.Bullets)
            {
                item.MovePlayerBullets();
            }

            this.FindInactiveBullet(this.Player.Bullets);
            this.PlayerBullettCollideWithEnemy();
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

            // And now we will delete these bullets
            foreach (Bullet item in this.bulletsToDelete)
            {
                bulletToInvestigate.Remove(item);
            }
        }

        private void PlayerBullettCollideWithEnemy()
        {
            // Some code Here
        }
    }
}