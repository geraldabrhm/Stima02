using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Msagl.Drawing;

namespace FolderCrawling
{
    class BFS : Form1
    {
        
    }
    
    class DFS : Form1
    {
        public static string[] searchAll(string selectedDir, string file)
        {
            string[] path = {};
            string[] dirs = Directory.GetDirectories(selectedDir, "*.", SearchOption.TopDirectoryOnly);
            string[] files = Directory.GetFiles(selectedDir);
            bool found = false;

            int i = 0;
            while (!found && i < files.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last());
                if (file == files[i].Split('\\').Last())
                {
                    List<string> ls = path.ToList();
                    ls.Add(selectedDir);
                    path = ls.ToArray();
                    found = true;
                }
                i++;
            }
            
            for (i = 0; i < dirs.Length; i++)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), dirs[i].Split('\\').Last());
                List<string> ls = path.ToList();
                path = ls.Concat(searchAll(dirs[i],file).ToList()).ToArray();
            }
            return path;
        }

        public static string searchOne(string selectedDir, string file)
        {
            string path = String.Empty;
            string[] dirs = Directory.GetDirectories(selectedDir, "*.", SearchOption.TopDirectoryOnly);
            string[] files = Directory.GetFiles(selectedDir);
            bool found = false;
            int i = 0;

            while (!found && i < files.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last());
                if (file.Equals(files[i].Split('\\').Last()))
                {
                    path = selectedDir;
                    found = true;
                }
                i++;
            }

            i = 0;
            while (!found && i < dirs.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), dirs[i].Split('\\').Last());
                path = searchOne(dirs[i], file);
                if (path != String.Empty)
                {
                    found = true;
                }
                i++;
            }
            string[] splitPathResult = path.Split('\\');
            //foreach(string toDelete in splitPathResult)
            //for(int j = 1; j < splitPathResult.Length; j++)
            //{
            //    MessageBox.Show(splitPathResult[j]);
            //    // graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            //    Form1.graph.FindNode(splitPathResult[j]).Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            //}
            Form1.graph.FindNode(selectedDir.Split('\\').Last()).Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            return path;
        }
    }
}
