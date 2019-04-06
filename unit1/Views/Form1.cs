using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        int[] traps = new int[9];
        
        public Form1()
        {
            InitializeComponent();
            draw.DrawMap(getPB);
            Meow = new Entity(logic.GetCenterById(4));
            Vampus = new Entity(logic.GetCenterById(4));
            Ghost = new Entity(logic.GetCenterById(4));
            logic.SetupCenters();
            traps = logic.SetupTraps();
            draw.DrawTraps(getPB, traps);
        }

        
        private void button1_Click(object sender, EventArgs e) // стереть тракектории
        {
            draw.DrawMap(getPB);
            draw.DrawTraps(getPB, traps);
            Meow.start = false;
            Vampus.start = false;
            Ghost.start = false;
        }
        
        private void button2_Click(object sender, EventArgs e) //перетасовать ловушки
        {
            draw.DrawMap(getPB);
            traps = logic.SetupTraps();
            draw.DrawTraps(getPB, traps);
            Meow.start = false;
            Vampus.start = false;
            Ghost.start = false;
        }

        public PictureBox getPB
        {
            get
            {
                return pictureBox1;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!Meow.start)
            {
                Meow.XY = logic.GetCenterById(4);
                draw.DrawTrace(logic.BuildTrace(Meow), getPB, catTrace);
                Meow.start = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Vampus.start)
            {
                Vampus.XY = logic.GetCenterById(4);
                draw.DrawTrace(logic.BuildTrace(Vampus), getPB, vampusTrace);
                Vampus.start = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!Ghost.start)
            {
                Ghost.XY = logic.GetCenterById(4);
                draw.DrawTrace(logic.BuildTrace(Ghost), getPB, ghostTrace);
                Ghost.start = true;
            }
        }



    }
}
