using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyList.Application.Lookup;
using MyList.Application.Persistence;
using MyList.Domain.Behaviors;

namespace MyList.Application.Initialization
{
    public static class ApplicationInitializer
    {
        public static void ApplicationRegister(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationInitializer).Assembly);

            services.AddSingleton<ItemDb>();
            services.AddSingleton<IItemPersistence, ItemPersistence>();
            services.AddSingleton<IItemLookup, ItemLookup>();
            
        }
    }
}
