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
using Microsoft.Msagl.Drawing;

namespace FolderCrawling
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        protected static string selectedDir = string.Empty;
        protected static string[] dirs = new string[] {};
        protected static string[] files = new string[] {};
        public static Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
        public static Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
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
            if (objPath.ShowDialog() == DialogResult.OK)
            {
                selectedDir = objPath.SelectedPath;
                MessageBox.Show("You have selected " + selectedDir);
                label5.Text = selectedDir;
                label5.ForeColor = System.Drawing.Color.Green;

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
                if (selectedDir == "")
                {
                    MessageBox.Show("You haven't pick any folder yet");
                    label5.Text = "No File Chosen";
                    label5.ForeColor = System.Drawing.Color.Black;
                } else
                {
                    MessageBox.Show("Your current selected dir the same as before: " + selectedDir);
                    label5.Text = selectedDir;
                    label5.ForeColor = System.Drawing.Color.Green;
                }
                 
            }
            if(selectedDir != "")
            {
                dirs = Directory.GetDirectories(selectedDir, "*.", SearchOption.TopDirectoryOnly);
                files = Directory.GetFiles(selectedDir);
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
            foreach(Edge edge in graph.Edges.ToArray())
            {
                graph.RemoveEdge(edge);
            }
            foreach (Node node in graph.Nodes.ToArray())
            {
                graph.RemoveNode(node);
            }
            if (checkBox1.Checked && radioButton1.Checked)
            {
                // Do BFS and find all occurences
            }
            else if (checkBox1.Checked && radioButton2.Checked)
            {
                // Do DFS and find all occurences
                string[] path = DFS.searchAll(selectedDir, textBox1.Text);
                for (int i = 0; i < path.Length; i++)
                {
                    MessageBox.Show(path[i]);
                }
            }
            else if(!checkBox1.Checked && radioButton1.Checked)
            {
                // Do BFS and find the first occurence only 
            }
            else if(!checkBox1.Checked && radioButton2.Checked)
            {
                // Do DFS and find the first occurence only
                string path = DFS.searchOne(selectedDir, textBox1.Text);
                //MessageBox.Show(DFS.searchOne(selectedDir,textBox1.Text));
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
            Form1.viewer.Graph = graph;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }


        protected void panel1_Paint(object sender, PaintEventArgs e)
        {

            ////this.Controls.Add(viewer);
            ////create the graph content 
            //graph.AddEdge("A", "B");
            //graph.AddEdge("B", "C");
            //graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            ////bind the graph to the viewer 
            //graph.AddEdge("C://", "files.txt");
            viewer.Graph = graph;
            //associate the viewer with the form 
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            viewer.ToolBarIsVisible = false;
            this.panel1.Controls.Add(viewer);
            //show the form 
        }
    }
}
