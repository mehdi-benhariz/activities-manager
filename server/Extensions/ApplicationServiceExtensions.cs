using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace server.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

     services.AddDbContext<DataContext>(opt =>{
     opt.UseSqlite(
          configuration.GetConnectionString("DefaultConnection")
     );
     });
     services.AddMediatR(typeof(List.Handler).Assembly);
     services.AddAutoMapper(typeof(MappingProfiles).Assembly);
         
            return services;
        }
    }
//             builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<DataContext>(opt =>{
//      opt.UseSqlite(
//           builder.Configuration.GetConnectionString("DefaultConnection")
//      );
//      });
// builder.Services.AddMediatR(typeof(List.Handler).Assembly);
// builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

    }   
