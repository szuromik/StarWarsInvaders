﻿// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
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
        private int tickCounting = 20;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
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
                    if (this.tickCounting == 0)
                    {
                        this.vm.Player.Score++;
                        this.vm.EnemyControl();
                        this.tickCounting = 20;
                    }
                    else
                    {
                        this.tickCounting--;
                    }
                }
            }
            else
            {
                this.Close();
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.vm.Billentyunyomas(e.Key);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.vm = new GameLogic(new Size(this.Jatekter.ActualWidth, this.Jatekter.ActualHeight));
            this.Jatekter.Init(this.vm);
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromMilliseconds(25);
            this.timer.Tick += this.Timer_Tick;
            this.timer.Start();
        }
    }
}
