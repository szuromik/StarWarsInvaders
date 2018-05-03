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
        Simple, Laser, Imperial, ImperialLaser
    }

    public class Bullet
    {
        private Point location;
        private Rect shape;
        private BulletType bulletType;
        private int damageLevel;
        private int bulletVelocity;

        public Bullet(Point location, BulletType bulletType, int damageLevel)
        {
            this.Location = location;
            this.Shape = new Rect(location.X, location.Y, 10, 10);
            this.bulletType = bulletType;
            this.damageLevel = damageLevel;
            this.InitalizeBulletVelocity();
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

        public int DamageLevel
        {
            get
            {
                return this.damageLevel;
            }

            set
            {
                this.damageLevel = value;
            }
        }

        public void MovePlayerBullets()
        {
            this.location.Y -= 10 * this.bulletVelocity;
            this.shape.Y -= 10 * this.bulletVelocity;
        }

        public void MoveEnemyBullets()
        {
            this.location.Y += 10;
            this.shape.Y += 10;
        }

        private void InitalizeBulletVelocity()
        {
            if (this.bulletType == BulletType.Simple || this.bulletType == BulletType.Imperial)
            {
                this.bulletVelocity = 1;
            }
            else
            {
                this.bulletVelocity = 2;
            }
        }
    }
}
