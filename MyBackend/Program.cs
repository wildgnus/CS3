using Microsoft.EntityFrameworkCore;
  using HotelCheckInSystem.Data;

  var builder = WebApplication.CreateBuilder(args);

  builder.WebHost.UseUrls("http://0.0.0.0:5000"); // Bind to all interfaces

  // Add services to the container.
  builder.Services.AddControllers();
  builder.Services.AddDbContext<HotelContext>(options =>
      options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
  builder.Services.AddCors(options =>
  {
      options.AddPolicy("AllowFrontend", policy =>
      {
          policy.WithOrigins("http://127.0.0.1:8080") // Match your frontend origin
                .AllowAnyMethod()
                .AllowAnyHeader();
      });
  });

  var app = builder.Build();

  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
      app.UseDeveloperExceptionPage(); // Enable detailed error pages
  }

  app.UseRouting();
  app.UseCors("AllowFrontend"); // Apply the CORS policy
  app.UseAuthorization();

  app.MapControllers();

  app.Run();