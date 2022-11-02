using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApplication_Test_Work.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v2", new OpenApiInfo { Title = "WebApplication_Test_Work", Version = "v2" }); });

builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{

    var services = scope.ServiceProvider;

    DepositSeedData.Initialize(services);
    CurrenciesSeedData.Initialize(services);
}

if (!app.Environment.IsDevelopment())
{
    
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "WebApplication_Test_Work");
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
