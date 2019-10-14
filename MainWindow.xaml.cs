using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HeXED
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMenuItem_File_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == true)
            {
                StringBuilder sb = new StringBuilder();
                StringBuilder sbHex = new StringBuilder();
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();

                string fileName = openDialog.FileName;
                string[] fileLines = File.ReadAllLines(fileName);

                int loadingStatus = 0;

                Parallel.ForEach(File.ReadLines(fileName), line =>
                {
                    sb.Append(line);
                });

                string hexString;

                foreach (var c in sb.ToString())
                {
                    ushort hexVal = Convert.ToUInt16(c);
                    sbHex.Append(hexVal);
                    sbHex.Append("\t");
                    Console.WriteLine(string.Format("Char: {0}   HEX: {1}", c, hexVal));
                }
                hexString = sbHex.ToString();
                rtbEditor.AppendText(hexString);
                

                rtbEditor.AppendText("\n\n WRITING FINISHED!!!");
                Console.WriteLine("Writing finished!");

            }
        }
    }
}
