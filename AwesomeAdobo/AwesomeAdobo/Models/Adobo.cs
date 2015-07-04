using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AwesomeAdobo
{
    class Adobo
    {        
        /**********************************************
         * Protected Properties
         * ********************************************/
        protected int id;
        protected string color;
        protected string taste;
        protected string lapotness;
        protected string typeOfMeat;

        /**********************************************
         * Private Properties
         * ********************************************/

        /**********************************************
         * Public Properties
         * ********************************************/
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Taste
        {
            get { return taste; }
            set { taste = value; }
        }

        public string Lapotness
        {
            get { return lapotness; }
            set { lapotness = value; }
        }

        public string TypeOfMeat
        {
            get { return typeOfMeat; }
            set { typeOfMeat = value; }
        }

        /**********************************************
         * Constructor
         * ********************************************/
        
        /**********************************************
         * Protected Methods
         * ********************************************/
        
        /**********************************************
         * Private Methods
         * ********************************************/
        
        /**********************************************
         * Public Methods
         * ********************************************/

        /// <summary>
        /// Insert data to the database
        /// </summary>
        public void Save()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(AwesomeAdobo.Config.GetConnectionString()))
                {
                    //open connection
                    con.Open();

                    //set query string
                    string sql = "INSERT INTO adobo(adobo_color, adobo_taste, adobo_lapotness, adobo_type_of_meat) " +
                        "VALUES(@color, @taste, @lapotness, @typeOfMeatPo)";

                    //perpare connection and query string
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //set parameters
                    cmd.Parameters.AddWithValue("color", color);
                    cmd.Parameters.AddWithValue("taste", taste);
                    cmd.Parameters.AddWithValue("lapotness", lapotness);
                    cmd.Parameters.AddWithValue("typeOfMeatPo", typeOfMeat);

                    //execute query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("New adobo recipe has been added.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}