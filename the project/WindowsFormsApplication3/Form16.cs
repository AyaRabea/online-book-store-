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
    public partial class Form16 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
        public Form16()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("user_edit", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter username = new SqlParameter("@username", textBox1.Text);
            cmd.Parameters.Add(username);


            SqlParameter columnname = new SqlParameter("@columnname", comboBox1.Text);
            cmd.Parameters.Add(columnname);

            SqlParameter newdata = new SqlParameter("@newdata", textBox2.Text);
            cmd.Parameters.Add(newdata);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
