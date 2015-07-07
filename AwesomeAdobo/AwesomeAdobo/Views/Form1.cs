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

        List<Adobo> adobos = new List<Adobo>();
        public void Edit(int id)
        {
            //set object properties
            adobo.Id = id;

            //clear list
            adobos.Clear();

            //get the data using the supplied attributes
            adobos = adobo.GetById();

            textBox1.Text = adobos[0].Color;
            textBox2.Text = adobos[0].Taste;
            textBox3.Text = adobos[0].Lapotness;
            textBox4.Text = adobos[0].TypeOfMeat;

            //change the caption of the button save
            button1.Text = "Update";
        }
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

            if (button1.Text == "Save")
            {
                adobo.Save();
            }
            else
            {
                adobo.Update();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmConfig frmConfig = new frmConfig();
            frmConfig.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
