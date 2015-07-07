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
    public partial class Form2 : Form
    {
        //instantiate model
        Adobo adobo = new Adobo();

        //list
        List<Adobo> adobos = new List<Adobo>();
        public void Render()
        {
            //clear adobo list
            adobos.Clear();

            //perform query
            adobos = adobo.Read();

            //clear listview
            listView1.Items.Clear();

            //loop through list and add the record to listview
            foreach (Adobo item in adobos)
            {
                listView1.Items.Add(item.Id.ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.Color);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.Taste);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.Lapotness);
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(item.TypeOfMeat);
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();

            Render();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Render();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pass the id on the edit dialog/form
            Form1 form1 = new Form1();
            form1.Edit(int.Parse(listView1.SelectedItems[0].Text));
            form1.ShowDialog();
            //open the form

            //refresh list
            Render();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //set id to be deleted
            adobo.Id = int.Parse(listView1.SelectedItems[0].Text);

            adobo.Delete();

            //refresh
            Render();
        }
    }
}
