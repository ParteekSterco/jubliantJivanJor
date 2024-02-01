<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<%@ Register Src="~/usercontrols/mainmenu.ascx" TagName="mainmenu" TagPrefix="uc5" %>
<%@ Register Src="~/usercontrols/homebanner.ascx" TagName="homebanner" TagPrefix="uc2" %>
<%@ Register Src="~/usercontrols/footer.ascx" TagName="footer" TagPrefix="uc3" %>
<%@ Register Src="~/usercontrols/seosection.ascx" TagName="seosection" TagPrefix="uc4" %>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
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
</head>
<body>
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
        <section class="filter_slider accordion-product">
            <%--<div class="container-lg">
                <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-indicators">
                        <asp:Repeater ID="rptproductlist" runat="server" OnItemDataBound="rptproductlist_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                <button id="btn1" runat="server" data-bs-target="#carouselExampleIndicators" data-bs-slide-to='<%#Container.ItemIndex %>'>
                                    <%#Eval("productname")%></button>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="carousel-inner">
                        <asp:Repeater ID="rptproductdetail" runat="server" OnItemDataBound="rptproductdetail_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                <asp:Literal ID="litproducticon" runat="server" Visible="false" Text='<%#Eval("producticon")%>'></asp:Literal>
                                <asp:Literal ID="litlargeimage" runat="server" Visible="false" Text='<%#Eval("largeimage")%>'></asp:Literal>
                                <div id="panel1" runat="server">
                                    <div class="slider-box">
                                        <div class="text" id="panelicon" runat="server" visible="false">
                                            <figure>
                                                <img src="/uploads/ProductsImage/<%#Eval("producticon")%>" alt="filter-slider-img">
                                            </figure>
                                        </div>
                                        <div class="img-box" id="panellarge" runat="server" visible="false">
                                            <figure>
                                                <img src="/uploads/ProductsImage/<%#Eval("largeimage")%>" alt="filter-slider-img">
                                            </figure>
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

            </div>--%>
             <div class="container-lg">
               <%-- <ul class="nav nav-tabs d-none d-lg-flex border-0" id="myTab" role="tablist">
                    <asp:Repeater ID="rptproductlist" runat="server" OnItemDataBound="rptproductlist_ItemDataBound">
                        <ItemTemplate>
                            <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>                            
                            <li class="nav-item" role="presentation">
                                <button id="btn" runat="server" aria-controls="course-tab-pane02" data-bs-toggle="tab" role="tab"
                                    type="button">
                                    <%#Eval("category")%></button>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>--%>
                <div class="col-right">
                    <div class="tab-content accordion" id="myTabContent">
                        <asp:Repeater ID="rptproductdetail" runat="server" OnItemDataBound="rptproductdetail_ItemDataBound">
                            <ItemTemplate>
                                <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>                                
                                <div id="panel1" runat="server" role="tabpanel" tabindex="0">
                                    <h2 class="accordion-header d-lg-none" id="headingTwo">
                                        <button id="btn" runat="server" aria-controls="collapseTwo" data-bs-toggle="collapse" type="button">
                                            <%#Eval("category")%></button>
                                    </h2>
                                    <div id="panel2" runat="server" aria-labelledby="headingTwo" data-bs-parent="#myTabContent">
                                        <div class="accordion-body">
                                            <div class="slider-box_wrapper11">
                                                <div class="home_banner_slider owl-carousel owl-theme">
                                                
                                                <asp:Repeater ID="rptproductimage" runat="server" OnItemDataBound="rptproductimage_ItemDataBound">
                                                    <ItemTemplate>
                                                        <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                                        <asp:Literal ID="litpanelimage1" runat="server" Visible="false" Text='<%#Eval("producticon")%>'></asp:Literal>
                                                        <asp:Literal ID="litpanelimage2" runat="server" Visible="false" Text='<%#Eval("largeimage")%>'></asp:Literal>
                                                        <div>
                                                            <div class="item">

                                                          <%-- <div class="slider-box">--%>
                                                           <div class="slider-box r1" id="panelbanner" runat="server">                                                        
                                                                <div class="text" id="panelimage1" runat="server" visible="false">
                                                                    <figure>
                                                                        <img src="/uploads/LargeImages/<%#Eval("producticon")%>" alt="filter-slider-img">
                                                                    </figure>
                                                                </div>
                                                                <div class="img-box" id="panelimage2" runat="server" visible="false">
                                                                    <figure>
                                                                        <img src="/uploads/ProductsImage/<%#Eval("largeimage")%>" alt="filter-slider-img">
                                                                    </figure>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>


                                            </div>
                                        </div>
                                    </div>
                                </div> </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
					 <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
						<span class="carousel-control-prev-icon" aria-hidden="true"></span>
						<span class="visually-hidden">Previous</span>
					  </button>
					  <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
						<span class="carousel-control-next-icon" aria-hidden="true"></span>
						<span class="visually-hidden">Next</span>
					  </button>
                </div>
            </div>

            <asp:Literal ID="litshortdesc" runat="server"></asp:Literal>

        </section>
        <section class="application">
            <div class="container-lg">
                <h2 class="text-center font-24 mb-50" data-aos="fade-up">Application</h2>
                <div class="testimonial-slider" data-aos="fade-up">
                    <asp:Repeater ID="rptapplication" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="lblpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Label>
                            <div>
                                <div class="box">
                                    <a href="/uploads/ProductsImage/<%#Eval("banner")%>" data-fancybox="images">
                                        <figure>
                                            <img src="/uploads/ProductsImage/<%#Eval("banner")%>" alt="<%#Eval("brand")%>">
                                        </figure>
                                    </a>
                                    <p class="p-24"><%#Eval("brand")%></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>


                </div>
                <div class="view_all" data-aos="fade-up">
                    <a href="/application.aspx?mpgid=6&pgidtrail=6">view all <i class="fa fa-angle-right" aria-hidden="true"></i></a>
                </div>
            </div>
        </section>
        <!-- Testimonials -->
        <section class="testimonials">
            <div class="container-lg">
                <h2 class="text-center font-24 mb-50" data-aos="fade-up">Testimonials</h2>
                <div class="testimonial-slider" data-aos="fade-up">
                    <asp:Repeater ID="rpttestimonials" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="lbltestimonialid" runat="server" Visible="false" Text='<%#Eval("testimonialid")%>'></asp:Label>
                            <div>
                                <div class="box">
                                    <figure>
                                        <img src="/uploads/TestimonialImage/<%#Eval("uploadphoto")%>" alt="testmonial-img">
                                    </figure>
                                    <p class="p-24 text-center">
                                        <%#Server.HtmlDecode(Eval("testimonialdesc").ToString())%>
                                    </p>
                                    <h5 class="text-center"><%#Eval("testimonialname")%></h5>
                                    <span class="text-center"><%#Eval("desg")%></span>
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


        <asp:Literal ID="litsmalldesc" runat="server"></asp:Literal>
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
