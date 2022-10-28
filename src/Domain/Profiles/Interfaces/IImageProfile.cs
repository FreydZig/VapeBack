namespace Domain.Profiles.Interfaces
{
    public interface IImageProfile
    {
        ImageType ImageType { get; }

        string Folder { get; }

        int Width { get; }

        int Height { get; }

        int MaxSizeBytes { get; }
    }
}
