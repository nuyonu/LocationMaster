using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maps.Views
{
    public class SiteMapperBase : ComponentBase
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }
        protected override async Task OnAfterRenderAsync(bool firstLoad)
        {
            await JSRuntime.InvokeAsync<Task>("loadMap");
        }
    }
}
