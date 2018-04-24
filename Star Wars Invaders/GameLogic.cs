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
        private Player kristof;
        private Size size;
        private List<Bullet> playerBullet;
        private List<Bullet> bulletsToDelete;
        public List<Rect> random_fos;
        private Random r = new Random();

        public GameLogic(Size size)
        {
            this.size = size;
            this.Init(this.size);
            this.PlayerBullet = new List<Bullet>();
            this.random_fos = new List<Rect>();
            for (int i = 0; i < 50; i++)
            {
                this.random_fos.Add(new Rect(r.Next(0, 500), r.Next(0, 500), 25, 25));
            }
        }

        public Player Kristof
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

        public List<Bullet> PlayerBullet
        {
            get
            {
                return this.playerBullet;
            }

            set
            {
                this.playerBullet = value;
            }
        }

        public void Init(Size size)
        {
            this.kristof = new Player(this.size.Width / 2, this.size.Height - 100);
        }

        public void Billentyunyomas(Key e)
        {
            if (e == Key.Left)
            {
                int value = -10;
                if (this.Kristof.PlayerPoint.X + value > 0)
                {
                    this.Kristof.Move(value);
                }
                else
                {
                    return;
                }
            }

            if (e == Key.Right)
            {
                int value = 10;
                if (this.Kristof.PlayerPoint.X + 60 + value < this.size.Width)
                {
                    this.Kristof.Move(value);
                }
                else
                {
                    return;
                }
            }

            if (e == Key.Space)
            {
                this.playerBullet.Add(new Bullet(new Point(this.kristof.PlayerPoint.X + 30, this.size.Height - 100)));
            }
        }

           public void Move()
                {
                    foreach (Bullet item in this.playerBullet)
                    {
                        item.MovePlayerBullets();
                    }

                    this.FindInactiveBullet(this.playerBullet);
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
            List<Rect> RectToDelete = new List<Rect>();
            foreach (Bullet bullet in playerBullet)
            {
                foreach (Rect rect in random_fos)
                {
                    if (bullet.Shape.IntersectsWith(rect))
                        {
                        RectToDelete.Add(rect);
                        }

                    }
                }

            foreach (Rect rect in RectToDelete)
            {
                random_fos.Remove(rect);
            }
            }
        }
        }
    

