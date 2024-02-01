<%@ Control Language="C#" AutoEventWireup="true" CodeFile="homebanner.ascx.cs" Inherits="usercontrols_homebanner" %>
<section class="home_banner">
    <div class="home_slider">
        <asp:Repeater ID="rptbanner" runat="server" OnItemDataBound="rptbanner_ItemDataBound">
            <ItemTemplate>
                  <asp:Literal ID="litbid" runat="server" Visible="false" Text='<%#Eval("bid")%>'></asp:Literal>
                <asp:Literal ID="litblogo" runat="server" Visible="false" Text='<%#Eval("blogo")%>'></asp:Literal>
                 <asp:Literal ID="litbtype" runat="server" Visible="false" Text='<%#Eval("btype")%>'></asp:Literal>
                <div>
                    <div id="panel1" runat="server" visible="false">
                        <figure>
                            <img src="/uploads/banner/<%#Eval("bannerimage")%>" class="w-100" alt="home-banner">
                        </figure>
                        <div class="container-lg">
                            <div class="icon" id="panellogo" runat="server" visible="false">
                                <img src="/uploads/banner/<%#Eval("blogo")%>" alt="home-icon">
                            </div>
                            <div class="text">
                                <h2 class="text-white"><%#Eval("title")%></h2>
                            </div>
                        </div>
                    </div>
                     <div class="banner-text" runat="server" id="divvideo" visible="false">
					
					<video playsinline="playsinline" autoplay="autoplay" muted="muted" loop="loop">
                        <source src="/uploads/banner/<%#Eval("bannerimage")%>" type="video/mp4" width="100%">
                    </video>
					 
                </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>       
    </div>
    <div class="down_arrow">
        <a href="#" class="scroll-down" address="true"><i class="fa fa-angle-down" aria-hidden="true"></i></a>
    </div>
</section>
