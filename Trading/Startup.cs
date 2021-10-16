using Trading.Data;
using Trading.Data.Models;
using Trading.Interfaces;
using Trading.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Trading.Middlewares;
using System.Net.Http.Headers;
using Trading.OptionBinders;

namespace Trading
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("ConnectionString")));

            //Services
            services.AddTransient<IFiatService, FiatCurrencyService>();
            services.AddTransient<ICryptoService, CryptoCurrencyService>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddHttpClient();

            //FiatApiOptions fiatOptions = Configuration.GetSection(FiatApiOptions.FiatApi).Get<FiatApiOptions>();

            //services.AddHttpClient<IFiatService, FiatCurrencyService>(client => 
            //{
            //    client.BaseAddress = new Uri(fiatOptions.BaseUrl);
            //});

            //CryptoApiOptions cryptoOptions = Configuration.GetSection(CryptoApiOptions.CryptoApi).Get<CryptoApiOptions>();

            //services.AddHttpClient<ICryptoService, CryptoCurrencyService>(client =>
            //{
            //    client.BaseAddress = new Uri(cryptoOptions.BaseUrl);
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(cryptoOptions.Header, cryptoOptions.Key);
            //});

            //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly(), Assembly.GetExecutingAssembly());

            //JWT Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });

            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Custom Exception Handler
            app.UseExceptionHandlerMiddleware();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
