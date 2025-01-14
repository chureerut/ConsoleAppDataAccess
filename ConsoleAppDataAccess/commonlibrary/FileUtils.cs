using System.IO;

namespace ConsoleAppDataAccess.commonlibrary
{
    public class FileUtils
    {
        // Check if a file exists
        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        // Read all text from a file
        public static string ReadFileText(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }

            return File.ReadAllText(filePath);
        }

        // Write text to a file
        public static void WriteFileText(string filePath, string content)
        {
            File.WriteAllText(filePath, content);
        }

        // Append text to a file
        public static void AppendFileText(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        // Delete a file if it exists
        public static void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        // Copy a file to a new location
        public static void CopyFile(string sourceFilePath, string destFilePath)
        {
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException($"Source file not found: {sourceFilePath}");
            }

            File.Copy(sourceFilePath, destFilePath, true);
        }

        // Move a file to a new location
        public static void MoveFile(string sourceFilePath, string destFilePath)
        {
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException($"Source file not found: {sourceFilePath}");
            }

            if (File.Exists(destFilePath))
            {
                throw new IOException($"Destination file already exists: {destFilePath}");
            }

            File.Move(sourceFilePath, destFilePath);
        }

    }
}
