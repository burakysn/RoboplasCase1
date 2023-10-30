using Roboplas.WebAPI.Middlewares;
using Roboplas.WebAPI;
using Roboplas.Business;

namespace WS.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddApiService(builder.Configuration);
            builder.Services.AddBusinessServices();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                {
                    builder.WithOrigins(
                        "http://localhost:4200"
                        )
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials();
                });
            });
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseCustomException();
            app.UseCors("AllowSpecificOrigin");
            app.Run();
        }
    }
}
