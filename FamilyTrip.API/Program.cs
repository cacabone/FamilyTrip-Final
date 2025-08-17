using FamilyTrip.Application.Contract;
using FamilyTrip.Application.Mapping;
using FamilyTrip.Application.Service;
using FamilyTrip.Application.Services; // Usa solo este si aquí están tus servicios
using FamilyTrip.Infrastructure.Context;
using FamilyTrip.Infrastructure.Repositories; // Ajusta al namespace correcto
using FamilyTrip.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FamilyTripDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add CORS for Blazor WASM dev server
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7067") // Blazor dev server (matches launchSettings.json)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Repositories & Services
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<ITripService, TripService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

builder.Services.AddScoped<IItineraryRepository, ItineraryRepository>();
builder.Services.AddScoped<IItineraryService, ItineraryService>();
builder.Services.AddScoped<IItineraryItemService, ItineraryItemService>();

builder.Services.AddScoped<IPackingListRepository, PackingListRepository>();
builder.Services.AddScoped<IPackingListService, PackingListService>();

builder.Services.AddScoped<IFamilyRepository, FamilyRepository>();
builder.Services.AddScoped<IFamilyMemberService, FamilyMemberService>();
builder.Services.AddScoped<IFamilyService, FamilyService>();

// Swagger & AutoMapper
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
builder.Services.AddControllers(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS before controllers
app.UseCors();

// Serve static files (for Blazor)
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

// Fallback to index.html for client-side routing
app.MapFallbackToFile("index.html");

app.Run();

