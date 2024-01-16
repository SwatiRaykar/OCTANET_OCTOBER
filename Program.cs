using EmployeePaySlip.Interface;
using EmployeePaySlip.Models.Tables;
using EmployeePaySlip.Repository;
using Configuration = System.Configuration.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IHttpContextAccessor>();
//builder.Services.AddControllers();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();//Dependency injection
                                                                         //builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(
                                                                         //  builder.Configuration.GetConnectionString("MvcConn")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();