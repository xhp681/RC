#pragma checksum "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "083ec367f74df64371d25fba39469e78c4e488f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Install__Install_ConnectionString), @"mvc.1.0.view", @"/Views/Install/_Install.ConnectionString.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
#nullable restore
#line 1 "D:\RC\RC\Rs.Ply\Views\_ViewImports.cshtml"
using Rs.Ply;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\RC\RC\Rs.Ply\Views\_ViewImports.cshtml"
using Rs.Ply.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\RC\RC\Rs.Ply\Views\_ViewImports.cshtml"
using System.Text.Encodings.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\RC\RC\Rs.Ply\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.ViewFeatures;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\RC\RC\Rs.Ply\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Primitives;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\RC\RC\Rs.Ply\Views\_ViewImports.cshtml"
using Rs.Ply.Framework.TagHelpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\RC\RC\Rs.Ply\Views\_ViewImports.cshtml"
using Rs.Ply.Framework.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\RC\RC\Rs.Ply\Views\_ViewImports.cshtml"
using Rs.Ply.Framework.Themes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\RC\RC\Rs.Ply\Views\Install\_ViewImports.cshtml"
using Rs.DataBase;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\RC\RC\Rs.Ply\Views\Install\_ViewImports.cshtml"
using Rs.Server;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\RC\RC\Rs.Ply\Views\Install\_ViewImports.cshtml"
using Rs.Ply.Models.Install;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\RC\RC\Rs.Ply\Views\Install\_ViewImports.cshtml"
using Rs.Ply.Infrastructure;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"083ec367f74df64371d25fba39469e78c4e488f2", @"/Views/Install/_Install.ConnectionString.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfcf5511762f5d960398dbff6ad9464077355007", @"/Views/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f191c807416835ac8a03e0a26247adb96b524c7", @"/Views/Install/_ViewImports.cshtml")]
    public class Views_Install__Install_ConnectionString : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<InstallModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div id=\"sqlDatabaseInfo\">\r\n    <div class=\"credentials\">\r\n        <div class=\"form-group row\">\r\n            <label class=\"col-sm-3 col-form-label text-right font-weight-bold\">\r\n                ");
#nullable restore
#line 6 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
           Write(ILS.GetResource("ServerName"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </label>
            <div class=""col-sm-8"">
                <input asp-for=""ServerName"" class=""form-control"" />
            </div>
        </div>
        <div class=""form-group row"">
            <label class=""col-sm-3 col-form-label text-right font-weight-bold"">
                ");
#nullable restore
#line 14 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
           Write(ILS.GetResource("DatabaseName"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </label>
            <div class=""col-sm-8"">
                <input asp-for=""DatabaseName"" class=""form-control"" />
            </div>
        </div>
    </div>
    <div class=""form-group row"">
        <div class=""col-md-6 offset-md-3"">
            <div class=""form-check"">
                <input class=""form-check-input"" asp-for=""IntegratedSecurity""");
            BeginWriteAttribute("asp-value", " asp-value=\"", 948, "\"", 965, 1);
#nullable restore
#line 24 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
WriteAttributeValue("", 960, true, 960, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <label class=\"form-check-label\"");
            BeginWriteAttribute("for", " for=\"", 1018, "\"", 1062, 1);
#nullable restore
#line 25 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
WriteAttributeValue("", 1024, Html.IdFor(m => m.IntegratedSecurity), 1024, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
#nullable restore
#line 26 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
               Write(ILS.GetResource("IntegratedAuthentication"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
        </div>
    </div>
    <div class=""credentials"" id=""pnlSqlServerCredentials"">
        <div class=""form-group row"">
            <label class=""col-sm-3 col-form-label text-right font-weight-bold"">
                ");
#nullable restore
#line 34 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
           Write(ILS.GetResource("SqlUsername"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </label>
            <div class=""col-sm-8"">
                <input asp-for=""Username"" class=""form-control"" />
            </div>
        </div>
        <div class=""form-group row"">
            <label class=""col-sm-3 col-form-label text-right font-weight-bold"">
                ");
#nullable restore
#line 42 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
           Write(ILS.GetResource("SqlPassword"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </label>\r\n            <div class=\"col-sm-8\">\r\n                <input asp-for=\"Password\" class=\"form-control\" />\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    $(document).ready(function () {\r\n        $(\'#");
#nullable restore
#line 53 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
       Write(Html.IdFor(x => x.IntegratedSecurity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\').click(toggleSqlAuthenticationType);\r\n\r\n        toggleSqlAuthenticationType();\r\n    })\r\n\r\n    function toggleSqlAuthenticationType() {\r\n        var sqlAuthentication = $(\"#");
#nullable restore
#line 59 "D:\RC\RC\Rs.Ply\Views\Install\_Install.ConnectionString.cshtml"
                               Write(Html.IdFor(x => x.IntegratedSecurity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\").is(\':checked\');\r\n        if (sqlAuthentication) {\r\n            $(\'#pnlSqlServerCredentials\').hide();\r\n        } else {\r\n            $(\'#pnlSqlServerCredentials\').show();\r\n        }\r\n    }\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IInstallationLocalizationService ILS { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<InstallModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
