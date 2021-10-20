#pragma checksum "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20024e86f61d80da01a26f7ce467dc9821773a61"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\_ViewImports.cshtml"
using AdminPanelEventManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\_ViewImports.cshtml"
using AdminPanelEventManager.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20024e86f61d80da01a26f7ce467dc9821773a61", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cfe9ed6cb310cf339c2ffdb2737ef5887a0e173", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<AdminPanelEventManager.Models.HealthCheckViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "IndexAsync";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>API Health Checks</h1>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Service Name\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 17 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                Service Status\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 27 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
         foreach (var item in Model)
        {
            if (item.Status == "Healthy")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"bg-success rounded\">\r\n                    <td class=\"rounded\">\r\n                        ");
#nullable restore
#line 33 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Tags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td class=\"rounded\">\r\n                        ");
#nullable restore
#line 37 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td class=\"rounded\">\r\n                        ");
#nullable restore
#line 40 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n\r\n                </tr>\r\n");
#nullable restore
#line 45 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
            }
            else if (item.Status == "Unhealthy")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"bg-danger\">\r\n                    <td td class=\"rounded\">\r\n                        ");
#nullable restore
#line 50 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Tags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td td class=\"rounded\">\r\n                        ");
#nullable restore
#line 53 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td td class=\"rounded\">\r\n                        ");
#nullable restore
#line 56 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 60 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr class=\"bg-warning\">\r\n                    <td td class=\"rounded\">\r\n                        ");
#nullable restore
#line 65 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Tags));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td td class=\"rounded\">\r\n                        ");
#nullable restore
#line 68 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Duration));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td td class=\"rounded\">\r\n                        ");
#nullable restore
#line 71 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 75 "C:\Users\99555\source\repos\AdminPanelEventManager\Views\Home\Index.cshtml"
            }

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<AdminPanelEventManager.Models.HealthCheckViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591