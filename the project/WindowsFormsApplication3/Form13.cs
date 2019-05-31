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
    public partial class Form13 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=onlinebookstore;Integrated Security=True");
        public Form13()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            
            SqlCommand cm = new SqlCommand(@"select book_ID from book where book_name=@nam", con);
            cm.Parameters.Add(new SqlParameter("@nam ", textBox1.Text));
            int book_id = (int)cm.ExecuteScalar();

            SqlCommand c = new SqlCommand(@"delete from buy where book_ID=@book_id", con);
            c.Parameters.Add(new SqlParameter("@book_id ", book_id));
            c.ExecuteNonQuery();

            SqlCommand cmd = new SqlCommand(@"delete from book  where book_name=@name ", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add(new SqlParameter("@name", textBox1.Text));
            cmd.ExecuteNonQuery();

            con.Close();

        }
    }
}
