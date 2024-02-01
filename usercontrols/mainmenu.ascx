<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mainmenu.ascx.cs" Inherits="usercontrols_mainmenu" %>
<%@ Register Src="~/usercontrols/hamburger.ascx" TagName="hamburger" TagPrefix="uchamburger" %>
<nav>
    <ul class="d-flex align-items-center">
        <li>
            <a href="/cpage.aspx?mpgid=7&pgidtrail=7">About Jivanjor</a>
        </li>
        <asp:Repeater ID="rptmainemenu" runat="server" OnItemDataBound="rptmainmenu_ItemDataBound">
            <ItemTemplate>
                <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                <li id="l1" runat="server">
                    <a id="ank" runat="server"><%#Eval("category")%></a>
                    <asp:Literal ID="litmegamenu" runat="server" Visible="true"></asp:Literal>
                    <div class="sub_menu" id="panlesubmenu" runat="server" visible="false">
                        <div class="box-wrapper" runat="server" visible="false">
                            <asp:Repeater ID="rptinner" runat="server" OnItemDataBound="rptinner_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                                    <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                    <div class="box">
                                        <a id="ank" runat="server">
                                            <figure>
                                                <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product">
                                            </figure>
                                            <h4><%#Eval("productname")%></h4>
                                        </a>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="new_menu_work" runat="server" visible="false" id="panelnewmenu">
                            <div class="row">
                                <asp:Repeater ID="rptproductsub" runat="server" OnItemDataBound="rptproductsub_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                                        <asp:Literal ID="litpsubcatid" runat="server" Visible="false" Text='<%#Eval("psubcatid")%>'></asp:Literal>
                                        <div id="panel1" runat="server" class="col-md-4">
                                            <h3><%#Eval("category")%></h3>
                                            <ul>
                                                <li>
                                                    <asp:Repeater ID="rptproductinner" runat="server" OnItemDataBound="rptproductinner_ItemDataBound">
                                                        <ItemTemplate>
                                                            <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                                                            <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                                            <div class="box">
                                                                <a id="ank" runat="server">
                                                                    <figure>
                                                                        <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product">
                                                                    </figure>
                                                                    <h4><%#Eval("productname")%></h4>
                                                                </a>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>


                                                </li>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>



                            </div>
                        </div>
                        <div class="btn_wrapper">
                            <a href="/application.aspx?mpgid=6&pgidtrail=6" class="btn">Advice & Tips</a>
                            <%--<a href="javascript:void(0);" class="btn">Where to Buy</a>--%>
                            <a href="javascript:void(0);">Help Me Choose A Product</a>

                        </div>
                    </div>
                </li>
            </ItemTemplate>
        </asp:Repeater>

        <li class="toggle">
            <a href="javascript:void(0);" class="inner_toggle">
                <span></span>
                <span></span>
                <span></span>
            </a>
            <uchamburger:hamburger ID="hamburger1" runat="server" />
        </li>
    </ul>
</nav>
