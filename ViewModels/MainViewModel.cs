using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Attendo.Services;

namespace Attendo.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IPhotoService photoService;
    
    [ObservableProperty]
    private string photoPath;
    
    public MainViewModel(IPhotoService photoService)
    {
        photoService = photoService;
    }
    
    [RelayCommand]
    private async Task TakePhotoAsync()
    {
        var photo = await MediaPicker.Default.CapturePhotoAsync();
        if (photo != null)
        {
            PhotoPath = await photoService.SavePhotoAsync(photo);
        }
    }
}