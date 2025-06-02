using AgendaProfit.Infraestructure.Context;
using AgendaProfit.Infraestructure.Repositories.Interfaces;
using AgendaProfit.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using AgendaProfit.Application.AppllicationService.Interfaces;
using AgendaProfit.Application.AppllicationService;

var builder = WebApplication.CreateBuilder(args);

//repository
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//services
builder.Services.AddScoped<IContatoApplicationService, ContatoApplicationService>();
builder.Services.AddScoped<IAgendaApplicationService, AgendaApplicationService>();
builder.Services.AddScoped<IUsuarioApplicationService, UsuarioApplicationService>();

//cache
builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration["DBConfig"];

builder.Services.AddDbContext<AgendaDbContext>(options =>
       options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
