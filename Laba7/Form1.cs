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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                    TArrayContainer container = new TArrayContainer(openFileDialog.FileName);
                    foreach(var a in container.Arrays)
                {
                    if(a is TSortedArray<int> || a is TSortedArray<float>)SortedColumn.AppendText( a + "\n");
                    else UnsortedColumn.AppendText(a + "\n");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
