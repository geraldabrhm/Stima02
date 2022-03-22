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
        public static List<string> waitingList = new List<string> {};
        public static string[] searchAll(string selectedDir, string file)
        {
            string[] paths = { };
            string[] dirs = Directory.GetDirectories(selectedDir, "*.", SearchOption.TopDirectoryOnly);
            string[] files = Directory.GetFiles(selectedDir);
            bool found = false;
            int i = 0;        

            Form1.graph.AddNode(selectedDir.Split('\\').Last()).Attr.FillColor = Color.Red; //buat node

            while(!found && i < files.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last()).Attr.Color = Color.Red;
                Form1.graph.FindNode(files[i].Split('\\').Last()).Attr.FillColor = Color.Red;
                if (file == files[i].Split('\\').Last())
                {
                    Form1.graph.FindNode(files[i].Split('\\').Last()).Attr.FillColor = Color.LightBlue;
                    List<string> ls = paths.ToList();
                    ls.Add(selectedDir);
                    paths = ls.ToArray();
                    found = true;
                }
                i++;
            }

            while (i < files.Length) {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last());
                i++;
            }

            foreach(var dir in dirs)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), dir.Split('\\').Last()); 
                waitingList.Add(dir);
            }

            if (waitingList.Count() != 0)
            {
                foreach (var edge in Form1.graph.Edges)
                {
                    if (edge.Target == waitingList[0].Split('\\').Last())
                    {
                        edge.Attr.Color = Color.Red;
                    }
                }
                Form1.graph.FindNode(waitingList[0].Split('\\').Last()).Attr.FillColor = Color.Red;
                string prioDir = waitingList[0];
                waitingList.RemoveAt(0);
                List<string> ls = paths.ToList();
                paths = ls.Concat(searchAll(prioDir,file).ToList()).ToArray();
            }

            foreach (var path in paths)
            {
                string[] splitPathResult = path.Split('\\');
                for (i = 0; i < splitPathResult.Length; i++)
                {
                    Node node = Form1.graph.FindNode(splitPathResult[i]);
                    if (node != null)
                    {
                        node.Attr.FillColor = Color.LightBlue;
                        if (i == splitPathResult.Length - 1)
                        {
                            foreach (var edge in Form1.graph.Edges)
                            {
                                if (edge.Source == splitPathResult[i] && edge.Target == file)
                                {
                                    edge.Attr.Color = Color.LightBlue;
                                }
                            }
                        }
                        else
                        {
                            foreach (var edge in Form1.graph.Edges)
                            {
                                if (edge.Source == splitPathResult[i] && edge.Target == splitPathResult[i + 1])
                                {
                                    edge.Attr.Color = Color.LightBlue;
                                }
                            }
                        }
                    }
                }
            }

            return paths;
        }

        public static string searchOne(string selectedDir, string file)
        {
            string path = "";
            string[] dirs = Directory.GetDirectories(selectedDir, "*.", SearchOption.TopDirectoryOnly);
            string[] files = Directory.GetFiles(selectedDir);
            bool found = false;
            int i = 0;

            Form1.graph.AddNode(selectedDir.Split('\\').Last()).Attr.FillColor = Color.Red; //buat node path awal

            while (!found && i < files.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last()).Attr.Color = Color.Red; //beri warna merah pada edge
                Form1.graph.FindNode(files[i].Split('\\').Last()).Attr.FillColor = Color.Red; //beri warna merah pada node file
                if (file == files[i].Split('\\').Last())
                {
                    Form1.graph.FindNode(files[i].Split('\\').Last()).Attr.FillColor = Color.LightBlue; //beri warna biru pada node file
                    path = selectedDir;
                    found = true;
                }
                i++;
            }

            while (i < files.Length) {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last());
                i++;
            }

            foreach (var dir in dirs)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), dir.Split('\\').Last()); 
                waitingList.Add(dir);
            }

            if (waitingList.Count() != 0 && !found)
            {
                foreach (var edge in Form1.graph.Edges)
                {
                    if (edge.Target == waitingList[0].Split('\\').Last())
                    {
                        edge.Attr.Color = Color.Red;
                    }
                }
                Form1.graph.FindNode(waitingList[0].Split('\\').Last()).Attr.FillColor = Color.Red;
                string prioDir = waitingList[0];
                waitingList.RemoveAt(0);
                path = searchOne(prioDir, file);
            }

            string[] splitPathResult = path.Split('\\');
            for (i = 0; i < splitPathResult.Length; i++) {
                Node node = Form1.graph.FindNode(splitPathResult[i]);
                if (node != null)
                {
                    node.Attr.FillColor = Color.LightBlue;
                    if (i == splitPathResult.Length - 1)
                    {
                        foreach (var edge in Form1.graph.Edges)
                        {
                            if (edge.Source == splitPathResult[i] && edge.Target == file)
                            {
                                edge.Attr.Color = Color.LightBlue;
                            }
                        }
                    } else
                    {
                        foreach (var edge in Form1.graph.Edges)
                        {
                            if (edge.Source == splitPathResult[i] && edge.Target == splitPathResult[i+1])
                            {
                                edge.Attr.Color = Color.LightBlue;
                            }
                        }
                    }
                }
            }

            return path;
        }
    }
    
    class DFS : Form1
    {
        public static string[] searchAll(string selectedDir, string file)
        {
            string[] paths = {};
            string[] dirs = Directory.GetDirectories(selectedDir, "*.", SearchOption.TopDirectoryOnly);
            string[] files = Directory.GetFiles(selectedDir);
            bool found = false;
            int i = 0;

            Form1.graph.AddNode(selectedDir.Split('\\').Last()).Attr.FillColor = Color.Red;
            while (!found && i < files.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last()).Attr.Color = Color.Red;
                Form1.graph.FindNode(files[i].Split('\\').Last()).Attr.FillColor = Color.Red;
                if (file == files[i].Split('\\').Last())
                {
                    Form1.graph.FindNode(files[i].Split('\\').Last()).Attr.FillColor = Color.LightBlue;
                    List<string> ls = paths.ToList();
                    ls.Add(selectedDir);
                    paths = ls.ToArray();
                    found = true;
                }
                i++;
            }

            while (i < files.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last());
                i++;
            }


            for (i = 0; i < dirs.Length; i++)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), dirs[i].Split('\\').Last()).Attr.Color = Color.Red;
                Form1.graph.FindNode(dirs[i].Split('\\').Last()).Attr.FillColor = Color.Red;
                List<string> ls = paths.ToList();
                paths = ls.Concat(searchAll(dirs[i],file).ToList()).ToArray();
            }

            foreach (var path in paths)
            {
                string[] splitPathResult = path.Split('\\');
                for (i = 0; i < splitPathResult.Length; i++)
                {
                    Node node = Form1.graph.FindNode(splitPathResult[i]);
                    if (node != null)
                    {
                        node.Attr.FillColor = Color.LightBlue;
                        if (i == splitPathResult.Length - 1)
                        {
                            foreach (var edge in Form1.graph.Edges)
                            {
                                if (edge.Source == splitPathResult[i] && edge.Target == file)
                                {
                                    edge.Attr.Color = Color.LightBlue;
                                }
                            }
                        }
                        else
                        {
                            foreach (var edge in Form1.graph.Edges)
                            {
                                if (edge.Source == splitPathResult[i] && edge.Target == splitPathResult[i + 1])
                                {
                                    edge.Attr.Color = Color.LightBlue;
                                }
                            }
                        }
                    }
                }
            }

            return paths;
        }

        public static string searchOne(string selectedDir, string file)
        {
            string path = String.Empty;
            string[] dirs = Directory.GetDirectories(selectedDir, "*.", SearchOption.TopDirectoryOnly);
            string[] files = Directory.GetFiles(selectedDir);
            bool found = false;
            int i = 0;

            Form1.graph.AddNode(selectedDir.Split('\\').Last()).Attr.FillColor = Color.Red;

            while (!found && i < files.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last()).Attr.Color = Color.Red;
                Form1.graph.FindNode(files[i].Split('\\').Last()).Attr.FillColor = Color.Red;

                if (file.Equals(files[i].Split('\\').Last()))
                {
                    Form1.graph.FindNode(files[i].Split('\\').Last()).Attr.FillColor = Color.LightBlue;
                    path = selectedDir;
                    found = true;
                }
                i++;
            }

            while (i < files.Length) {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), files[i].Split('\\').Last());
                i++;
            }


            i = 0;
            while (!found && i < dirs.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), dirs[i].Split('\\').Last()).Attr.Color = Color.Red;
                Form1.graph.FindNode(dirs[i].Split('\\').Last()).Attr.FillColor = Color.Red;

                path = searchOne(dirs[i], file);
                if (path != String.Empty)
                {
                    found = true;
                }
                i++;
            }
            while (i < dirs.Length)
            {
                Form1.graph.AddEdge(selectedDir.Split('\\').Last(), dirs[i].Split('\\').Last());
                i++;
            }

            string[] splitPathResult = path.Split('\\');
            for (i = 0; i < splitPathResult.Length; i++) {
                Node node = Form1.graph.FindNode(splitPathResult[i]);
                if (node != null)
                {
                    node.Attr.FillColor = Color.LightBlue;
                    if (i == splitPathResult.Length - 1)
                    {
                        foreach (var edge in Form1.graph.Edges)
                        {
                            if (edge.Source == splitPathResult[i] && edge.Target == file)
                            {
                                edge.Attr.Color = Color.LightBlue;
                            }
                        }
                    } else
                    {
                        foreach (var edge in Form1.graph.Edges)
                        {
                            if (edge.Source == splitPathResult[i] && edge.Target == splitPathResult[i+1])
                            {
                                edge.Attr.Color = Color.LightBlue;
                            }
                        }
                    }
                }
            }

            return path;
        }
    }
}
