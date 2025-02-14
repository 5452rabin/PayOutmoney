using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Assignment.Data;
using Assignment.Areas.Identity.Data;
using Assignment.Services.Interface;
using Assignment.Services.Implementation;
using Assignment.Constraints;
using AutoMapper;
using Assignment.Mapper;
using Assignment.GenericRepository.Interface;
using Assignment.GenericRepository.Implementation;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AssignmentDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'AssignmentDbContextConnection' not found.");

// Add DbContext with SQL Server provider
builder.Services.AddDbContext<AssignmentDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Identity services
builder.Services.AddDefaultIdentity<AssignmentUser>(options =>
    options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AssignmentDbContext>();


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
// Add services to the container.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IForexService,ForexService>();
builder.Services.AddScoped<ITransactionService,TrasactionService>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();
app.Lifetime.ApplicationStarted.Register(async () =>
{
    using (var scope = app.Services.CreateScope())
    {
        var rateService = scope.ServiceProvider.GetRequiredService<IForexService>();
        StaticForexRates.rateVMs = await rateService.GetAllRates();
    }
});


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
app.MapRazorPages();

app.Run();
