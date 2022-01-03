using HotelTravelMemories.API.Services;
using HotelTravelMemories.Data.Context;
using HotelTravelMemories.Data.Interfaces;
using HotelTravelMemories.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace HotelTravelMemories.API
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
            services.AddDbContext<HotelContext>(opt =>
            {
                opt.UseMySQL(Configuration.GetConnectionString("UserConnection"));
            });

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<ICheckoutRepository, CheckouRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IQuartoRepository, QuartoRepository>();
            services.AddScoped<IReservaRepository, ReservaRepository>();
            services.AddScoped<ITipoQuartoRepository, TipoQuartoRepository>();

            services.AddScoped<ClienteService, ClienteService>();
            services.AddScoped<CargoService, CargoService>();
            services.AddScoped<CheckoutService, CheckoutService>();
            services.AddScoped<CidadeService, CidadeService>();
            services.AddScoped<EnderecoService, EnderecoService>();
            services.AddScoped<FuncionarioService, FuncionarioService>();
            services.AddScoped<QuartoService, QuartoService>();
            services.AddScoped<ReservaService, ReservaService>();
            services.AddScoped<TipoQuartoService, TipoQuartoService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
