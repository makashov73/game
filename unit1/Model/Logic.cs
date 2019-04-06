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
        int[,] traps = new int[n, 2] { { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 }, { 0, 0 } };
        List<Point> points = new List<Point>();

        public void SetupCenters() // определяем центры ячеек
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

        public void ClearTraps() // очистка списка центров (ловушек)
        {
            points.Clear();
        }

        public Point GetCenterById(int id) //получаем координаты центра по id
        {
            SetupCenters();
            Point[] center = points.ToArray();
            Point dot = new Point();
            dot.X = center[id].X;
            dot.Y = center[id].Y;
            return dot;
        }

        public Entity MoveLeft(Entity entity) // перемещение сущности влево
        {
            entity.XY = new Point(entity.XY.X - 80, entity.XY.Y);
            return entity;
        }

        public Entity MoveRight(Entity entity) // перемещение сущности вправо
        {
            entity.XY = new Point(entity.XY.X + 80, entity.XY.Y);
            return entity;
        }

        public Entity MoveUp(Entity entity) // перемещение сущности вверх
        {
            entity.XY = new Point(entity.XY.X, entity.XY.Y - 80);
            return entity;
        }

        public Entity MoveDown(Entity entity) // перемещение сущности вниз
        {
            entity.XY = new Point(entity.XY.X, entity.XY.Y + 80);
            return entity;
        }

        public Point[] BuildTrace(Entity entity) // построение координат троектории движения сущеости
        {
            List<Point> trace = new List<Point>();
            Random rnd = new Random();
            trace.Add(entity.XY);
            Activate(entity);
            do
            {
                int id = rnd.Next(0, 4);
                switch (id)
                {
                    case 0:
                        MoveLeft(entity);
                        trace.Add(entity.XY);
                        Activate(entity);
                        break;
                    case 1:
                        MoveUp(entity);
                        trace.Add(entity.XY);
                        Activate(entity);
                        break;
                     case 2:
                        MoveRight(entity);
                        trace.Add(entity.XY);
                        Activate(entity);
                        break;
                     case 3:
                        MoveDown(entity);
                        trace.Add(entity.XY);
                        Activate(entity);
                        break;
                }
            } while (points.Contains(entity.XY));
            return trace.ToArray();
        }

        public void Activate(Entity entity) //определение активированных ловушек
        {
            switch (entity.Type)
            {
                case 0:
                    for (int i = 0; i < n; i++)
                        if (entity.XY == GetCenterById(i))
                            if (IsTrap(i))
                                if ((traps[i, 0] == 1) || (traps[i, 0] == 2))
                                    traps[i, 1] += 1;
                    break;
                case 1:
                    for (int i = 0; i < n; i++)
                        if (entity.XY == GetCenterById(i))
                            if (IsTrap(i))
                                if (traps[i, 0] == 1)
                                    traps[i, 1] = 2;
                    break;
                case 2:
                    for (int i = 0; i < n; i++)
                        if (entity.XY == GetCenterById(i))
                            if (IsTrap(i))
                                if (traps[i, 0] == 2)
                                    traps[i, 1] = 2;
                    break;
            }
        }

        public bool IsTrap(int id) //является ли ячейка ловушкой
        {
            if (traps[id, 0] != 0)
                return true;
            else
                return false;
        }

        public int[,] SetupTraps() //расстановка ловушек по ячейкам
        {
            Array.Clear(traps, 0, traps.Length);
            Random rnd = new Random();
            int cell;
            int k = 0;
            while (k < 6)
            {
                cell = rnd.Next(0, n);
                if(traps[cell, 0] == 0)
                {
                    if (k > 2)
                        traps[cell, 0] = 2;
                    else
                        traps[cell, 0] = 1;
                    k++;
                }
            }
            return traps;
        }
    }
}
