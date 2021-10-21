using MinApi.EndpointsDefinations;
using MinApi.Models;
using MinApi.Repositories;

namespace MinApi.EndpointDefination;

public class ProductEndpointDefination : IEndpointDefination
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/products", (IProductRepository productRepository) =>
        {
            return Results.Ok(productRepository.GetAll());
        });

        app.MapGet("/products/{id}", (IProductRepository productRepository, Guid id) =>
        {
            var product = productRepository.GetById(id);
            return product is not null ? Results.Ok(product) : Results.NotFound();
        });

        app.MapPost("/products", (IProductRepository productRepository, Product product) =>
        {
            productRepository.Create(product);
            return Results.Created($"products/{product.Id}", product);
        });

        app.MapPut("/products", (IProductRepository productRepository, Product product) =>
        {
            productRepository.Update(product);
            return Results.Ok(product);
        });

        app.MapDelete("/products", (IProductRepository productRepository, Guid id) =>
        {
            productRepository.Delete(id);
            return Results.Ok();
        });
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
    }
}