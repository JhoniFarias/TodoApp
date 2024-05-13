using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
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

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("todos"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.Authority = "https://securetoken.google.com/project-894259307264";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = "https://securetoken.google.com/todo-4cddb",
            ValidateAudience = true,
            ValidAudience = "todo-4cddb",
            ValidateLifetime = true,
        };
    });

builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddMvc();

var app = builder.Build();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials


app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

//app.UseHttpsRedirection();

app.Run();

