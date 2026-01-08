using PruebaTecnicaCarsales.Clients;
using PruebaTecnicaCarsales.Common;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<Utils>();

var clientBaseUrl = builder.Configuration["Client:BaseUrl"];
builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularAppPolicy", policy =>
    {
        policy.WithOrigins(clientBaseUrl) //Se deja opcion http por defecto
       .AllowAnyHeader()
       .AllowAnyMethod();

    });
});

// Add services to the container.
var rickAndMortyApiUrl = builder.Configuration.GetValue<string>("ExternalApis:RickAndMortyApi:BaseUrl");

builder.Services.AddControllers();

builder.Services.AddHttpClient<IRickAndMortyApiClient, RickAndMortyApiClient>(client =>
{
    client.BaseAddress = new Uri(rickAndMortyApiUrl);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AngularAppPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
