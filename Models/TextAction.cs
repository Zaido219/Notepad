namespace NotepadApp.Models
{
    public class TextAction : ITextAction
    {
        public string Text {get;init;}
        public int StartIndex {get;set;}
        public string OperationType {get;init;}
        // construction
        public  TextAction(string t, int i, string o)
        {
            Text =t;
            StartIndex = i;
            OperationType = o;
        }
    }
}