using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using unit1.Views;


namespace unit1.Model
{
    class Logic
    {
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

        public void ClearTraps()
        {
            points.Clear();
        }

        public Point GetCenterById(int id)
        {
            SetupCenters();
            Point[] centr = points.ToArray();
            Point dot = new Point();
            dot.X = centr[id].X;
            dot.Y = centr[id].Y;
            return dot;
        }

        public Entity MoveLeft(Entity entity)
        {
            entity.XY = new Point(entity.XY.X - 80, entity.XY.Y);
            return entity;
        }

        public Entity MoveRight(Entity entity)
        {
            entity.XY = new Point(entity.XY.X + 80, entity.XY.Y);
            return entity;
        }

        public Entity MoveUp(Entity entity)
        {
            entity.XY = new Point(entity.XY.X, entity.XY.Y - 80);
            return entity;
        }

        public Entity MoveDown(Entity entity)
        {
            entity.XY = new Point(entity.XY.X, entity.XY.Y + 80);
            return entity;
        }

        public Point[] BuildTrace(Entity entity)
        {
            List<Point> trace = new List<Point>();
            Random rnd = new Random();
                trace.Add(entity.XY);
                do
                {
                    int id = rnd.Next(0, 4);
                    switch (id)
                    {
                        case 0:
                            MoveLeft(entity);
                            trace.Add(entity.XY);
                            break;
                        case 1:
                            MoveUp(entity);
                            trace.Add(entity.XY);
                            break;
                        case 2:
                            MoveRight(entity);
                            trace.Add(entity.XY);
                            break;
                        case 3:
                            MoveDown(entity);
                            trace.Add(entity.XY);
                            break;
                    }
                } while (points.Contains(entity.XY));
            return trace.ToArray();
        }

        public int[] SetupTraps()
        {
            Array.Clear(traps, 0, n);
            Random rnd = new Random();
            int type;
            int k = 0;
            while (k < 6)
            {
                type = rnd.Next(0, 9);
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

        public int TrapType(int id)
        {
            int type = 0;
            if (traps[id] == 2)
            {
                return type = 2;
            }
            else if (traps[id] == 1)
            {
                return type = 1;
            }
            else
                return type;
             
        }

    }
}
