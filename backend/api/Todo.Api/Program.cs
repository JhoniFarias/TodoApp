using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using Todo.Application.Handlers;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Infra.DataContexts;
using Todo.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();


builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("connection_string");
}
);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://securetoken.google.com/your-project";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/your-project",
            ValidateAudience = true,
            ValidAudience = "your-project",
            ValidateLifetime = true,
        };
    });

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddMvc();

var app = builder.Build();

var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
dbContext.Database.Migrate();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());


app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

//app.UseHttpsRedirection();

app.Run();

