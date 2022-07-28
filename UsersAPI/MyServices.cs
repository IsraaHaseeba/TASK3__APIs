using UsersAPI.ActionFilters.Filters;
using UsersAPI.Repo;

namespace UsersAPI
{
    public static class MyServices
    {
        public static void services(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            Services.AddScoped<IUserRepo, UserRepo>();
            Services.AddScoped<ActionFilterExample>(_ => new ActionFilterExample("admin"));
            Services.AddScoped<IPostRepo, PostRepo>();

        }

    }
}
