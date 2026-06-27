namespace NotepadApp.Services
{
    public interface IFileService
    {
        public string LoadTextFromFile(string text);
        public void SaveTextFromFile(string filePath, string text);
    }
}