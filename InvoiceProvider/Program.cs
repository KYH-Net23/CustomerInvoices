using InvoiceManagementLibrary.Contexts;
using InvoiceManagementLibrary.Factories;
using InvoiceManagementLibrary.Repositories;
using InvoiceManagementLibrary.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInvoiceService ,InvoiceService>();
builder.Services.AddScoped<IInvoiceRepository ,InvoiceRepository>();

builder.Services.AddDbContext<InvoiceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
}
    );
  var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<InvoiceDbContext>();
    //context.Database.Migrate();
}

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
