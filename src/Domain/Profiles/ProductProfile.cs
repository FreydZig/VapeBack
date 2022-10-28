using Domain.Profiles.Interfaces;

namespace Domain.Profiles
{
    public class ProductProfile : IImageProfile
    {
        private const int mb = 1048576;

        public ImageType ImageType => ImageType.Product;

        public string Folder => "Products";

        public int Width => 100;

        public int Height => 100;

        public int MaxSizeBytes => mb * 10;
    }
}
