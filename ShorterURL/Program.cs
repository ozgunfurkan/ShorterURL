using BusinessLayer;
using DataLayer.Interfaces;
using DataLayer.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IShorterUrl,ShorterUrlRepo>();
builder.Services.AddTransient<IShorterUrlBusinessInterface, ShorterUrlBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallback(handler:  (HttpContext ctx,IShorterUrlBusinessInterface _businessInterface) =>
{
   
    string geturl = ctx.Request.Scheme + "://" + ctx.Request.Host + ctx.Request.Path;
    var getData = _businessInterface.CheckUrl(geturl);
    
    if (getData == null)
    {
        return Results.BadRequest("Y�nlendirilecek url bulunamad�");
    }

    return Results.Redirect(getData.Url);
});
app.Run();
