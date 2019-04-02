using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace unit1.Model
{
    class Logic
    {
        //Point[] points;
        const int n = 9; // размерность массива

        List<Point> points = new List<Point>();

        public void SetupCenter()
        {
            points.Add(new Point(40, 40));
            points.Add(new Point(120, 40));
            points.Add(new Point(200, 40));
            points.Add(new Point(40, 120));
            points.Add(new Point(120, 120));
            points.Add(new Point(200, 120));
            points.Add(new Point(40, 200));
            points.Add(new Point(120, 200));
            points.Add(new Point(200, 200));
        }

        public Point GetCenterById(int id)
        {
            Point dot = new Point();
            dot.X = points[id].X;
            dot.Y = points[id].Y;
            return dot;
        }

        public int[,] SetTrap()
        {
            Random rnd = new Random();
            int type;
            int k = 0, m = 0;
            int[,] traps = new int[3, 1] { { 0 }, { 0 }, { 0 } };
            for(int i = 1; i <= n; i++)
            {
                type = rnd.Next(1, 4);

            }

            return traps;
        }
    }
}
