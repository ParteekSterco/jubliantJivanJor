<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<%@ Register Src="~/usercontrols/mainmenu.ascx" TagName="mainmenu" TagPrefix="uc5" %>
<%@ Register Src="~/usercontrols/homebanner.ascx" TagName="homebanner" TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="~/usercontrols/seosection.ascx" TagName="seosection" TagPrefix="uc4" %>
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title></title>
    <uc4:seosection ID="seosection1" runat="server" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="/css/bootstrap.css">

    <link rel="stylesheet" href="/css/comman.css">
    <link rel="stylesheet" href="/css/header.css">
    <link rel="stylesheet" href="/css/aos.css">
    <link rel="stylesheet" href="/css/jquery.fancybox.min.css">
    <link rel="stylesheet" href="/css/footer.css">
    <link rel="stylesheet" href="/css/home.css">
    <link rel="stylesheet" href="/css/home-responsive.css">
    <link rel="stylesheet" href="/css/slick.css">
    <link rel="stylesheet" href="/css/animate.css">
    <link href="/css/owl.carousel.min.css" rel="stylesheet">
    <link rel="shortcut icon" type="image/x-icon" href="/images/favicon.png">
</head>
<body>

    <script>
        window.onload = function () {
            // This code runs after everything is loaded.
            var myCarousel = document.getElementById('carouselExampleIndicators');
            var slider = document.getElementById('filter_slider');
            var products = document.getElementsByClassName('carousel-item');
            if (products.length > 0) {
                products[0].classList.add('active');
                slider.classList.add('r' + products[0].getElementsByClassName('hdnProductID')[0].value);
            }

            myCarousel.addEventListener('slid.bs.carousel', function (event) {
                for (var i = 0; i < products.length; i++) {
                    if (products[i].classList.contains('active')) {
                        var productId = products[i].getElementsByClassName('hdnProductID')[0].value;
                        slider.classList = [];
                        slider.classList.add('filter_slider');
                        slider.classList.add('r' + productId);
                    }
                }
            })
        };

    </script>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Name="MicrosoftAjax.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
                    <asp:ScriptReference Name="Common.Common.js" Assembly="AjaxControlToolkit" />
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>

        <header class="d-flex justify-content-between align-items-center w-100">
            <div class="logo">
                <a href="/">
                    <figure>
                        <img src="/images/logo.png" alt="logo" class="head-logo">
                    </figure>
                    <figure>
                        <img src="/images/inner-logo.png" alt="logo" class="sticky-logo">
                    </figure>
                </a>
            </div>
            <uc5:mainmenu ID="mainmenu2" runat="server" />
        </header>
        <div class="loading-group">
            <figure>
                <img src="/images/inner-logo.png" alt="loading-image" />
            </figure>
        </div>
        <uc2:homebanner ID="homebanner1" runat="server" />

        <div class="d-sm-none d-block bg-white">
            <div class="container">
                <div class="adhesive_mobile">
                    <figure>
                        <img src="/images/adhesive2.png" alt="loading-image" class="img-fluid" />
                    </figure>
                    <h3>One of the <br>Largest Adhesive Brand in India</h3>
                </div>
            </div>
        </div>

        <section id="filter_slider" class=" filter_slider">
            <div class="container-lg">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">

                    <div class="carousel-inner home_filter_slider" >
                        <asp:Repeater ID="rptproductimage" runat="server" OnItemDataBound="rptproductimage_ItemDataBound">
                            <ItemTemplate>
                                <div class="carousel-item">
                                    <input type="hidden" id="hdnProductID" class="hdnProductID" runat="server" value='<%#Eval("productid")%>' />
                                    <asp:Literal ID="litpanelimage1" runat="server" Visible="false" Text='<%#Eval("producticon")%>'></asp:Literal>
                                    <asp:Literal ID="litpanelimage2" runat="server" Visible="false" Text='<%#Eval("largeimage")%>'></asp:Literal>
                                    <div class="slider-box">
                                        <div class="home_img_box1">
                                        <div class="text" id="panelimage1" runat="server" visible="false">
                                        
                                            <figure>
                                                <img src="/uploads/ProductsImage/<%#Eval("producticon")%>" alt="logo-icon">
                                                <p><%#Eval("modelno")%></p>
                                            </figure>
                                        </div>
                                        </div>
                                        <div class="home_img_box2">
                                        <div class="img-box" id="panelimage2" runat="server" visible="false">
                                            <figure>
                                                <img src="/uploads/ProductsImage/<%#Eval("largeimage")%>" alt="filter-slider-img">
                                            </figure>
                                        </div>
                                        </div>
                                        <div class="home_box3">  <asp:Literal ID="litshortdesc" runat="server" Text='<%#Server.HtmlDecode(Eval("shortdetail").ToString())%>'></asp:Literal>
                                            <ul class="product-btn-fix">
                                                <li>
                                                    <a href="/application.aspx?mpgid=6&amp;pgidtrail=6" class="btn-red">View All Application</a>
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                  
                                </div>
                            </ItemTemplate>

                        </asp:Repeater>

                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>  
            </div>
        </section>




        <section class="application pt-0">          
                <!-- <h2 class="text-center font-24 mb-50" data-aos="fade-up">Applications</h2> -->
                <div class="testimonial-video" data-aos="fade-up">
                    <asp:Repeater ID="rptapplication" runat="server">
                        <ItemTemplate>
                            <div>
                                <div class="box">
                                    <%--   <a href="/uploads/ProductsImage/<%#Eval("banner")%>" data-fancybox="images">
                                        <figure>
                                            <img src="/uploads/ProductsImage/<%#Eval("banner")%>" alt="<%#Container.ItemIndex%>">
                                        </figure>
                                    </a>--%>
                                    <div class="box video">
                                        <figure>
                                            <a data-fancybox="images" href="/uploads/<%#Eval("purl")%>">
                                                <img alt="application-img" src="/uploads/ProductsImage/<%#Eval("videoimage")%>" />
                                            </a>
                                        </figure>
                                        <div class="bottom_text">
                                            <h4><%#Server.HtmlDecode(Eval("appvideodetail").ToString())%></h4>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>
                <div class="view_all text-white" data-aos="fade-up">
                    <a href="/application.aspx?mpgid=6&pgidtrail=6">view all <i class="fa fa-angle-right" aria-hidden="true"></i></a>
                </div>            
        </section>
        <!-- Testimonials -->
        <section class="testimonials mt-2">
            <div class="container-lg">
                <h2 class="text-center font-24 mb-50" data-aos="fade-up">TESTIMONIALS</h2>
                <div class="testimonial-slider" data-aos="fade-up">
                    <asp:Repeater ID="rpttestimonials" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="lbltestimonialid" runat="server" Visible="false" Text='<%#Eval("testimonialid")%>'></asp:Label>
                            <div>
                                <div class="box">
                                    <figure>
                                        <a data-fancybox="images" href="/uploads/<%#Eval("uploadvedio")%>">
                                            <img src="/uploads/TestimonialImage/<%#Eval("uploadphoto")%>" alt="testmonial-img">
                                        </a>
                                    </figure>
                                    <div class="test-box">
                                        <%#Server.HtmlDecode(Eval("testimonialdesc").ToString())%>
                               
                                    <h5 class="text-center"><%#Eval("testimonialname")%></h5>
                                    <span class="text-center"><%#Eval("desg")%></span>
                                </div>
                            </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>
                <div class="view_all" data-aos="fade-up">
                    <a href="/testimonials.aspx?mpgid=9&pgidtrail=9">view all <i class="fa fa-angle-right" aria-hidden="true"></i></a>
                </div>
            </div>
        </section>
        <section class="happenings">
            <div class="container">
                <div class="row" data-aos="fade-up">

                    <div class="col-lg-5">
                        <div class="row">
                            <asp:Repeater ID="rpthappleft" runat="server" OnItemDataBound="rpthappleft_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Label ID="lblevents" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Label>
                                    <asp:Label ID="lbleventstitle" runat="server" Visible="false" Text='<%#Eval("eventstitle")%>'></asp:Label>
                                    <div id="panel1" runat="server">
                                        <div>
                                            <a id="ank" runat="server">
                                                <img src="/Uploads/SmallImages/<%#Eval("uploadevents") %>" class="img-fluid" alt="happening">
                                                <div class="icon">
                                                    <img src="images/lock.svg" alt="icon">
                                                </div>
                                                <div id="panel3" runat="server">
                                                    <div class="content">
                                                        <div class="date">
                                                            <h4><%#Eval("eventsdate","{0:dd}")%> <span><%#Eval("eventsdate","{0:MMM yy}")%> </span></h4>
                                                            <p><%#Eval("eventstitle")%></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </a>
                                        </div>
                                    </div>

                                    <div id="panel2" runat="server">
                                        <div class="text">
                                            <div class="icon">
                                                <img src="images/twitter-white.svg" alt="icon">
                                            </div>
                                            <div class="date">
                                                <h4><%#Eval("eventsdate","{0:dd}")%> <span><%#Eval("eventsdate","{0:MMM yy}")%> </span>
                                                    <h4>
                                                        <p><%#Eval("eventstitle")%></p>
                                            </div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>


                    <div class="col-lg-5">
                        <div class="row">
                            <asp:Repeater ID="rpthapplemiddle" runat="server" OnItemDataBound="rpthappmiddle_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Label ID="lblevents" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Label>
                                    <asp:Label ID="lbleventstitle" runat="server" Visible="false" Text='<%#Eval("eventstitle")%>'></asp:Label>
                                    <div id="panel1" runat="server">
                                        <div>
                                            <a id="ank" runat="server">
                                                <img src="/Uploads/SmallImages/<%#Eval("uploadevents") %>" class="img-fluid" alt="happening">
                                                <div class="icon">
                                                    <img src="images/lock.svg" alt="icon">
                                                </div>
                                                <div id="panel3" runat="server">
                                                    <div class="content">
                                                        <div class="date">
                                                            <h4><%#Eval("eventsdate","{0:dd}")%> <span><%#Eval("eventsdate","{0:MMM yy}")%> </span></h4>
                                                            <p><%#Eval("eventstitle")%></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </a>
                                        </div>
                                    </div>
                                    <div id="panel2" runat="server">
                                        <div class="text">
                                            <div class="icon">
                                                <img src="images/twitter-white.svg" alt="icon">
                                            </div>
                                            <div class="date"><%#Eval("eventsdate","{0:dd}")%> <span><%#Eval("eventsdate","{0:MMM yy}")%> </span></div>
                                            <p><%#Eval("eventstitle")%></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                    <div class="col-lg-2">
                        <div class="row">
                            <asp:Repeater ID="rpthappright" runat="server" OnItemDataBound="rpthappright_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Label ID="lblevents" runat="server" Visible="false" Text='<%#Eval("eventsid")%>'></asp:Label>
                                    <asp:Label ID="lbleventstitle" runat="server" Visible="false" Text='<%#Eval("eventstitle")%>'></asp:Label>
                                    <div class="col-lg-12">
                                        <div id="panel1" runat="server" class="img-box">
                                            <div class="icon">
                                                <img src="images/lock.svg" alt="icon">
                                            </div>

                                            <img src="/Uploads/SmallImages/<%#Eval("uploadevents") %>" alt="happening">

                                            <div class="content">
                                                <div class="date">
                                                    <h4><%#Eval("eventsdate","{0:dd}")%> <span><%#Eval("eventsdate","{0:MMM yy}")%> </span></h4>
                                                </div>
                                                <p><%#Eval("eventstitle")%></p>
                                            </div>
                                        </div>

                                        <div id="panel2" runat="server" class="text text-white">
                                            <div class="icon">
                                                <img src="images/twitter-white.svg" alt="icon">
                                            </div>
                                            <div class="date">
                                                <h4><%#Eval("eventsdate","{0:dd}")%> <span><%#Eval("eventsdate","{0:MMM yy}")%> </span></h4>
                                            </div>
                                            <p><%#Eval("eventstitle")%></p>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>



                    <div class="col-lg-12">
                        <div class="view_all">
                            <a href="javascript:void(0);">view all <i class="fa fa-angle-right" aria-hidden="true"></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="certified" id="counter">
            <div class="container-lg">
                <div class="row">
                    <div class="img-box" data-aos="fade-right">
                        <figure>
                            <img alt="certified-img" class="w-100" src="/images/certified01.png" />
                        </figure>
                    </div>
                    <div class="text_box" data-aos="fade-up">
                        <div class="row">
                            <div class="col-lg-5">
                                <div class="contractor_left">
                                <h4 class="fw-semibold position-relative">Jubilant Certified Contractors</h4>
                                <h5 class="fw-semibold position-relative">Step into the realm of champions and unlock a world of limitless advantages</h5>
                                <p>
                                    We have transformed the lives of over <span id="span1" runat="server" visible="true" class="count percent" data-count="275"></span>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"
                                        ViewStateMode="Enabled" Visible="false">
                                        <ContentTemplate>
                                            <asp:Timer ID="Timer1" runat="server" Interval="900000" OnTick="Timer1_Tick">
                                            </asp:Timer>
                                            <div class="figr-update">
                                                <asp:Label ID="Label1" runat="server" Text="275"></asp:Label>k
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    contractors Benefited
                                </p>
                            </div>
                            </div>
                            <asp:Literal ID="litsmalldesc" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <uc3:footer ID="footer1" runat="server" />

        <script src="/js/jquery.js"></script>
        <script src="/js/aos.js"></script>
        <script src="/js/fancybox.js"></script>
        <script src="/js/bootstrap.js"></script>
        <script src="/js/slick.js"></script>
        <script src="/js/owl.carousel.min.js"></script>
        <script src="/js/main.js"></script>
    </form>
</body>
</html>
