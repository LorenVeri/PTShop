#pragma checksum "C:\Users\asus\Desktop\PTShop_GitRespon\PTShop\PTShop_Layout\PTShop_Layout\Views\ShopCart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d6fe23ae6907dedeab3db7eda2cde145dad236a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ShopCart_Index), @"mvc.1.0.view", @"/Views/ShopCart/Index.cshtml")]
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
#line 1 "C:\Users\asus\Desktop\PTShop_GitRespon\PTShop\PTShop_Layout\PTShop_Layout\Views\_ViewImports.cshtml"
using PTShop_Layout;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\asus\Desktop\PTShop_GitRespon\PTShop\PTShop_Layout\PTShop_Layout\Views\_ViewImports.cshtml"
using PTShop_Layout.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\asus\Desktop\PTShop_GitRespon\PTShop\PTShop_Layout\PTShop_Layout\Views\ShopCart\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\asus\Desktop\PTShop_GitRespon\PTShop\PTShop_Layout\PTShop_Layout\Views\ShopCart\Index.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d6fe23ae6907dedeab3db7eda2cde145dad236a", @"/Views/ShopCart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"494a8ae523880bd56117b0f82205d2b1f1b4ac7a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_ShopCart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\Users\asus\Desktop\PTShop_GitRespon\PTShop\PTShop_Layout\PTShop_Layout\Views\ShopCart\Index.cshtml"
  
    ViewData["Title"] = "Shopping Cart";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script>\r\n    const backendUrl = ");
