<%@ Control Language="C#" AutoEventWireup="true" CodeFile="hamburger.ascx.cs" Inherits="usercontrols_hamburger" %>
<div class="main-menu">
    <ul class="text-center d-flex justify-content-center flex-column align-items-center">
        <asp:Repeater ID="rpthamburger" runat="server" OnItemDataBound="rpthamburger_ItemDataBound">
            <ItemTemplate>
                    <asp:Literal ID="litrewriteurl" runat="server" Visible="false" Text='<%#Eval("rewriteurl")%>'></asp:Literal>
                    <asp:Literal ID="litpageid" runat="server" Visible="false" Text='<%#Eval("pageid")%>'></asp:Literal>
                    <asp:Literal ID="litpageurl" runat="server" Text='<%#Eval("pageurl")%>' Visible="false"></asp:Literal>
                    <asp:Literal ID="litdynamicrewrite" runat="server" Text='<%#Eval("dynamicurlrewrte")%>' Visible="false"></asp:Literal>
                   <li><a id="ank" runat="server"><%#Eval("linkname")%></a></li>
            </ItemTemplate>
        </asp:Repeater>
      
        <li>
            <div class="social_icon d-flex align-items-center">
                <h5>Follow Us</h5>
                <a href="https://www.facebook.com/jivanjor" target="_blank">
                    <img src="images/fb-t.svg" alt="facebook"></a>
				<a href="https://twitter.com/jivanjor_india?lang=en" target="_blank"><img src="/images/twitter-side-icon.png" alt="social-icon"></a>
                <a href="https://www.youtube.com/channel/UCP72-RdBd8VfYjk9CnK0qhw" target="_blank">
                    <img src="images/yt-b.svg" alt="youtube"></a>
                <a href="https://www.instagram.com/jivanjor_premium_adhesives/" target="_blank">
                    <img src="images/ins-t.svg" alt="instragram"></a>
				<a href="javascript:void(0)"><img src="/images/linkedin-side-icon.png" alt="social-icon"></a>
            </div>
        </li>
    </ul>
</div>
