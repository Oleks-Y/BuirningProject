using System.Linq;
using BurningProject.DataAccess.Data;
using BurningProject.DataAccess.Repository.IRepository;
using BurningProject.Models.Blog;

namespace BurningProject.DataAccess.Repository
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly ApplicationDbContext _db;
        public ArticleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Article article)
        {
            var objFromDb = _db.Articles.FirstOrDefault(a => a.Id == article.Id);

            if (objFromDb != null)
            {
                objFromDb.Date = article.Date;
                objFromDb.Text = article.Text;
                objFromDb.Title = article.Text;
                objFromDb.ImageId = article.ImageId;
            }
        }
    }
}