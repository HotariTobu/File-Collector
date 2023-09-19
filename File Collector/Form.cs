using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Collector
{
    public partial class Form : System.Windows.Forms.Form
    {
        private static NaturalComparer s_Comparer = new NaturalComparer();

        public Form()
        {
            InitializeComponent();
        }

        private void collect(string[] paths)
        {
            string boxText = box.Text;
            if (Directory.Exists(boxText))
            {
                int i = 0;
                for (; i < 10000; i++)
                {
                    if (!Directory.Exists(Path.Combine(boxText, $"{i:0000}")))
                    {
                        i--;
                        break;
                    }
                }

                int j = 0;
                string dir = null;
                if (i == -1)
                {
                    i = 0;
                    upDateDir();
                }
                else
                {
                    upDateDir();
                    foreach (string file in Directory.EnumerateFiles(dir))
                    {
                        int result = 0;
                        string a = Path.GetFileNameWithoutExtension(file);
                        int.TryParse(Path.GetFileNameWithoutExtension(file), out result);
                        j = j < result ? result : j;
                    }
                }

                var droppedPathList = paths.ToList();
                droppedPathList.Sort(s_Comparer);
                foreach (string path in droppedPathList)
                {
                    List<string> pathList = new List<string>();
                    if (File.Exists(path))
                    {
                        pathList.Add(path);
                    }
                    else if (Directory.Exists(path))
                    {
                        pathList = Directory.GetFiles(path, "*", SearchOption.AllDirectories).ToList();
                    }

                    pathList.Sort(s_Comparer);

                    foreach (string file in pathList)
                    {
                        j++;
                        if (j == 10000)
                        {
                            i++;
                            upDateDir();
                        }

                        File.Move(file, Path.Combine(dir, $"{j:0000}{Path.GetExtension(file)}"));
                    }
                }

                void upDateDir()
                {
                    dir = Path.Combine(boxText, $"{i:0000}");
                    Directory.CreateDirectory(dir);
                    j = 0;
                }
            }
        }

        private void box_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect== DragDropEffects.Copy)
            {
                box.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }
        }

        private void box_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                if (Directory.Exists(((string[])e.Data.GetData(DataFormats.FileDrop))[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy)
            {
                collect((string[])e.Data.GetData(DataFormats.FileDrop));
            }
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
