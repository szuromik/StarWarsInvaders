// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Star_Wars_Invaders
{
    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameLogic vm;
        private DispatcherTimer timer;
        private int shootCounting = 40;
        private int moveCounting = 2;
        private int immortalCount = 120;

        public MainWindow() // Főablak konstruktora
        {
            this.InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e) // Ebben található mit hív meg a DispactherTimer
        {
            if (this.vm.LeaderBoardOpen)
            {
                LeaderBoardWindow leaderBoardWindow = new LeaderBoardWindow(this.vm.ActualScore());
                leaderBoardWindow.ShowDialog();
                this.vm.LeaderBoardOpen = false;
                this.vm.ToStartState();
                this.vm.PlayerScores.Add(leaderBoardWindow.Score);
                this.vm.SaveScores();
            }

            if (!this.vm.MainMenu.Exit)
            {
                if (!this.vm.GameOver)
                {
                    this.vm.DoTurn();
                    this.Jatekter.InvalidateVisual();
                    if (this.shootCounting == 0)
                    {
                        this.vm.EnemyShoot();
                        this.shootCounting = 40;
                    }
                    else
                    {
                        this.shootCounting--;
                    }

                    if (this.moveCounting == 0)
                    {
                        this.vm.Player.Score++;
                        this.vm.EnemyMove();
                        this.moveCounting = 2;
                    }
                    else
                    {
                        this.moveCounting--;
                    }

                    if (this.vm.IsPlayerImmortal)
                    {
                        this.immortalCount--;
                        if (this.immortalCount == 0)
                        {
                            this.vm.IsPlayerImmortal = false;
                            this.immortalCount = 120;
                        }
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) // kezeli a billentyűlenyomást
        {
            this.vm.Billentyunyomas(e.Key);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) // mi történjen az ablak betöltődése után
        {
            this.vm = new GameLogic(new Size(this.Jatekter.ActualWidth, this.Jatekter.ActualHeight));
            this.Jatekter.Init(this.vm);
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(25);
            this.timer.Tick += this.Timer_Tick;
            this.timer.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // mi történjen az ablak berázódásakor
        {
            this.vm.SaveScores();
        }
    }
}
