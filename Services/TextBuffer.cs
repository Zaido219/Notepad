using System;
using System.Text;
namespace NotepadApp.Services
{
    public class TextBuffer : IBuffer
    {
        public string currentText => buffer.ToString(); // auto-calculate currentText by converting buffer to string
        public bool isEmpty => buffer.Length == 0; // auto-calculate is empty via buffer length
        public int startIndex { get; set; }
        public StringBuilder buffer { get; } = new StringBuilder(1024);
        public void Append(char c, int caretIndex)
        {
            // STEP 1: Set the start line FIRST if the buffer was just cleared
            if (isEmpty)
            {
                startIndex = caretIndex;
            }

            // STEP 2: Calculate the local position
            int localIndex = caretIndex - startIndex;

            // STEP 3: Safety checks (Guard Clauses) using the local position
            if (localIndex < 0 || localIndex > buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(caretIndex), "Index is out of bounds!");
            }

            // STEP 4: Insert the character into the buffer
            buffer.Insert(localIndex, c);

            Console.WriteLine($"Buffer insert: {buffer.ToString()}");
        }
        public void Clear()
        {
            // clear the buffer
            buffer.Clear();
            startIndex = 0; // reset startIndex
            Console.WriteLine("Buffer was cleared");
        }

    }
}