#pragma checksum "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\Estudiantes\Telefonos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c34c5308e494293220428eabcfbe930d72998c8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Estudiantes_Telefonos), @"mvc.1.0.view", @"/Views/Estudiantes/Telefonos.cshtml")]
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
#line 1 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\_ViewImports.cshtml"
using ClienteWebMatricula;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\_ViewImports.cshtml"
using ClienteWebMatricula.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c34c5308e494293220428eabcfbe930d72998c8b", @"/Views/Estudiantes/Telefonos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b135ed3a9a77729d2177c8fff085c457bfba9b5", @"/Views/_ViewImports.cshtml")]
    public class Views_Estudiantes_Telefonos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ModelTelefonos>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-horizontal form-material mx-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Telefonos.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\Estudiantes\Telefonos.cshtml"
  
    int contador = Model.Count + 1;
    ViewData["Title"] = "Estudiantes Telefonos";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c34c5308e494293220428eabcfbe930d72998c8b6374", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <!-- Tell the browser to be responsive to screen width -->
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta name=""keywords""
          content=""wrappixel, admin dashboard, html css dashboard, web dashboard, bootstrap 5 admin, bootstrap 5, css3 dashboard, bootstrap 5 dashboard, Xtreme lite admin bootstrap 5 dashboard, frontend, responsive bootstrap 5 admin template, Xtreme admin lite design, Xtreme admin lite dashboard bootstrap 5 dashboard template"">
    <meta name=""description""
          content=""Xtreme Admin Lite is powerful and clean admin dashboard template, inpired from Bootstrap Framework"">
    <meta name=""robots"" content=""noindex,nofollow"">
    <title>");
#nullable restore
#line 19 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\Estudiantes\Telefonos.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <link rel=""canonical"" href=""https://www.wrappixel.com/templates/xtreme-admin-lite/"" />
    <!-- Favicon icon -->
    <link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""../../assets/images/favicon.png"">
    <!-- Custom CSS -->
    <link href=""../../dist/css/style.min.css"" rel=""stylesheet"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c34c5308e494293220428eabcfbe930d72998c8b8095", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src=""https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js""></script>
        <script src=""https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js""></script>
    <![endif]-->
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c34c5308e494293220428eabcfbe930d72998c8b10377", async() => {
                WriteLiteral(@"
    <!-- ============================================================== -->
    <!-- Preloader - style you can find in spinners.css -->
    <!-- ============================================================== -->
    <div class=""preloader"">
        <div class=""lds-ripple"">
            <div class=""lds-pos""></div>
            <div class=""lds-pos""></div>
        </div>
    </div>
    <!-- ============================================================== -->
    <!-- Main wrapper - style you can find in pages.scss -->
    <!-- ============================================================== -->

    <div class=""page-wrapper"">
        <div class=""page-breadcrumb"">
            <div class=""row align-items-center"">
                <div class=""col-5"">
                    <h4 class=""page-title"">Mantenimiento de Telefonos</h4>
                    <div class=""d-flex align-items-center"">
                        <nav aria-label=""breadcrumb"">
                            <ol class=""breadcrumb"">
             ");
                WriteLiteral(@"                   <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                                <li class=""breadcrumb-item active"" aria-current=""page"">Estudiantes</li>
                                <li class=""breadcrumb-item active"" aria-current=""page"">Telefonos</li>
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
        <div class=""container-fluid"">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-body"">
                            <h4 class=""card-title"">Telefonos</h4>
");
                WriteLiteral("                        </div>\r\n                        <div class=\"card-body\">\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c34c5308e494293220428eabcfbe930d72998c8b12592", async() => {
                    WriteLiteral(@"
                                <div class=""form-group"">
                                    <label class=""col-md-12"">Numero Telefono</label>
                                    <div class=""col-md-12"">
                                        <input id=""txtTelefono"" type=""text"" class=""form-control form-control-line"">
                                    </div>
                                </div>
                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            <div class=""text-end upgrade-btn"">
                                <a id=""btnAdd"" onclick=""addrow()"" class=""btn btn-success text-white"">Agregar</a>
                            </div>
                        </div>
                            <div class=""table-responsive"">
                                <table id=""tablaTelefonos"" class=""table table-striped"">
                                    <thead>
                                        <tr>
                                            <th scope=""col"">Posicion</th>
                                            <th scope=""col"">Telefono</th>
                                            <th scope=""col"">Opciones</th>
                                        </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 98 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\Estudiantes\Telefonos.cshtml"
                                         foreach (var item in Model)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <tr>\r\n");
#nullable restore
#line 101 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\Estudiantes\Telefonos.cshtml"
                                                  
                                                    contador = Model.IndexOf(item) + 1;
                                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <td>");
#nullable restore
#line 104 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\Estudiantes\Telefonos.cshtml"
                                               Write(contador);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 105 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\Estudiantes\Telefonos.cshtml"
                                               Write(item.telefono);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</td>
                                                <td>
                                                    <a class=""btn"" href=""https://www.google.co.cr/""><i class="" fa fa-edit""></i></a>
                                                    <a class=""btn"" href=""https://www.youtube.com/""><i class=""fa fa-trash""></i></a>
                                                </td>
                                            </tr>
");
#nullable restore
#line 111 "C:\Users\PereiraCoto\Documents\Personal\Cuatrimestre\Programacion5\Proyectos\Proyecto2\ClienteWebMatricula\ClienteWebMatricula\Views\Estudiantes\Telefonos.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
            </div>
            <!-- ============================================================== -->
            <!-- End PAge Content -->
            <!-- ============================================================== -->
            <!-- ============================================================== -->
            <!-- Right sidebar -->
            <!-- ============================================================== -->
            <!-- .right-sidebar -->
            <!-- ============================================================== -->
            <!-- End Right sidebar -->
            <!-- ============================================================== -->
        </div>
        <!-- ============================================================== -->
        <!-- End Container fluid  -->
        <!-- =========");
                WriteLiteral(@"===================================================== -->
        <!-- ============================================================== -->
        <!-- footer -->
        <!-- ============================================================== -->
        <footer class=""footer text-center"">
            Todos los derechos reservados. Sistema de Matricula.
        </footer>
        <!-- ============================================================== -->
        <!-- End footer -->
        <!-- ============================================================== -->
    </div>
    <!-- ============================================================== -->
    <!-- End Page wrapper  -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->
    <!-- End Wrapper -->
    <!-- ============================================================== -->
    <!-- ============================================================== -->
  ");
                WriteLiteral("  <!-- All Jquery -->\r\n    <!-- ============================================================== -->\r\n    <script src=\"../../assets/libs/jquery/dist/jquery.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c34c5308e494293220428eabcfbe930d72998c8b20081", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <!-- Bootstrap tether Core JavaScript -->
    <script src=""../../assets/libs/bootstrap/dist/js/bootstrap.bundle.min.js""></script>
    <script src=""../../dist/js/app-style-switcher.js""></script>
    <!--Wave Effects -->
    <script src=""../../dist/js/waves.js""></script>
    <!--Menu sidebar -->
    <script src=""../../dist/js/sidebarmenu.js""></script>
    <!--Custom JavaScript -->
    <script src=""../../dist/js/custom.js""></script>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c34c5308e494293220428eabcfbe930d72998c8b21637", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ModelTelefonos>> Html { get; private set; }
    }
}
#pragma warning restore 1591
