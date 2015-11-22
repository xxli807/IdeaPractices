using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryDecimalConverterApp
{
    public partial class Form1 : Form
    {
        public List<int> binarys = new List<int>();
        public Regex regex = new Regex("^\\d+$");

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text)) { 

                if (regex.IsMatch(textBox1.Text))
                {
                    //classic way
                    binarys.Clear();
                    ConvertToDecimal(int.Parse(textBox1.Text));
                    binarys.Reverse();
                    this.textBox2.Text = string.Join("", binarys);

                    //easyway
                    //this.textBox2.Text = Convert.ToString(int.Parse(textBox1.Text), 2);
                }
                else
                    MessageBox.Show("Only Numbers are allowed.");
               
            }
        }

         
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                if (regex.IsMatch(textBox2.Text)) { 
                    //easyway
                    this.textBox1.Text = Convert.ToInt32(textBox2.Text, 2).ToString();
                }
                else
                    MessageBox.Show("Only Numbers are allowed.");
            }
        }

         
        private void ConvertToDecimal(int binary)
        {
            var reminder = binary % 2;
            var result = binary / 2;

            if (result != 0)
            {
                binarys.Add(reminder);
                ConvertToDecimal(result);
            }
            else
            {
                binarys.Add(reminder);
            }
        }
    }
}
