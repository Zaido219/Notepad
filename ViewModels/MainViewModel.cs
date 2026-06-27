using System.IO;
using System.Windows.Input;

namespace NotepadApp.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private string _documentText = "";
        public string _filePath { get; set; }
        // tracks if file is currently being edited
        public bool _isDirty { get; set; }
        public ICommand NewDocumentCommand { get; set; }

        public string DocumentText
        {
            get => _documentText;
            set
            {
                if (_documentText != value)
                {
                    _documentText = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    OnPropertyChanged();
                }
            }
        }
        // constructor
        public MainViewModel()
        {
            // bind the actions directly in the constructor
            NewDocumentCommand = new RelayCommand(_ => NewDocument(),
            _ => !string.IsNullOrEmpty(DocumentText)
            );

        }
        public void NewDocument()
        {
            // can be executed by itself no need to call file service
            DocumentText = "";
            FilePath = "";
            IsDirty = false;

        }
        public void OpenDocument()
        {
            //calls file service
        }
        public void SaveDocument()
        {
            // calls file service
        }
        public void SaveDocumentAs()
        {
            // calls file service
        }
    }
}