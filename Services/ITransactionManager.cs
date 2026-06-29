namespace NotepadApp.Services
{
    public interface ITransactionManager
    {
        void HandleKeyStroke(char c, int currenCaretIndex);
        void ForceCommit(); // triggered by timer or space bar
        void Undo();
    }
}