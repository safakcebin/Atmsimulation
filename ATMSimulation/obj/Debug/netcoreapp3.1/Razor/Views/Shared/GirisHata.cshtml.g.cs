#pragma checksum "C:\Users\safak\Desktop\ATMSimulation\ATMSimulation\Views\Shared\GirisHata.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "182e9ac6b3bd0726f4150fc649bfb0eb5e655352"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_GirisHata), @"mvc.1.0.view", @"/Views/Shared/GirisHata.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\safak\Desktop\ATMSimulation\ATMSimulation\Views\_ViewImports.cshtml"
using ATMSimulation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\safak\Desktop\ATMSimulation\ATMSimulation\Views\_ViewImports.cshtml"
using ATMSimulation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"182e9ac6b3bd0726f4150fc649bfb0eb5e655352", @"/Views/Shared/GirisHata.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b8e2c9a805c8ffd20d5c6488f828ec871e6e85d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_GirisHata : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<String>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\safak\Desktop\ATMSimulation\ATMSimulation\Views\Shared\GirisHata.cshtml"
  
    ViewData["Title"] = @Model;

#line default
#line hidden
#nullable disable
            WriteLiteral("<h2 class=\"text-danger\">");
#nullable restore
#line 5 "C:\Users\safak\Desktop\ATMSimulation\ATMSimulation\Views\Shared\GirisHata.cshtml"
                   Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n\r\n\r\n<a href=\"/giris/index\"><p>Tekrar Dene</p></a>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<String> Html { get; private set; }
    }
}
#pragma warning restore 1591
