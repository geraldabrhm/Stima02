using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

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
                if (file == files[i].Split('\\').Last())
                {
                    List<string> ls = path.ToList();
                    ls.Add(selectedDir);
                    path = ls.ToArray();
                    found = true;
                }
            }

            for (i = 0; i < dirs.Length; i++)
            {
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
                if (file.Equals(files[i].Split('\\').Last()))
                {
                    path = selectedDir;
                    found = true;
                }
            }

            i = 0;
            while (!found && i < dirs.Length)
            {
                path = searchOne(dirs[i], file);
                if (path != String.Empty)
                {
                    found = true;
                }
            }
            return path;
        }
    }
}
