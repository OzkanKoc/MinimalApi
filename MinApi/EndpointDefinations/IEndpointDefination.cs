namespace MinApi.EndpointsDefinations;

public interface IEndpointDefination
{
    void DefineEndpoints(WebApplication app);
    void DefineServices(IServiceCollection services);
}
