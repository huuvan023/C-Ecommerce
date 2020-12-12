#pragma checksum "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b781491560741025da41030099542dcf071d577e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Pager_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Pager/Default.cshtml")]
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
#line 1 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\_ViewImports.cshtml"
using WebAPI.AdminApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\_ViewImports.cshtml"
using WebAPI.AdminApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b781491560741025da41030099542dcf071d577e", @"/Views/Shared/Components/Pager/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"caa60ac5fa082f353f43e37be5fbc0cbd21cc645", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Pager_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebAPI.ViewModels.Common.PagedResultBase>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
  
    var urlTemplate = Url.Action() + "?pageIndex={0}";
    var request = ViewContext.HttpContext.Request;
    foreach (var key in request.Query.Keys)
    {
        if (key == "pageIndex")
        {
            continue;
        }
        if (request.Query[key].Count > 1)
        {
            foreach (var item in (string[])request.Query[key])
            {
                urlTemplate += "&" + key + "=" + item;
            }
        }
        else
        {
            urlTemplate += "&" + key + "=" + request.Query[key];
        }
    }

    var startIndex = Math.Max(Model.PageIndex - 5, 1);
    var finishIndex = Math.Min(Model.PageIndex + 5, Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 28 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
 if (Model.PageCount > 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <ul class=\"pagination\">\n");
#nullable restore
#line 31 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
         if (Model.PageIndex != startIndex)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\n                <a class=\"page-link\" title=\"1\"");
            BeginWriteAttribute("href", " href=\"", 913, "\"", 952, 1);
#nullable restore
#line 34 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 920, urlTemplate.Replace("{0}", "1"), 920, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Đầu</a>\n            </li>\n            <li class=\"page-item\">\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1051, "\"", 1117, 1);
#nullable restore
#line 37 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1058, urlTemplate.Replace("{0}", (Model.PageIndex-1).ToString()), 1058, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Trước</a>\n            </li>\n");
#nullable restore
#line 39 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
         for (var i = startIndex; i <= finishIndex; i++)
        {
            if (i == Model.PageIndex)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item active\">\n                    <a class=\"page-link\" href=\"#\">");
#nullable restore
#line 45 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
                                             Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\n                </li>\n");
#nullable restore
#line 47 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("title", " title=\"", 1543, "\"", 1570, 2);
            WriteAttributeValue("", 1551, "Trang", 1551, 5, true);
#nullable restore
#line 50 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue(" ", 1556, i.ToString(), 1557, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1571, "\"", 1619, 1);
#nullable restore
#line 50 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1578, urlTemplate.Replace("{0}", i.ToString()), 1578, 41, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 50 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
                                                                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\n");
#nullable restore
#line 51 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
         if (Model.PageIndex != finishIndex)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\n                <a class=\"page-link\"");
            BeginWriteAttribute("title", " title=\"", 1783, "\"", 1818, 1);
#nullable restore
#line 56 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1791, Model.PageCount.ToString(), 1791, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("href", " href=\"", 1819, "\"", 1885, 1);
#nullable restore
#line 56 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1826, urlTemplate.Replace("{0}", (Model.PageIndex+1).ToString()), 1826, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Sau</a>\n            </li>\n            <li class=\"page-item\">\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1984, "\"", 2046, 1);
#nullable restore
#line 59 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
WriteAttributeValue("", 1991, urlTemplate.Replace("{0}", Model.PageCount.ToString()), 1991, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Cuối</a>\n            </li>\n");
#nullable restore
#line 61 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\n");
#nullable restore
#line 63 "C:\Users\Truong08\Desktop\New folder\WebAPI.AdminApp\Views\Shared\Components\Pager\Default.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebAPI.ViewModels.Common.PagedResultBase> Html { get; private set; }
    }
}
#pragma warning restore 1591
