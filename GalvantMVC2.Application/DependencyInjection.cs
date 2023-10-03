using GalvantMVC2.Application.Interfaces;
using GalvantMVC2.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GalvantMVC2.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<ILocation2Service, Location2Service>();
            services.AddTransient<IEquipmentService, EquipmentService>();            
            return services;
        }
    }
}
