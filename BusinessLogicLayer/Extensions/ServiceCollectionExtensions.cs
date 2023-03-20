using BusinessLogicLayer.Factories;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Implementations;
using DataAccessLayer.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BusinessLogicLayer.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IDepartmentService, DepartmentService>();
        collection.AddScoped<IDeviceService, DeviceService>();
        collection.AddScoped<IReportService, ReportService>();
        collection.AddScoped<ISessionService, SessionService>();
        
        collection.TryAddEnumerable(ServiceDescriptor.Scoped<IReportInfoFactory, ReportInfoByDeviceFactory>());
        collection.TryAddEnumerable(ServiceDescriptor.Scoped<IReportInfoFactory, ReportInfoProcessedFactory>());
        collection.TryAddEnumerable(ServiceDescriptor.Scoped<IReportInfoFactory, ReportInfoByTimeFactory>());

        return collection;
    }
}