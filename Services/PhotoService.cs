using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace Attendo.Services;

public class PhotoService : IPhotoService
{
    private readonly string photoDirectory;
    public PhotoService()
    {
        // used constant storage
        photoDirectory = Path.Combine(FileSystem.AppDataDirectory, "AttendoPhotos");  
        
        if (!Directory.Exists(photoDirectory))
        {
            Directory.CreateDirectory(photoDirectory);
        }
    }  
    
    public async Task<string?> SavePhotoAsync(FileResult? photo)
    {
        // TODO: handle errors 
        if (photo == null)
        {
            return null;
        }

        var fileName = $"photo_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
        var filePath = Path.Combine(photoDirectory, fileName);

        using var sourceStream = await photo.OpenReadAsync();
        using var fileStream = File.Create(filePath);
        await sourceStream.CopyToAsync(fileStream);

        return filePath;
    }

    public Task<List<string>> GetSavedPhotosAsync()
    {
        var files = Directory.GetFiles(photoDirectory, "*.jpg");
        return Task.FromResult(files.ToList());
    }

    public Task<bool> DeletePhotoAsync(string photoPath)
    {
        if (File.Exists(photoPath))
        {
            File.Delete(photoPath);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
    
}