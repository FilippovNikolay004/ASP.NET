using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPortal.DAL.EF;
using Microsoft.EntityFrameworkCore;


namespace MusicPortal.BLL.Infrastructure {
    public static class MusicPortalContextExtensions {
        public static void AddMusicPortalContext(this IServiceCollection services, string connection) {
            services.AddDbContext<MusicPortalDbContext>(options => options.UseSqlServer(connection));
        }
    }
}
