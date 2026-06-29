namespace NotepadApp.Models
{
    public enum SupportedOperations
    {
        Insert,
        Delete
    }
    public interface ITextAction
    {
        string Text { get; init; } //TODO:Use enum for the operation type
        int StartIndex {get;}
        SupportedOperations OperationType {get; init;}
    }
}