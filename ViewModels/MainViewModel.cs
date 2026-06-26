namespace NotepadApp.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel
    {
        private string _documentText = "";
        public string FilePath { get; set; }
        // tracks if file is currently being edited
        public bool isDirty  {get; set;}
        public string DocumentText
        {
            get => _documentText;
            set
            {
                if(_documentText != value)
                {
                    _documentText = value;
                    OnPropertyChanged();
                }
            }
        }

        public void NewDocument()
        {
            // can be executed by itself no need to call file service
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