using GalvantMVC2.Domain.Interfaces;
using GalvantMVC2.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GalvantMVC2.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            return services;
        }
    }
}
