using System.IO;
using System.Windows.Input;
using NotepadApp.Services;
using Microsoft.Win32;
using NotepadApp.Commands;
using System.Windows;
using NotepadApp.Models;


namespace NotepadApp.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IFileService _fileService;
        private readonly ITransactionManager _transactionManager;
        private string _documentText = "";
        private string? _filePath { get; set; }
        // tracks if file is currently being edited
        public bool _isDirty;
        public string? _windowTitle {get; set;}
        public ITextAction _textAction;
        public ICommand NewDocumentCommand { get; set; }
        public ICommand OpenDocumentCommand { get; set; }
        public ICommand SaveDocumentCommand {get; set;}
        public ICommand SaveDocumentAsCommand {get; set;}
        public ICommand ExitCommand {get; set;}
        public ICommand UndoCommand {get; set;}

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
            get => _filePath ?? "";
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(WindowTitle)); // forces xaml to changed the title too
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
                    OnPropertyChanged(nameof(WindowTitle)); // forces xaml to changed the title too
                }
            }
        }
        public string WindowTitle
        {
            // let the view model automatically compute the correct string whenever xaml reads it
            get
            {
                string fileName = string.IsNullOrEmpty(FilePath) ? "Untitled" : System.IO.Path.GetFileName(FilePath);
                // determine the modification indicator
                string dirtyIndicator = IsDirty ? " *" : "";
                // combine into the final presentation output
                return $"{fileName}{dirtyIndicator} - Notepad Clone";
            }
            set
            {
                if(_windowTitle != value)
                {
                    _windowTitle = value;
                    OnPropertyChanged();
                }
            }
        }
        // constructor
        public MainViewModel(IFileService fileService, ITransactionManager transactionManager)
        {
            _fileService = fileService ?? throw new System.ArgumentNullException(nameof(fileService));
            _transactionManager = transactionManager ?? throw new System.ArgumentNullException(nameof(transactionManager));
            // bind the actions directly in the constructor
            NewDocumentCommand = new RelayCommand(_ => NewDocument(),
            _ => !string.IsNullOrEmpty(DocumentText)
            );
            OpenDocumentCommand = new RelayCommand(_ => OpenDocument());
            SaveDocumentCommand = new RelayCommand(_ => SaveDocument());
            SaveDocumentAsCommand = new RelayCommand(_ => SaveDocumentAs());
            ExitCommand = new RelayCommand(_ => Exit());
            UndoCommand = new RelayCommand(_ => Undo());

        }
        public void NewDocument()
        {
            // can be executed by itself no need to call file service
            DocumentText = "";
            FilePath = "";
            IsDirty = true;
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
            if (openFileDialog.ShowDialog() == true)
            {
                // capture the selected path
                string selectedPath = openFileDialog.FileName ?? "";
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
            // check if file path is empty
            if (!string.IsNullOrEmpty(FilePath))
            {
                //directly save the document
                _fileService.SaveTextFromFile(FilePath, DocumentText);
                // reset state varibles
                IsDirty = false;
            }
            else
            {
                SaveDocumentAs();
            }
        }
        public void SaveDocumentAs()
        {
            // open system dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = "txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                string fileContent = DocumentText;
                // delegate work to the file service
                _fileService.SaveTextFromFile(filePath, fileContent);
                // update state variables
                FilePath = filePath;
                IsDirty = false;
            }
        }
        public void Exit()
        {
            // exit the applicaiton
            Application.Current.Shutdown();
        }
        public void Undo()
        {
            // undo is handled by transaction manager
            ITextAction? textAction = _transactionManager.Undo();
            if(textAction != null)
            {
                //update UI
                DocumentText = textAction.Text;
            }
        }
    }
}