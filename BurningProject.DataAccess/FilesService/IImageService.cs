using System.IO;
using System.Threading.Tasks;

namespace BurningProject.DataAccess.FilesService
{
    public interface IImageService
    {
        Task<byte[]> GetImage(string id);

        string StoreImage(Stream imageStream, string imageName);
    }
}