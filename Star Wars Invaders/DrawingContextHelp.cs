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
        public static void DrawMenu(DrawingContext drawingContext)
            {
            drawingContext.DrawEllipse(Brushes.Azure, null, new Point(300, 300), 40, 40);
            }

        public static void DrawPlayerBullets(DrawingContext drawingContext, GameLogic vm)
        {
            foreach (Bullet item in vm.Player.Bullets)
            {
                if (item.BulletType == BulletType.Laser)
                {
                    drawingContext.DrawEllipse(Brushes.Green, null, item.Location, 5, 5);
                }
                else
                {
                    drawingContext.DrawEllipse(Brushes.Blue, null, item.Location, 5, 5);
                }
            }
        }

        public static void DrawEnemies(DrawingContext drawingContext, GameLogic vm)
        {
            foreach (Enemy enemy in vm.EnemyList)
            {
                drawingContext.DrawRectangle(Brushes.Azure, new Pen(Brushes.Black,1), new Rect(enemy.EnemyPoint.X, enemy.EnemyPoint.Y, enemy.Shape.Width, enemy.Shape.Height));
            }
        }
    }
}
