#pragma checksum "C:\Users\AlphaData\source\repos\ADA\ADA.web\Areas\DashBoard\Views\Role\Role.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2aa93858dc37437cee0992550cbec39a16b9d63a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_DashBoard_Views_Role_Role), @"mvc.1.0.view", @"/Areas/DashBoard/Views/Role/Role.cshtml")]
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
#line 1 "C:\Users\AlphaData\source\repos\ADA\ADA.web\Areas\DashBoard\Views\_ViewImports.cshtml"
using ADA.web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\AlphaData\source\repos\ADA\ADA.web\Areas\DashBoard\Views\_ViewImports.cshtml"
using ADA.web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2aa93858dc37437cee0992550cbec39a16b9d63a", @"/Areas/DashBoard/Views/Role/Role.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1700b3d16605669eeb2ee0635b3c7c1c15318cca", @"/Areas/DashBoard/Views/_ViewImports.cshtml")]
    public class Areas_DashBoard_Views_Role_Role : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formRole"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<section class=""content"">
    <div class=""container-fluid"">
        <!-- Small boxes (Stat box) -->
        <!-- Main row -->
        <div class=""row"">
            <!-- Left col -->
            <section class=""col-lg-12"">
                <!-- Custom tabs (Charts with tabs)-->
                <div class=""card"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">
                            <b style=""font-size: 30px;"">
                                Role Setup
                            </b>
                        </h3>
                    </div><!-- /.card-header -->
                    <div class=""card-body"">
                        <div class=""row"">
                            <div class=""col-12"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2aa93858dc37437cee0992550cbec39a16b9d63a4466", async() => {
                WriteLiteral(@"
                                    <input type=""hidden"" id=""hdRoleId"" value=""0"" />
                                    <div class=""row"">
                                        <div class=""col-sm-4"">
                                            <div class=""form-group"">

                                                <label class=""col-12 control-label"">Role Name<span class=""mandatory""></span></label>
                                                <input id=""txtRoleName"" name=""txtRoleName"" type=""text"" maxlength=""50"" class=""form-control form-control-sm"" placeholder=""Role Name"">
                                            </div>
                                        </div>

                                        <div class=""col-sm-2"">
                                            <!-- select -->
                                            <div class=""form-group"">
                                                <label>Active</label>
                                                <div class=""for");
                WriteLiteral(@"m-check"">
                                                    <input class=""form-check-input"" type=""checkbox"" checked=""checked"" id=""chkIsActive"">
                                                    <label class=""form-check-label"">Active</label>
                                                </div>

                                            </div>
                                        </div>


                                    </div>
                                    <div class=""row  d-flex justify-content-end pr-2"">

                                        <button id=""Save"" type=""button"" class=""btn btn-sm  shadow  sharp btn-info mt-1 mr-2"">Save</button>
                                        <button id=""Edit"" type=""button"" style=""display:none"" class=""btn  btn-sm   shadow  sharp btn-success mr-2 mt-1"">Update</button>
                                        <button id=""Clear"" type=""button"" style=""display:block"" class=""btn  btn-sm   shadow  sharp btn-danger mt-1"">Clear</button>

       ");
                WriteLiteral("                             </div>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </div>
                        </div>
                    </div><!-- /.card-body -->
                </div>
                <!-- /.card -->

                <div class=""card"">

                    <!-- /.card-header -->

                    <div class=""card-body"">

                        <div class=""table-responsive"">
                            <table id=""dt_Role"" class="" table table-bordered  table-striped"" style=""width:100%;"">
                                <thead>
                                    <tr role=""row"">
                                        <th>ID</th>
                                        <th>Role Name</th>
                                        <th>Active</th>
                                        <th>Last Modified</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                </");
            WriteLiteral(@"tbody>
                            </table>
                        </div>
                    </div>
                    <!-- /.card-body -->
                </div>
            </section>

        </div>
        <!-- /.row (main row) -->
    </div><!-- /.container-fluid -->
</section>

");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n <script");
                BeginWriteAttribute("src", " src=\"", 4301, "\"", 4335, 1);
#nullable restore
#line 91 "C:\Users\AlphaData\source\repos\ADA\ADA.web\Areas\DashBoard\Views\Role\Role.cshtml"
WriteAttributeValue("", 4307, Url.Content("~/js/Role.js"), 4307, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
