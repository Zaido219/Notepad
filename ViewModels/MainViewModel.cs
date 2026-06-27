using System.IO;
using System.Windows.Input;
using NotepadApp.Services;
using Microsoft.Win32;
using NotepadApp.Commands;

namespace NotepadApp.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IFileService _fileService;
        private string _documentText = "";
        public string _filePath { get; set; }
        // tracks if file is currently being edited
        public bool _isDirty { get; set; }
        public ICommand NewDocumentCommand { get; set; }
        public ICommand OpenDocumentCommand {get; set;}

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
        public MainViewModel(IFileService fileService)
        {
            _fileService = fileService ?? throw new System.ArgumentNullException(nameof(fileService));
            // bind the actions directly in the constructor
            NewDocumentCommand = new RelayCommand(_ => NewDocument(),
            _ => !string.IsNullOrEmpty(DocumentText)
            );
            OpenDocumentCommand = new RelayCommand(_ => OpenDocument());

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
            // create the OS Dialog box
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
               Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Open Text Document"
            };
            // present the dialog the user via the OS
            if(openFileDialog.ShowDialog() == true)
            {
                // capture the selected path
                string selectedPath = openFileDialog.FileName;
                // delegate the disk reading operation to the service layer
                string fileContent = _fileService.LoadTextFromFile(selectedPath);
                // update state
                DocumentText = fileContent;
                FilePath = selectedPath;
                IsDirty = false; // reset tracking since it matches disk perfectly
            }
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