namespace MinApi.EndpointsDescribers;

public interface IEndpointDescriber
{
    void DescribeEndpoints(WebApplication app);
    void DescribeServices(IServiceCollection services);
}
