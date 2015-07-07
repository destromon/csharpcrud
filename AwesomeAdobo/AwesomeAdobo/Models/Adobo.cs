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

        protected List<Adobo> adobos = new List<Adobo>();

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
                MessageBox.Show(ex.Message.ToString());
            }
        }


        public List<Adobo> Read()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(AwesomeAdobo.Config.GetConnectionString()))
                {
                    //open connection
                    con.Open();

                    //set query string
                    string sql = "SELECT * FROM adobo WHERE active = 1";

                    //prepare command
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //execute query
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Adobo adobo = new Adobo();

                        adobo.id = int.Parse(reader["id"].ToString());
                        adobo.color = reader["adobo_color"].ToString();
                        adobo.taste = reader["adobo_taste"].ToString();
                        adobo.lapotness = reader["adobo_lapotness"].ToString();
                        adobo.typeOfMeat = reader["adobo_type_of_meat"].ToString();

                        adobos.Add(adobo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return adobos;
        }

        /// <summary>
        /// Get the selected id from the database.
        /// </summary>
        /// <returns>List</returns>
        public List<Adobo> GetById()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(AwesomeAdobo.Config.GetConnectionString()))
                {
                    //open connection
                    con.Open();

                    //set query string
                    string sql = "SELECT * FROM adobo WHERE id = @id";

                    //prepare command
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //set parameters
                    cmd.Parameters.AddWithValue("id", id);

                    //execute query
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Adobo adobo = new Adobo();

                        adobo.id = int.Parse(reader["id"].ToString());
                        adobo.color = reader["adobo_color"].ToString();
                        adobo.taste = reader["adobo_taste"].ToString();
                        adobo.lapotness = reader["adobo_lapotness"].ToString();
                        adobo.typeOfMeat = reader["adobo_type_of_meat"].ToString();

                        adobos.Add(adobo);
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return adobos;
        }

        public void Update()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(AwesomeAdobo.Config.GetConnectionString()))
                {
                    //open connection
                    con.Open();

                    //set query string
                    string sql = "UPDATE adobo SET adobo_color = @color, " +
                        "adobo_taste = @taste, " +
                        "adobo_lapotness = @lapotness, " +
                        "adobo_type_of_meat = @typeOfMeat " +
                        "WHERE id = @id";

                    //prepare command
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //set parameters
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("color", color);
                    cmd.Parameters.AddWithValue("taste", taste);
                    cmd.Parameters.AddWithValue("lapotness", lapotness);
                    cmd.Parameters.AddWithValue("typeOfMeat", typeOfMeat);

                    //execute query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uy, naupdate :)", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Delete()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(AwesomeAdobo.Config.GetConnectionString()))
                {
                    //open connection
                    con.Open();

                    //set query string
                    string sql = "UPDATE adobo SET active = 0 WHERE id = @id";

                    //prepare command
                    MySqlCommand cmd = new MySqlCommand(sql, con);

                    //set parameters
                    cmd.Parameters.AddWithValue("id", id);

                    //execute query
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Uy, nadelete :)", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}