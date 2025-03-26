using homework.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDistributedMemoryCache(); // ��������� IDistributedMemoryCache
builder.Services.AddSession(); // ��������� ������� ������

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<GuestBookContext>(options => options.UseSqlServer(connection));

// ��������� ������� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// ��������� middleware-��������� ��� ������ � ��������
app.UseSession(); 

// ������������ ������� � ������ � ����� wwwroot
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
