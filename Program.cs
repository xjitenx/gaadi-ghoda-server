using gaadi_ghoda_server.IRepository.IBookieRepository;
using gaadi_ghoda_server.IRepository.IBrokerRepository;
using gaadi_ghoda_server.IRepository.ICommonRepository;
using gaadi_ghoda_server.IService.IBookieService;
using gaadi_ghoda_server.IService.IBrokerService;
using gaadi_ghoda_server.IService.ICommonService;
using gaadi_ghoda_server.Repository.BookieRepository;
using gaadi_ghoda_server.Repository.BrokerRepository;
using gaadi_ghoda_server.Repository.CommonRepository;
using gaadi_ghoda_server.Service.BookieService;
using gaadi_ghoda_server.Service.BrokerService;
using gaadi_ghoda_server.Service.CommonServie;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// IoC - Start

// SERVICES

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IBookieBrokerService, BookieBrokerService>();
builder.Services.AddScoped<IBookieLorryReceiptService, BookieLorryReceiptService>();
builder.Services.AddScoped<IBookiePartyService, BookiePartyService>();

builder.Services.AddScoped<IBrokerPartyService, BrokerPartyService>();

// REPOSITORIES

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IBookieBrokerRepository, BookieBrokerRepository>();
builder.Services.AddScoped<IBookieLorryReceiptRepository, BookieLorryReceiptRepository>();
builder.Services.AddScoped<IBookiePartyRepository, BookiePartyRepository>();

builder.Services.AddScoped<IBrokerPartyRepository, BrokerPartyRepository>();

// IoC - End

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
