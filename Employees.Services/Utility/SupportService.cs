
namespace Employees.Services.Utility
{
    public class SupportService
    {
        public static bool CreateDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath)) return true;

            Directory.CreateDirectory(directoryPath);

            return true;
        }

        public static string SaveStreamToFile(string directoryPath, Stream inputStream, string fileName)
        {
            SupportService.CreateDirectory(directoryPath);
            string path = Path.Combine(directoryPath, fileName);
            using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
            {
                inputStream.CopyTo(outputFileStream);
            }

            return path;
        }

        public static FileInfo NewFileInfo(string directoryPath, string fileName)
        {
            SupportService.CreateDirectory(directoryPath);

            string filePath = Path.Combine(directoryPath, fileName);

            return new FileInfo(filePath);
        }

        public static bool DeleteFile(string directoryFile)
        {
            if (!File.Exists(directoryFile)) return false;

            File.Delete(directoryFile);

            return true;
        }
    }
}
