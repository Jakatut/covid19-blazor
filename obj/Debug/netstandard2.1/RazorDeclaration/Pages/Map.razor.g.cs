#pragma checksum "/home/cmac/workspace/hackday/corona_map/Pages/Map.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9200d68d0d24c7ec2205cb68e2c9cf4fcafc035b"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace corona_map.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/cmac/workspace/hackday/corona_map/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/cmac/workspace/hackday/corona_map/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/cmac/workspace/hackday/corona_map/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/cmac/workspace/hackday/corona_map/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/cmac/workspace/hackday/corona_map/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/cmac/workspace/hackday/corona_map/_Imports.razor"
using corona_map;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/cmac/workspace/hackday/corona_map/_Imports.razor"
using corona_map.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Map : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "/home/cmac/workspace/hackday/corona_map/Pages/Map.razor"
       

    public string SelectedValue { get { return _SelectedValue; } set { _SelectedValue = value; TriggerMapRender(); } }
    private string _SelectedValue = "total";

    protected override void OnInitialized() {
        TriggerMapRender();
    }
    public async Task TriggerMapRender()
    {
        var corona_map = new CoronaMap(JSRuntime);
        corona_map.InitMap(this.SelectedValue);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
