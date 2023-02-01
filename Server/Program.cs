using DAL;
using ProtoBuf.Grpc.Server;
using ServerLibrary;
using Server.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Server.GRPCServices;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCodeFirstGrpc();

            builder.Services.AddSingleton<IConnectionStringProvider, ConnecionStringProvider>();
            builder.Services.AddSingleton<IDataSaver, DataSaver>();
            builder.Services.AddSingleton<ICache, Cache>();
            builder.Services.AddScoped<IDataReciever, DataReciever>();
            builder.Services.AddScoped<IDataSource, DataSource>();
            builder.Services.AddScoped<IDataSender, DataSender>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:7163",
                                                          "http://localhost:5079").AllowAnyHeader()
                                                        .AllowAnyMethod();
                                  });
            });

            var app = builder.Build();

            app.UseCors(MyAllowSpecificOrigins);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseWebSockets();

            
            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGrpcService<GRPCRecieverService>();
            app.MapControllers();

            app.Run();
        }
    }
}