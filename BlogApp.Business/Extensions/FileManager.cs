using Microsoft.AspNetCore.Http;

namespace BlogApp.Business.Extensions
{
    public static class FileManager
    {
        public static bool CheckType(this IFormFile imageFile)
        {
            return imageFile.ContentType.Contains("image/");
        }

        public static bool CheckSize(this IFormFile imageFile, int maxSize)
        {
            return imageFile.Length / 1024 / 1024 < maxSize;
        }

        public static string SaveImage(this IFormFile imageFile, string web,string path)
        {
            string DirectoryPath = Path.Combine(web, path);

            if(!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            string fileName = Guid.NewGuid().ToString() + imageFile.FileName;

            string pathToSave = Path.Combine(web, path, fileName);

            using (var stream = new FileStream(pathToSave, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return fileName;
        }

        public static void DeleteImage(this string fileName, string web, string path)
        {
            string pathToDelete = Path.Combine(web, path, fileName);

            if (File.Exists(pathToDelete))
            {
                File.Delete(pathToDelete);
            }
        }
    }
}
