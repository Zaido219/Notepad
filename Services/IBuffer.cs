using System.Text;

namespace NotepadApp.Services
{
    public interface IBuffer
    {
        string currentText {get;} // the full constructed word
        int startIndex {get;} // current caret index
        bool isEmpty {get;} // check if buffer has any chars
        int Length {get;}
        StringBuilder buffer {get;}
        void Append(char c, int caretIndex); // appends character to buffer
        void Clear(); // clears buffer for next append operations
    }
}