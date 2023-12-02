using API.Lazospetshop.Models.TImage;

namespace API.Lazospetshop.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> SaveImageFromBase64Async(string base64, string filename);
        Task<string> GetImageAsBase64Async(string filename);
        Task<Stream> GetImageStreamAsync(string filename);
    }
}
