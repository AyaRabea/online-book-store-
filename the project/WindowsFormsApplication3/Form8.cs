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
    public partial class Form8 : Form
    { 
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
        public Form8()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(String.IsNullOrEmpty(textBox1.Text) )
            {
                MessageBox.Show("please Enter Author name ");
            }
            else
            {
                con.Open();
                SqlCommand cm = new SqlCommand("check_author", con);
                cm.CommandType = CommandType.StoredProcedure;

                cm.Parameters.Add(new SqlParameter("@authorname", textBox1.Text));
                SqlParameter output = new SqlParameter("@@out", SqlDbType.NVarChar);
                output.Direction = ParameterDirection.Output;
                output.Size = 50;
                cm.Parameters.Add(output);

                cm.ExecuteNonQuery();
                if (cm.Parameters["@@out"].Value is System.DBNull)
                {
                    SqlCommand cmd = new SqlCommand(@"insert into author (author_name,date_of_birth,nationality)values(@name,@date,@nationality)", con);
                    cmd.Parameters.Add(new SqlParameter("@name", textBox1.Text));
                    cmd.Parameters.Add(new SqlParameter("@date", dateTimePicker1.Text));
                    cmd.Parameters.Add(new SqlParameter("@nationality", textBox3.Text));
                    cmd.ExecuteNonQuery();
                }
                else if (cm.Parameters["@@out"].Value.ToString() == "true")
                {
                    MessageBox.Show("this author already exists ");
                    Form8 f = new Form8();
                    f.Show();
                    this.Hide();
                }
                con.Close();
            }
        
        }
    }
}
