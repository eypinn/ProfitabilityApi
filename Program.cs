using ProfitabilityApi.Services;
using Microsoft.EntityFrameworkCore;
using ProfitabilityApi.Data;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDb>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("BankDb")));
builder.Services.AddControllers();
builder.Services.AddScoped<ICalculationService, CalculationService>();
builder.Services.AddScoped<ICrmDirectoryService, CrmDirectoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISubProductService, SubProductService>();
builder.Services.AddScoped<IProductSegmentService, ProductSegmentService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ITransactionExceptionService, TransactionExceptionService>();
builder.Services.AddScoped<IMonthlyProfitabilityService, MonthlyProfitabilityService>();

builder.Services.AddHttpClient("crm",c=>c.BaseAddress=new Uri(builder.Configuration["CrmApi:BaseUrl"]!));

var app=builder.Build();

app.MapControllers(); app.Run();
