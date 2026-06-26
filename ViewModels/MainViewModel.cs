namespace NotepadApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _documentText = "";
        private string _filePath = "";
        // tracks if file is currently being edited
        private bool isDirty = false;
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
    }
}