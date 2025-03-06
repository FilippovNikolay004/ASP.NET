// CreateBuilder ������� ����� ��������� WebApplicationBuilder � ������������������ �����������.
// ��� ������������� ������� WebApplicationBuilder � ����� CreateBuilder ����� ������������
// ��������� ��������� ������, ��������� ��� ������� ����������.
var builder = WebApplication.CreateBuilder(args);

// ����� Build ������� ��������� Web-����������.
var app = builder.Build();
/* ����� �������� ������� WebApplication ����� WebApplicationBuilder ��������� 
   ��� ��� �����, ����� ������� ����� �������� ���������:
   - ��������� ������������ ����������
   - ���������� ��������
   - ��������� ����������� � ����������
   - ��������� ��������� ����������
   - ������������ �������� IHostBuilder � IWebHostBuilder, 
     ������� ����������� ��� �������� ����� ����������.
*/

// ����� Run ��������� ������������ middleware-��������� � �������� ��������� �������.
// ������������ middleware-���������, ��� ��������, ��������� ��������� �������.
// ������� ����� ���������, ������������ ����� ����� Run, �� �������� ������� ������
// ���������� � ������ ��������� ������� �� ��������.
app.Run(HandleRequest);

// Run ��� ���������� ��������� ����������,
// � ���-������ �������� ������������ ��� �������� HTTP-�������
app.Run();

async Task HandleRequest(HttpContext context)
{
    /*
     ��� ��������� ������� ������ ��������� �� ��� ������ ������ HttpContext, 
    ������� �������� ��� ����������� ���������� � �������. 
    ��� ���������� ����������� ������� HttpContext ���������� ���� 
    ����������� middleware � ����������.
    */

    // Request: ���������� ������ HttpRequest,
    // ������� ������ ���������� � ������� �������.
    // Query: ���������� ��������� ���������� �� ������ �������.

    var name = context.Request.Query["Name"];
    var surname = context.Request.Query["Surname"];
    string responseStr = "<html><head><meta charset='utf8'></head><body><h1>"
        + name + "  " + surname + "</h1>"
        + "<a href='/?Name=Lesya&Surname=Ukrainka'>Poet 1</a><br />"
        + "<a href='/?Name=Taras&Surname=Shevchenko'>Poet 2</a><br />"
        + "<a href='/?Name=Ivan&Surname=Franko'>Poet 3</a><br />"
        + "</body></html>";

    // Response: ���������� ������ HttpResponse,
    // ������� ��������� ��������� ������� ������

    // ContentType: �������� ��� ������������� ��������� Content-Type
    context.Response.ContentType = "text/html; charset=utf-8";

    // WriteAsync(): ���������� ��������� ���������� �������.
    await context.Response.WriteAsync(responseStr);
}
