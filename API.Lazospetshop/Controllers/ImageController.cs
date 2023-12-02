using API.Lazospetshop.Interfaces;
using API.Lazospetshop.Models.TImage;
using API.Lazospetshop.Services;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Lazospetshop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageService;
        protected Response _response;

        public ImageController(IImageRepository imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveImage(Image image)
        {
            var url = await _imageService.SaveImageFromBase64Async(image.imageBase64, image.filename);
            url.imageBase64 = $"https://lazospetshop.azurewebsites.net/Image/{url.filename}";
            return Ok(url);
        }

        [HttpGet("GetImageBase64/{filename}")]
        public async Task<IActionResult> GetImageBase64(string filename)
        {
            var base64 = await _imageService.GetImageAsBase64Async(filename);
            return Ok(base64);
        }

        [HttpGet("{filename}")]
        public async Task<IActionResult> GetImage(string filename)
        {
            var stream = await _imageService.GetImageStreamAsync(filename);
            if (stream == null)
            {
                return NotFound();
            }

            return File(stream, "image/jpeg");
        }
    }
}
