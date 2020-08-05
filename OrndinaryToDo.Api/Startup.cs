using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrndinaryToDo.Domain.Handlers;
using OrndinaryToDo.Domain.Commands;
using OrndinaryToDo.Domain.Repositories;
using OrndinaryToDo.Infra.Contexts;
using OrndinaryToDo.Domain.Handlers.Contracts;
using OrndinaryToDo.Infra.Repositories;

namespace OrndinaryToDo.Api
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
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            //services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ConnString")));

            services.AddTransient<ITodoRepository, TodoRepository>();
            // services.AddTransient<IHandler<CreateTodoCommand>, TodoHandler>();
            // services.AddTransient<IHandler<UpdateTodoCommand>, TodoHandler>();
            // services.AddTransient<IHandler<MarkTodoAsDoneCommand>, TodoHandler>();
            // services.AddTransient<IHandler<MarkTodoAsUndoneCommand>, TodoHandler>();

            //Or simplefy with:
            services.AddTransient<TodoHandler, TodoHandler>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            //Enable access for localhost
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
