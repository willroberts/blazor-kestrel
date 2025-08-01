using blazor_kestrel.Components;

// ASP.NET Core project templates use Kestrel by default when not hosted with IIS. In the following
// template-generated Program.cs, the WebApplication.CreateBuilder method calls UseKestrel internally:
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see
	// https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Configure Kestrel in non-Blazor context.
//app.MapGet("/", () => "hello world");

// Configure Kestrel in Blazor context.
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
