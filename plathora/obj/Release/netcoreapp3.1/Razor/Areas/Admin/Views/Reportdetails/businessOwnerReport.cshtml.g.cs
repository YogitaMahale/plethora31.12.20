#pragma checksum "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0ec556cd8be99a2a831a7e686c498921965b2de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Reportdetails_businessOwnerReport), @"mvc.1.0.view", @"/Areas/Admin/Views/Reportdetails/businessOwnerReport.cshtml")]
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
#line 1 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\_ViewImports.cshtml"
using plathora;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\_ViewImports.cshtml"
using plathora.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0ec556cd8be99a2a831a7e686c498921965b2de", @"/Areas/Admin/Views/Reportdetails/businessOwnerReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"396188bb9b5a5b30811f4f1a58a7e68134b9e9d4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Reportdetails_businessOwnerReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<plathora.pagination.collectionreport_affilatePagination<BusinessownercollectionReportSPModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
  
    ViewBag.Title = "Business Owners Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"side-app\">\r\n\r\n");
#nullable restore
#line 9 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
          
            decimal amount = 0;
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n        <div class=\"row\">\r\n\r\n            <div class=\"col-md-12 col-lg-12\">\r\n                <div class=\"card-header\">\r\n                    <h3 class=\"card-title\">");
#nullable restore
#line 21 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                      Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                </div>\r\n                <div class=\"card\">\r\n");
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 30 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                     using (Html.BeginForm("businessOwnerReport", "Reportdetails", FormMethod.Post))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <table class=""table"">
                            <tr>
                                <td> <label>From Date</label></td>
                                <td>
                                    <div class=""input-group date"" data-provide=""datepicker"">

                                        <input type=""text"" id=""datepicker1"" autocomplete=""off"" class=""form-control datepicker""");
            BeginWriteAttribute("value", " value=\"", 1344, "\"", 1366, 1);
#nullable restore
#line 38 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
WriteAttributeValue("", 1352, ViewBag.from1, 1352, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"from1\">\r\n\r\n");
            WriteLiteral(@"                                    </div>
                                </td>
                                <td> <label>To Date</label></td>
                                <td>
                                    <input type=""text"" id=""datepicker2"" autocomplete=""off"" class=""form-control datepicker""");
            BeginWriteAttribute("value", " value=\"", 1909, "\"", 1929, 1);
#nullable restore
#line 47 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
WriteAttributeValue("", 1917, ViewBag.to1, 1917, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"to1\">\r\n                                </td>\r\n\r\n                                <td> <label>Select Affilate</label></td>\r\n                                <td>");
#nullable restore
#line 51 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                               Write(Html.DropDownList("deliveryboyid", (IEnumerable<SelectListItem>)ViewData["affilatelist"], new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                                <td> <input type=""submit"" name=""search"" value=""Search"" class=""btn btn-primary"" /></td>
                                <td> <input type=""submit"" name=""ExcelFileDownload"" value=""Excel Download"" class=""btn btn-primary"" /></td>

                            </tr>
                        </table>
");
#nullable restore
#line 57 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"


                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    <div class=""card-body"">
                        <div class=""table-responsive"" style=""overflow-x:scroll;"">
                            <table id=""example2"" class=""hover table-bordered border-top-0 border-bottom-0"">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Phone</th>
                                        <th>Date</th>
                                        <th>Business Package</th>
                                        <th>Package Amount</th>
                                        <th>Commi(%)</th>
                                        <th>GST(%)</th>
                                        <th>GST Amount</th>
                                        <th>Plethora </th>
                                        <th>Commission</th>
                                        <th>TDS</th>
                                        <th>Total</t");
            WriteLiteral("h>\r\n\r\n\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n\r\n");
#nullable restore
#line 84 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                     foreach (var item in Model)
                                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 88 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 89 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 90 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.createddate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 91 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.pkgname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 92 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.PackageAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 93 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.commissionper);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 94 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.gst);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 95 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.gstAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 96 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.plethoraamt);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                        <td>");
#nullable restore
#line 97 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.commissionAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 98 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.tds);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 99 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(item.PaymentAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                    </tr>\r\n");
#nullable restore
#line 102 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                </tbody>\r\n");
#nullable restore
#line 107 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                     foreach (var item in Model)
                                    {
                                        amount += item.PaymentAmount;
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                <tfoot>

                                    <tr>

                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th></th>
                                        <th>  </th>
                                        <th> </th>
                                        <th>Total</th>

                                        <th>");
#nullable restore
#line 129 "E:\yogita 6.8.19\asp.net core\Final backup 4.9.20\plathoraNewDomain\15.12.20\multiple business add\plathora\plathora\plathora\Areas\Admin\Views\Reportdetails\businessOwnerReport.cshtml"
                                       Write(amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n\r\n                                    </tr>\r\n                                </tfoot>\r\n                            </table>\r\n");
            WriteLiteral("                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0ec556cd8be99a2a831a7e686c498921965b2de17766", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral(@"<script>
    $(function () {
        //$(""#datepicker1"").datepicker({
        //    autoclose: true,
        //        format: 'dd/mm/yyyy'
        //});
        //$(""#datepicker2"").datepicker({
        //    autoclose: true,
        //    format: 'dd/mm/yyyy'
        //});
        $("".datepicker"").datepicker({
            autoclose: true,
            dateFormat: 'dd/mm/yy'
        });
    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<plathora.pagination.collectionreport_affilatePagination<BusinessownercollectionReportSPModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591