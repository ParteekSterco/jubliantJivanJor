<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="testimonials.aspx.cs" Inherits="testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb">
        <div class="container-lg">
            <h1 class="text-center">Testimonials</h1>
            <div class="contractor_dropdown">
                <div class="dropdown">
                    <button class="btn btn-light dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Contractor
                    </button>
                    <ul class="dropdown-menu">
                        <li><a class="dropdown-item" href="#">Carpenter</a></li>                       
                    </ul>
                </div>
            </div>
        </div>
    </div>    
    <div class="testimonial">
        <div class="container">
            <div class="row">
                <asp:Repeater ID="rpttestimonials" runat="server">
                    <ItemTemplate>
                        <asp:Literal ID="littesid" runat="server" Visible="false" Text='<%#Eval("tesid")%>'></asp:Literal>

                        <div class="col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <%--<a href="/Uploads/TestimonialImage/<%#Eval("Uploadphoto") %>" class="wow fadeIn animated" data-wow-delay=".1s" data-bs-toggle="modal" data-bs-target="#video-modal<%#Eval("testimonialid")%>">--%>
                                <figure runat="server" visible="false">
                                    <img class="w-100" src="/Uploads/TestimonialImage/<%#Eval("Uploadphoto") %>" alt="testimonial-img">
                                </figure>
                                <figure>
                                    <a data-fancybox="images" href="/uploads/<%#Eval("uploadvedio")%>">
                                        <img alt="application-img" src="/Uploads/TestimonialImage/<%#Eval("Uploadphoto") %>" />
                                    </a>
                                </figure>

                                <div class="detail">
                                    <figure>
                                        <img src="/images/play-icon-white.svg" alt="play-icon">
                                    </figure>
                                    <h5><%#Eval("testimonialname")%></h5>
                                    <span><%#Eval("desg")%></span>
                                </div>
                                <%--</a>--%>
                            </div>
                        </div>
                        <div class="col-md-6" data-aos="fade-up">
                            <div class="text-box">
                                <p>
                                    <%#Server.HtmlDecode(Eval("testimonialdesc").ToString()).Replace("<p>","").Replace("</p>","")%>
                                </p>

                                <h5><%#Eval("testimonialname")%></h5>
                                <span><%#Eval("desg")%></span>
                            </div>

                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div class="col-md-6" data-aos="fade-up">
                            <div class="text-box">
                                <p>
                                    <%#Server.HtmlDecode(Eval("testimonialdesc").ToString()).Replace("<p>","").Replace("</p>","")%>
                                </p>

                                <h5><%#Eval("testimonialname")%></h5>
                                <span><%#Eval("desg")%></span>
                            </div>

                        </div>
                        <div class="col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <figure>
                                    <a data-fancybox="images" href="/uploads/<%#Eval("uploadvedio")%>">
                                        <img alt="application-img" src="/Uploads/TestimonialImage/<%#Eval("Uploadphoto") %>" />
                                    </a>
                                </figure>
                                <div class="detail">
                                    <figure>
                                        <img src="/images/play-icon-white.svg" alt="play-icon">
                                    </figure>
                                    <h5><%#Eval("testimonialname")%></h5>
                                    <span><%#Eval("desg")%></span>
                                </div>
                            </div>
                        </div>
                    </AlternatingItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
