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
        //Placer placer = new Placer();
        
        public Form1()
        {
            InitializeComponent();
            draw.DrawMap(getPB);
            logic.SetupCenter();
        }

        

        private void button1_Click(object sender, EventArgs e) // стереть тракектории
        {

            draw.DrawRing(getPB);
        }
        
        private void button2_Click(object sender, EventArgs e) //перетасовать ловушки
        {
            draw.DrawMap(getPB);
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
            MessageBox.Show(logic.GetCenterById(2).ToString());
        }


        //Placer pl = new Placer();

        //pl.ReFill();
        //MessageBox.Show("OK");



    }
}
