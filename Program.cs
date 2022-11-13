var builder = WebApplication.CreateBuilder(args);
//Add thêm
builder.Services.AddSession();
builder.Services.AddControllersWithViews(); 

var app = builder.Build();
app.UseSession();
//Cần sửa
//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");
app.Run();