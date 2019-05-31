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
    public partial class Form9 : Form
    {
       
        public Form9()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");

            
            if(comboBox1.Text=="category")
            {
                

                con.Open();
                SqlCommand cmd = new SqlCommand(@"update book set category=@newdata where book_name=@txt",con);
                cmd.Parameters.Add(new SqlParameter("@txt", textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@newdata", textBox2.Text));

                cmd.ExecuteNonQuery();
                con.Close();
               
            }
            else if (comboBox1.Text == "price")
            {


                con.Open();
                SqlCommand cmd = new SqlCommand(@"update book set price=@newdata where book_name=@txt", con);
                cmd.Parameters.Add(new SqlParameter("@txt", textBox1.Text));
                cmd.Parameters.Add(new SqlParameter("@newdata", textBox2.Text));
                cmd.ExecuteNonQuery();

                con.Close();
            }
           
            

        }
    }
}
