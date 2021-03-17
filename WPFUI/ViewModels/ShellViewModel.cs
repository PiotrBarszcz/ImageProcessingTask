using Caliburn.Micro;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using ImageProcessingTask.Models;
using System.Windows;

namespace ImageProcessingTask.ViewModels
{
    public class ShellViewModel : Conductor<object>

    {
        public ShellViewModel()
        {
        }

        private string _fileNameTextBox;
        private string _imageSource;
        private string _imageSource2;
        private int _time = 0;
        private int _timeAsync = 0;
        private Image image;
        private Bitmap bitmap;
        private int imageCount = 0;

        public ImageModel ImageTransformed
        {
            get { return new ImageModel { ImageName = "Image transformed" }; }
            set
            {}
        }

        public ImageModel ImageOriginal
        {
            get { return new ImageModel { ImageName = "Image original" }; }
            set
            {}
        }

        public string FileNameTextBox
        {
            get { return _fileNameTextBox; }
            set
            {
                _fileNameTextBox = value;
                NotifyOfPropertyChange(() => FileNameTextBox);
            }

        }
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                NotifyOfPropertyChange(() => ImageSource);
            }

        }
        public string ImageSource2
        {
            get { return _imageSource2; }
            set
            {
                _imageSource2 = value;
                NotifyOfPropertyChange(() => ImageSource2);
            }

        }
        public int Time
        {
            get { return _time; }
            set
            {
                _time = value;
                NotifyOfPropertyChange(() => Time);
            }

        }

        public int TimeAsync
        {
            get { return _timeAsync; }
            set
            {
                _timeAsync = value;
                NotifyOfPropertyChange(() => TimeAsync);
            }
        }

        public async Task DrawImage(string ImageSource)
        {
            Stopwatch sw = new Stopwatch();

            image = Image.FromFile(ImageSource);
            bitmap = new Bitmap(image);

            ImageProcessing imageProcessing = new ImageProcessing();
            sw.Start();
            imageProcessing.ToMainColors(ref bitmap);
            Time = (int)sw.ElapsedMilliseconds;
            bitmap.Save(@"D:\\Image\\newImage" + imageCount + ".jpg");

            Bitmap bitmapResult = await imageProcessing.ToMainColorsAsync(bitmap);
            TimeAsync = (int)sw.ElapsedMilliseconds - Time;

            ImageSource2 = @"D:\\Image\\newImage"+ imageCount + ".jpg";
            MessageBox.Show("Image has been processed successfully");
            imageCount++;
        }
        public async void OpenBrowse()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".jpg",
                Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*"
            };

            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = openFileDialog.FileName;
                FileNameTextBox = filename;
                ImageSource = filename;
                await DrawImage(ImageSource);
            }
        }
    }
}

   
