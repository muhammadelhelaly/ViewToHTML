using Microsoft.Extensions.DependencyInjection;
using ViewToHTML.Services;

namespace ViewToHTML.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddViewToHTML(this IServiceCollection services) =>
            services.AddScoped<IViewRendererService, ViewRendererService>();
    }
}