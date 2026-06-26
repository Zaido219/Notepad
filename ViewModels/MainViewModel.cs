namespace NotepadApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _documentText = "";
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