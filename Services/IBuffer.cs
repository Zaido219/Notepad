using System.Text;

namespace NotepadApp.Services
{
    public interface IBuffer
    {
        string currentText {get;}
        int startIndex {get;}
        bool isEmpty {get;}
        StringBuilder buffer {get;}
        void Append(char c, int caretIndex);
        void Clear();
    }
}