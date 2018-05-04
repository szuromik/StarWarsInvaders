namespace Star_Wars_Invaders
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for leaderBoardWindow.xaml
    /// </summary>
    public partial class LeaderBoardWindow : Window
    {
        public LeaderBoardWindow(int score) // konstruktor a ranglista ablaknak
        {
            this.InitializeComponent();
            this.Score = new Scores(string.Empty, score);
            this.DataContext = this.Score;
        }

        public Scores Score { get; set; } // ponthoz tulajdonság

        private void Button_Click(object sender, RoutedEventArgs e) // kezeli az egérnyomást
        {
            this.DialogResult = true;
        }
    }
}
