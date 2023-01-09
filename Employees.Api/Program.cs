using Autofac.Extensions.DependencyInjection;
using Autofac;
using Employees.Api.Infrastructure.AutofacModules;
using Employees.Api.Infrastructure.Delegates;
using Employees.Api.Infrastructure.Extensions;
using Employees.Api.Middlewares;
using Employees.Application;
using Employees.Services.Services.Interfaces;
using Employees.Services.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    //.AddCorsCustom()
    //.AddCustomMvc()
    .AddCustomAuthentication(builder.Configuration)
    .AddSwaggerDoc(builder.Configuration);

    builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
    builder.Services.AddTransient<HttpClientAuthorizationDelegatingHandler>();
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    builder.Services.AddHttpClient<ISecurityService, SecurityService>(s => s.BaseAddress = new Uri(builder.Configuration["MsSecurity"])).AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

    builder.Services.AddConfigureCors();
    builder.Services.AddControllers();
}

builder.Services.AddApplicationLayer();

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new ApplicationModule(builder.Configuration["ConnectionSting"], builder.Configuration["TimeZone"])));
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new MediatorModule()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerDoc(builder.Configuration);
}

app.UseCors("corsApp");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();