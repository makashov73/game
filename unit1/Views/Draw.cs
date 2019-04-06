using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using unit1.Model;

namespace unit1.Views
{
    class Draw
    {
        Logic logic = new Logic();
        Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 1);
        Pen blackPenTraps = new Pen(Color.FromArgb(255, 0, 0, 0), 2);
        SolidBrush redSquare = new SolidBrush(Color.FromArgb(255, 255, 0, 0));

        public void DrawMap(PictureBox gamemap) // отрисовка игрового поля
        {
            gamemap.Image = new Bitmap(gamemap.Width, gamemap.Height);
            using (Graphics g = Graphics.FromImage(gamemap.Image))
            {
                Point[] points =
                {
                    new Point(0, 0),
                    new Point(0, 239),
                    new Point(239, 239),
                    new Point(239, 0),
                    new Point(0, 0),

                    new Point(0, 80),
                    new Point(240, 80),
                    new Point(240, 160),
                    new Point(0, 160),

                    new Point(0, 239),
                    new Point(80, 239),
                    new Point(80, 0),
                    new Point(160, 0),
                    new Point(160, 239)
                };
                g.DrawLines(blackPen, points);
            }
        }

        public void DrawTrace(Point[] trace, PictureBox gamemap, Pen ct, int [,] traps) // отрисовка траекторий сущностей
        {
            DrawTraps(gamemap, traps);
            using (Graphics g = Graphics.FromImage(gamemap.Image))
            {
                
                g.DrawLines(ct, trace);
                gamemap.Refresh();
            }
        }

        public void DrawBell(PictureBox gamemap, int id, int activated) //отрисовка колокольчика
        {
            Point center = logic.GetCenterById(id);

            Point[] bell =
            {
                new Point(center.X-38,center.Y),
                new Point(center.X,center.Y-38),
                new Point(center.X+38,center.Y),
                new Point(center.X,center.Y+38),
                new Point(center.X-38,center.Y)
            };

            using (Graphics g = Graphics.FromImage(gamemap.Image))
            {
                if(activated < 2)
                    g.DrawLines(blackPenTraps, bell);
                else
                {
                    g.FillRectangle(redSquare, new Rectangle(center.X-39, center.Y-39, 79, 79));
                    g.DrawLines(blackPenTraps, bell);
                }
                gamemap.Refresh();
            }
            Array.Clear(bell, 0, bell.Length);
        }

        public void DrawPlasm(PictureBox gamemap, int id, int activated) // отрисовка детектора протоплазмы
        {
            Point center = logic.GetCenterById(id);

            Point[] plasm =
            {
                new Point(center.X-38,center.Y),
                new Point(center.X-10,center.Y-10),
                new Point(center.X,center.Y-38),
                new Point(center.X+10,center.Y-10),
                new Point(center.X+38,center.Y),
                new Point(center.X+10,center.Y+10),
                new Point(center.X,center.Y+38),
                new Point(center.X-10,center.Y+10),
                new Point(center.X-38,center.Y)
            };

            using (Graphics g = Graphics.FromImage(gamemap.Image))
            {
                if (activated < 2)
                g.DrawLines(blackPenTraps, plasm);
                else
                {
                    g.FillRectangle(redSquare, new Rectangle(center.X - 39, center.Y - 39, 79, 79));
                    g.DrawLines(blackPenTraps, plasm);
                }
                gamemap.Refresh();
            }
            Array.Clear(plasm, 0, plasm.Length);
        }

        public void DrawTraps(PictureBox gamemap, int[,] traps) // отрисовка ловушек (в зависимости от типа)
        {
            for (int i = 0; i < 9; i++)
            {
                switch(traps[i, 0])
                {
                    case 0:
                        break;
                    case 1:
                        DrawBell(gamemap, i, traps[i, 1]);
                        break;
                    case 2:
                        DrawPlasm(gamemap, i, traps[i, 1]);
                        break;
                }
            }
        }
    }
}
