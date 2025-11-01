using Microsoft.AspNetCore.Http;

namespace SportZone_MVC.Services.Interfaces
{
    public interface IFileStorageService
    {
        Task<string?> UploadFileAsync(IFormFile file, string folderName);
        bool DeleteFile(string fileUrl);
    }
}