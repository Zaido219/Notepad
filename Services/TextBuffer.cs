using System;
using System.Text;
namespace NotepadApp.Services
{
    public class TextBuffer : IBuffer
    {
        public string currentText => buffer.ToString(); // auto-calculate currentText by converting buffer to string
        public bool isEmpty => buffer.Length == 0; // auto-calculate is empty via buffer length
        public int startIndex {get; set; }
        public StringBuilder buffer {get; set; } = new StringBuilder(1024);
        public void Append(char c, int caretIndex)
        {
            // append char to buffer to a specific index
            buffer.Insert(caretIndex, c);
        }
        public void Clear()
        {
            // clear the buffer
            buffer.Clear();
        }

    }
}