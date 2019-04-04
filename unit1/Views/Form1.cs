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
        Pen catTrace = new Pen(Color.FromArgb(255, 58, 119, 227), 3);

        int[] traps = new int[9];
        //Placer placer = new Placer();
        
        public Form1()
        {
            InitializeComponent();
            draw.DrawMap(getPB);
        }

        
        private void button1_Click(object sender, EventArgs e) // стереть тракектории
        {
            draw.DrawMap(getPB);
            //draw.DrawRing(getPB);
        }
        
        private void button2_Click(object sender, EventArgs e) //перетасовать ловушки
        {
            draw.DrawMap(getPB);
            logic.ClearTraps();
            logic.SetupCenters();
            draw.PlaceTraps(getPB, logic.SetupTraps());
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
            //MessageBox.Show(logic.GetCenterById(4).ToString());
            //draw.DrawTrace(getPB);
            Entity Meow = logic.Start();
            draw.DrawTrace(logic.BuildTrace(Meow), getPB, catTrace);
            //MessageBox.Show(logic.BuildTrace(Meow).ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }


        //Placer pl = new Placer();

        //pl.ReFill();
        //MessageBox.Show("OK");



    }
}
