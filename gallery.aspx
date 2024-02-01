<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="gallery.aspx.cs" Inherits="gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="breadcrumb">
        <div class="container-lg">
            <h1 class="text-center">
                Gallery</h1>
        </div>
    </div>
    
    <section class="gallery">
        <div class="container">
            <ul class="nav nav-tabs nav-fill" id="ex1" role="tablist">
                <li>
                    <div class="contractor_dropdown pb-0">
                        <div class="dropdown">
                            <button class="btn btn-light dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                                Type
                            </button>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="#">Action</a></li>
                                <li><a class="dropdown-item" href="#">Another action</a></li>
                                <li><a class="dropdown-item" href="#">Something else here</a></li>
                            </ul>
                        </div>
                    </div>
                </li>

                <asp:Repeater ID="rptgallerytype" runat="server" OnItemDataBound="rptgallerytype_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="littypeid" runat="server" Visible="false" Text='<%#Eval("typeid")%>'></asp:Literal>
                        <li class="nav-item" role="presentation">
                            <a class="nav-link" id="ank" runat="server" data-bs-toggle="tab" role="tab"
                                aria-controls="ex2-tabs-2" aria-selected="false">
                                <i id="i1" runat="server" aria-hidden="true"></i>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <div class="tab-content" id="ex2-content">
                <asp:Repeater ID="rptgallerymain" runat="server" OnItemDataBound="rptgallerymain_ItemDataBound">
                    <ItemTemplate>
                        <asp:Literal ID="littypeid" runat="server" Visible="false" Text='<%#Eval("typeid")%>'></asp:Literal>
                        <div id="panel1" runat="server" class="tab-pane fade show active ex2-tabs-1" role="tabpanel" aria-labelledby="ex2-tab-1">
                            <div class="row" id="panelphoto" runat="server" visible="false">
                                <asp:Repeater ID="rptalbum" runat="server" OnItemDataBound="rptalbum_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="littypeid" runat="server" Visible="false" Text='<%#Eval("typeid")%>'></asp:Literal>
                                        <asp:Literal ID="litalbumid" runat="server" Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                                            <div class="img-box">
                                                <a id="ank" runat="server">
                                                    <figure>
                                                        <img src="/uploads/LargeImages/<%#Eval("uploadaimage")%>" class="w-100">
                                                    </figure>
                                                    <div class="item">
                                                        <span>
                                                            <asp:Literal ID="lblcount" runat="server"></asp:Literal></span>
                                                        <p>
                                                            <asp:Literal ID="lbltype" runat="server" Text='<%#Eval("typename")%>'></asp:Literal>
                                                        </p>
                                                    </div>
                                                </a>
                                                <div class="text">
                                                    <p><%#Eval("albumtitle")%></p>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="row" id="panelvedio" runat="server" visible="false">
                                <asp:Repeater ID="rptvedio" runat="server" OnItemDataBound="rptvedio_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litvedioid" runat="server" Visible="false" Text='<%#Eval("vedioid")%>'></asp:Literal>
                                        <asp:Literal ID="litalbumid" runat="server" Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                                        <div class="col-md-4">
                                            <div class="video-box">
                                                <a data-fancybox="images" href="<%#Eval("uploadvedio")%>">
                                                    <figure>
                                                     <img src="/uploads/vedio/<%#Eval("thumbnailimage")%>" class="img-fluid" alt="video">
                                                    </figure>
                                                    <div class="item" runat="server" visible="false">
                                                        <span><asp:Literal ID="lblcount" runat="server"></asp:Literal></span>
                                                        <p>Videos</p>
                                                    </div>
                                                </a>
                                                <div class="text">
                                                    <p><%#Eval("vediotitle")%></p>
                                                </div>
                                            </div>
                                       
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>


                        <%-- <div class="tab-pane fade" id="profile-tab-pane" role="tabpanel" aria-labelledby="profile-tab" tabindex="0">
                            
                        </div>--%>
                    </ItemTemplate>
                </asp:Repeater>
                <%--   <div class="tab-pane fade ex2-tabs-2" role="tabpanel" aria-labelledby="ex2-tab-2">
                    <div class="row">
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/gallery01.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/gallery01.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>05</span>
                                        <p>Photos</p>
                                    </div>
                                </a>

                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/gallery02.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/gallery02.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>05</span>
                                        <p>Photos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/gallery03.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/gallery03.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>05</span>
                                        <p>Photos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/galelry04.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/galelry04.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>10</span>
                                        <p>Photos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/gallery06.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/gallery06.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>12</span>
                                        <p>Photos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/gallery07.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/gallery07.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>09</span>
                                        <p>Photos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/gallery08.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/gallery08.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>05</span>
                                        <p>Photos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/gallery09.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/gallery09.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>05</span>
                                        <p>Photos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="img-box">
                                <a href="images/gallery10.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/gallery10.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>15</span>
                                        <p>Photos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade ex2-tabs-3" role="tabpanel" aria-labelledby="ex2-tab-3">
                    <div class="row">
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="video-box">
                                <a href="images/video01.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/video01.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>05</span>
                                        <p>Videos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="video-box">
                                <a href="images/video02.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/video02.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>05</span>
                                        <p>Videos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6" data-aos="fade-up">
                            <div class="video-box">
                                <a href="images/video03.png" data-fancybox="images">
                                    <figure>
                                        <img src="images/video03.png" class="w-100">
                                    </figure>
                                    <div class="item">
                                        <span>05</span>
                                        <p>Videos</p>
                                    </div>
                                </a>
                                <div class="text">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
    </section>
</asp:Content>

