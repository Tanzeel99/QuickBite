using QuickBite.Web.Service.IService;
using QuickBite.Web.Service;
using QuickBite.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Used to work with cookies
builder.Services.AddHttpContextAccessor();

//To configure http client in coupon service (actually base service but base service is called as DI in coupon service)
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<ICouponService, CouponService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<ICartService, CartService>();
builder.Services.AddHttpClient<IOrderService, OrderService>();

//Assigning the base URL from appsetings to property CouponAPIBaseURL present in staticdetail class in utility folder
StaticDetails.CouponAPIBaseURL = builder.Configuration["ServiceURLs:CouponAPI"];
StaticDetails.AuthAPIBaseURL = builder.Configuration["ServiceURLs:AuthAPI"];
StaticDetails.ProductAPIBaseURL = builder.Configuration["ServiceURLs:ProductAPI"];
StaticDetails.ShoppingCartAPIBaseURL = builder.Configuration["ServiceURLs:CartAPI"];
StaticDetails.OrderAPIBase = builder.Configuration["ServiceURLs:OrderAPI"];

builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

//To add authentication with cookie method
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/Auth/Login"; //If the user is not logged in redirect to this path
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
