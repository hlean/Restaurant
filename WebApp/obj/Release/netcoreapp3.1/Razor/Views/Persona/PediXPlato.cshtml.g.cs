#pragma checksum "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c249d78ecf55afcfbb4fc8c1d93faa1f5d26db13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Persona_PediXPlato), @"mvc.1.0.view", @"/Views/Persona/PediXPlato.cshtml")]
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
#line 1 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c249d78ecf55afcfbb4fc8c1d93faa1f5d26db13", @"/Views/Persona/PediXPlato.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Persona_PediXPlato : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Dominio.Servicio>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formRegistro"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
  
    ViewData["Title"] = "PediXPlato";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c249d78ecf55afcfbb4fc8c1d93faa1f5d26db134317", async() => {
                WriteLiteral("\r\n    <label>Nombre del plato</label>\r\n    <input type=\"text\" id=\"txtnomPlato\" name=\"nomPlato\" />\r\n    <span id=\"avisoNomPlato\" class=\"text-danger\"></span><br>\r\n\r\n    <input type=\"submit\" value=\"Buscar\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<h1>Pedi X Plato</h1>\r\n<br />\r\n\r\n");
#nullable restore
#line 18 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
Write(ViewBag.mensaje);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 21 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
 if (Model != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
#nullable restore
#line 27 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 30 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.DisplayNameFor(model => model.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 33 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.DisplayNameFor(model => model.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 36 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.DisplayNameFor(model => model.PrecioFinal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 42 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.DisplayFor(modelItem => item.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.DisplayFor(modelItem => item.Estado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.DisplayFor(modelItem => item.PrecioFinal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
               Write(Html.ActionLink("Detalles", "Details", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 61 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 64 "C:\Users\leand\OneDrive\Escritorio\Obligatorios\Obligatorio 2 - P2\New folder\P2-OBLI 2\WebApp\Views\Persona\PediXPlato.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    document.querySelector(""#formRegistro"").addEventListener('submit', validarDatos);

    function validarDatos(viajeDatos) {

        viajeDatos.preventDefault();

        let nomPlato = document.querySelector(""#txtnomPlato"").value;

        let nomPlatoValido = false;

        if (nomPlato != """") { nomPlatoValido = true; } else { document.querySelector(""#avisoNomPlato"").innerHTML = ""El nombre del plato no puede ser vacio"" }


        if (nomPlato) {
            this.submit();
        }
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Dominio.Servicio>> Html { get; private set; }
    }
}
#pragma warning restore 1591
