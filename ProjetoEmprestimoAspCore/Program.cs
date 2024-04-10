using ProjetoEmprestimoAspCore.Repository.Contrato;
using ProjetoEmprestimoAspCore.Repository;
using ProjetoEmprestimoAspCore.CarrinhoCompra;
using ProjetoEmprestimoAspCore.GerenciaArquivos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
//builder.Services.AddScoped<Carrinho, Carrinho>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
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
    app.UseExceptionHandler("/Livro/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Livro}/{action=Index}/{id?}");


app.Run();
