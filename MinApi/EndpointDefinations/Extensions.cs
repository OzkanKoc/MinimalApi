namespace MinApi.EndpointsDefinations;

public static class Extensions
{
    private static List<IEndpointDefination> _endpointDefinitions = GetEndpoints();

    public static void AddEndpointDefinitions(this IServiceCollection services)
        => _endpointDefinitions.ForEach(x => x.DefineServices(services));

    public static void UseEndpointDefinitions(this WebApplication app)
        => _endpointDefinitions.ForEach(x => x.DefineEndpoints(app));

    private static List<IEndpointDefination> GetEndpoints()
        => AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(t => typeof(IEndpointDefination)
                            .IsAssignableFrom(t)
                            && !t.IsAbstract
                            && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<IEndpointDefination>()
                .ToList();
}
