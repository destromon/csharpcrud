using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeAdobo
{
    public partial class Form1 : Form
    {
        //instantiate model
        Adobo adobo = new Adobo();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //set object properties
            adobo.Color = textBox1.Text;
            adobo.Taste = textBox2.Text;
            adobo.Lapotness = textBox3.Text;
            adobo.TypeOfMeat = textBox4.Text;

            adobo.Save();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.Show();
        }
    }
}
