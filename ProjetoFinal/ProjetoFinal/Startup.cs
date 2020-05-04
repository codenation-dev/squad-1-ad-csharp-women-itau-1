using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ProjetoFinal.Models;
using ProjetoFinal.Services;
using AutoMapper;
using ProjetoFinal.ConfigStartup;

namespace ProjetoFinal
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<Context>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IAmbienteService, AmbienteService>();
            services.AddScoped<IErroService, ErroService>();
            services.AddScoped<INivelService, NivelService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddIdentityConfiguration(Configuration); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
