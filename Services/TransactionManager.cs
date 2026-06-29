using System.Windows.Automation;
using NotepadApp.Models;
using NotepadApp.Services;
using System.Collections.Generic;
namespace NotepadApp.Services
{
    public class TransactionManager : ITransactionManager
    {
        // inject dependencies
        private readonly IBuffer _textBuffer = new TextBuffer();
        private Stack<ITextAction> UndoStack = new Stack<ITextAction>(); // this stack should be limited to 5 actions
        public void HandleKeyStroke(char c, int currenCaretIndex)
        {
            // add chars to text buffer
            _textBuffer.Append(c, currenCaretIndex);

            if (c == ' ') // if space
            {
                Commit();
            }
        }
        public void Commit()
        {
            //extract current text and start index from the buffer
            string currentText = _textBuffer.currentText;
            int currentCaretIndex = _textBuffer.startIndex;
            //create a new ITextAction
            ITextAction _textAction = new TextAction(currentText, currentCaretIndex, SupportedOperations.Insert);
            // push to stack
            UndoStack.Push(_textAction);
        }
        public void Undo()
        {
            // 
        }
    }
}