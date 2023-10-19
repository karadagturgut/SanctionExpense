using Microsoft.EntityFrameworkCore;
using SanctionExpense.Core.Repositories;
using SanctionExpense.Core.Services;
using SanctionExpense.Core.UnitOfWork;
using SanctionExpense.Repository;
using SanctionExpense.Repository.Repositories;
using SanctionExpense.Repository.UnitOfWork;
using System.Reflection;

namespace SanctionExpense.Web.Extension
{
    public static class StartupExtension
    {
        public static void AddConnection (this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer("Server=94.73.170.33;Initial Catalog=u1429400_SExpens;User Id=u1429400_user278;Password=r:yg69A=.jB:4GK2",
                options=>options.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)).GetName().Name
                
                )));
        }

        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //builder.Services.AddScoped(typeof(IService<>),typeof(Service<>))
        }
    }
}
