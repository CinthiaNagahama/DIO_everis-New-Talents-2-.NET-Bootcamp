#pragma checksum "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "269d77a1745bdac2581ffdb40f3c22ed002d2f00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Course_List), @"mvc.1.0.view", @"/Views/Course/List.cshtml")]
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
#line 1 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\_ViewImports.cshtml"
using mvc_web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\_ViewImports.cshtml"
using mvc_web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"269d77a1745bdac2581ffdb40f3c22ed002d2f00", @"/Views/Course/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0066ec82d227a13ae76ef9c4aebad06fe7ddc9c3", @"/Views/_ViewImports.cshtml")]
    public class Views_Course_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<mvc_web.Models.Course.ListCoursesViewModelOutput>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
  
  ViewData["Title"] = "Listar";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Listar Cursos</h1>\r\n\r\n<p>\r\n  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "269d77a1745bdac2581ffdb40f3c22ed002d2f003787", async() => {
                WriteLiteral("Registrar Novo Curso");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n<table class=\"table\">\r\n  <thead>\r\n    <tr>\r\n      <th>\r\n        ");
#nullable restore
#line 17 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
   Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      </th>\r\n      <th>\r\n        ");
#nullable restore
#line 20 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
   Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      </th>\r\n      <th>\r\n        ");
#nullable restore
#line 23 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
   Write(Html.DisplayNameFor(model => model.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n      </th>\r\n      <th></th>\r\n    </tr>\r\n  </thead>\r\n  <tbody>\r\n");
#nullable restore
#line 29 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("      <tr>\r\n        <td>\r\n          ");
#nullable restore
#line 33 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
     Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n          ");
#nullable restore
#line 36 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
     Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n          ");
#nullable restore
#line 39 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
     Write(Html.DisplayFor(modelItem => item.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n          ");
#nullable restore
#line 42 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
     Write(Html.ActionLink("Editar", "Edit", new {}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n          ");
#nullable restore
#line 43 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
     Write(Html.ActionLink("Detalhes", "Details", new {}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n          ");
#nullable restore
#line 44 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
     Write(Html.ActionLink("Deletar", "Delete", new {}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n      </tr>\r\n");
#nullable restore
#line 47 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 52 "C:\Users\cinth\Documents\GitHub\DIO_everis-New-Talents-2-.NET-Bootcamp\mvc_web\Views\Course\List.cshtml"
  await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<mvc_web.Models.Course.ListCoursesViewModelOutput>> Html { get; private set; }
    }
}
#pragma warning restore 1591