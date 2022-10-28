using Domain.Profiles;
using Domain.Profiles.Interfaces;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace Domain.Services
{
    public class ImageService : IImageService
    {
        private readonly IEnumerable<IImageProfile> _imageProfile;

        public ImageService(IEnumerable<IImageProfile> imageProfile)
        {
            _imageProfile = imageProfile;
        }

        public string Create(IFormFile file)
        {
            var imageProfile = _imageProfile.FirstOrDefault(profile =>
                       profile.ImageType == ImageType.Product);

            if (imageProfile == null)
                throw new ImageProcessingException("Image profile has not found");

            ValidateFileSize(file, imageProfile);

            var image = Image.Load(file.OpenReadStream());

            ValidateImageSize(image, imageProfile);

            var folderPath = Path.Combine("Static", imageProfile.Folder);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            string filePath;
            string fileName;

            do
            {
                fileName = GenerateFileName(file);
                filePath = Path.Combine(folderPath, fileName);
            } while (File.Exists(filePath));

            Resize(image, imageProfile);
            Crop(image, imageProfile);

            image.Save(filePath, new JpegEncoder { Quality = 75 });

            return Path.Combine(imageProfile.Folder, fileName);
        }

        private string GenerateFileName(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());

            return $"{fileName}{fileExtension}";
        }

        //private void ValidateExtension(IFormFile file, IImageProfile imageProfile)
        //{
        //    var fileExtension = Path.GetExtension(file.FileName);

        //    if (imageProfile.AllowedExtensions.Any(ext => ext == fileExtension.ToLower()))
        //        return;

        //    throw new ImageProcessingException(Strings.WrongImageFormat);
        //}

        private void ValidateFileSize(IFormFile file, IImageProfile imageProfile)
        {
            if (file.Length > imageProfile.MaxSizeBytes)
                throw new ImageProcessingException("Image is too large!");
        }

        private void ValidateImageSize(Image image, IImageProfile imageProfile)
        {
            if (image.Width < imageProfile.Width || image.Height < imageProfile.Height)
                throw new ImageProcessingException("Image is to small!");
        }

        private void Resize(Image image, IImageProfile imageProfile)
        {
            var resizeOptions = new ResizeOptions
            {
                Mode = ResizeMode.Min,
                Size = new Size(imageProfile.Width)
            };

            image.Mutate(action => action.Resize(resizeOptions));
        }

        private void Crop(Image image, IImageProfile imageProfile)
        {
            var rectangle = GetCropRectangle(image, imageProfile);
            image.Mutate(action => action.Crop(rectangle));
        }

        private Rectangle GetCropRectangle(IImageInfo image, IImageProfile imageProfile)
        {
            var widthDifference = image.Width - imageProfile.Width;
            var heightDifference = image.Height - imageProfile.Height;
            var x = widthDifference / 2;
            var y = heightDifference / 2;

            return new Rectangle(x, y, imageProfile.Width, imageProfile.Height);
        }
    }
}
