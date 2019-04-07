using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using unit1.Views;
using unit1.Model;


namespace unit1
{
    public partial class Form1 : Form
    {
        Draw draw = new Draw();
        Logic logic = new Logic();
        Entity Meow;
        Entity Vampus;
        Entity Ghost;
        Pen catTrace = new Pen(Color.FromArgb(255, 58, 119, 227), 3);
        Pen vampusTrace = new Pen(Color.FromArgb(255, 42, 159, 29), 3);
        Pen ghostTrace = new Pen(Color.FromArgb(255, 237, 194, 51), 3);
        int[,] traps = new int[9, 2];
        
        public Form1()
        {
            InitializeComponent();
            draw.DrawMap(getPB);
            Meow = new Entity(logic.GetCenterById(4), 0);
            Vampus = new Entity(logic.GetCenterById(4), 1);
            Ghost = new Entity(logic.GetCenterById(4), 2);
            logic.SetupCenters();
            traps = logic.SetupTraps();

            draw.DrawTraps(getPB, traps);
        }
        
        private void button1_Click(object sender, EventArgs e) // очистка траекторий
        {
            draw.DrawMap(getPB);
            draw.DrawTraps(getPB, traps);
            Meow.Start = false;
            Vampus.Start = false;
            Ghost.Start = false;
        }
        
        private void button2_Click(object sender, EventArgs e) // перетасовка ловушек
        {
            draw.DrawMap(getPB);
            traps = logic.SetupTraps();
            draw.DrawTraps(getPB, traps);
            Meow.Start = false;
            Vampus.Start = false;
            Ghost.Start = false;
        }

        public PictureBox getPB //получить игровое поле
        {
            get
            {
                return pictureBox1;
            }

        }

        private void button3_Click(object sender, EventArgs e) //запустить кота
        {
            if (!Meow.Start)
            {
                Meow.XY = logic.GetCenterById(4);
                draw.DrawTrace(logic.BuildTrace(Meow), getPB, catTrace, traps);
                Meow.Start = true;
            }
        }

        private void button4_Click(object sender, EventArgs e) //запустить вампуса
        {
            if (!Vampus.Start)
            {
                Vampus.XY = logic.GetCenterById(4);
                draw.DrawTrace(logic.BuildTrace(Vampus), getPB, vampusTrace, traps);
                Vampus.Start = true;
            }
        }

        private void button5_Click(object sender, EventArgs e) // запустить призрака
        {
            if (!Ghost.Start)
            {
                Ghost.XY = logic.GetCenterById(4);
                draw.DrawTrace(logic.BuildTrace(Ghost), getPB, ghostTrace, traps);
                Ghost.Start = true;
            }
        }
    }
}
