namespace NotepadApp.Services
{
    public interface ITransactionManager
    {
        void HandleKeyStroke(char c, int currenCaretIndex);
        void Commit(); // triggered by timer or space bar
        void Undo();
    }
}