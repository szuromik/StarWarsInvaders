// <copyright file="Bullet.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public enum BulletType
    {
        Simple, Laser
    }

    public class Bullet
    {
        private Point location;
        private Rect shape;
        private BulletType bulletType;

        public Bullet(Point location, BulletType bulletType)
        {
            this.Location = location;
            this.Shape = new Rect(location.X, location.Y, 10, 10);
            this.bulletType = bulletType;
        }

        public Point Location
        {
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

        public Rect Shape
        {
            get
            {
                return this.shape;
            }

            set
            {
                this.shape = value;
            }
        }

        public BulletType BulletType
        {
            get
            {
                return this.bulletType;
            }

            set
            {
                this.bulletType = value;
            }
        }

        public void MovePlayerBullets()
        {
            this.location.Y -= 10;
            this.shape.Y -= 10;
        }
    }
}
