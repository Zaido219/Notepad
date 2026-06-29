namespace NotepadApp.Models
{
    public class TextAction : ITextAction
    {
        public string Text {get;init;}
        public int StartIndex {get;set;}
        public SupportedOperations OperationType {get;init;}
        // construction
        public  TextAction(string t, int i, SupportedOperations op)
        {
            Text =t;
            StartIndex = i;
            OperationType = op;
        }
    }
}