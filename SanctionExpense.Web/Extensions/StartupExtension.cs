using SanctionExpense.Core.Repositories;
using SanctionExpense.Core.Services;
using SanctionExpense.Core.UnitOfWork;
using SanctionExpense.Repository.Repositories;
using SanctionExpense.Repository.UnitOfWork;
using SanctionExpense.Service.Services.Mapping;
using SanctionExpense.Service.Services;
using SanctionExpense.Service;

namespace SanctionExpense.Web.Extensions
{
    public static class StartupExtension
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
            builder.Services.AddScoped(typeof(IService<>), typeof(GenericService<>));
            builder.Services.AddScoped<IExpenseService, ExpenseService>();
        }


        public static void AddMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MapProfile));
        }
    }
}
