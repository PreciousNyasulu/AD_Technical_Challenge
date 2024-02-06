using NaLib;
using NaLib.Data;
using NaLib.Models;
using NaLib.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IRepository<Users>, UserRepository>();
builder.Services.AddScoped<LibraryResourceService>();
builder.Services.AddScoped<IRepository<LibraryResource>, LibraryResourceRepository>();
builder.Services.AddScoped<HtmlService>();
builder.Services.AddScoped<IRepository<LibraryMember>,LibraryMemberRepository>();
builder.Services.AddScoped<LibraryMemberService>();

builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.WriteIndented = true;
            });

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
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

// Use CORS before other middleware
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
