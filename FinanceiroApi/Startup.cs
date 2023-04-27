using FinanceiroCore.Application.CadastrarLancamento;
using FinanceiroCore.Application.Consolidado;
using FinanceiroCore.Infrasctructure;
using FinanceiroCore.Infrasctructure.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Globalization;
using System.IO;
using System.Text.Json.Serialization;

namespace FinanceiroApi
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
            services.AddControllers().AddJsonOptions(opcoes => {
                opcoes.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanceiroApi", Version = "v1", Description= "Aplicação demonstrativa para teste MTTECHNE" });
                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            services.ConfigureSwaggerGen(options => options.CustomSchemaIds(x => x.FullName));

            services.AddDbContext<FinanceiroContext>(o => o.UseInMemoryDatabase("DbFinanceiro"));
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<ISaldoRepository, SaldoRepository>();
            
            services.AddScoped<ICadastrarLancamentoCommand, CadastrarLancamentoCommand>();
            services.Decorate<ICadastrarLancamentoCommand, AtualizarSaldoCommand>();

            services.AddScoped<IConsolidadoQuery, ConsolidadoQuery>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(p =>
            {
                p.AllowAnyHeader();
                p.AllowAnyMethod();
                p.AllowAnyOrigin();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanceiroApi v1"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
