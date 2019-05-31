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
   
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();

            textBox2.PasswordChar = '*';
            textBox5.PasswordChar = '*';
            textBox2.MaxLength = 20;
            textBox5.MaxLength = 20;
        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                Form3 ff = new Form3();
                ff.Show();
                
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("check_login", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter username = new SqlParameter("@username", textBox1.Text);
                cmd.Parameters.Add(username);

                SqlParameter password = new SqlParameter("@password", textBox2.Text);
                cmd.Parameters.Add(password);

                SqlParameter result = new SqlParameter("@@out", SqlDbType.NVarChar);
                result.Direction = ParameterDirection.Output;
                result.Size = 50;
                cmd.Parameters.Add(result);

                cmd.ExecuteNonQuery();

                if (cmd.Parameters["@@out"].Value is System.DBNull)
                {
                    MessageBox.Show("invalid username & password , please try again ");
                }
                else if (cmd.Parameters["@@out"].Value.ToString() == textBox1.Text)
                {
                    Form2 f = new Form2(textBox1.Text);
                    f.Show();
                   
                }

                con.Close();
            }
            

           
        }

        private void button2_Click(object sender, EventArgs e)
        {

              if (String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text) ||
                String.IsNullOrEmpty(textBox5.Text) ||checkBox1.Checked ==checkBox2.Checked )
                 
            {
                MessageBox.Show("please enter username , mail and password ,  choose one way to pay  ");
            }
              else{
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

                    SqlParameter user_name = new SqlParameter("@username", textBox3.Text);
                    cmd2.Parameters.Add(user_name);

                    SqlParameter user_mail = new SqlParameter("@usermail", textBox4.Text);
                    cmd2.Parameters.Add(user_mail);

                    SqlParameter usercode = new SqlParameter("@usercode", textBox6.Text);
                    cmd2.Parameters.Add(usercode);

                    SqlParameter userphone = new SqlParameter("@userphone", textBox7.Text);
                    cmd2.Parameters.Add(userphone);

                    SqlParameter userpassword = new SqlParameter("@password", textBox5.Text);
                    cmd2.Parameters.Add(userpassword);

                    SqlParameter userregion = new SqlParameter("@region", textBox8.Text);
                    cmd2.Parameters.Add(userregion);

                    SqlParameter userstreet = new SqlParameter("@street", textBox9.Text);
                    cmd2.Parameters.Add(userstreet);

                 //   SqlParameter wayofpay = new SqlParameter("@wayofpay", textBox10.Text);
                   // cmd2.Parameters.Add(wayofpay);
                    if (checkBox1.Checked == true)
                    {
                        cmd2.Parameters.Add(new SqlParameter("@wayofpay","cash"));
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

                Form1 f = new Form1();
                f.Show();
                this.Hide();

               
                con.Close();
            
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
