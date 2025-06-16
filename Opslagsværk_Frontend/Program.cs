using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Opslagsværk_Frontend;
using Opslagsværk_Frontend.Services;

namespace Opslagsværk_Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5043") });

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped<JwtService>();

            await builder.Build().RunAsync();
        }
    }
}
