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

        int[] traps = new int[n] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        
        List<Point> points = new List<Point>();

        public void SetupCenters()
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

        public int[] SetupTraps()
        {
            Random rnd = new Random();
            int type;
            int k = 0;
            while (k < 6)
            {
                type = rnd.Next(1, 9);
                if(traps[type] == 0)
                {
                    if (k > 2)
                        traps[type] = 2;
                    else
                        traps[type] = 1;
                    k++;
                }
            }
            return traps;
        }


    }
}
