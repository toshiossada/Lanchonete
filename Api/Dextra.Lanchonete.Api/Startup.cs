using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dextra.Lanchonete.Api.Business;
using Dextra.Lanchonete.Api.Models;
using Dextra.Lanchonete.Api.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Dextra.Lanchonete.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            services.AddDbContext<MyAppContext> (options =>
                options.UseSqlServer (Configuration.GetConnectionString ("DefaultConnection")));

            //Injeção de Depedencia Repository
            #region DI_Repository
            services.AddTransient<IIngredienteRepository, IngredienteRepository> ();
            services.AddTransient<ILancheRepository, LancheRepository> ();
            services.AddTransient<IPedidoLancheRepository, PedidoLancheRepository> ();
            #endregion
            //Injeção de Depedencia Business
            #region DI_Business
            services.AddTransient<IIngredienteBll, IngredienteBll> ();
            services.AddTransient<ILancheBll, LancheBll> ();
            services.AddTransient<IPedidoLancheBll, PedidoLancheBll> ();
            #endregion

            //Inicializando Swagger
            services.AddSwaggerGen (
                c => {
                    c.SwaggerDoc ("v1", new Info {
                        Title = "UsuarioWebAPI",
                            Version = "v1",
                            Description = "API para Lanchonete",
                            TermsOfService = "None",
                            Contact = new Contact { Name = "Toshi Ossada", Email = "toshiossada@gmail.com", Url = "https://github.com/toshiossada" },
                            License = new License { Name = "GNU", Url = "https://www.gnu.org/licenses/licenses.pt-br.html" }

                    });
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();

            //Definindo Endpoint Swagger
            app.UseSwagger ();
            app.UseSwaggerUI (
                c => {
                    c.SwaggerEndpoint ("/swagger/v1/swagger.json", "Minha API v1");
                }
            );

            app.UseMvc ();
        }
    }
}