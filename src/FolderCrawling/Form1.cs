using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FolderCrawling
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog objPath = new FolderBrowserDialog();
            string selectedDir = string.Empty;

            if (objPath.ShowDialog() == DialogResult.OK)
            {
                selectedDir = objPath.SelectedPath;
                MessageBox.Show("You have selected " + selectedDir);
                label5.Text = selectedDir;
                label5.ForeColor = System.Drawing.Color.Green;

                /* This is how to get file and subdirectory names of selectedDir */
                //string[] dirs = Directory.GetDirectories(selectedDir, "*.", SearchOption.TopDirectoryOnly);
                //string[] files = Directory.GetFiles(selectedDir);
                /* Display the content */
                //foreach (string dir in dirs)
                //{
                //    MessageBox.Show(dir);
                //}
                //foreach (string file in files)
                //{
                //    MessageBox.Show(file);
                //}
            } else
            {
                MessageBox.Show("You haven't pick any folder yet");
                label5.Text = "No File Chosen";
                label5.ForeColor = System.Drawing.Color.Black;
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && radioButton1.Checked)
            {
                // Do BFS and find all occurences
            }
            else if (checkBox1.Checked && radioButton2.Checked)
            {
                // Do DFS and find all occurences
            }
            else if(!checkBox1.Checked && radioButton1.Checked)
            {
                // Do BFS and find the first occurence only 
            }
            else if(!checkBox1.Checked && radioButton2.Checked)
            {
                // Do BFS and find the first occurence only
            }
            else
            {
                MessageBox.Show("Please choose any search algorithm option", "ErrorMessage");
            }

            /* Currently failed switch case, find out more soon */
            //string a = "default";
            //(checkBox1.Checked, radioButton1.Checked) switch
            //{
            //    (true, true) => string a = "aa",
            //    (true, false) => string a = "ab",
            //    (false, true) => string a = "ac",
            //    (false, false) => string a = "ad",
            //};
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
