using homework;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRegisterMiddleware();
app.UseLoginMiddleware();
app.UseHomePageMiddleware();


app.MapGet("/", () => "Hello World!");

app.Run();
