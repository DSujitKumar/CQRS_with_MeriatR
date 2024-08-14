using BooksAPI.DLL;
using Microsoft.EntityFrameworkCore;
using MediatR;
using BooksAPI.Interfaces;
using BooksAPI.BLLServices;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Adding DB Context
        builder.Services.AddDbContext<BookStoreDBContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConnection")), ServiceLifetime.Singleton);

        // implementing MediatR dependancy 
        builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<AddRecords,AddRecordsService>();
        builder.Services.AddTransient<FetchRecord,FetchRecordService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}