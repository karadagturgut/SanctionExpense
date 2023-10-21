using Microsoft.EntityFrameworkCore;
using SanctionExpense.Core.Repositories;
using SanctionExpense.Core.Services;
using SanctionExpense.Core.UnitOfWork;
using SanctionExpense.Repository.Repositories;
using SanctionExpense.Repository.UnitOfWork;
using SanctionExpense.Repository;
using SanctionExpense.Service.Services.Mapping;
using SanctionExpense.Service;
using System.Reflection;
using SanctionExpense.Service.Services;

namespace SanctionExpense.API.Extension
{
    public static class StartupExtension
    {
        public static void AddConnection(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer("Server=94.73.170.33;Initial Catalog=u1429400_SExpens;User Id=u1429400_user278;Password=r:yg69A=.jB:4GK2",
                options => options.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)).GetName().Name

                )));
        }

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
