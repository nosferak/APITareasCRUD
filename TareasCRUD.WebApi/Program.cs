using TareasCRUD.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// CREATE STARTUP INSTANCE
var startup = new Startup(builder.Configuration);

// CONFIGURE SERVICES 
startup.ConfigureServices(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

 //CONFIGURE LIFETIME
startup.Configure(app, app.Lifetime);

//Cors
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();
app.UseSwaggerUI(config =>
{
    config.RoutePrefix = ""; //para evitar problemas con la ruta en la que se lanza ...
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
