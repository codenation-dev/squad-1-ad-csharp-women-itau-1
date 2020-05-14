using ProjetoFinal.ConfigStartup;
using ProjetoFinal.Filters;
using ProjetoFinal.Models;
using ProjetoFinal.Services;
using ProjetoFinal.Interfaces;
using AutoMapper;
using System.Security.Claims;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


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
            services.AddMvcCore()
            .AddAuthorization(opt => {
                opt.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Email, "squad1@codenation.com"));
            })
            .AddJsonFormatters()
            .AddApiExplorer()
            .AddVersionedApiExplorer(p =>
            {
                p.GroupNameFormat = "'v'VVV";
                p.SubstituteApiVersionInUrl = true;
            });
            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ErrorResponseFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<Context>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IAmbienteService, AmbienteService>();
            services.AddScoped<IErroService, ErroService>();
            services.AddScoped<INivelService, NivelService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddIdentityConfiguration(Configuration);

            services.AddApiVersioning(p =>
            {
                p.DefaultApiVersion = new ApiVersion(1, 0);
                p.ReportApiVersions = true;
                p.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            // config swagger para gerar arquivo de documentação swagger.json
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityRequirement(
                    new Dictionary<string, IEnumerable<string>> {
                            { "Bearer", new string[] { } }
                });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey",
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}"
                });

            });

            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });

            services.AddTransient<IEmailServices, EmailServices>();

            //CONFIG GRID
            services.Configure<SendGridOptions>(Configuration.GetSection("SendGridOptions"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
                }

                options.DocExpansion(DocExpansion.List);
            });

            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

        }
    }
}
