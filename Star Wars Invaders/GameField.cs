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
        private ImageBrush playerBrush;
        private ImageBrush backgroundBrush;
        private Size size;

        public GameField()
        {
            this.KeyDown += this.GameField_KeyDown;
            this.Loaded += this.GameField_Loaded;
        }

        public GameLogic Game { get; set; }

        public void Init()
        {
            if (this.Game == null)
            {
                return;
            }

            this.Game.Init();
            this.playerBrush = new ImageBrush(new BitmapImage(new Uri("Pics\\Player.png", UriKind.Relative)));
            this.backgroundBrush = new ImageBrush(new BitmapImage(new Uri("Pics\\space.jpg", UriKind.Relative)));
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.Game != null)
            {
                drawingContext.DrawRectangle(this.backgroundBrush, null, new Rect(0, 0, 1366, 740));
                drawingContext.DrawRectangle(this.playerBrush, null, new Rect(this.Game.Kristof.PlayerPoint.X, this.Game.Kristof.PlayerPoint.Y, 60, 100));
            }
        }

        private void GameField_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
        }

        private void GameField_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Left)
            {
                this.Game.Kristof.Move(-10);
            }

            if (e.Key == System.Windows.Input.Key.Right)
            {
                this.Game.Kristof.Move(10);
            }

            this.InvalidateVisual();
        }
    }
}
