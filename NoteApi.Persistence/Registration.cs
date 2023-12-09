using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteApi.Application.Interfaces.Repositories;
using NoteApi.Application.Interfaces.UnitOfWorks;
using NoteApi.Persistence.context;
using NoteApi.Persistence.Repositories;
using NoteApi.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApi.Persistence
{
    public static class Registration
    {

        //Dependency 
        public static void AddPersistence(this IServiceCollection  services,IConfiguration config)
        {

            services.AddDbContext<AppDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>),typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();

        }


    }
}
