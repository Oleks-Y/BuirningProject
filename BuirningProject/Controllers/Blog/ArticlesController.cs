using System;
using System.Threading.Tasks;
using BuirningProject.Controllers.Blog.PostObjects;
using BurningProject.DataAccess.FilesService;
using BurningProject.DataAccess.Repository.IRepository;
using BurningProject.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace BuirningProject.Controllers.Blog
{
        [Route("api/v1/Blog/[controller]")]
        public class ArticlesController : Controller
        {
        private IUnitOfWork _unitOfWork;
        private IImageService _imageService;
        public ArticlesController(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody]ArticlePost a)
        {
            // TODO Use different class for input and convert to db class
            if (String.IsNullOrWhiteSpace(a.Text) || String.IsNullOrWhiteSpace(a.Title))
            {
                // Title and text cannot be empty
                // TODO Add Other checks
                return NotFound();
            }

            // string imageId = null;
            // if (a.Image != null)
            // {
            //     imageId = _imageService
            //         .StoreImage(a.Image.OpenReadStream(),
            //                                     a.Image.FileName);
            // }
            //
            var article = new Article()
           {
               Date= DateTime.Now,
               Title = a.Title,
               Text = a.Text,
               
           };
            

            _unitOfWork.Articles.Add(article);
            _unitOfWork.Save();
            return Json(article);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json( _unitOfWork.Articles.GetAll());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(string id)
        {
            var article = _unitOfWork.Articles.Get(id);
            if (article == null)
            {
                return NotFound();
            }
        
            return Json(article);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle(string id,[FromBody]ArticlePost a)
        {
            if (String.IsNullOrWhiteSpace(a.Text) || String.IsNullOrWhiteSpace(a.Title))
            {
                // Title and text cannot be empty
                // TODO Add Other checks
                return NotFound();
            }
            
            var article = new Article()
            {
                Id = id,
                Date= DateTime.Now,
                Title = a.Title,
                Text = a.Text
            };
        
            _unitOfWork.Articles.Update(article);
            _unitOfWork.Save();
            return Json(article);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(string id)
        {
            var article = _unitOfWork.Articles.Get(id);
            if (article == null)
            {
                // Id does not exist
                return NotFound();
            }
        
            _unitOfWork.Articles.Remove(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}