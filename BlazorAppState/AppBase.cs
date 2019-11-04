using BlazorState.Features.JavaScriptInterop;
using BlazorState.Features.Routing;
using BlazorState.Pipeline.ReduxDevTools;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
namespace BlazorAppState
{
    public class AppBase: ComponentBase
    {
        [Inject] private JsonRequestHandler JsonRequestHandler { get; set; }
        [Inject] private ReduxDevToolsInterop ReduxDevToolsInterop { get; set; }
        [Inject] private RouteManager RouteManager { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await ReduxDevToolsInterop.InitAsync();
            await JsonRequestHandler.InitAsync();
        }
    }
}
//https://timewarpengineering.github.io/blazor-state/Tutorial.html