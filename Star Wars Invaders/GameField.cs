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
        private List<ImageBrush> enemies;
        private GameLogic vm;

        public void Init(GameLogic vm)
        {
            this.vm = vm;
            this.playerBrush = new ImageBrush(new BitmapImage(new Uri("Pics\\Player.png", UriKind.Relative)));
            this.backgroundBrush = new ImageBrush(new BitmapImage(new Uri("Pics\\space.jpg", UriKind.Relative)));
            this.enemies = new List<ImageBrush>();
            this.enemies.Add(new ImageBrush(new BitmapImage(new Uri("Pics\\boss1.png", UriKind.Relative))));
            this.enemies.Add(new ImageBrush(new BitmapImage(new Uri("Pics\\boss2.png", UriKind.Relative))));
            this.enemies.Add(new ImageBrush(new BitmapImage(new Uri("Pics\\boss3.png", UriKind.Relative))));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.vm != null)
            {
                drawingContext.DrawRectangle(this.backgroundBrush, null, new Rect(0, 0, this.ActualWidth, this.ActualHeight));
                if (!this.vm.MainMenu.GameActive)
                {
                    if (!this.vm.MainMenu.IsMenuInactive && !this.vm.MainMenu.ControlMenuElementActive && !this.vm.MainMenu.LeaderBoardActive)
                    {
                        DrawingContextHelp.DrawMenu(drawingContext, this.vm);
                    }
                    else if (this.vm.MainMenu.ControlMenuElementActive)
                    {
                        DrawingContextHelp.DrawControlMenu(drawingContext);
                    }
                    else
                    {
                        DrawingContextHelp.DrawLeaderBoard(drawingContext, this.vm);
                    }
                }
                else
                {
                    if (!this.vm.GameOver)
                    {
                        drawingContext.DrawRectangle(this.playerBrush, null, new Rect(this.vm.Player.PlayerPoint.X, this.vm.Player.PlayerPoint.Y, 60, 100));
                        DrawingContextHelp.DrawPlayerBullets(drawingContext, this.vm);
                        DrawingContextHelp.DrawEnemies(this.enemies, drawingContext, this.vm);
                        DrawingContextHelp.DrawEnemyLifeScore(drawingContext, this.vm);
                        DrawingContextHelp.DrawPlayerScore(drawingContext, this.vm);
                        DrawingContextHelp.DrawPlayerLifeScore(drawingContext, this.vm);
                    }

                    else
                    {
                        MessageBox.Show("Beszoptad");
                    }
                }
            }
        }
    }
}