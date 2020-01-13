using System.IO;

namespace LocationMaster_API.Services
{
    public class FileService
    {
        public static void SaveStreamAsFile(string filePath, Stream inputStream, string fileName)
        {
            DirectoryInfo info = new DirectoryInfo(filePath);
            if (!info.Exists)
            {
                info.Create();
            }

            string path = Path.Combine(filePath, fileName);
            using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
            {
                inputStream.CopyTo(outputFileStream);
            }
        }

        public static byte[] GetBytesOfImage(string filePath, string fileName)
        {
            var path = Path.Combine(filePath, fileName);
            return File.ReadAllBytes(path);
        }
    }
}