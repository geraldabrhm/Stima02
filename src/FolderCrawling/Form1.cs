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
using System.Diagnostics;

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

        private void button2_Click(object sender, EventArgs e)
        {
            linkLabel1.Visible = false;
            linkLabel2.Visible = false;
            linkLabel2.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            
            bool touch = false;
            foreach(Edge edge in graph.Edges.ToArray())
            {
                graph.RemoveEdge(edge);
            }
            foreach (Node node in graph.Nodes.ToArray())
            {
                graph.RemoveNode(node);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (checkBox1.Checked && radioButton1.Checked)
            {
                // Do BFS and find all occurences
                touch = true;
            }
            else if (checkBox1.Checked && radioButton2.Checked)
            {
                // Do DFS and find all occurences
                string[] paths = DFS.searchAll(selectedDir, textBox1.Text);
                for(int i = 0; i < paths.Length; i++)
                {
                    if(i == 0)
                    {
                        string pathWithFile = paths[0] + "\\" + textBox1.Text;
                        linkLabel1.Text = pathWithFile;
                        linkLabel1.Visible = true;
                        label11.Visible = true;
                    } 
                    else if(i == 1)
                    {
                        string pathWithFile = paths[1] + "\\" + textBox1.Text;
                        linkLabel2.Text = pathWithFile;
                        linkLabel2.Visible = true;
                        label12.Visible = true;
                    }
                    else if(i == 2)
                    {
                        string pathWithFile = paths[2] + "\\" + textBox1.Text;
                        linkLabel3.Text = pathWithFile;
                        linkLabel3.Visible = true;
                        label13.Visible = true;
                    }
                    else
                    {
                        break;
                    }
                }
                if (paths.Length != 0)
                {
                    label10.Visible = true;
                    touch = true;
                }
            }
            else if (!checkBox1.Checked && radioButton1.Checked)
            {
                // Do BFS and find the first occurence only
                touch = true;
            }
            else if (!checkBox1.Checked && radioButton2.Checked)
            {
                // Do DFS and find the first occurence only
                string path = DFS.searchOne(selectedDir, textBox1.Text);
                if (path != "") 
                {
                    string pathWithFile = path + "\\" + textBox1.Text;
                    linkLabel1.Text = pathWithFile;
                    linkLabel1.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    touch = true;
                } else
                {
                    MessageBox.Show("File Not Found", "Result");
                }
            }
            else
            {
                MessageBox.Show("Please choose any searching algorithm option", "ErrorMessage");
            }
            stopwatch.Stop();
            if(touch)
            {
                label15.Text = stopwatch.ElapsedMilliseconds.ToString() + " ms";
                label15.Visible = true;
                label14.Visible = true;
            }
            Form1.viewer.Graph = graph;
        }

        protected void panel1_Paint(object sender, PaintEventArgs e)
        {
            viewer.Graph = graph;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            viewer.ToolBarIsVisible = false;
            this.panel1.Controls.Add(viewer);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = linkLabel1.Text.Split('\\').Last();
            string stringToRemove = "\\" + fileName;
            string copyLinkLabel1 = linkLabel1.Text;
            int index = linkLabel1.Text.IndexOf(stringToRemove);
            string clean = (index < 0) ? fileName : copyLinkLabel1.Remove(index, stringToRemove.Length);
            Process.Start(@clean);
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = linkLabel2.Text.Split('\\').Last();
            string stringToRemove = "\\" + fileName;
            string copyLinkLabel2 = linkLabel2.Text;
            int index = linkLabel2.Text.IndexOf(stringToRemove);
            string clean = (index < 0) ? fileName : copyLinkLabel2.Remove(index, stringToRemove.Length);
            Process.Start(@clean);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileName = linkLabel3.Text.Split('\\').Last();
            string stringToRemove = "\\" + fileName;
            string copyLinkLabel3 = linkLabel3.Text;
            int index = linkLabel3.Text.IndexOf(stringToRemove);
            string clean = (index < 0) ? fileName : copyLinkLabel3.Remove(index, stringToRemove.Length);
            Process.Start(@clean);
        }
    }
}
