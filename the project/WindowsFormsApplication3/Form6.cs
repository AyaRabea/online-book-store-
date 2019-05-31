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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) ||
                String.IsNullOrEmpty(textBox6.Text) || checkBox1.Checked == checkBox2.Checked)
            {
                MessageBox.Show("please enter username , mail and password ,  choose one way to pay  ");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("register", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter("@username", textBox3.Text);
                cmd.Parameters.Add(username);

                SqlParameter usermail = new SqlParameter("@usermail", textBox4.Text);
                cmd.Parameters.Add(usermail);

                SqlParameter result = new SqlParameter("@@out", SqlDbType.NVarChar);
                result.Direction = ParameterDirection.Output;
                result.Size = 50;
                cmd.Parameters.Add(result);

                cmd.ExecuteNonQuery();
                if (cmd.Parameters["@@out"].Value is System.DBNull)
                {
                    SqlCommand cmd2 = new SqlCommand("add_user", con);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    SqlParameter user_name = new SqlParameter("@username", textBox2.Text);
                    cmd2.Parameters.Add(user_name);

                    SqlParameter user_mail = new SqlParameter("@usermail", textBox3.Text);
                    cmd2.Parameters.Add(user_mail);

                    SqlParameter usercode = new SqlParameter("@usercode", textBox4.Text);
                    cmd2.Parameters.Add(usercode);

                    SqlParameter userphone = new SqlParameter("@userphone", textBox5.Text);
                    cmd2.Parameters.Add(userphone);

                    SqlParameter userpassword = new SqlParameter("@password", textBox6.Text);
                    cmd2.Parameters.Add(userpassword);

                    SqlParameter userregion = new SqlParameter("@region", textBox1.Text);
                    cmd2.Parameters.Add(userregion);

                    SqlParameter userstreet = new SqlParameter("@street", textBox8.Text);
                    cmd2.Parameters.Add(userstreet);
                    if (checkBox1.Checked == true)
                    {
                        cmd2.Parameters.Add(new SqlParameter("@wayofpay", "cash"));
                    }
                    else
                    {
                        cmd2.Parameters.Add(new SqlParameter("@wayofpay", "credit"));
                    }

                    cmd2.ExecuteNonQuery();

                }


                else if (cmd.Parameters["@@out"].Value.ToString() == "false")
                {
                    MessageBox.Show("invalid username or user mail ,please try again");

                }

                con.Close();

            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
