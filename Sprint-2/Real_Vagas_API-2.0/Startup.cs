using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Real_Vagas_API.Interfaces;
using Real_Vagas_API.Repositories;

namespace Real_Vagas_API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
           .AddMvc()
           .AddJsonOptions(options => {
                   options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                   options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
           })

           // Define a versão do .NET Core
           .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            services
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = "JwtBearer";
                   options.DefaultChallengeScheme = "JwtBearer";
               })

               // Define os parâmetros de validação do token
               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       // Quem está solicitando
                       ValidateIssuer = true,

                       // Quem está validando
                       ValidateAudience = true,

                       // Definindo o tempo de expiração
                       ValidateLifetime = true,

                       // Forma de criptografia
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("RealVagas-chave-autenticacao")),

                       // Tempo de expiração do token
                       ClockSkew = TimeSpan.FromMinutes(30),

                       // Nome da issuer, de onde está vindo
                       ValidIssuer = "RealVagas.WebApi.C#",

                       // Nome da audience, de onde está vindo
                       ValidAudience = "RealVagas.WebApi.C#"
                   };
               });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Real Vagas API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddTransient<IAdministrador, AdministradorRepository>();
            services.AddTransient<IDados, DadosRepository>();
            services.AddTransient<IEmpresas, EmpresasRepository>();
            services.AddTransient<IInscricao, InscricaoRepository>();
            services.AddTransient<ITipoUsuario, TipoUsuarioRepository>();
            services.AddTransient<IUsuarios, UsuariosRepository>();
            services.AddTransient<IVagas, VagasRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Real Vagas API");
                c.RoutePrefix = string.Empty;
            });

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
