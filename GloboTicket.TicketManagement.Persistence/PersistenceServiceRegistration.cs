using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDbContext>(options => options.UseSqlite(configuration.GetConnectionString("GloboTicketManagementConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IEventRepository), typeof(EventRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            return services;
        }
    }
}
