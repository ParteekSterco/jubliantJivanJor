<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true"
    CodeFile="application.aspx.cs" Inherits="application" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

      <asp:Literal ID="litpagedescription" runat="server"></asp:Literal>


    <section class="application-banner ap-box1" data-aos="fade-up" runat="server" Visible="false">
        <div class="container">
            <div class="comman_text text-center">
                <h5>
                    <asp:Literal ID="littltle" runat="server"></asp:Literal>
                </h5>
                <p>
                    <asp:Literal ID="litdetail" runat="server"></asp:Literal>
                </p>
            </div>
            <div class="row">
                <div class="col-lg-10">
                    <figure>
                        <img class="w-100" src="/images/application-left-img.png" alt="application-img">
                    </figure>
                </div>
                <div class="col-lg-2">
                    <div class="box-wrapper d-flex justify-content-between flex-wrap">
                        <div class="row">
                            <asp:Repeater ID="rptproduct" runat="server" OnItemDataBound="rptproduct_ItemDataBound">
                                <ItemTemplate>
                                    <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                    <div class="col-md-6">
                                        <div class="box">
                                            <figure>
                                                <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product01">
                                            </figure>
                                            <h4><%#Eval("productname")%></h4>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="col-md-12">
                                <div class="row">
                                    <asp:Repeater ID="rptprod" runat="server">
                                        <ItemTemplate>
                                            <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                            <div class="col-md-6">
                                                <div class="box">
                                                    <figure>
                                                        <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product01">
                                                    </figure>
                                                    <h4><%#Eval("productname")%></h4>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="ply" id="ply" runat="server" Visible="false">
        <div class="container">
            <asp:Repeater ID="rptplywood" runat="server" OnItemDataBound="rptplywood_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                    <div class="comman_text" data-aos="fade-up">
                        <h5 class="text-white text-center"><%#Eval("brand")%></h5>
                        <p class="text-white text-center">
                            <%#Server.HtmlDecode(Eval("detail").ToString()).Replace("<p>","").Replace("</p>","")%>
                        </p>
                    </div>
					<div class="box_wrapper">
                    <asp:Repeater ID="rptinner" runat="server">
                        <ItemTemplate>
                            <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                            <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                            
                                <div class="box" data-aos="fade-up">
                                    <figure>
                                        <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="<%#Eval("productid")%>">
                                    </figure>
                                    <h6><%#Eval("productname")%></h6>
                                </div>
                            
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
			</div>
        
    </section>
   <!-- <section class="application-banner decorative_laminate" id="decorative">
        <div class="container">
            <div class="comman_text text-center" data-aos="fade-up">
                <h5>
                    <asp:Literal ID="litapptitle" runat="server"></asp:Literal>
                </h5>
                <p>
                    <asp:Literal ID="litappdetail" runat="server"></asp:Literal>
                </p>
            </div>
            <div class="row" data-aos="fade-up">
                <div class="col-lg-6">
                    <figure>
                        <img class="w-100" src="/images/application-left-img.png" alt="application-img">
                    </figure>
                </div>
                <div class="col-lg-6">
                    <div class="box-wrapper d-flex justify-content-between flex-wrap">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <asp:Repeater ID="rptdecorative" runat="server" OnItemDataBound="rptdecorative_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                            <div class="col-md-6">
                                                <div class="box">
                                                    <figure>
                                                        <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product01">
                                                    </figure>
                                                    <h4><%#Eval("productname")%></h4>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <asp:Repeater ID="rptdecorative2" runat="server">
                                        <ItemTemplate>
                                            <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                            <div class="col-md-6">
                                                <div class="box">
                                                    <figure>
                                                        <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product01">
                                                    </figure>
                                                    <h4><%#Eval("productname")%></h4>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
    <section class="ply plytoply" id="plytoply">
        <div class="container">
            <asp:Repeater ID="rptplytoply" runat="server" OnItemDataBound="rptplytoply_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                    <div class="comman_text" data-aos="fade-up">
                        <h5 class="text-white text-center"><%#Eval("brand")%></h5>
                    </div>

                    <div class="row">
                        <div class="col-lg-6">
                            <div class="box_wrapper">
                                <asp:Repeater ID="rptrptplytoplyinner" runat="server">
                                    <ItemTemplate>
                                        <asp:Literal ID="litpcatid" runat="server" Visible="false" Text='<%#Eval("pcatid")%>'></asp:Literal>
                                        <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>

                                        <div class="box" data-aos="fade-up">
                                            <figure>
                                                <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="<%#Eval("productid")%>">
                                            </figure>
                                            <h6><%#Eval("productname")%></h6>
                                        </div>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="ply-to-ply-txt">
                                <p class="text-white">
                                    <%#Server.HtmlDecode(Eval("detail").ToString()).Replace("<p>","").Replace("</p>","")%>
                                </p>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>-->

  <%--  <section class="application-banner wood-vaneers" id="wood-v" >--%>
    <section class="application-banner wood-vaneers" id="woodv" runat="server" visible="false" >
        <div class="container">
            <div class="comman_text text-center">
                <h5>
                    <asp:Literal ID="littitle1" runat="server"></asp:Literal>
                </h5>
                <p>
                    <asp:Literal ID="lidetail1" runat="server"></asp:Literal>
                </p>
            </div>
            <div class="row">

                <div class="col-lg-6">
                    <div class="box-wrapper d-flex justify-content-between flex-wrap">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <asp:Repeater ID="rptveneers" runat="server" OnItemDataBound="rptveneers_ItemDataBound">
                                        <ItemTemplate>
                                            <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                            <div class="col-md-6">
                                                <div class="box">
                                                    <figure>
                                                        <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product01">
                                                    </figure>
                                                    <h4><%#Eval("productname")%></h4>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <asp:Repeater ID="rptveneers2" runat="server">
                                        <ItemTemplate>
                                            <asp:Literal ID="litproductid" runat="server" Visible="false" Text='<%#Eval("productid")%>'></asp:Literal>
                                            <div class="col-md-6">
                                                <div class="box">
                                                    <figure>
                                                        <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product01">
                                                    </figure>
                                                    <h4 id="wppd-acry"><%#Eval("productname")%></h4>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

                <div class="col-lg-6">
                    <figure>
                        <img class="w-100" src="/images/application-left-img.png" alt="application-img">
                    </figure>
                </div>
            </div>
        </div>
    </section>
  <%--  <section class="application-banner wood-acrylic" data-aos="fade-up" runat="server" visible="false" id="secapp">--%>
    <section class="application-banner wood-acrylic" data-aos="fade-up"  id="secapp" runat="server" visible="false">
        <div class="container">
            <div class="comman_text text-center">
                <h5><asp:Literal ID="littopbrand" runat="server"></asp:Literal></h5>
               <p><asp:Literal ID="littopdetail" runat="server"></asp:Literal></p>
            </div>
            <div class="row">
                
                <div class="col-lg-12">
                    <div class="box-wrapper justify-content-between flex-wrap">
                        <div class="row">
                        <asp:Repeater ID="repapplication" runat="server"  OnItemDataBound="repapplication_ItemDataBound">
                                        <ItemTemplate>
                            <div class="col-md-6">
                                <div class="box">
                                    <figure>
                                        <img src="/uploads/ProductsImage/<%#Eval("uploadaimage")%>" alt="product01">
                                    </figure>
                                    <h4><%#Eval("productname")%></h4>
                                </div>
                            </div>
                            <asp:Literal ID="litbrand" runat="server" Visible="false" Text='<%#Eval("brand")%>'></asp:Literal>
                            <asp:Literal ID="litdetail" runat="server" Visible="false" Text='<%#Eval("detail")%>'></asp:Literal>
                            </ItemTemplate>
                            </asp:Repeater>
							<%--<div class="col-md-3">
                                <div class="box">
                                    <figure>
                                        <img src="images/app02.png" alt="product01">
                                    </figure>
                                    <h4>All Rounder</h4>
                                </div>
                            </div>
                           
                                    <div class="col-md-3">
                                        <div class="box">
                                            <figure>
                                                <img src="images/app03.png" alt="product01">
                                            </figure>
                                            <h4>Aquabond</h4>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="box">
                                            <figure>
                                                <img src="images/ply02.png" alt="product01">
                                            </figure>
                                            <h4>Watershield</h4>
                                        </div>
                                    </div>
                                --%>
                        </div>

                    </div>
                </div>
				
			
            </div>
        </div>
    </section>

</asp:Content>
