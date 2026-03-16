using E_Learning.Service.Contract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Service.Services
{
    public class FileService : IFileService
    {
        private readonly IHostEnvironment _env;

        public FileService(IHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folderName)
        {
            if (file == null || file.Length == 0)
                throw new Exception("No file provided");

            // أنواع الملفات المسموح بها
            var allowedExtensions = new[] { ".pdf", ".docx", ".txt", ".jpg", ".jpeg", ".png" };
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                throw new Exception("Invalid file type. Allowed: .pdf, .docx, .txt, .jpg, .jpeg, .png");

            // الحد الأقصى للحجم (5MB)
            var maxSize = 5 * 1024 * 1024;
            if (file.Length > maxSize)
                throw new Exception("File size exceeds limit (5MB)");

            // إنشاء المجلد لو مش موجود
            var uploadFolder = Path.Combine(_env.ContentRootPath, "wwwroot", folderName);
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            // إنشاء اسم ملف فريد
            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadFolder, fileName);

            // رفع الملف
            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            // رابط النسبي للملف
            return $"/{folderName}/{fileName}";
        }
    }
}