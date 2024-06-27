using Application;
using Domain.Entities;
using Domain.ValueObjects;
using Infra.Data;
using Infra.Data.Context;
using Infra.Email;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataBaseInMemoryService();
builder.Services.AddEmailService();
builder.Services.AddApplicationService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

DataInit(app);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

void DataInit(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var context = serviceScope.ServiceProvider.GetService<InMemoryContext>();

        if(context == null)
        {
            throw new Exception("Context could not be created!");
        }

        context.Database.EnsureCreated();

        if (!context.Users.Any())
        {
            var mariaName = new NameVo("Maria", "da Silva");
            var mariaEmail = new EmailVo("maria.silva @example.com");
            var maria = new User(Guid.NewGuid(), mariaName, mariaEmail);

            var joaoName = new NameVo("Jo�o", "Pereira");
            var joaoEmail = new EmailVo("joao.pereira@example.com");
            var joao = new User(Guid.NewGuid(), joaoName, joaoEmail);

            var anaName = new NameVo("Ana", "Souza");
            var anaEmail = new EmailVo("ana.souza@example.com");
            var ana = new User(Guid.NewGuid(), anaName, anaEmail);

            context.Users.AddRange(maria, ana, joao);
            context.SaveChanges();
        }
    }
}

