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
    public partial class frmConfig : Form
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void GetServerSettings()
        {
            txtDSN.Text = AwesomeAdobo.Config.DSN;
            txtHost.Text = AwesomeAdobo.Config.DB_HOST;
            txtName.Text = AwesomeAdobo.Config.DB_NAME;
            txtUser.Text = AwesomeAdobo.Config.DB_USER;
            txtPassword.Text = AwesomeAdobo.Config.DB_PASSWORD;
        }
        private void btnSaveConfiguration_Click(object sender, EventArgs e)
        {
            //set properties
            AwesomeAdobo.Config.DSN = txtDSN.Text;
            AwesomeAdobo.Config.DB_HOST = txtHost.Text;
            AwesomeAdobo.Config.DB_NAME = txtName.Text;
            AwesomeAdobo.Config.DB_USER = txtUser.Text;
            AwesomeAdobo.Config.DB_PASSWORD = txtPassword.Text;

            //save settings
            AwesomeAdobo.Config.saveSettings();

            if (AwesomeAdobo.Config.TestConnection())
            {
                MessageBox.Show("Database configuration has been successfully updated", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            this.GetServerSettings();
        }
    }
}
