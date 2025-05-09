namespace EventManagmentAPI.Repository
{
    public class ImageHandler
    {
        private readonly IWebHostEnvironment _env;

        public ImageHandler(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveImageAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                return null;

            string uploadsFolder = Path.Combine(_env.WebRootPath, folderName);
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Path.Combine(folderName, uniqueFileName).Replace("\\", "/");
        }

        public void DeleteImage(string relativePath)
        {
            var fullPath = Path.Combine(_env.WebRootPath, relativePath);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
