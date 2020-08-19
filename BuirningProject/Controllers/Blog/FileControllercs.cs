using System.Threading.Tasks;
using BurningProject.DataAccess.FilesService;
using BurningProject.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuirningProject.Controllers.Blog
{
    public class FileController : Controller
    {
        private IImageService _articleService;
        private IUnitOfWork _unitOfWork;
        public FileController(IImageService articleService, IUnitOfWork unitOfWork)
        {
            _articleService = articleService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("{id}")]
        public async Task<IActionResult> AttachImage(string id, IFormFile uploadedFile)
        {
            string imageId=null;
            if (uploadedFile != null)
            {
                imageId = _articleService.StoreImage(uploadedFile.OpenReadStream(), uploadedFile.FileName);
            }
            else
            {
                return BadRequest("No file uploaded");
            }
            //Todo check for empty value;
            var article = _unitOfWork.Articles.Get(id);
            if (article == null)
            {
                return BadRequest("No such article");
            }
            article.ImageId = imageId;
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetImage(string imageId)
        {
            // Todo Check if file exists   
            byte[] image ;
            try
            {
                image = await _articleService.GetImage(imageId);
            }
            catch
            {
                return NotFound();
            }

            if (image == null)
            {
                return NotFound();
            }

            return File(image, "image/png");
        }
    }
    }
