namespace Attendo.Services;

public interface IPhotoService
{
    Task<string?> SavePhotoAsync(FileResult? photo);
    Task<List<string>> GetSavedPhotosAsync();
    Task<bool> DeletePhotoAsync(string photoPath);
}