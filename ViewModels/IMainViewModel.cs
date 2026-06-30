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
        bool IsDirty { get; set; }
        // the structural actions (Commands) that the top Menu items will bind to
        void NewDocument();
        void Undo();
        void OpenDocument();
        void SaveDocument();
        void SaveDocumentAs();
        void Exit();
        void ProcessKeyPress(char c, int caretIndex); // captures inputs
    }
}