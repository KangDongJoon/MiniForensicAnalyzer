using System.ComponentModel;

namespace MiniForensicAnalyzer.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _filePath;
        public string FilePath
        {
            get => _filePath;
            set
            {
                _filePath = value;
                OnPropertyChanged(nameof(FilePath));
            }
        }

        private string _fileInfo;
        public string FileInfoText
        {
            get => _fileInfo;
            set
            {
                _fileInfo = value;
                OnPropertyChanged(nameof(FileInfoText));
            }
        }

        private string _hexText;
        public string HexText
        {
            get => _hexText;
            set
            {
                _hexText = value;
                OnPropertyChanged(nameof(HexText));
            }
        }

        private string _hashText;
        public string HashText
        {
            get => _hashText;
            set
            {
                _hashText = value;
                OnPropertyChanged(nameof(HashText));
            }
        }

        private string _stringText;
        public string StringText
        {
            get => _stringText;
            set
            {
                _stringText = value;
                OnPropertyChanged(nameof(StringText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
