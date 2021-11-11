using Core;
using Core.Service;
using Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;

namespace CondoTechWEB
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
            services.AddControllersWithViews();

            //Injeção de dependência DBContext
            services.AddDbContext<CondoTechContext>(options =>
                options.UseMySQL(
                    Configuration.GetConnectionString("CondoTechConnection")));

            //Injeção de dependência Services
            services.AddTransient<IAreacomumService, AreacomumService>();
            services.AddTransient<IAvisoService, AvisosService>();
            services.AddTransient<ICondominioService, CondominioService>();
            services.AddTransient<IOcorrenciaService, OcorrenciaService>();
            services.AddTransient<ITarefaRecorrenteService, TarefaRecorrenteService>();
            services.AddTransient<IPessoaService, PessoaService>();


            //Injeção de dependência Mapper
            services.AddAutoMapper(typeof(Startup).Assembly);



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
