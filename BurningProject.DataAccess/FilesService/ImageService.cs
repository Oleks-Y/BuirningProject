using System.IO;
using System.Threading.Tasks;
using BurningProject.Models.Blog;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
namespace BurningProject.DataAccess.FilesService
{
    public class ImageService : IImageService
    {
        private IGridFSBucket gridFS;
        

        public ImageService()
        {
            string connectionString = "mongodb://localhost:27017/BurningImages";
            
            var connection = new MongoUrlBuilder(connectionString);
            
            MongoClient client = new MongoClient(connectionString);

            IMongoDatabase database = client.GetDatabase(connection.DatabaseName);
            
            gridFS = new GridFSBucket(database);

            

        }
        public async Task<byte[]> GetImage(string id)
        {
            return await gridFS.DownloadAsBytesAsync(new ObjectId(id));
        }
        
        public  string StoreImage(Stream imageStream, string imageName)
        {
            
            ObjectId imageId = gridFS.UploadFromStream(imageName, imageStream);

            return imageId.ToString();
        }
    }
}