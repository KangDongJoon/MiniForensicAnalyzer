using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;

namespace MiniForensicAnalyzer
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

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                FilePathText.Text = dialog.FileName;

                byte[] bytes = File.ReadAllBytes(dialog.FileName);

                StringBuilder hex = new StringBuilder();

                foreach (byte b in bytes)
                {
                    hex.Append(b);
                    hex.Append(' ');
                }

                HexViewr.Text = hex.ToString();
            }
        }
    }
}