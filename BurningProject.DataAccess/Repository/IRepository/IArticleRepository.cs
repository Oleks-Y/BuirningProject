using BurningProject.Models.Blog;

namespace BurningProject.DataAccess.Repository.IRepository
{
    public interface IArticleRepository : IRepository<Article>
    {
        void Update(Article article);
    }
}