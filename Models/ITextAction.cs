namespace NotepadApp.Models
{
    public interface ITextAction
    {
        string Text { get; init; } //TODO:Use enum for the operation type
        int StartIndex {get;}
        string OperationType {get; init;}
    }
}