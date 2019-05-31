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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Book")
            {
              
                form5 fff= new form5();
                 fff.Show();
                



            }
            else if(comboBox1.Text=="User")
            {

                Form6 f = new Form6();
                f.Show();
                

            }
            else if (comboBox1.Text == "Author")
            {

                Form8 f = new Form8();
                f.Show();
                

            }
            else if (comboBox1.Text == "Publisher")
            {

                Form7 f = new Form7();
                f.Show();
                

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Book")
            {

                Form9 fff = new Form9();
                fff.Show();
                



            }
            else if (comboBox1.Text == "User")
            {

                Form16 f = new Form16();
                f.Show();

            }
            else if (comboBox1.Text == "Author")
            {

                Form11 f = new Form11();
                f.Show();
                

            }
            else if (comboBox1.Text == "Publisher")
            {

                Form10 f = new Form10();
                f.Show();
               

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Book")
            {

                Form13 f = new Form13();
                f.Show();
                



            }
            else if (comboBox1.Text == "User")
            {

                Form12 f = new Form12();
                f.Show();
                

            }
            else if (comboBox1.Text == "Author")
            {

                Form15 f = new Form15();
                f.Show();
                

            }
            else if (comboBox1.Text == "Publisher")
            {

                Form14 f = new Form14();
                f.Show();
                

            }

        }
    }
}
