using Microsoft.OpenApi.Models;
using SecureOnlineVoting.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
//builder.Services.AddSwaggerGen();

/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}*/

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
//app.UseStaticFiles();
//app.UseAntiforgery();

//app.MapRazorComponents<App>()
// .AddInteractiveServerRenderMode();

app.Run();