var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// WelcomePageMiddleware - ��������� middlware-���������,
// ������� ���������� ������� ��������� ����������� ���-��������
app.UseWelcomePage();

app.Run();
