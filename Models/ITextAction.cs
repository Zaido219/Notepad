namespace NotepadApp.Models
{
    public enum SupportedOperations
    {
        Insert,
        Delete
    }
    public interface ITextAction
    {
        string Text { get; init; }
        int StartIndex {get;}
        SupportedOperations OperationType {get; init;}
    }
}