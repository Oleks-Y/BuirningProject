namespace BurningProject.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IArticleRepository Articles { get; set; }

        void Save();
    }
}