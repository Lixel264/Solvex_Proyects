using Marvel.Application.Characters;
using Marvel.Application.Characters.Interfaces;
using Marvel.Application.Comics;
using Marvel.Domain.Characters;
using Marvel.Infraestructure.API;
using Marvel.Infraestructure.Characters;

var builder = WebApplication.CreateBuilder(args);

// Add configuration to the container.
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// TODO : Investigar como implementar dependency injection en .NET 6

var httpClient = new HttpClient();


// Api key de marvel
string apiKey = config.GetValue<string>("marvelApiKey");
string hash = config.GetValue<string>("marvelHash");




builder.Services.AddSingleton<IMarvelRestClient<MarvelSearch>, MarvelRestClient<MarvelSearch>>(config => new MarvelRestClient<MarvelSearch>(httpClient,apiKey,hash));

builder.Services.AddScoped<ICharacterRepository, CharacterRepository>();

builder.Services.AddScoped<ICharacterService, CharacterService>();


//builder.Services.AddScoped<IComicService, ComicService>();
//builder.Services.AddScoped<IImageRepository, ImageRepository>();




builder.Services.AddHttpClient();




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

app.Run();
