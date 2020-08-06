using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OrndinaryToDo.Domain.Handlers;
using OrndinaryToDo.Domain.Repositories;
using OrndinaryToDo.Infra.Contexts;
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
            //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));

            services.AddTransient<ITodoRepository, TodoRepository>();
            // services.AddTransient<IHandler<CreateTodoCommand>, TodoHandler>();
            // services.AddTransient<IHandler<UpdateTodoCommand>, TodoHandler>();
            // services.AddTransient<IHandler<MarkTodoAsDoneCommand>, TodoHandler>();
            // services.AddTransient<IHandler<MarkTodoAsUndoneCommand>, TodoHandler>();

            //Or simplefy with:
            services.AddTransient<TodoHandler, TodoHandler>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.Authority = "https://securetoken.google.com/todo-a6920";
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "https://securetoken.google.com/todo-a6920",
                    ValidateAudience = true,
                    ValidAudience = "todo-a6920",
                    ValidateLifetime = true
                };
            });
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
