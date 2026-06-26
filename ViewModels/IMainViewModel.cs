using System.ComponentModel;

namespace NotepadApp.ViewModels
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        // the data contract the textbox binds to
        string DocumentText {get; set; }
        // The path display contract
        string FilePath { get; set; }
        // The changed tracking contract
        bool isDirty { get; set; }
        // the structural actions (Commands) that the top Menu items will bind to
        void NewDocument();
        void OpenDocument();
        void SaveDocument();
        void SaveDocumentAs();
    }
}