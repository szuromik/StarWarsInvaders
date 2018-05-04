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

    public enum BulletType // lőszertípus
    {
        Simple, Laser, Imperial, ImperialLaser
    }

    public class Bullet
    {
        private Point location; // lőszer helyzete
        private Rect shape; // lőszer alakzata
        private BulletType bulletType; // lőszer típusa
        private int damageLevel; // lőszer sérőlés okozása
        private int bulletVelocity; // lőszer gyorsaság

        public Bullet(Point location, BulletType bulletType, int damageLevel) // konstruktor egy lövedéknek
        {
            this.Location = location;
            this.Shape = new Rect(location.X, location.Y, 10, 10);
            this.bulletType = bulletType;
            this.damageLevel = damageLevel;
            this.InitalizeBulletVelocity();
        }

        public Point Location // tulajdonsága a helyzetnek
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

        public Rect Shape // tulajdonság az alakzatnak
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

        public BulletType BulletType // tulajdonság a lőszer típusának
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

        public int DamageLevel // tulajdonsága a lőszer sebzésének
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

        public void MovePlayerBullets() // Mozgató függvény a játékosnál
        {
            this.location.Y -= 10 * this.bulletVelocity;
            this.shape.Y -= 10 * this.bulletVelocity;
        }

        public void MoveEnemyBullets() // mozgató függvény az ellenfélnél
        {
            this.location.Y += 10;
            this.shape.Y += 10;
        }

        private void InitalizeBulletVelocity() // lőszergyorsaságot állít be 
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
