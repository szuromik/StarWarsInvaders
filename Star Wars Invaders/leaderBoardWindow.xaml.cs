using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Star_Wars_Invaders
{
    /// <summary>
    /// Interaction logic for leaderBoardWindow.xaml
    /// </summary>
    public partial class LeaderBoardWindow : Window
    {
        public LeaderBoardWindow(int score)
        {
            this.InitializeComponent();
            this.Score = new Scores(" ", score);
            this.DataContext = this.Score;
        }

        public Scores Score { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
