using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using MiniForensicAnalyzer.ViewModels;
using MiniForensicAnalyzer.Services;

namespace MiniForensicAnalyzer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel viewModel;
        private FileAnalysisService service;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainViewModel();

            DataContext = viewModel;

            service = new FileAnalysisService();
        }

        private string currentFilePath;
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                currentFilePath = dialog.FileName;
                viewModel.FilePath = currentFilePath;
                
                viewModel.FileInfoText = service.GetFileInfo(currentFilePath);
                viewModel.HexText = service.GetHex(currentFilePath);
            }
        }

        private void HashButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                MessageBox.Show("파일을 먼저 선택하세요");
                return;
            }

            viewModel.HashText = service.CalculateSHA256(currentFilePath);
        }

        private void StringButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                MessageBox.Show("파일을 먼저 선택하세요");
                return;
            }

            viewModel.StringText = service.ExtractString(currentFilePath);
        }
    }
}