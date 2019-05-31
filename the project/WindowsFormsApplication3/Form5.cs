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
    public partial class form5: Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
        
        public form5()
        {
            InitializeComponent();
        }

        private void add_for_book_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox3.Text))
            {

                MessageBox.Show("You should Enter book name and price");
            }
            else
            {
                con.Open();
                SqlCommand cm = new SqlCommand("check_book", con);
                cm.CommandType = CommandType.StoredProcedure;

                cm.Parameters.Add(new SqlParameter("@bookname", textBox1.Text));
                SqlParameter output = new SqlParameter("@@out", SqlDbType.NVarChar);
                output.Direction = ParameterDirection.Output;
                output.Size = 50;
                cm.Parameters.Add(output);

                cm.ExecuteNonQuery();
                if (cm.Parameters["@@out"].Value is System.DBNull)
                {
                    SqlCommand cmd = new SqlCommand(@"insert into book  (book_name,category,price)values(@name,@category,@price)", con);
                    SqlParameter nam = new SqlParameter("@name", textBox1.Text);
                    cmd.Parameters.Add(nam);
                    cmd.Parameters.Add(new SqlParameter("@category", textBox2.Text));
                    cmd.Parameters.Add(new SqlParameter("@price", textBox3.Text));
                    cmd.ExecuteNonQuery();
                }
                else if (cm.Parameters["@@out"].Value .ToString()== "true")
                {
                    MessageBox.Show("this book already exists ");
                    form5 f = new form5();
                    f.Show();
                    this.Hide();
                }



             
                con.Close();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
