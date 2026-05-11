using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

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

        private string currentFilePath;
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                currentFilePath = dialog.FileName;
                FilePathText.Text = currentFilePath;

                byte[] bytes = File.ReadAllBytes(currentFilePath);

                StringBuilder hex = new StringBuilder();

                foreach (byte b in bytes)
                {
                    hex.Append(b);
                    hex.Append(' ');
                }

                HexViewr.Text = hex.ToString();
            }
        }

        private void HashButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                MessageBox.Show("파일을 먼저 선택하세요");
                return;
            }

            byte[] fileBytes = File.ReadAllBytes(currentFilePath);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(fileBytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));

                }

                HashText.Text = $"SHA256: {sb}";
            }
        }

        private void StringButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                MessageBox.Show("파일을 먼저 선택하세요");
                return;
            }

            byte[] fileBytes = File.ReadAllBytes(currentFilePath);

            string text = Encoding.ASCII.GetString(fileBytes);

            MatchCollection matches = Regex.Matches(text, @"[ -~]{4,}");

            StringBuilder sb = new StringBuilder();

            foreach (Match match in matches) 
            {
                sb.AppendLine(match.Value);
            }

            StringViewer.Text = sb.ToString();
        }
    }
}