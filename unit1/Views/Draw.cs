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

        /*public void Initializer(PictureBox gamemap)
        {
            Bitmap bitmap;
            bitmap = new Bitmap(gamemap.Width, gamemap.Height);
        }*/

        public void DrawMap(PictureBox gamemap) // отрисовка поля
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

        public void DrawTrace(Point[] trace, PictureBox gamemap, Pen ct) // отрисовка поля
        {
            using (Graphics g = Graphics.FromImage(gamemap.Image))
            {
                
                g.DrawLines(ct, trace);
                gamemap.Refresh();
            }
        }

        public void DrawRing(PictureBox gamemap)
        {
            
            //gamemap.Image = new Bitmap(gamemap.Width, gamemap.Height);
            using (Graphics g = Graphics.FromImage(gamemap.Image))
            {
                Point[] points =
                {
                    new Point(40, 40),
                    new Point(120, 40),
                    new Point(200, 40),
                    new Point(40, 120),
                    new Point(120, 120),
                    new Point(200, 120),
                    new Point(40,200),
                    new Point(120, 200),
                    new Point(200,200)
                };
                
                g.DrawLines(blackPenTraps, points);
                gamemap.Refresh();
            }
        }

        public void DrawBell(PictureBox gamemap, int id)
        {
            Point centr = logic.GetCenterById(id);

            Point[] bell =
            {
                new Point(centr.X-40,centr.Y),
                new Point(centr.X,centr.Y-40),
                new Point(centr.X+40,centr.Y),
                new Point(centr.X,centr.Y+40),
                new Point(centr.X-40,centr.Y)
            };

            using (Graphics g = Graphics.FromImage(gamemap.Image))
            {
                g.DrawLines(blackPenTraps, bell);
                gamemap.Refresh();
            }
        }

        public void DrawPlasm(PictureBox gamemap, int id)
        {
            Point centr = logic.GetCenterById(id);

            Point[] bell =
            {
                new Point(centr.X-40,centr.Y),
                new Point(centr.X-10,centr.Y-10),
                new Point(centr.X,centr.Y-40),
                new Point(centr.X+10,centr.Y-10),
                new Point(centr.X+40,centr.Y),
                new Point(centr.X+10,centr.Y+10),
                new Point(centr.X,centr.Y+40),
                new Point(centr.X-10,centr.Y+10),
                new Point(centr.X-40,centr.Y)
            };

            using (Graphics g = Graphics.FromImage(gamemap.Image))
            {
                g.DrawLines(blackPen, bell);
                gamemap.Refresh();
            }
        }

        public void PlaceTraps(PictureBox gamemap, int[] traps)
        {
            //gamemap.Image = new Bitmap(gamemap.Width, gamemap.Height);
            //using (Graphics g = Graphics.FromImage(gamemap.Image))
            //{

                /*Point[] points =
                {
                    new Point(40, 40),
                    new Point(120, 40),
                    new Point(200, 40),
                    new Point(40, 120),
                    new Point(120, 120),
                    new Point(200, 120),
                    new Point(40,200),
                    new Point(120, 200),
                    new Point(200,200)
                };

                g.DrawLines(blackPen, points);*/

                // цикл по массиву
                // если элемент = 0 - ничего
                // если элемент = 1 - колокольчик
                // если элемент = 2 - детектор протоплазмы
                // GetCenterById
            //}


        }

        public void ClearTrace()
        {

        }
        
    }
}
