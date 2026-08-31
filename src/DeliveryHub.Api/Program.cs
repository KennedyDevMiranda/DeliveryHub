using DeliveryHub.Application.Estabelecimentos.Criar;
using DeliveryHub.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DeliveryHub.Application.Repositories;
using DeliveryHub.Infrastructure.Repositories;
using DeliveryHub.Application.Estabelecimentos.Listar;
using DeliveryHub.Application.Estabelecimentos.BuscarPorId;
using DeliveryHub.Application.Produtos.Criar;
using DeliveryHub.Application.Produtos.BuscarPorId;
using DeliveryHub.Application.Produtos.ListarPorEstabelecimento;
using DeliveryHub.Application.Clientes.Criar;
using DeliveryHub.Application.Pedidos.Criar;

var builder = WebApplication.CreateBuilder(args);

var connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DeliveryHubDbContext>(options =>
{
	options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<CriarEstabelecimentoUseCase>();

builder.Services.AddScoped<ListarEstabelecimentosUseCase>();

builder.Services.AddScoped<BuscarEstabelecimentoPorIdUseCase>();

builder.Services.AddScoped<CriarProdutoUseCase>();

builder.Services.AddScoped<BuscarProdutoPorIdUseCase>();

builder.Services.AddScoped<CriarClienteUseCase>();

builder.Services.AddScoped<CriarPedidoUseCase>();

builder.Services.AddScoped<
    ListarProdutosPorEstabelecimentoUseCase>();
    
builder.Services.AddScoped<
    IEstabelecimentoRepository,
    EstabelecimentoRepository>();

builder.Services.AddScoped<
    IProdutoRepository,
    ProdutoRepository>();
    
builder.Services.AddScoped<
    IClienteRepository,
    ClienteRepository>();

builder.Services.AddScoped<
    IPedidoRepository,
    PedidoRepository>();
    
// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();