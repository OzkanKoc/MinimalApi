namespace MinApi.EndpointsDescribers;

public static class Extensions
{
    private static List<IEndpointDescriber> _endpointDefinitions = GetEndpoints();

    public static void AddEndpointDefinitions(this IServiceCollection services)
        => _endpointDefinitions.ForEach(x => x.DescribeServices(services));

    public static void UseEndpointDefinitions(this WebApplication app)
        => _endpointDefinitions.ForEach(x => x.DescribeEndpoints(app));

    private static List<IEndpointDescriber> GetEndpoints()
        => AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(IEndpointDescriber)
                            .IsAssignableFrom(t)
                            && !t.IsAbstract
                            && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDescriber>()
                .ToList();
}
