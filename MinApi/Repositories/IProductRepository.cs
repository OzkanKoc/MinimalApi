using MinApi.Models;

namespace MinApi.Repositories;

public interface IProductRepository
{
    List<Product> GetAll();
    Product? GetById(Guid id);
    void Create(Product? product);
    void Update(Product product);
    void Delete(Guid id);
}
