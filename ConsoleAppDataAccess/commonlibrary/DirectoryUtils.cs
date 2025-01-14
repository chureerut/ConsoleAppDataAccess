using System.IO;

namespace ConsoleAppDataAccess.commonlibrary
{
    public class DirectoryUtils
    {
        // Create a directory if it does not exist
        public static void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        // Delete a directory if it exists
        public static void DeleteDirectoryIfExists(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true); // true to delete recursively
            }
        }

        // Copy a directory and its contents to a new location
        public static void CopyDirectory(string sourceDir, string destDir)
        {
            if (!Directory.Exists(sourceDir))
            {
                throw new DirectoryNotFoundException($"Source directory not found: {sourceDir}");
            }

            Directory.CreateDirectory(destDir);

            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (string directory in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(directory));
                CopyDirectory(directory, destSubDir);
            }
        }

        // Get the size of a directory in bytes
        public static long GetDirectorySize(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            long size = 0;

            // Calculate size of files in the directory
            foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }

            return size;
        }

        // List all files in a directory
        public static string[] ListAllFiles(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            return Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        }

        // List all subdirectories in a directory
        public static string[] ListAllDirectories(string path)
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            return Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
        }

        // Move a directory to a new location
        public static void MoveDirectory(string sourceDir, string destDir)
        {
            if (!Directory.Exists(sourceDir))
            {
                throw new DirectoryNotFoundException($"Source directory not found: {sourceDir}");
            }

            if (Directory.Exists(destDir))
            {
                throw new IOException($"Destination directory already exists: {destDir}");
            }

            Directory.Move(sourceDir, destDir);
        }

    }
}
