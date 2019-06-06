#pragma checksum "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fd090455e6de518e00d6deba83d7dd25cc23a3d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restrict_MyOrders), @"mvc.1.0.view", @"/Views/Restrict/MyOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Restrict/MyOrders.cshtml", typeof(AspNetCore.Views_Restrict_MyOrders))]
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
#line 1 "Z:\public_html\ASP\ANVBookstore\Views\_ViewImports.cshtml"
using ANVBookstore;

#line default
#line hidden
#line 2 "Z:\public_html\ASP\ANVBookstore\Views\_ViewImports.cshtml"
using ANVBookstore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fd090455e6de518e00d6deba83d7dd25cc23a3d", @"/Views/Restrict/MyOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2b5ba13ef8db57a55407d31393c2f3a084a7cbe", @"/Views/_ViewImports.cshtml")]
    public class Views_Restrict_MyOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<OrderItems>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
  
    ViewData["Title"] = "My Orders";

#line default
#line hidden
            BeginContext(81, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(115, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 10 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
 if (Model.Any())
{

#line default
#line hidden
            BeginContext(139, 19, true);
            WriteLiteral("    <h1>Orders for ");
            EndContext();
            BeginContext(159, 26, false);
#line 12 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
              Write(Context.User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(185, 7, true);
            WriteLiteral("</h1>\r\n");
            EndContext();
            BeginContext(194, 434, true);
            WriteLiteral(@"    <table class=""table table-sm table-striped table-bordered"">
        <thead>
            <tr>
                <th>
                    Order Date
                </th>
               
                <th class=""text-right"">
                    Price
                </th>
                <th class=""text-right"">
                    Quanitity
                </th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 30 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(685, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(747, 13, false);
#line 34 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
                Write( item.OrderId);

#line default
#line hidden
            EndContext();
            BeginContext(761, 90, true);
            WriteLiteral("\r\n                </td>\r\n\r\n\r\n                <td class=\"text-right\">\r\n                    ");
            EndContext();
            BeginContext(852, 13, false);
#line 39 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
               Write(item.OrderQty);

#line default
#line hidden
            EndContext();
            BeginContext(865, 86, true);
            WriteLiteral("\r\n                </td>\r\n                <td class=\"text-right\">\r\n                    ");
            EndContext();
            BeginContext(952, 12, false);
#line 42 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
               Write(item.OrderId);

#line default
#line hidden
            EndContext();
            BeginContext(964, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 45 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
            }

#line default
#line hidden
            BeginContext(1023, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 48 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1067, 22, true);
            WriteLiteral("    <h1>No orders for ");
            EndContext();
            BeginContext(1090, 26, false);
#line 51 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
                 Write(Context.User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1116, 7, true);
            WriteLiteral("</h1>\r\n");
            EndContext();
#line 52 "Z:\public_html\ASP\ANVBookstore\Views\Restrict\MyOrders.cshtml"
}

#line default
#line hidden
            BeginContext(1126, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<OrderItems>> Html { get; private set; }
    }
}
#pragma warning restore 1591
