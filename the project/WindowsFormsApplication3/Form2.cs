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
    public partial class Form2 : Form
    {
        string currentname;
        SqlConnection c = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
       
        public Form2(string u)
        {
            InitializeComponent();
            currentname = u;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Open();
            SqlCommand cm = new SqlCommand("check_book", c);
            cm.CommandType = CommandType.StoredProcedure;

            SqlParameter b_name = new SqlParameter("@bookname", textBox1.Text);
            cm.Parameters.Add(b_name);

            SqlParameter output = new SqlParameter("@@out", SqlDbType.NVarChar);
            output.Size = 50;
            output.Direction = ParameterDirection.Output;
            cm.Parameters.Add(output);

            cm.ExecuteNonQuery();
            if(cm.Parameters["@@out"].Value is System.DBNull)
            {
                MessageBox.Show("this book is unavailable");
            }
            else
            {
                SqlCommand cmd_book = new SqlCommand("book_data", c);
                cmd_book.CommandType = CommandType.StoredProcedure;

                SqlParameter book_n = new SqlParameter("@book_n",textBox1.Text);
                cmd_book.Parameters.Add(book_n);
                SqlDataReader reader = cmd_book.ExecuteReader();

                DataTable t = new DataTable();
                t.Columns.Add("book_ID");
                t.Columns.Add("book_name");
                t.Columns.Add("category");
                t.Columns.Add("price");
               
                DataRow row;
                while(reader.Read())
                {
                    row = t.NewRow();
                    row["book_ID"] = reader["book_ID"];
                    row["book_name"] = reader["book_name"];
                    row["category"] = reader["category"];
                    row["price"] = reader["price"];
                  
                    t.Rows.Add(row);
                }
                reader.Close();
                dataGridView1.DataSource = t;
            }

            c.Close();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.Open();
            string table = @"select book_ID,book_name,category,price from book";
            SqlCommand cmd = new SqlCommand(table, c);

            cmd.CommandType = CommandType.Text;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable t = new DataTable();
            
            t.Columns.Add("book_ID");
            t.Columns.Add("book_name");
            t.Columns.Add("category");
            t.Columns.Add("price");
            
            DataRow row;
            while (reader.Read())
            {
                row = t.NewRow();
                
                row["book_ID"] = reader["book_ID"];
                row["book_name"] = reader["book_name"];
                row["category"] = reader["category"];
                row["price"] = reader["price"];
                
                t.Rows.Add(row);
            }
            reader.Close();

            dataGridView1.DataSource = t;
            c.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(currentname);
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            c.Open();
            SqlCommand cmd = new SqlCommand(@"select book_ID from book where @bookname=book_name", c);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@bookname", textBox1.Text));
            int bookid = (int)cmd.ExecuteScalar();

            SqlCommand cm= new SqlCommand(@"select user_ID from users where @username=user_name", c);
           cm.CommandType = CommandType.Text;
            cm.Parameters.Add(new SqlParameter("@username", currentname));
            int userid = (int)cm.ExecuteScalar();

            SqlCommand com = new SqlCommand(@"insert into buy(user_ID,book_ID) values(@u_id,@b_id)", c);
           com.CommandType = CommandType.Text;

            com.Parameters.Add(new SqlParameter("@u_id",userid));
            com.Parameters.Add(new SqlParameter("@b_id", bookid));

            com.ExecuteNonQuery(); 

            c.Close();
        }
    }
}
