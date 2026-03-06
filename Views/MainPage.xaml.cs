namespace Attendo.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    // TODO: save photos to the storage, 'll use methods from PhotoService  
    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        var photo = await MediaPicker.Default.CapturePhotoAsync();
        if (photo != null)
        {
            await DisplayAlert("Фото", $"Сделано фото: {photo.FileName}", "OK");
        }
    }
}