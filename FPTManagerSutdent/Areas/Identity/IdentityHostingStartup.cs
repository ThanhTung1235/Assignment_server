using System;
using FPTManagerSutdent.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(FPTManagerSutdent.Areas.Identity.IdentityHostingStartup))]
namespace FPTManagerSutdent.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FPTManagerSutdentContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FPTManagerSutdentContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                    .AddEntityFrameworkStores<FPTManagerSutdentContext>();
            });
        }
    }
}