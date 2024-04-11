using ProjetoEmprestimoAspCore.Repository.Contrato;
using ProjetoEmprestimoAspCore.Repository;
using ProjetoEmprestimoAspCore.CarrinhoCompra;
using ProjetoEmprestimoAspCore.GerenciaArquivos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
//builder.Services.AddScoped<Carrinho, Carrinho>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

// Corrigir problema com TEMPDATA para aumentar o tempo de duração
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // Set a short timeout for easy testing. 
    options.IdleTimeout = TimeSpan.FromSeconds(900);
    options.Cookie.HttpOnly = true;
    // Deixar informado para o navegador que a sessão é essencial
    options.Cookie.IsEssential = true;
});

builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddMemoryCache();

builder.Services.AddScoped<GerenciadorArquivo>();
builder.Services.AddScoped<ProjetoEmprestimoAspCore.Cookie.Cookie>();
builder.Services.AddScoped<ProjetoEmprestimoAspCore.CarrinhoCompra.Carrinho>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
