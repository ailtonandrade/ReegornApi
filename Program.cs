using static AuthApi.Services.Transactions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
//init sqlite
InitData();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors(option => option.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
app.MapControllers();

app.Run();
