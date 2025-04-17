using Gestao.Components;
using Gestao.Components.Account;
using Gestao.Data;
using Gestao.Data.Repositories;
using Gestao.Data.Repositories.Interfaces;
using Gestao.Libraries.Mail;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Gestao.Data.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Google:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Google:ClientSecret")!;
    })
    .AddFacebook(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Facebook:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Facebook:ClientSecret")!;
    })
    .AddMicrosoftAccount(options =>
    {
        options.ClientId = builder.Configuration.GetValue<string>("OAuth:Microsoft:ClientId")!;
        options.ClientSecret = builder.Configuration.GetValue<string>("OAuth:Microsoft:ClientSecret")!;
    })
    .AddTwitter(options =>
    {
        options.ConsumerKey = builder.Configuration.GetValue<string>("OAuth:Twitter:ConsumerKey")!;
        options.ConsumerSecret = builder.Configuration.GetValue<string>("OAuth:Twitter:ConsumerSecret")!;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), 
        b => b.MigrationsAssembly("Gestao")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;

    options.Password.RequireDigit = true; // É necessário ter números
    options.Password.RequireLowercase = false; // Não é necessário ter letras minúsculas
    options.Password.RequireUppercase = false; // Não é necessário ter letras maiúsculas
    options.Password.RequireNonAlphanumeric = false; // Não é necessário ter caracteres especiais
    options.Password.RequiredLength = 6; // Tamanho mínimo da senha
                                         //options.SignIn.RequireConfirmedAccount = true; // O usuário precisa confirmar a conta
    options.User.RequireUniqueEmail = true; // O email do usuário precisa ser único
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();



builder.Services.AddSingleton<SmtpClient>(options =>
{
    var smtp = new SmtpClient();
    smtp.Host = builder.Configuration.GetValue<string>("EmailSender:Server")!;
    smtp.Port = builder.Configuration.GetValue<int>("EmailSender:Port");
    smtp.EnableSsl = builder.Configuration.GetValue<bool>("EmailSender:EnableSsl");
    smtp.Credentials = new System.Net.NetworkCredential(
        builder.Configuration.GetValue<string>("EmailSender:User"),
        builder.Configuration.GetValue<string>("EmailSender:Password"));
    return smtp;
});
builder.Services.AddSingleton<IEmailSender<ApplicationUser>, EmailSender>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Gestao.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.MapAccountsEndpoints();
app.MapCategoryEndpoints();
app.MapCompanyEndpoints();
app.MapFinancialTransactionsEndpoints();

app.Run();