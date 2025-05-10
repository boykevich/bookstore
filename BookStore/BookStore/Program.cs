using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BookStore.Components;
using BookStore.Components.Models;
using BookStore.Components.Account;
using BookStore.Data;
using Stripe;
using Amazon.S3;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // Ensures compatibility with legacy PostgreSQL timestamp behavior
var builder = WebApplication.CreateBuilder(args);

// ---------------------
// Configure Services
// ---------------------

// Add Razor components and server-side Blazor support
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add support for MVC/Web API controllers
builder.Services.AddControllers();

// Enable cascading auth state and identity components
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

// Bind configuration for Stripe and OpenAI
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.Configure<OpenAIOptions>(builder.Configuration.GetSection("OpenAI"));

// Add AWS S3 support
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();

// Configure Identity authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

// Configure Entity Framework and PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

// Set Stripe API key
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

// Configure Identity with roles and token support
builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// Use no-op email sender (you can replace it with your implementation)
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// ---------------------
// Configure Middleware
// ---------------------

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint(); // Useful for dev migrations and DB management
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // Adds HTTP Strict Transport Security for production
}

// ---------------------
// Ensure Roles and Default Admin User
// ---------------------
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    // Create default roles
    string[] roleNames = { "Admin", "User" };
    foreach (var role in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Create default admin user if not exists
    var adminEmail = "admin@bookstore.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var user = new ApplicationUser
        {
            UserName = adminEmail,
            Email = adminEmail,
            EmailConfirmed = true
        };
        var result = await userManager.CreateAsync(user, "Admin@123");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

// ---------------------
// Apply Pending Migrations
// ---------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate(); // Applies migrations or creates DB if not exists
}

// ---------------------
// HTTP Pipeline Configuration
// ---------------------

app.UseHttpsRedirection();
app.UseStaticFiles();     // Serves static files like CSS, JS, images
app.UseAntiforgery();     // CSRF protection

// Maps Razor components and enables interactive server rendering
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Identity endpoints (login, register, etc.)
app.MapAdditionalIdentityEndpoints();

// Maps API controllers (e.g., for REST endpoints)
app.MapControllers();

// Starts the application
app.Run();
