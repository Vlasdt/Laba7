using System;
using System.Windows.Forms;

namespace Laba7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TArrayContainer container = new TArrayContainer(@"C:\Users\user\source\repos\Laba7\Laba7\Array.txt");
            richTextBox1.Text = container.ToString();
        }
    }
}
