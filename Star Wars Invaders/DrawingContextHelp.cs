namespace Star_Wars_Invaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;

    public static class DrawingContextHelp
    {
        public static void DrawMenu(DrawingContext drawingContext, GameLogic vm)
        {
            for (int i = 0; i < vm.MainMenu.MenuElements.Count; i++)
            {
                SolidColorBrush menuElementColor;
                if (i == vm.MainMenu.ChoosenMenuElement)
                {
                    menuElementColor = Brushes.White;
                }
                else
                {
                    menuElementColor = Brushes.Red;
                }

                drawingContext.DrawText(
                new FormattedText(
                vm.MainMenu.MenuElements[i].ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal), 
                24,
                menuElementColor), new Point(200, (i * 50) + 200));
            }
        }

        public static void DrawPlayerBullets(DrawingContext drawingContext, GameLogic vm)
        {
            foreach (Bullet item in vm.Player.Bullets)
            {
                if (item.BulletType == BulletType.Laser)
                {
                    drawingContext.DrawEllipse(Brushes.Green, null, item.Location, 7, 5);
                }
                else
                {
                    drawingContext.DrawEllipse(Brushes.Blue, null, item.Location, 7, 5);
                }
            }
        }

        public static void DrawEnemies(List<ImageBrush> enemyList, DrawingContext drawingContext, GameLogic vm)
        {
            foreach (Enemy enemy in vm.EnemyList)
            {
                if (enemy.Type == EnemyType.Easy)
                {
                    drawingContext.DrawRectangle(enemyList[0], null, new Rect(enemy.EnemyPoint.X, enemy.EnemyPoint.Y, enemy.Shape.Width, enemy.Shape.Height));
                }

                if (enemy.Type == EnemyType.Medium)
                {
                    drawingContext.DrawRectangle(enemyList[1], null, new Rect(enemy.EnemyPoint.X, enemy.EnemyPoint.Y, enemy.Shape.Width, enemy.Shape.Height));
                }

                if (enemy.Type == EnemyType.Hard)
                {
                    drawingContext.DrawRectangle(enemyList[2], null, new Rect(enemy.EnemyPoint.X, enemy.EnemyPoint.Y, enemy.Shape.Width, enemy.Shape.Height));
                }
            }
        }

        public static void DrawPlayerScore(DrawingContext drawingContext, GameLogic vm)
        {
            drawingContext.DrawText(
                    new FormattedText(
                        vm.Player.Score.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                    14,
                    Brushes.White), new Point(10, 10));
        }

        public static void DrawEnemyLifeScore(DrawingContext drawingContext, GameLogic vm)
        {
            foreach (Enemy enemy in vm.EnemyList)
            {
                drawingContext.DrawText(
                        new FormattedText(
                            enemy.LifeScore.ToString(),
                        System.Globalization.CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                        14,
                        Brushes.White), new Point(enemy.EnemyPoint.X, enemy.EnemyPoint.Y));
            }
        }

        public static void DrawLeaderBoard(DrawingContext drawingContext, GameLogic vm)
        {
            for (int i = 0; i <vm.PlayerScores.Count;i++)
            {
                string text = vm.PlayerScores[i].Name + "\t" + vm.PlayerScores[i].Score;
                drawingContext.DrawText(
                        new FormattedText(
                            text,
                        System.Globalization.CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                        14,
                        Brushes.White), new Point(10, 20 + (i * 10)));
            }
        }

        public static void DrawControlMenu(DrawingContext drawingContext)
        {
            string text = "A játékban az ezeréves solymot tudod irányítani.\n-Mozgáshoz használd a jobbra-balra nyilat\n-Lövés - Space billentyű.\n-Két fegyver közötti váltáshoz - Jobb vagy Bal Shift.";
            drawingContext.DrawText(
                    new FormattedText(
                        text,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                    15,
                    Brushes.White), new Point(10, 10));
        }

        public static void DrawGameOver(DrawingContext drawingContext, GameLogic vm)
        {
            string text = "Game Over";
            drawingContext.DrawText(
                    new FormattedText(
                        text,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                    50,
                    Brushes.Red), new Point(130, vm.Size.Height / 2));
        }

        public static void DrawPlayerLifeScore(DrawingContext drawingContext, GameLogic vm)
        {
            drawingContext.DrawText(
                    new FormattedText(
                    vm.Player.LifeScore.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal),
                    15,
                    Brushes.White), new Point(vm.Player.PlayerPoint.X, vm.Player.PlayerPoint.Y));
        }
    }
}
