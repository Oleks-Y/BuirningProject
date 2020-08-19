using System;
using BurningProject.DataAccess.Data;
using BurningProject.DataAccess.Repository.IRepository;

namespace BurningProject.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;
        public IArticleRepository Articles { get; set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Articles = new ArticleRepository(_db);
        }
        
        
        public void Dispose()
        {
            _db.Dispose();
        }
        
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}