using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace E_Learning.Service.Contract
{
    public interface IFileService
    {
        /// <summary>
        /// Uploads a file to a specific folder and returns its relative URL.
        /// </summary>
        /// <param name="file">The file to upload</param>
        /// <param name="folderName">Folder under wwwroot</param>
        /// <returns>Relative URL of the uploaded file</returns>
        Task<string> UploadFileAsync(IFormFile file, string folderName);
    }
}