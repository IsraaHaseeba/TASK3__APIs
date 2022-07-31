using UsersAPI.ActionFilters.Filters;
using UsersAPI.Repo;
using UsersAPI.ViewModels;

namespace UsersAPI
{
    public static class MyServices
    {
        public static void services(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            Services.AddScoped<IUserRepo, UserRepo>();
            Services.AddScoped(_ => new ActionFilterExample("admin"));
            Services.AddScoped<IPostRepo, PostRepo>();

        }

    }
}
