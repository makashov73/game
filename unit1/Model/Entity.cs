using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace unit1.Model
{
    class Entity
    {
        public Point XY { get; set; }

        public bool start { get; set; } = false;

        public Entity() { }

        public Entity(Point start)
        {
            XY = start;
        }
    }
}
