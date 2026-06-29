using System;
using System.Text;
namespace NotepadApp.Services
{
    public class TextBuffer : IBuffer
    {
        public string currentText => buffer.ToString(); // auto-calculate currentText by converting buffer to string
        public bool isEmpty => buffer.Length == 0; // auto-calculate is empty via buffer length
        public int startIndex {get; set; }
        public StringBuilder buffer {get;} = new StringBuilder(1024);
        public void Append(char c, int caretIndex)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(caretIndex, buffer.Length); // if careIndex > bufferLength.
            ArgumentOutOfRangeException.ThrowIfNegative(caretIndex); // if caretIndex is negative

            buffer.Insert(caretIndex,c); //buffer.Insert can already handle if insert index is 0
        }
        public void Clear()
        {
            // clear the buffer
            buffer.Clear();
            startIndex = 0; // reset startIndex
        }

    }
}