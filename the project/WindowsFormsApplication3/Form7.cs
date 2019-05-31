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
    public partial class Form7 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
        public Form7()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) )
            {
                MessageBox.Show("please Enter publisher name and publisher mail");
            }
            else
            {
                con.Open();
                SqlCommand cm = new SqlCommand("check_publisher", con);
                cm.CommandType = CommandType.StoredProcedure;

                cm.Parameters.Add(new SqlParameter("@publishername", textBox2.Text));
                cm.Parameters.Add(new SqlParameter("@publishermail", textBox1.Text));

                SqlParameter output = new SqlParameter("@@out", SqlDbType.NVarChar);
                output.Direction = ParameterDirection.Output;
                output.Size = 50;
                cm.Parameters.Add(output);

                cm.ExecuteNonQuery();
                if (cm.Parameters["@@out"].Value is System.DBNull)
                {
                    SqlCommand cmd = new SqlCommand(@"insert into publisher (publisher_name,publisher_mail,p_code,p_phone_number)values(@name,@mail,@code,@phone)", con);
                    cmd.Parameters.Add(new SqlParameter("@name", textBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("@mail", textBox1.Text));
                    cmd.Parameters.Add(new SqlParameter("@code", textBox3.Text));
                    cmd.Parameters.Add(new SqlParameter("@phone", textBox4.Text));
                    cmd.ExecuteNonQuery();
                }
                else if (cm.Parameters["@@out"].Value.ToString() == "true")
                {
                    MessageBox.Show("the name or mail is already exist");
                    Form7 f = new Form7();
                    f.Show();
                    this.Hide();
                }
                con.Close();
            }
        }
    }
}
