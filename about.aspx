<%@ Page Title="" Language="C#" MasterPageFile="~/layouts/inner.master" AutoEventWireup="true" CodeFile="about.aspx.cs" Inherits="about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      

     <asp:Repeater ID="rptaboutbanner" runat="server">
                        <ItemTemplate>                       
                               <figure>                     
                                   <img src="/uploads/banner/<%#Eval("UploadBanner")%>" class="w-100">
                                                              
                          </figure>
                        </ItemTemplate>
                    </asp:Repeater>

<asp:Literal ID="litpagedes" runat="server"></asp:Literal>


<%--<section class="about">
        <div class="container">          
                    <asp:Repeater ID="rptalbumabout" runat="server">
                        <ItemTemplate>                                                    
                                <div class="img-box">
                               
                                        <figure>
                                            <img src="/uploads/banner/<%#Eval("UploadBanner")%>" class="w-100">
                                        </figure>                                
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>           
    </section>
    <asp:Literal ID="litpagedes" runat="server"></asp:Literal>--%>

</asp:Content>
