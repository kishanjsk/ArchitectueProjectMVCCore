#pragma checksum "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09709a3e951d83a02113b684dc828928d400a368"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Users_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Users/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Users/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Users_Index))]
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
#line 1 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\_ViewImports.cshtml"
using Architechture.Web;

#line default
#line hidden
#line 2 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\_ViewImports.cshtml"
using Architechture.Web.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09709a3e951d83a02113b684dc828928d400a368", @"/Areas/Admin/Views/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da5c14a2fd040740a191176a78fc60c8476b361d", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Architecture.Entities.UsersEntity>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminTheme/NewFolder/no-photo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("50"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(157, 694, true);
            WriteLiteral(@"
<section class=""content-header"">
    <h1>
        Index
        <small>Preview</small>
    </h1>
    <ol class=""breadcrumb"">
        <li><a href=""#""><i class=""fa fa-dashboard""></i> Home</a></li>
        <li><a href=""#"">Forms</a></li>
        <li class=""active"">General Elements</li>
    </ol>
</section>

<!-- Main content -->
<section class=""content"">
    <div class=""row"">
        <!-- left column -->
        <div class=""col-md-12"">
            <div class=""box box-primary"">
                <div class=""box-header with-border"">
                    <h3 class=""box-title"">Quick Example</h3>
                    <div class=""box-tools pull-right"">
                        ");
            EndContext();
            BeginContext(851, 65, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09709a3e951d83a02113b684dc828928d400a3685952", async() => {
                BeginContext(902, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(916, 278, true);
            WriteLiteral(@"
                    </div>
                </div>
                <div class=""box-body"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>
                                    ");
            EndContext();
            BeginContext(1195, 38, false);
#line 37 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(1233, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(1349, 44, false);
#line 40 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(1393, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(1509, 46, false);
#line 43 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.IsApproved));

#line default
#line hidden
            EndContext();
            BeginContext(1555, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(1671, 45, false);
#line 46 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1716, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(1832, 44, false);
#line 49 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(1876, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(1992, 43, false);
#line 52 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.EmailId));

#line default
#line hidden
            EndContext();
            BeginContext(2035, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2151, 45, false);
#line 55 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.ContactNo));

#line default
#line hidden
            EndContext();
            BeginContext(2196, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2312, 44, false);
#line 58 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.Password));

#line default
#line hidden
            EndContext();
            BeginContext(2356, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2472, 46, false);
#line 61 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.ProfilePic));

#line default
#line hidden
            EndContext();
            BeginContext(2518, 115, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
            EndContext();
            BeginContext(2634, 48, false);
#line 64 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                               Write(Html.DisplayNameFor(model => model.LoginAttempt));

#line default
#line hidden
            EndContext();
            BeginContext(2682, 186, true);
            WriteLiteral("\r\n                                </th>\r\n                                <th></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
            EndContext();
#line 70 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
            BeginContext(2957, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3078, 37, false);
#line 74 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Id));

#line default
#line hidden
            EndContext();
            BeginContext(3115, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3243, 43, false);
#line 77 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(3286, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3414, 45, false);
#line 80 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.IsApproved));

#line default
#line hidden
            EndContext();
            BeginContext(3459, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3587, 44, false);
#line 83 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(3631, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3759, 43, false);
#line 86 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
            EndContext();
            BeginContext(3802, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3930, 42, false);
#line 89 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.EmailId));

#line default
#line hidden
            EndContext();
            BeginContext(3972, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(4100, 44, false);
#line 92 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.ContactNo));

#line default
#line hidden
            EndContext();
            BeginContext(4144, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(4272, 43, false);
#line 95 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Password));

#line default
#line hidden
            EndContext();
            BeginContext(4315, 87, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 98 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                         if (string.IsNullOrEmpty(item.ProfilePic))
                                        {

#line default
#line hidden
            BeginContext(4530, 44, true);
            WriteLiteral("                                            ");
            EndContext();
            BeginContext(4574, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "09709a3e951d83a02113b684dc828928d400a36818037", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
#line 100 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                                                                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(4726, 48, true);
            WriteLiteral("                                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 4774, "\"", 4796, 1);
#line 103 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
WriteAttributeValue("", 4780, item.ProfilePic, 4780, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4797, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
#line 104 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                        }

#line default
#line hidden
            BeginContext(4845, 125, true);
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(4971, 47, false);
#line 107 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.LoginAttempt));

#line default
#line hidden
            EndContext();
            BeginContext(5018, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(5146, 51, false);
#line 110 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                                   Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
            EndContext();
            BeginContext(5197, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(5411, 84, true);
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 115 "D:\Projects\ArchitectueProjectMVCCore\ArchitechtureProject\Areas\Admin\Views\Users\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(5526, 146, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Architecture.Entities.UsersEntity>> Html { get; private set; }
    }
}
#pragma warning restore 1591
