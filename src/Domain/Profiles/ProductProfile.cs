using Domain.Profiles.Interfaces;

namespace Domain.Profiles
{
    public class ProductProfile : IImageProfile
    {
        private const int mb = 1048576;

        public ImageType ImageType => ImageType.Product;

        public string Folder => "Products";

        public int Width => 300;

        public int Height => 300;

        public int MaxSizeBytes => mb * 10;
    }
}
