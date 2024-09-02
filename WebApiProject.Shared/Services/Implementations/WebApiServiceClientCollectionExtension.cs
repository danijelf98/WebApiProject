using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiProject.Shared.Services.Interfaces;

namespace WebApiProject.Shared.Services.Implementations
{
    public static class WebApiServiceClientCollectionExtension
    {
        public static IServiceCollection AddWebApiMovieServiceClient(this IServiceCollection services, string webApiServiceBaseUrl, Action<HttpResponseMessage> unsuccessfulResponseAction = null)
        {
            services.AddHttpClient(nameof(WebApiMovieServiceClient)).AddTypedClient<IWebApiMovieServiceClient>(c => new WebApiMovieServiceClient(c, unsuccessfulResponseAction))
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(webApiServiceBaseUrl);
                });

            return services;
        }
    }
}
