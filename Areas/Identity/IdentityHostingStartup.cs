//using System;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using WebApplication2.Areas.Identity.Data;
//using WebApplication2.Data;

//[assembly: HostingStartup(typeof(UsingIdentity.Areas.Identity.IdentityHostingStartup))]
//namespace UsingIdentity.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<FurnitureDBContext>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("UsingIdentityContextConnection")));

//                services.AddDefaultIdentity<UsingIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//                 .AddRoles<IdentityRole>()
//                .AddEntityFrameworkStores<FurnitureDBContext>();
//            });
//        }
//    }
//}