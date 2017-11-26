using EyeCare.Backend.Data;
using EyeCare.Backend.Services;
using EyeCare.Backend.Services.Abstractions;
using EyeCare.Backend.Training.Abstractions;
using EyeCare.Backend.Training.Data;
using EyeCare.Backend.Training.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackifyMiddleware;

namespace EyeCare.Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment, EyesTrainer eyesTrainer)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;

            eyesTrainer.SetTrainingKey("52231d7c3fe84c37a3b25b2f1abe6ac2");
            eyesTrainer.InitializeModel();
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<EyeCareDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("EyeCare")));
            services.AddScoped<IDiagnosisData, SqlDiagnosisData>();
            services.AddScoped<IPatientsData, SqlPatientsData>();
            services.AddScoped<IEyesData, SqlEyesData>();
            services.AddScoped<ITrainingsData, SqlTrainingsesData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMiddleware<RequestTracerMiddleware>();

            app.UseMvc();
        }
    }
}
