using System;
using System.Diagnostics;
using System.Threading.Tasks;
using EyeCare.Models;
using EyeCare.Services;
using EyeCare.Shared.Extensions;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace EyeCare.PageViewModels
{
    public class CameraPageViewModel : NavPageViewModelBase
    {
        private readonly DiagnosesClient _diagnosesClient;

        private ImageSource _previewPhoto;

        public CameraPageViewModel()
        {
            _diagnosesClient = new DiagnosesClient();
        }

        public ImageSource PreviewPhoto
        {
            get => _previewPhoto;
            set => Set(ref _previewPhoto, value);
        }

        private Command _takePhotoCommand = default(Command);
        public Command TakePhotoCommand => _takePhotoCommand ?? (_takePhotoCommand = new Command(ExecuteTakePhoto, CanExecuteTakePhoto));
        public bool CanExecuteTakePhoto() => true;
        private async void ExecuteTakePhoto()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var imageFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "EyeCare",
                    Name = "eye_photo.jpg"
                });

                await SetPhotoAsync(imageFile);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
            }
        }

        private Command _pickPhotoCommand = default(Command);
        public Command PickPhotoCommand => _pickPhotoCommand ?? (_pickPhotoCommand = new Command(ExecutePickPhoto, CanExecutePickPhoto));
        public bool CanExecutePickPhoto() => true;
        private async void ExecutePickPhoto()
        {
            try
            {
                await CrossMedia.Current.Initialize();

                var imageFile = await CrossMedia.Current.PickPhotoAsync();

                await SetPhotoAsync(imageFile);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
            }
        }

        private async Task SetPhotoAsync(MediaFile file)
        {
            PreviewPhoto = ImageSource.FromFile(file.Path);

            await _diagnosesClient.AddDiagnosisAsync(new Diagnosis
            {
                Date = DateTime.Now,
                Eye = new Eye
                {
                    Data = file.GetStream().ToByteArray()
                },
                Patient = new Patient
                {
                    Name = "Francesco",
                    Surname = "Bonacci"
                }
            });
        }
    }
}