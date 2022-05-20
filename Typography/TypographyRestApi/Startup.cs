
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TypographyDatabaseImplement.Implements;
using TypographyBusinessLogic.BusinessLogics;
using TypographyContracts.BusinessLogicsContracts;
using TypographyContracts.StoragesContracts;
using TypographyBusinessLogic.MailWorker;
using TypographyBusinessLogic.MailWorker.Implements;
using TypographyContracts.BindingModels;
using System;

namespace TypographyRestApi
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
            services.AddTransient<IClientStorage, ClientStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();
            services.AddTransient<IPrintedStorage, PrintedsStorage>();
            services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<IClientLogic, ClientLogic>();
            services.AddTransient<IPrintedLogic, PrintedLogic>();
            services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();
            services.AddSingleton<AbstractMailWorker, MailKitWorker>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TypographyRestApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TypographyRestApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var mailSender = app.ApplicationServices.GetService<AbstractMailWorker>();
            mailSender.MailConfig(new MailConfigBindingModel
            {
                MailLogin = Configuration?["MailLogin"]?.ToString(),
                MailPassword = Configuration?["MailPassword"]?.ToString(),
                SmtpClientHost = Configuration?["SmtpClientHost"]?.ToString(),
                SmtpClientPort = Convert.ToInt32(Configuration?["SmtpClientPort"]?.ToString()),
                PopHost = Configuration?["PopHost"]?.ToString(),
                PopPort = Convert.ToInt32(Configuration?["PopPort"]?.ToString())
            });
        }
    }
}
