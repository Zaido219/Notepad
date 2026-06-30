using System.Windows.Automation;
using NotepadApp.Models;
using NotepadApp.Services;
using System.Collections.Generic;
using System.Timers;
namespace NotepadApp.Services
{
    public class TransactionManager : ITransactionManager
    {
        // inject dependencies
        const int MAX_LIMIT = 5;
        private readonly IBuffer _textBuffer = new TextBuffer();
        private LinkedList<ITextAction> UndoStack = new LinkedList<ITextAction>(); // this stack should be limited to 5 actions
        private System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();
        // constructor
        public TransactionManager()
        {
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += OnTimerElapsed;
        }
        private void OnTimerElapsed(object? sender, System.EventArgs e)
        {
            _timer.Stop();
            Commit();
        }
        public void HandleKeyStroke(char c, int currenCaretIndex)
        {
            int expectedIndex = _textBuffer.startIndex + _textBuffer.Length;
            if(!_textBuffer.isEmpty && currenCaretIndex != expectedIndex)
            {
                // caret disconnect check, it may jump to all places
                // its not always sequentially forward
                Commit(); // securely save the old word to the UndoStack before wipin it

            }
            if (c == ' ') // if space
            {
                Commit();
                Console.WriteLine("Space was detected a word was commited");
            }
            else
            {
                // add chars to text buffer
                _textBuffer.Append(c, currenCaretIndex);
                Console.WriteLine("A new char is added to the buffer");
                // Debounce the idle timer: Stop the active countdown and restart it.
                // This pushes the 2-second commit window forward with every single keystroke.
                _timer.Stop();
                _timer.Start();
            }
        }
        public void Commit(){
            //extract current text and start index from the buffer
            string currentText = _textBuffer.currentText;
            int currentCaretIndex = _textBuffer.startIndex;
            //create a new ITextAction
            ITextAction _textAction = new TextAction(currentText, currentCaretIndex, SupportedOperations.Insert);
            // push to stack
            UndoStack.AddFirst(_textAction);
            Console.WriteLine("New textaction was pushed to the UndoStack");
            CheckSpace(); // check the stack if its over the limit
            // clear buffer
            _textBuffer.Clear();
        }
        public ITextAction? Undo()
        {
            if (UndoStack.Count <= 0)
            {
                return null;
            }
            //read most recent action save
            ITextAction lastAction = UndoStack.First();
            // delete most recent action save
            UndoStack.RemoveFirst();

            return lastAction;
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