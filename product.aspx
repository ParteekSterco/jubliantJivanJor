<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true"
    CodeFile="product.aspx.cs" Inherits="product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section class="rounder_banner r1" id="panelbanner" runat="server" visible="false">
        <div class="container">
            <div class="rounder_slider" data-aos="fade-up">
                <asp:Repeater ID="rptbanner" runat="server" OnItemDataBound="rptbanner_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                        <div>
                            <div class="slider-box">
                                <div class="row align-items-center">
                                    <asp:Literal ID="litbid" runat="server" Text='<%#Server.HtmlDecode(Eval("bid").ToString())%>'></asp:Literal>
                                    <div class="col-lg-5">
                                        <div class="big-img">
                                            <figure>
                                                <img src="/uploads/SmallImages/<%#Eval("smallimage")%>" alt="all-rounder-banner"
                                                    class="w-100">
                                            </figure>
                                        </div>
                                    </div>
                                    <asp:Literal ID="litshortdesc" runat="server" Text='<%#Server.HtmlDecode(Eval("shortdetail").ToString())%>'></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!-- div class="btn_wrapper">
                <a href="javascript:void(0);" class="btn-red">Where to Buy</a>
            </div -->
        </div>
    </section>
    <asp:Literal ID="litfeature" runat="server"></asp:Literal>
    <asp:Literal ID="littechnical" runat="server"></asp:Literal>
    <asp:Literal ID="litpacksize" runat="server"></asp:Literal>
    
    <!-- Testimonials -->
    


    <section class="application rounder_application" id="panelapplication" runat="server"
        visible="false">
        <div class="container-lg">
            <!-- <h2 class="text-center font-24 mb-50">Applications</h2> -->
            <div class="text-black text-center aos-init aos-animate mb-4" data-aos="fade-up">
                <h5>Applications</h5>
            </div>
            <asp:Literal ID="litdetail" runat="server" Visible="true"></asp:Literal>
            <div class="testimonial-slider">
                <asp:Repeater ID="rptapplication" runat="server" OnItemDataBound="rptapplication_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                        <asp:Literal ID="lityoutubeurl" runat="server" Visible="false" Text='<%#Eval("youtubeurl")%>'></asp:Literal>
                        <asp:Literal ID="litbanner" runat="server" Visible="false" Text='<%#Eval("banner")%>'></asp:Literal>
                        <asp:Literal ID="litbannerspec" runat="server" Visible="false" Text='<%#Eval("homeimage")%>'></asp:Literal>

                        <div id="panel1" runat="server" visible="false">
                            <div class="box">
                                <a href="/uploads/ProductsImage/<%#Eval("banner")%>" data-fancybox="images">
                                    <figure>
                                        <img runat="server" id="imgbanner" alt="application-img" />
                                    </figure>
                                </a>
                                <p class="p-24"><%#Eval("brand")%></p>
                            </div>
                        </div>
                        <div runat="server" id="divvideo" visible="false">
                            <a class="wow fadeIn animated" data-wow-delay=".1s" data-bs-toggle="modal" data-bs-target="#video-modal<%#Eval("appid")%>">
                                <div class="box">
                                    <figure>
                                        <img runat="server" id="img1" alt="application-img" />
                                    </figure>
                                    <p class="p-24"><%#Eval("brand")%></p>
                                </div>
                            </a>
                            
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

    <section class="testimonials rounder_testimonial bg-white" id="paneltestimonial" runat="server"
        visible="false">
        <div class="container-lg">
            <div class="text-black text-center aos-init aos-animate mb-4" data-aos="fade-up">
                <h5>Testimonials</h5>
            </div>
            <!-- <h2 class="text-center font-24 mb-50" data-aos="fade-up"></h2> -->
            <div class="testimonial-slider" data-aos="fade-up">
                <asp:Repeater ID="rpttestimonials" runat="server">
                    <ItemTemplate>
                        <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                        <div>
                            <div class="box">
                                <figure>
                                    <img src="/uploads/TestimonialImage/<%#Eval("uploadphoto")%>" alt="testmonial-img">
                                </figure>
                                <p class="p-24 text-center">
                                    <%#Server.HtmlDecode(Eval("testimonialdesc").ToString()).Replace("<p>","").Replace("</p>","")%>
                                </p>
                                <h5 class="text-center"><%#Eval("testimonialname")%></h5>
                                <span class="text-center"><%#Eval("desg")%></span>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

            
            <div class="view_all">
                <a href="/testimonials.aspx?mpgid=9&pgidtrail=9">view all <i class="fa fa-angle-right" aria-hidden="true"></i></a>
            </div>
        </div>
    </section>

    <asp:Repeater ID="rptvedio" runat="server">
        <ItemTemplate>
            <asp:Literal ID="littesid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
            <div class="modal fade video-modal" id="video-modal<%#Eval("appid")%>" tabindex="-1" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-body">
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close">
                                <img src="/images/close.svg" alt="icon close">
                            </button>
                            <iframe style="display: none;"></iframe>
                            <iframe width="1264" height="711" style="width: 100%; height: 50rem;" src="<%#Eval("youtubeurl")%>" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                        </div>
                        <div class="modal-footer">
                            <p><%#Eval("brand")%></p>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
