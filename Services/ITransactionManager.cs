using NotepadApp.Models;

namespace NotepadApp.Services
{
    public interface ITransactionManager
    {
        void HandleKeyStroke(char c, int currenCaretIndex);
        void Commit(); // triggered by timer or space bar
        ITextAction? Undo(); // returns the last textaction, let mainviewmodel do the ui update
        void CheckSpace(); // check if storage has reach predefined max limit
    }
}