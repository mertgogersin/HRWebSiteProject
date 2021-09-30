using Core.EmailSenderManager;
using Core.Entities;
using Core.Model.Authentication;
using Core.Services;
using Core.UnitOfWork;
using DataAccess.Context;
using DataAccess.CustomPolicies;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Services;

namespace HRWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRWebApi", Version = "v1" });
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddDbContext<HRContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));

            services.AddIdentity<User, Role>(opts =>
            {

                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireDigit = true;

            }).AddEntityFrameworkStores<HRContext>()
            .AddDefaultTokenProviders()
            .AddUserValidator<CustomUserValidator<User>>();

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<Admin>(Configuration.GetSection("Admin"));
            services.AddAutoMapper(typeof(Startup));

            services.AddCors(opts => opts.AddPolicy("myPolicy", builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
                builder.WithOrigins("http://localhost:37338");
            }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRWebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
