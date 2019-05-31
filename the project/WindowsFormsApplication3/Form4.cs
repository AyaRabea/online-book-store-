using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace is_3
{
    
    public partial class Form4 : Form
    {
        string currentname;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
        public Form4(string u)
        {
            InitializeComponent();
            currentname = u;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            /*SqlCommand cm = new SqlCommand(@"select user_name from users where @user=user_name", con);

            SqlParameter user = new SqlParameter("@user", currentname);
            cm.Parameters.Add(user);

            string exist = (string)cm.ExecuteScalar();
            if (exist != currentname)
            {
                MessageBox.Show("invalid username");

            }*/

          //  else
            //{
                SqlCommand cmd = new SqlCommand("user_edit", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter("@username",currentname);
                cmd.Parameters.Add(username);


                SqlParameter columnname = new SqlParameter("@columnname", comboBox1.Text);
                cmd.Parameters.Add(columnname);

                SqlParameter newdata = new SqlParameter("@newdata", textBox2.Text);
                cmd.Parameters.Add(newdata);

                cmd.ExecuteNonQuery();
            //}

            con.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
