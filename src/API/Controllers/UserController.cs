using DataLayer.Entities;
using Domain.Services.Interfaces;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IImageService _imageService;

        public UserController(IUserService userService, IImageService imageService)
        {
            _userService = userService;
            _imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Users user)
        {
            try
            {
                var answer = await _userService.AddUser(user);
                return Ok(answer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                var answer = await _userService.GetUser(userId);
                return Ok(answer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("img")]
        public IActionResult CreateImg(IFormFile file)
        {
            return Img(file);
        }

        private IActionResult Img(IFormFile img)
        {
            try
            {
                if (img.Length == 0) return BadRequest("File is empty!");

                var path = _imageService.Create(img);

                return Ok(path);
            }
            catch (ImageProcessingException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        private string GenerateFileName(IFormFile file)
        {
            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());

            return $"{fileName}{fileExtension}";
        }
    }
}
