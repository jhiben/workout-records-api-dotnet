using WorkoutRecords.Persistence.Configurations;
using WorkoutRecords.Persistence.Repositories;
using WorkoutRecords.Application.Services;

namespace WorkoutRecords.Api
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
            services.AddControllers();
            services.AddMarten(Configuration);
            services.AddScoped<IWorkoutRepository, WorkoutRepository>();
            services.AddScoped<IRecordHistoryRepository, RecordHistoryRepository>();
            services.AddScoped<WorkoutService>();
            services.AddScoped<RecordHistoryService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