#nullable restore
#line 10 "C:\Users\asus\Desktop\PTShop_GitRespon\PTShop\PTShop_Layout\PTShop_Layout\Views\ShopCart\Index.cshtml"
                  Write(Json.Serialize(@Configuration.GetSection("Domain").GetSection("Backend").Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";
</script>

<!-- Header Section Begin -->
<header class=""header"">
    <div class=""header__top"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-6 col-md-6"">
                    <div class=""header__top__left"">
                        <ul>
                            <li><i class=""fa fa-envelope""></i> longvu@gmail.com</li>
                            <li>Miễn phí Ship cho đơn 500K</li>
                        </ul>
                    </div>
                </div>
                <div class=""col-lg-6 col-md-6"">
                    <div class=""header__top__right"">
                        <div class=""header__top__right__social"">
                            <a href=""#""><i class=""fa fa-facebook""></i></a>
                            <a href=""#""><i class=""fa fa-twitter""></i></a>
                            <a href=""#""><i class=""fa fa-linkedin""></i></a>
                            <a href=""#""><i class=""fa fa-pinterest-p""></i></a>
                ");
            WriteLiteral("        </div>\r\n                        <div class=\"header__top__right__language\">\r\n                            <img style=\"display: none;\" src=\"img/language.png\"");
            BeginWriteAttribute("alt", " alt=\"", 1513, "\"", 1519, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                            <div>Vietnamese</div>
                            <span class=""arrow_carrot-down""></span>
                            <ul>
                                <li><a href=""#"">Vietnamese</a></li>
                                <li><a href=""#"">English</a></li>
                            </ul>
                        </div>
                        <div class=""header__top__right__auth"">
                            <a href=""#""><i class=""fa fa-user""></i> Đăng nhập</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""container-fluid header-sticky"">
        <div class=""row"">
            <div class=""container"" style=""display: flex;"">
                <div class=""col-lg-3"">
                <div class=""header__logo"">
                    <a href=""/Home""><img src=""img/logo.png""");
            BeginWriteAttribute("alt", " alt=\"", 2436, "\"", 2442, 0);
            EndWriteAttribute();
            WriteLiteral(@"></a>
                </div>
                </div>
                <div class=""col-lg-6"">
                    <nav class=""header__menu"">
                        <ul>
                            <li class=""active""><a href=""./Home"">Trang chủ</a></li>
                            <li><a href=""./ShopCart"">Cửa hàng</a>
                                <ul class=""header__menu__dropdown"">
                                    <li><a href=""./ProductDetail"">Danh sách sản phẩm</a></li>
                                    <li><a href=""./ShopCart"">Giỏ Hàng</a></li>
                                </ul>
                            </li>
                            <li><a href=""./blog.html"">Blog</a></li>
                            <li><a href=""./contact.html"">Liên hệ</a></li>
                        </ul>
                    </nav>
                </div>
                <div class=""col-lg-3"">
                    <div class=""header__cart"">
                        <ul>
                            <li><a hr");
            WriteLiteral(@"ef=""#""><i class=""fa fa-heart""></i> <span data-bind=""text: $root.favorite().length""></span></a></li>
                            <li><a href=""/ShopCart""><i class=""fa fa-shopping-bag""></i> <span data-bind=""text: $root.cart().length""></span></a></li>
                        </ul>
                        <div class=""header__cart__price"">Tổng tiền: <span data-bind=""text: $root.totalCart()""></span></div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""humberger__open"">
            <i class=""fa fa-bars""></i>
        </div>
    </div>
</header>
<!-- Header Section End -->
<!-- Hero Section Begin -->
<section class=""hero"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-3"">
                <div class=""hero__categories"">
                    <div class=""hero__categories__all"">
                        <i class=""fa fa-bars""></i>
                        <span>Sản phẩm</span>
                    </div>
      ");
            WriteLiteral(@"              <ul data-bind=""foreach: $root.categoryList"">
                        <li><a data-bind=""text: name"" href=""#""></a></li>
                    </ul>
                </div>
            </div>
            <div class=""col-lg-9"">
                <div class=""hero__search"">
                    <div class=""hero__search__form"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d6fe23ae6907dedeab3db7eda2cde145dad236a9788", async() => {
                WriteLiteral(@"
                            <div class=""hero__search__categories"">
                                Danh mục
                                <span class=""arrow_carrot-down""></span>
                                <div>
                                </div>
                            </div>
                            <input type=""text"" placeholder=""Tên sản phẩm?"">
                            <button type=""submit"" class=""site-btn"">Tìm kiếm</button>
                        ");
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
                    <div class=""hero__search__phone"">
                        <div class=""hero__search__phone__icon"">
                            <i class=""fa fa-phone""></i>
                        </div>
                        <div class=""hero__search__phone__text"">
                            <h5>+84 336.716.284</h5>
                            <span>Hỗ trợ 24/7</span>
                        </div>
                    </div>
                </div>
                <div class=""hero__item set-bg"" data-setbg=""https://belux.com.vn/wp-content/uploads/2022/04/2-1.jpg"">
                    <div class=""hero__text"">
                        <span>OGANI SHOP</span>
                        <h2>Sang trọng<br />Đẳng cấp</h2>
                        <p>Đồ phong thủy mạ vàng</p>
                        <a href=""#"" class=""primary-btn"">Xem ngay</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- Hero Section En");
            WriteLiteral(@"d -->


<div id=""shopping-cart"">
    <!-- Breadcrumb Section Begin -->
    <section class=""breadcrumb-section set-bg"" data-setbg=""https://belux.com.vn/wp-content/uploads/2020/04/%E1%BA%A3nh-li%C3%AAn-h%E1%BB%87.jpg"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12 text-center"">
                    <div class=""breadcrumb__text"">
                        <h2>Giỏ hàng</h2>
                        <div class=""breadcrumb__option"">
                            <a href=""./Home"">Trang chủ</a>
                            <span>Giỏ hàng</span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Breadcrumb Section End -->

    <!-- Shoping Cart Section Begin -->
    <section class=""shoping-cart spad"" id=""ShopCart"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""shoping__car");
            WriteLiteral(@"t__table"">
                        <table>
                            <thead>
                                <tr>
                                    <th class=""shoping__product"">Sản phẩm</th>
                                    <th>Giá</th>
                                    <th>Số lượng</th>
                                    <th>Tổng tiền</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody data-bind=""foreach: $root.cart"">
                                <tr>
                                    <td class=""shoping__cart__item"" data-bind=""foreach: productMedia"">
                                        <img style=""width: 20%;"" data-bind=""attr:{src: uri}"">
                                        <h5>
                                            <a data-bind=""attr: { href: '/chi-tiet/' + productId() +'-' + $root.slugifyLink(product.name())}"" style=""font-weight: 700; color: #000 !importa");
            WriteLiteral(@"nt;"">
                                                <span data-bind=""text: product.name""></span>
                                            </a>
                                        </h5>
                                    </td>
                                    <td class=""shoping__cart__price"" data-bind=""foreach: productPrices"">
                                        <p data-bind=""text: $root.formatToVND(price)""></p>
                                    </td>
                                    <td class=""shoping__cart__quantity"">
                                        <div class=""quantity"">
                                            <div class=""pro-qty"" data-bind=""click: $root.setchange"">
                                                <input type=""number"" class=""input-text qty text"" step=""1"" min=""1"" max=""1000"" name=""quantity"" title=""Qty"" size=""6"" data-bind=""attr: {id: 'spin_' + id(), value: Count()}"">
                                            </div>
                               ");
            WriteLiteral(@"         </div>
                                    </td>
                                    <td class=""shoping__cart__total"" data-bind=""text: $root.countPrice($data)"">
                                    </td>
                                    <td class=""shoping__cart__item__close"">
                                        <span data-bind=""click: $root.removeCart"" class=""icon_close""></span>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""shoping__cart__btns"">
                        <a href=""/Home/#ListProduct"" class=""primary-btn cart-btn"">TIẾP TỤC MUA HÀNG</a>
                        <a href=""#ShopCart"" class=""primary-btn cart-btn cart-btn-right""><span class=""icon_loading""></span>
                        </a>
         ");
            WriteLiteral(@"           </div>
                </div>
                <div class=""col-lg-6"">
                    <div class=""shoping__continue"">
                        <div class=""shoping__discount"">
                            <h5>Mã giảm giá</h5>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d6fe23ae6907dedeab3db7eda2cde145dad236a17276", async() => {
                WriteLiteral("\r\n                                <input type=\"text\" placeholder=\"Nhập mã giảm giá\">\r\n                                <button type=\"submit\" class=\"site-btn\">Áp dụng</button>\r\n                            ");
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
                </div>
                <div class=""col-lg-6"">
                    <div class=""shoping__checkout"">
                        <h5>Hóa đơn</h5>
                        <ul>
                            <li>Giảm giá <span>0</span></li>
                            <li>Tổng tiền
                                <span data-bind=""text: $root.totalCart()"">$454.98</span>
                            </li>
                        </ul>
                        <a href=""#"" class=""primary-btn"">Thanh toán</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Shoping Cart Section End -->
</div>
");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script src=\"./js/ShoppingCart/ShoppingCart.js\"></script>\r\n");
            }
            );
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration Configuration { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
