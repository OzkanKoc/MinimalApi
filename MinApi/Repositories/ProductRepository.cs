using MinApi.Models;

namespace MinApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly Dictionary<Guid, Product> _products = new();

    public Product? GetById(Guid id)
    {
        return _products.GetValueOrDefault(id);
    }

    public List<Product> GetAll()
    {
        return _products.Select(x => x.Value).ToList();
    }

    public void Create(Product? product)
    {
        if (product is null)
            return;

        _products.Add(product.Id, product);
    }

    public void Update(Product product)
    {
        var existingProduct = _products[product.Id];
        if (existingProduct is null)
            return;

        _products[product.Id] = product;
    }

    public void Delete(Guid id)
    {
        _products.Remove(id);
    }
}
