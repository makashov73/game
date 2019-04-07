using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;

namespace unit1.Model
{
    class Entity // класс сущности
    {
        public Point XY { get; set; } // для начальных координат

        public bool Start { get; set; } = false; // защита от повторных траекторий

        public int Type { get; set; } = 0; // тип сущности

        public Entity() { } // пустой конструктор

        public Entity(Point start, int type) // конструктор класса
        {
            XY = start;

            Type = type;
        }
    }
}
