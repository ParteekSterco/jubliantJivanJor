<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="gallery-detail.aspx.cs" Inherits="gallery_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section class="gallery">
        <div class="container">
            <div class="image_gallery_popup">
                <div class="row">
                    <asp:Repeater ID="rptalbum" runat="server">
                        <ItemTemplate>
                            <asp:Literal ID="liteventsid" runat="server" Visible="false" Text='<%#Eval("albumid")%>'></asp:Literal>
                            <asp:Literal ID="litphotoid" runat="server" Visible="false" Text='<%#Eval("photoid")%>'></asp:Literal>
                            <div class="col-lg-4 col-md-6" data-aos="fade-up">
                                <div class="img-box">
                                    <a href="/uploads/LargeImages/<%#Eval("Uploadphoto")%>" data-fancybox="images">
                                        <figure>
                                            <img src="/uploads/LargeImages/<%#Eval("Uploadphoto")%>" class="w-100">
                                        </figure>
                                    </a>
                                    <div class="text d-none">
                                        <p><%#Eval("phototitle")%></p>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>


  
</asp:Content>

