// <copyright file="GameField.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Star_Wars_Invaders
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class GameField : FrameworkElement
    {
        private ImageBrush playerBrush;
        private GameLogic game;

        private void GameField_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focusable = true;
            this.Focus();
        }

        public void Init()
        {
            this.playerBrush = new ImageBrush(new BitmapImage(new Uri("Pics\\Player.png", UriKind.Relative)));
            game = new GameLogic();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(this.playerBrush, null, new Rect(this.game.Kristof.playerRect.X,this.game.Kristof.playerRect.Y, 60, 100));
        }

        private void GameField_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Left)
            {
                this.game.Kristof.playerRect.X -= 50;
                this.InvalidateVisual();
            }

            if (e.Key == System.Windows.Input.Key.Right)
            {
                this.game.Kristof.playerRect.X += 50;
                this.InvalidateVisual();
            }
        }
    }
}
