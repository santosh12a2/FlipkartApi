using FlipkartApi.Entites;

namespace FlipkartApi.Interfaces
{
    public interface IProductProvider
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
        Product Update(Product product);
        int Delete(int id);
    }
}
