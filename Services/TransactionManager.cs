using System.Windows.Automation;
using NotepadApp.Models;
using NotepadApp.Services;
using System.Collections.Generic;
namespace NotepadApp.Services
{
    public class TransactionManager : ITransactionManager
    {
        // inject dependencies
        const int MAX_LIMIT = 5;
        private readonly IBuffer _textBuffer = new TextBuffer();
        private LinkedList<ITextAction> UndoStack = new LinkedList<ITextAction>(); // this stack should be limited to 5 actions
        public void HandleKeyStroke(char c, int currenCaretIndex)
        {
            if (c == ' ') // if space
            {
                Commit();
            }
            else
            {
                // add chars to text buffer
                _textBuffer.Append(c, currenCaretIndex);   
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
            UndoStack.AddFirst(_textAction);
            CheckSpace(); // check the stack if its over the limit
            // clear buffer
            _textBuffer.Clear();
        }
        public void Undo()
        {
            // 
        }

        public void CheckSpace()
        {
            // checks if there are still allowable space on the stack
            if(UndoStack.Count > MAX_LIMIT)
            {
                // remove oldest save
                UndoStack.RemoveLast();

            }
        }
    }
}