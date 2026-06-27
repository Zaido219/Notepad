using System.IO

namespace NotepadApp.Services
{
    public class FileService : IFileService
    {
        public string LoadTextFromFile(string filePath)
        {
            // direct call to the os's file stream reader
            return File.ReadAllText(filePath);
        }
        public void SaveTextFromFile(string filePath, string text)
        {
            // direct call to the os's file stream reader
            return File.WriteAllText(filePath, text);
        }
    }
}