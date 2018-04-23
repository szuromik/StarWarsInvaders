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

        public GameLogic(Size size)
        {
            this.size = size;
            this.Init(this.size);
            this.PlayerBullet = new List<Bullet>();
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
                this.playerBullet.Add(new Bullet(new Point(this.kristof.PlayerPoint.X+30,this.size.Height - 100)));
            }
        }

            public void Move() // it will move everything
                {
                    foreach (Bullet item in this.playerBullet)
                    {
                        item.MovePlayerBullets();
                    }
                }
        }
    }
