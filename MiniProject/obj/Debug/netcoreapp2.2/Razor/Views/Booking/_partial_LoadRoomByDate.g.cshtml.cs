#pragma checksum "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09e440ff89f56337b1305f5d11c4bbcbcc0004a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking__partial_LoadRoomByDate), @"mvc.1.0.view", @"/Views/Booking/_partial_LoadRoomByDate.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Booking/_partial_LoadRoomByDate.cshtml", typeof(AspNetCore.Views_Booking__partial_LoadRoomByDate))]
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
#line 1 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\_ViewImports.cshtml"
using MiniProject;

#line default
#line hidden
#line 2 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\_ViewImports.cshtml"
using MiniProject.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09e440ff89f56337b1305f5d11c4bbcbcc0004a5", @"/Views/Booking/_partial_LoadRoomByDate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"995f6496ea3e0f3b56c0144e78006c50eacee8cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Booking__partial_LoadRoomByDate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MiniProject.Models.Booking>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control select2 select-room"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
  
    Layout = null;
    var rooms = ViewData["Rooms"] as IEnumerable<Room>;

#line default
#line hidden
            BeginContext(121, 551, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09e440ff89f56337b1305f5d11c4bbcbcc0004a54344", async() => {
                BeginContext(187, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(193, 26, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "09e440ff89f56337b1305f5d11c4bbcbcc0004a54731", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(219, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 9 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
     foreach (var item in rooms)
                        {
                            var statusString = @item.RoomStatusByDate(Model.StartTime, Model.EndTime);
                            var dis = statusString != "Available" ? "disabled" : "";

    

#line default
#line hidden
                BeginContext(478, 1, true);
                WriteLiteral("<");
                EndContext();
                BeginContext(480, 6, true);
                WriteLiteral("option");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 486, "\"", 502, 1);
#line 14 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
WriteAttributeValue("", 494, item.Id, 494, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(503, 28, true);
                WriteLiteral("\r\n             data-status=\"");
                EndContext();
                BeginContext(532, 12, false);
#line 15 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
                     Write(statusString);

#line default
#line hidden
                EndContext();
                BeginContext(544, 30, true);
                WriteLiteral("\"\r\n             data-content=\"");
                EndContext();
                BeginContext(575, 16, false);
#line 16 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
                      Write(item.Description);

#line default
#line hidden
                EndContext();
                BeginContext(591, 2, true);
                WriteLiteral("\" ");
                EndContext();
                BeginContext(594, 3, false);
#line 16 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
                                         Write(dis);

#line default
#line hidden
                EndContext();
                BeginContext(597, 11, true);
                WriteLiteral(">\r\n        ");
                EndContext();
                BeginContext(609, 9, false);
#line 17 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
   Write(item.Name);

#line default
#line hidden
                EndContext();
                BeginContext(618, 8, true);
                WriteLiteral("\r\n    </");
                EndContext();
                BeginContext(627, 9, true);
                WriteLiteral("option>\r\n");
                EndContext();
#line 19 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
                        }

#line default
#line hidden
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#line 7 "C:\Users\tai02\source\repos\MiniProject\MiniProject\Views\Booking\_partial_LoadRoomByDate.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.RoomId);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MiniProject.Models.Booking> Html { get; private set; }
    }
}
#pragma warning restore 1591