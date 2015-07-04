using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeAdobo
{
    class Config
    {
        //server host name
        public static string DB_HOST = Properties.Settings.Default.HOST;

        //server database
        public static string DB_NAME = Properties.Settings.Default.DATABASE;

        //server username
        public static string DB_USER = Properties.Settings.Default.USERNAME;

        //server password
        public static string DB_PASSWORD = Properties.Settings.Default.PASSWORD;

        //server DSN
        public static string DSN = Properties.Settings.Default.DSN;

        /// <summary>
        /// save settings to property.
        /// </summary>
        public static void saveSettings()
        {
            Properties.Settings.Default.HOST = DB_HOST;
            Properties.Settings.Default.DATABASE = DB_NAME;
            Properties.Settings.Default.USERNAME = DB_USER;
            Properties.Settings.Default.PASSWORD = DB_PASSWORD;
            Properties.Settings.Default.DSN = DSN;

            //save settings
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Get all the credentials on the properties and create a connection string
        /// </summary>
        /// <returns>String - Connectionstring</returns>
        public static string GetConnectionString()
        {
            return string.Format("Server={0};Database={1};Uid={2};Pwd={3};Convert Zero Datetime=True; Default Command Timeout=0", DB_HOST, DB_NAME, DB_USER, DB_PASSWORD);
        }

        //test connection for server
        public static bool TestConnection()
        {
            try
            {
                //set database connection
                using (MySqlConnection con = new MySqlConnection(AwesomeAdobo.Config.GetConnectionString()))
                {
                    //open connection
                    con.Open();

                    return true;
                }
            }
            catch (MySqlException ex)
            {
                //revert settings
                Properties.Settings.Default.HOST = String.Empty;
                Properties.Settings.Default.DATABASE = String.Empty;
                Properties.Settings.Default.USERNAME = String.Empty;
                Properties.Settings.Default.PASSWORD = String.Empty;
                Properties.Settings.Default.DSN = String.Empty;

                //save settings
                Properties.Settings.Default.Save();

                //error configuration
                MessageBox.Show("Error: Cannot connect to server" + ex.Message.ToString(), "System Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
    }
}
