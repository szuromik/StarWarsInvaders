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
                    new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Bold, FontStretches.Normal), 24, menuElementColor),
                    new Point(200, (i * 50) + 200));
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

        public static void DrawEnemies(DrawingContext drawingContext, GameLogic vm)
        {
            foreach (Enemy enemy in vm.EnemyList)
            {
                drawingContext.DrawRectangle(Brushes.Azure, new Pen(Brushes.Black, 1), new Rect(enemy.EnemyPoint.X, enemy.EnemyPoint.Y, enemy.Shape.Width, enemy.Shape.Height));
            }
        }

        public static void DrawPlayerScore(DrawingContext drawingContext, GameLogic vm)
        {
            drawingContext.DrawText(
                    new FormattedText(
                        vm.Player.Score.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, new Typeface(
                        new FontFamily("Arial"),
                        FontStyles.Normal,
                        FontWeights.Bold,
                        FontStretches.Normal),
                        14,
                        Brushes.White),
                        new Point(10, 10));
        }

        public static void DrawLeaderBoard(DrawingContext drawingContext, GameLogic vm)
        {
            drawingContext.DrawText(
                    new FormattedText(
                        "Ez lenni LeaderBoard",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, new Typeface(
                        new FontFamily("Arial"),
                        FontStyles.Normal,
                        FontWeights.Bold,
                        FontStretches.Normal),
                        14,
                        Brushes.White),
                        new Point(10, 10));
        }

        public static void DrawControlMenu(DrawingContext drawingContext, GameLogic vm)
        {
            drawingContext.DrawText(
                    new FormattedText(
                        "Ez lenni control menü",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight, new Typeface(
                        new FontFamily("Arial"),
                        FontStyles.Normal,
                        FontWeights.Bold,
                        FontStretches.Normal),
                        14,
                        Brushes.White),
                        new Point(10, 10));
        }
    }
}
