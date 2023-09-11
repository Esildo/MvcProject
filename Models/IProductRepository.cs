using System.Linq;

namespace WebPetProject.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
