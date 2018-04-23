// <copyright file="GameField.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class GameField : FrameworkElement
    {
        // there will be brushes
        private ImageBrush playerBrush;
        private ImageBrush backgroundBrush;
        private Size size;
        private GameLogic vm;

        public void Init(GameLogic vm)
        {
            this.vm = vm;
            this.playerBrush = new ImageBrush(new BitmapImage(new Uri("Pics\\Player.png", UriKind.Relative)));
            this.backgroundBrush = new ImageBrush(new BitmapImage(new Uri("Pics\\space.jpg", UriKind.Relative)));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.vm != null)
            {
                drawingContext.DrawRectangle(this.backgroundBrush, null, new Rect(0, 0, this.ActualWidth, this.ActualHeight));
                drawingContext.DrawRectangle(this.playerBrush, null, new Rect(this.vm.Kristof.PlayerPoint.X, this.vm.Kristof.PlayerPoint.Y, 60, 100));

                // Draw the bullets --> Tesz
                foreach (Bullet item in this.vm.PlayerBullet)
                {
                    drawingContext.DrawEllipse(Brushes.Red, null, item.Location, 10, 10);
                }
            }
        }
    }
}
